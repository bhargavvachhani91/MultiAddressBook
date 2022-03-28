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

public partial class MultiUserAddressBook_Admin_Panel_City_CityList : System.Web.UI.Page
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
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
            SqlCommand objcmd = new SqlCommand();
            objcmd.Connection = objConn;
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_City_SelectAll";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvCity.DataSource = objSDR;
                gvCity.DataBind();
            }


            if (objConn.State == ConnectionState.Open)
                objConn.Close();


            objConn.Close();
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
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "DeleteRecord")
        {


            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }
        }
    }
    private void DeleteRecord(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[dbo].[PR_City_DeleteByPK]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objcmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());

            objcmd.ExecuteNonQuery();
            lblMessage.Text = "Deleted!";
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