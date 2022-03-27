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

public partial class MultiUserAddressBook_Admin_Panel_LoginPage_LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        #region Local Variable
        SqlString strUserName = SqlString.Null;
        SqlString strPassword = SqlString.Null;
        #endregion Local Variable

        #region Server Side Validation
        String strErrorMessage = "";
        if (txtUserName.Text.Trim() =="")
        {
            strErrorMessage += "- Enter UserName  <br />";
        }
        if (txtPasswordLogin.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Password  <br />";
        }
        if (strErrorMessage !="")
        {
            lblMessage.Text = "Kindly Solve Following Error <br />"+ strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Assign the Value
        if(txtUserName.Text.Trim()!="")
        {
            strUserName = txtUserName.Text.Trim();
        }
        if (txtPasswordLogin.Text.Trim() != "")
        {
            strPassword = txtPasswordLogin.Text.Trim();
        }

        #endregion Assign the Value

        #region ConnectionString
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion ConnectionString

        #region User Validation
        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();
            SqlCommand objCmd  = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_User_SelectByUsaerNamePassword";

            objCmd.Parameters.AddWithValue("@UserName",strUserName);
            objCmd.Parameters.AddWithValue("@Password", strPassword);

            SqlDataReader objSDR = objCmd.ExecuteReader();
            if (objSDR.HasRows)
            {
                lblMessage.Text = "valid User";
                while(objSDR.Read())
                {
                    if(!objSDR["UserID"].Equals(DBNull.Value))
                    { 
                        Session["UserID"] = objSDR["UserID"].ToString().Trim();
                    }
                    if (!objSDR["DisplayName"].Equals(DBNull.Value))
                    {
                        Session["DisplayName"] = objSDR["DisplayName"].ToString().Trim();
                    }
                    break;
                }
                Response.Redirect("~/MultiUserAddressBook/Admin Panel/Default.aspx",true);
            }

            else
            {
                lblMessage.Text = "Either username or password is not valid,Please try Again";
            }
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message; 
        }
        finally
        {
            if (objConn.State != ConnectionState.Closed)
                objConn.Close();
        }
        #endregion User Validation

    }
}