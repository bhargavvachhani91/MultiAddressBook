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

public partial class MultiUserAddressBook_Admin_Panel_ContactCategory_ContactCategoryList : System.Web.UI.Page
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

    #region FillGrid View
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
            objcmd.CommandText = "PR_ContactCategory_SelectAll";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objcmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                gvContactCategory.DataSource = objSDR;
                gvContactCategory.DataBind();
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
    #endregion FillGrid View

    #region Row Command
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {


            if (e.CommandArgument.ToString() != "")
            {
                DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

            }
        }
    }
    #endregion Row Command

    #region Delete Record
    private void DeleteRecord(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();

            SqlCommand objcmd = objConn.CreateCommand();
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandText = "[dbo].[PR_ContactCategory_DeleteByPK]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objcmd.Parameters.AddWithValue("@ContactCategoryID", ContactCategoryID.ToString().Trim());

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