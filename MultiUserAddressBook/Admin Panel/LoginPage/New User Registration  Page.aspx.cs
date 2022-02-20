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

public partial class MultiUserAddressBook_Admin_Panel_LoginPage_New_User_Login_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        SqlString strUserName = new SqlString();
        SqlString strPassword = new SqlString();
        SqlString strDisplayName = new SqlString();
        SqlString strMobileNo = new SqlString();
        SqlString strEmail = new SqlString();

        String strErroeMessage = "";
         
        if(txtUserName.Text.Trim() =="")
        {
            strErroeMessage += "- Enter Your UserName";
        }

        if (txtPasswordLogin.Text.Trim() == "")
        {
            strErroeMessage += "- Enter Your Password";
        }

        if (txtDisplayName.Text.Trim() == "")
        {
            strErroeMessage += "- Enter Your DisplayName";
        }

        if (txtMobileNo.Text.Trim() == "")
        {
            strErroeMessage += "- Enter Your mobileNo";
        }

        if (txtEmail.Text.Trim() == "")
        {
            strErroeMessage += "- Enter Your Email";
        }

        if(strErroeMessage.Trim() != "")
        {
            lblMessage.Text = strErroeMessage;
            return;
        }

        SqlConnection objConn  = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            objConn.Open();
            SqlCommand objCmd = new SqlCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_Insert";
            objCmd.Connection = objConn;

            strUserName = txtUserName.Text.Trim();
            objCmd.Parameters.AddWithValue("@UserName", strUserName);

            strPassword = txtPasswordLogin.Text.Trim();
            objCmd.Parameters.AddWithValue("@Password", strPassword);

            strDisplayName = txtDisplayName.Text.Trim();
            objCmd.Parameters.AddWithValue("@DisplayName", strDisplayName);

            strMobileNo = txtMobileNo.Text.Trim();
            objCmd.Parameters.AddWithValue("@MobileNo", strMobileNo);

            strEmail = txtEmail.Text.Trim();
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.ExecuteNonQuery();
            objConn.Close();
            txtUserName.Text.
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