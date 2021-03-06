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

public partial class MultiUserAddressBook_Admin_Panel_State_SateAddEdit : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDropDownList();
            
            if (RouteData.Values["StateID"] != null)
            {
                lblMessage.ForeColor = Color.Blue;
                lblMessage.Text = "Edit Mode | StateID " + EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString().Trim());
                FillControls(Convert.ToInt32(EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString().Trim())));
            }
            else
            {
                lblMessage.ForeColor = Color.Blue;
                lblMessage.Text = "Add Mode";
            }




        }

    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        #region local variable
        SqlInt32 strCountryID = new SqlInt32();
        SqlString strStateName = new SqlString();
        SqlString strStateCode = new SqlString();
        #endregion local variable

        string strErrorMessage = "";


        try
        {
            #region Server Side Validation

            if (ddlCountryID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select Country <br/>";

            }
            if (txtStateName.Text.Trim() == "")
            {
                strErrorMessage += "- Enter State Name <br/> ";
            }

            if (txtStateCode.Text.Trim() == "")
            {
                strErrorMessage += "- Enter State Code  <br/> ";
            }

            if (strErrorMessage.Trim() != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation


            #region Gather Enformation
            if (ddlCountryID.SelectedIndex > 0)
            {
                strCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }

            if (txtStateName.Text.Trim() != "")
            {
                strStateName = txtStateName.Text.Trim();
            }
            if (txtStateCode.Text.Trim() != "")
            {
                strStateCode = txtStateCode.Text.Trim();
            }
            #endregion Gather Enformation


            #region Connection Open & Command Object

            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }


            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@CountryID", strCountryID);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateName", strStateName);
            objCmd.Parameters.AddWithValue("@Statecode", strStateCode);

            #endregion Connection Open & Command Object


            if (RouteData.Values["StateID"] != null)
            {

                #region Edit Mode
                //Edit Mode
                objCmd.Parameters.AddWithValue("@StateID", EncryptionDecryption.Decode(RouteData.Values["StateID"].ToString().Trim()));
                objCmd.CommandText = "[PR_State_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/List", true);
                #endregion Edit Mode
            }
            else
            {
                #region Add Mode
                //Add Mode
                objCmd.CommandText = "[dbo].[PR_State_Insert]";
                objCmd.ExecuteNonQuery();
                txtStateName.Text = "";
                txtStateCode.Text = "";
                ddlCountryID.SelectedIndex = 0;
                ddlCountryID.Focus();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
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
    #endregion Button : Save

    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/List", true);
    }
    #endregion Button : Cancel

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropeDownListCountry(ddlCountryID, Session["UserID"]);
        
        //#region Local variable
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        //#endregion Local Variable
        //try
        //{
        //    #region Connection Open & Command Object
        //    if (objConn.State != ConnectionState.Open)
        //    {
        //        objConn.Open();
        //    }

        //    SqlCommand objCmd = objConn.CreateCommand();

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_Country_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //        objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objCmd.ExecuteReader();


        //    if (objSDR.HasRows == true)
        //    {
        //        ddlCountryID.DataSource = objSDR;
        //        ddlCountryID.DataValueField = "CountryID";
        //        ddlCountryID.DataTextField = "CountryName";
        //        ddlCountryID.DataBind();

        //    }
        //    ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();

        //    #endregion Connection Open & Command Object
        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Text = ex.Message;

        //}
        //finally { objConn.Close(); }
   

    }
    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
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
            objCmd.CommandText = "PR_State_SelectBy_PK";
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());

            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["StateName"].Equals(DBNull.Value))
                    {
                        txtStateName.Text = objSDR["StateName"].ToString().Trim();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "No Date Available for the StateID =" + StateID.ToString();
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
    #endregion FillControls
}