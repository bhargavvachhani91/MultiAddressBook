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

public partial class MultiUserAddressBook_Admin_Panel_Country_CountryList : System.Web.UI.Page
{
    #region Page Lode
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Page Lode

    #region Fill Grid View
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
                objcmd.CommandText = "PR_Country_SelectAll";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);

                SqlDataReader objSDR = objcmd.ExecuteReader();
                if (objSDR.HasRows)
                {
                    gvCountry.DataSource = objSDR;
                    gvCountry.DataBind();
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
    #endregion Fill Grid View

    #region Delete Record
    private void DeleteRecord(SqlInt32 CountryID)
        {
            SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

            try
            {
                objConn.Open();

                SqlCommand objcmd = objConn.CreateCommand();
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "[dbo].[PR_Country_DeleteByPK]";
            if (Session["UserID"] != null)
                objcmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objcmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());

                objcmd.ExecuteNonQuery();
            lblMessage.Text = "deleted!";
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

    #region Row Command
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() != "")
        {
            DeleteRecord(Convert.ToInt32(e.CommandArgument.ToString().Trim()));

        }
    }
    #endregion Row Command
    protected void gvCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


