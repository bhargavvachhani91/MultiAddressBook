using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
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


            if (objConn.State != ConnectionState.Open)
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
            if (objConn.State == ConnectionState.Open)
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
        else if (e.CommandName == "DeleteImage")
        {
            if(e.CommandArgument != null)
            {
                DeleteContactImage(Convert.ToInt32(e.CommandArgument.ToString()));
            }
        }
    }
    #endregion Row Commad

    #region Delete Record
    private void DeleteRecord(SqlInt32 ContactID )
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            FileInfo file = new FileInfo(Server.MapPath("~/MultiUserAddressBook/Admin Panel/SaveUploadedFie/" + ContactID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
            }

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
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }

    }
    #endregion Delete Record
    #region Delete Image
    private void DeleteContactImage(SqlInt32 Id)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameters
            SqlCommand objCmd = new SqlCommand("PR_Contact_DeleteImageByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();

            FileInfo file = new FileInfo(Server.MapPath("~/MultiUserAddressBook/Admin Panel/SaveUploadedFile/" + Id.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
                lblMessage.Text = "Image Deleted Successfully!";
                FillGridView();
            }
            else
            {
                lblMessage.Text = "Image dosen't upload!";
            }


            #endregion Create Command and Set Parameters

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Delete Image


}
