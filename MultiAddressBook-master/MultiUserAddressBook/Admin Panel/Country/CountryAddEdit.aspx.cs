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

public partial class MultiUserAddressBook_Admin_Panel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        if (!IsPostBack)
        {


            if (RouteData.Values ["CountryID"] != null)
            {
                lblMessage.ForeColor = Color.Blue;
                lblMessage.Text = "Edit Mode | CountryID " + EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["CountryID"].ToString().Trim())));
            }
            else
            {
                lblMessage.ForeColor = Color.Blue;
                lblMessage.Text = "Add Mode";
            }




        }
    }
    #region Btn Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;


        String strErrorMessage = "";
        if (txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Country Name <br />";
        }
        if (txtCountryCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Country Code <br />";
        }
        if (txtCountryName.Text.Trim() == "" && txtCountryCode.Text.Trim() == "")
        {
            strErrorMessage += "-Enter Country Name and Country Code";
        }
        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        if(txtCountryName.Text != null)
        {
            strCountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text != null)
        {
            strCountryCode = txtCountryName.Text.Trim();
        }
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        try
        {
            objConn.Open();
            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;


            //Pass the parameter in the SP
            objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);

            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
            if (Request.QueryString["CountryID"] != null)
            {
                #region Edit Mode
                objCmd.Parameters.AddWithValue("@CountryId", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.CommandText = "[PR_Country_UpdateByPK]";
                objCmd.ExecuteNonQuery();


                Response.Redirect("~/AdminPanel/Country/List", true);
                #endregion Edit Mode
            }
            else
            {
                #region Add Mode

                objCmd.CommandText = "[PR_Counrty_Insert]";
                objCmd.ExecuteNonQuery();


                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = txtCountryName.Text.Trim() + " : " + txtCountryCode.Text.Trim() + " - " + "Insert Successfully";
                txtCountryName.Text = txtCountryCode.Text = "";
                txtCountryName.Focus();
                #endregion Add Mode
            }
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

    #endregion Btn Save

    #region Button : cancel

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    
    #endregion Button : cancel

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        #region Local variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local variable
        try
        {
            #region Connection Open And Command Object
            if (objConn.State != ConnectionState.Open)

                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Date Available for the StateID =" + CountryID.ToString();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();


            #endregion Connection Open And Command Object

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

    }
    #endregion Fill Controls

}
