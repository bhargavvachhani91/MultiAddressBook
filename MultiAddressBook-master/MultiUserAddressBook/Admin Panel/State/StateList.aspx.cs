using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Admin_Panel_State_StateList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            //Establish the Connection
            //Create Blank Object connetion

            #region Command Open & CreateCommand


            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_State_SelectAll";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvState.DataSource = objSDR;
                gvState.DataBind();
            }


            if (objConn.State == ConnectionState.Open)
                objConn.Close();
            #endregion Command Open & CreateCommand
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;

        }
        finally
        {
            objConn.Close();
        }
    }
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {


            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }
        }

    }
    private void DeleteRecord(SqlInt32 StateID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[dbo].[PR_State_DeleteByPK]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objcmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            objcmd.ExecuteNonQuery();

            objConn.Close();

            FillGridView();
        }
        catch (Exception ex)
        {

            lblMessage.Text = ex.Message;
        }
        finally
        {
            objConn.Close();
        }

    }

}