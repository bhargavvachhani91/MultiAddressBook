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

public partial class MultiUserAddressBook_Admin_Panel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlString strCountryName = SqlString.Null;
        SqlString strCountryCode = SqlString.Null;

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        objConn.Open();
        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_Counrty_Insert";

        if (txtCountryName.Text.Trim() != "")
        {
            strCountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            strCountryCode = txtCountryCode.Text.Trim();
        }
        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        objCmd.Parameters.AddWithValue("@CountryName", strCountryName);
        objCmd.Parameters.AddWithValue("@CountryCode", strCountryCode);
        
        objCmd.ExecuteNonQuery();
        objConn.Close();
        lblMessage.Text = "Data Inserted Succesfully";
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Admin Panel/Country/CountryList.aspx",true);
    }
}