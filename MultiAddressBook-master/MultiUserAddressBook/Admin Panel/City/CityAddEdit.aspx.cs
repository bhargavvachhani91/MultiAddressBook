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

public partial class MultiUserAddressBook_Admin_Panel_City_CityAddEdit : System.Web.UI.Page
{
    #region page load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMessege.ForeColor = Color.Green;
                lblMessege.Text = "Edit Mode | CityID " + Request.QueryString["CityID"].Trim();
                FillControls(Convert.ToInt32(Request.QueryString["CityID"].Trim()));
            }
            else
            {
                lblMessege.ForeColor = Color.AliceBlue;
                lblMessege.Text = "Add Mode";
            }

        }
    }
    #endregion page load


    #region Button : save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlInt32 strStateID = new SqlInt32();
        SqlString strCityName = new SqlString();
        SqlString strPinCode = new SqlString();
        SqlString strSTDCode = new SqlString();


        string strErrorMessage = "";

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";

        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter State Name <br/> ";
        }


        if (strErrorMessage.Trim() != "")
        {
            lblMessege.Text = strErrorMessage;
            return;
        }

        if (ddlStateID.SelectedIndex > 0)
        {
            strStateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }

        if (txtCityName.Text.Trim() != "")
        {
            strCityName = txtCityName.Text.Trim();
        }

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[dbo].[PR_City_Insert]";
        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        objCmd.Parameters.AddWithValue("@StateID", strStateID);


        strCityName = txtCityName.Text.Trim();
        objCmd.Parameters.AddWithValue("@CityName", strCityName);

        strPinCode = txtPinCode.Text.Trim();
        objCmd.Parameters.AddWithValue("@PinCode", strPinCode);

        strSTDCode = txtSTDCode.Text.Trim();
        objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);



        if (Request.QueryString["CityID"] != null)
        {

            #region Edit Mode
            //Edit Mode
            objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
            objCmd.CommandText = "[PR_City_UpdateByPK]";
            objCmd.ExecuteNonQuery();
            Response.Redirect("~/MultiUserAddressBook/Admin Panel/City/CityList.aspx", true);
            #endregion Edit Mode
        }
        else
        {
            #region Add Mode
            //Add Mode
            objCmd.CommandText = "[dbo].[PR_City_Insert]";
            objCmd.ExecuteNonQuery();
            txtCityName.Text = "";
            txtPinCode.Text = "";
            txtSTDCode.Text = "";
            ddlStateID.SelectedIndex = 0;
            ddlStateID.Focus();
            lblMessege.ForeColor = Color.Green;
            lblMessege.Text = "Data Inserted Successfully";
            #endregion Add Mode
        }
    }
    #endregion Button : save


    #region FillDropDown
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropeDownListState(ddlStateID,Session["UserID"]);
        //SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        //try
        //{
        //    if (objConn.State != ConnectionState.Open)
        //    {
        //        objConn.Open();
        //    }

        //    SqlCommand objCmd = objConn.CreateCommand();

        //    objCmd.CommandType = CommandType.StoredProcedure;
        //    objCmd.CommandText = "PR_State_SelectForDropDownList";
        //    if (Session["UserID"] != null)
        //        objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        //    SqlDataReader objSDR = objCmd.ExecuteReader();

        //    if (objSDR.HasRows == true)
        //    {
        //        ddlStateID.DataSource = objSDR;
        //        ddlStateID.DataValueField = "StateID";
        //        ddlStateID.DataTextField = "StateName";
        //        ddlStateID.DataBind();

        //    }
        //    ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

        //    if (objConn.State == ConnectionState.Open)
        //        objConn.Close();
        //}
        //catch (Exception ex)
        //{
        //    lblMessege.Text = ex.Message;

        //}
        //finally
        //{
        //    if (objConn.State == ConnectionState.Open)
        //    {
        //        objConn.Close();
        //    }
        //}

    }
    #endregion FillDropDown


    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Admin Panel/City/CityList.aspx", true);
    }
    #endregion Button : Cancel


    #region FillControl
    private void FillControls(SqlInt32 CityID)
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
            objCmd.CommandText = "PR_City_SelectByPK";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }

                    break;
                }
            }
            else
            {
                lblMessege.Text = "No Date Available for the CityID =" + CityID.ToString();
            }

            if (objConn.State == ConnectionState.Open)
                objConn.Close();


            #endregion Connection Open And Command Object

        }
        catch (Exception ex)
        {
            lblMessege.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

    }
    #endregion FillControl
}