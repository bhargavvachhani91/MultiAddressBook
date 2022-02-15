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

public partial class MultiUserAddressBook_Admin_Panel_Contact_ContactList : System.Web.UI.Page
{
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Page Load

    #region Fill Grid view
    private void FillGridView()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            //Establish the Connection
            //Create Blank Object connetion



            objConn.Open();
            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "PR_Contact_SelectAll";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContact.DataSource = objSDR;
                gvContact.DataBind();
            }

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
    #endregion Fill Grid view

    #region Row Commad
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {


            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }
        }
    }
    #endregion Row Commad

    #region Delete Record
    private void DeleteRecord(SqlInt32 ContactID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[dbo].[PR_Contact_DeleteByPK]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objcmd.Parameters.AddWithValue("@ContactID", ContactID.ToString().Trim());

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
    #endregion Delete Record

}
