using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Admin_Panel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["ContactCategoryID"] != null)
            {
                lblMessege.ForeColor = Color.Blue;
                lblMessege.Text = "Edit Mode | ContactCategoryID = " + EncryptionDecryption.Decode(RouteData.Values["ContactCategoryID"].ToString().Trim());

                FillControls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["ContactCategoryID"].ToString().Trim())));
            }
            else
            {
                lblMessege.ForeColor = Color.Blue;
                lblMessege.Text = "Add Mode";
            }
        }
    }
    #endregion Page Load Event

    #region Button : Save
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        //Declare Local varibles to Insert the date
        SqlString strContactCategoryName = SqlString.Null;
        #endregion Local Variables
        try
        {
            #region Server Side Validation
            //Validate the Data | Server side Validation
            String strErrorMessage = "";
            if (txtContactCategoryName.Text.Trim() == "")
                strErrorMessage += "Enter ContactCategory Name";

            if (strErrorMessage != "")
            {
                lblMessege.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Informaction
            //Gather the Informaction           
            if (txtContactCategoryName.Text.Trim() != "")
                strContactCategoryName = txtContactCategoryName.Text.Trim();
            #endregion Gather Informaction

            #region Set Connection & Command Object
            //Save the Country Data
            //Establish the Connaction
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            //Prepare the Command
            //SqlCommand sqlCmd = new SqlCommand();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactCategoryName", strContactCategoryName);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            if (RouteData.Values["ContactCategoryID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.Parameters.AddWithValue("@ContactCategoryID", (EncryptionDecryption.Decode(RouteData.Values["ContactCategoryID"].ToString().Trim())));
                objCmd.CommandText = "[dbo].[PR_ContactCategory_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
                #endregion Update Record
            }
            else
            {
                #region Insert Record
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_ContactCategory_Insert]";
                objCmd.ExecuteNonQuery();
                lblMessege.ForeColor = Color.Green;
                lblMessege.Text = "Data Inserted Successfully";
                txtContactCategoryName.Text = "";
                txtContactCategoryName.Focus();
                #endregion Insert Record
            }
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessege.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            #region Set Connection & Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_ContactCategory_SelectByPK";
            objCmd.Parameters.AddWithValue("ContactCategoryID", ContactCategoryID.ToString().Trim());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            #endregion Set Connection & Command Object

            #region Read the value and set the controls
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactCategoryName"].Equals(DBNull.Value))
                    {
                        txtContactCategoryName.Text = objSDR["ContactCategoryName"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessege.Text = "No Data Available for the ContactCategoryID = " + ContactCategoryID.ToString();
            }
            #endregion Read the value and set the controls
        }
        catch (Exception ex)
        {
            lblMessege.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion FillControls

    #region Cancel Button
    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
    }
    #endregion Cancel Button
}