using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MultiUserAddressBook_Admin_Panel_Contact_ContactAddEdit : System.Web.UI.Page
{
    public object ConnectionStrings { get; private set; }
    
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //FillDropDownContactCategoryList(); 
            FillDropDownCountryList();
            FillDropDownContactCategoryList();
            //FillCBLContactCategory ();
            if (Request.QueryString["ContactID"] != null)
            {
                lblMessage.Text = "Edit Mode | ContactID " + Request.QueryString["ContactID"].Trim();
                FillControlls(Convert.ToInt32(Request.QueryString["ContactID"].Trim()));
                FillDropDownStateList(Convert.ToInt32(ddlCountryID.SelectedValue));
                FillDropDownCityList(Convert.ToInt32(ddlStateID.SelectedValue));
            }

        }
    }
    #endregion Page Load


    #region Button : save
    protected void btnSave_Click(object sender, EventArgs e )
    {
        #region Local Variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        
        SqlInt32 strCountryId = SqlInt32.Null;
        SqlInt32 strStateId = SqlInt32.Null;
        SqlInt32 strCityId = SqlInt32.Null;
        SqlInt32 strContactCategoryId = SqlInt32.Null;
        SqlInt32 ContactId = SqlInt32.Null;
        SqlString strContactName = SqlString.Null;
        SqlString strContactNo = SqlString.Null;
        SqlString strWhatsAppNo = SqlString.Null;
        SqlDateTime strBirthDate = SqlDateTime.Null;
        SqlString strEmail = SqlString.Null;
        SqlString strAge = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strBloodGroup = SqlString.Null;
        SqlString strFaceBook = SqlString.Null;
        SqlString strLinkedId = SqlString.Null;
        SqlString strFilePath = SqlString.Null;
        #endregion Local Variable

        try
        {
            #region Server Side Validation

            string strErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select Country <br />";
            }
            if (ddlStateID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select State <br />";
            }
            if (ddlCityID.SelectedIndex == 0)
            {
                strErrorMessage += "- Select City <br />";
            }
            if (cblContactCategory.SelectedValue == "")
            {
              strErrorMessage += "- Select Contact Category <br />";
            }
            if (txtContactName.Text == "")
            {
                strErrorMessage += "- Please Enter Contact Name <br />";
            }

            if (txtAddress.Text == "")
            {
                strErrorMessage += "- Please Enter Address  <br />";
            }
            if (txtEmail.Text == "")
            {
                strErrorMessage += "- Please Enter Email  <br />";
            }


            if (strErrorMessage != "")
            {
                lblMessage.Text = strErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Gather Information

            if (ddlCountryID.SelectedIndex > 0)
                strCountryId = Convert.ToInt32(ddlCountryID.SelectedValue);

            if (ddlStateID.SelectedIndex > 0)
                strStateId = Convert.ToInt32(ddlStateID.SelectedValue);

            if (ddlCityID.SelectedIndex > 0)
                strCityId = Convert.ToInt32(ddlCityID.SelectedValue);

            //if (cblContactCategory.SelectedIndex > 0)
            strContactCategoryId = Convert.ToInt32(cblContactCategory.SelectedValue);

            if (txtContactName.Text.Trim() != "")
                strContactName = txtContactName.Text.Trim();

            if (txtContactName.Text.Trim() != "")
                strContactNo = txtContactName.Text.Trim();

            if (txtWhatsappNo.Text.Trim() != "")
                strWhatsAppNo = txtWhatsappNo.Text.Trim();

            if (txtBirthdate.Text.Trim() != "")
                strBirthDate = Convert.ToDateTime(txtBirthdate.Text.Trim());

            if (txtEmail.Text.Trim() != "")
                strEmail = txtEmail.Text.Trim();

            if (txtAge.Text.Trim() != "")
                strAge = txtAge.Text.Trim();

            if (txtAddress.Text.Trim() != "")
                strAddress = txtAddress.Text.Trim();

            if (txtBloodGroup.Text.Trim() != "")
                strBloodGroup = txtBloodGroup.Text.Trim();

            if (txtFacebookID.Text.Trim() != "")
                strFaceBook = txtFacebookID.Text.Trim();

            if (txtLinkdINID.Text.Trim() != "")
                strLinkedId = txtLinkdINID.Text.Trim();
            #endregion Gather Information

            #region Set Connection & Command Object

            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;


            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            objCmd.Parameters.AddWithValue("@CountryID", strCountryId);
            objCmd.Parameters.AddWithValue("@StateID", strStateId);
            objCmd.Parameters.AddWithValue("@CityID", strCityId);
            //objCmd.Parameters.AddWithValue("@ContactCategoryID", strContactCategoryId);
            objCmd.Parameters.AddWithValue("@ContactName", strContactName);
            objCmd.Parameters.AddWithValue("@WhatsappNo", strWhatsAppNo);
            objCmd.Parameters.AddWithValue("@BirthDate", strBirthDate);
            objCmd.Parameters.AddWithValue("@Email", strEmail);
            objCmd.Parameters.AddWithValue("@Age", strAge);
            objCmd.Parameters.AddWithValue("@Address", strAddress);
            objCmd.Parameters.AddWithValue("@BloodGroup", strBloodGroup);
            objCmd.Parameters.AddWithValue("@FacebookID", strFaceBook);
            objCmd.Parameters.AddWithValue("@LinkedINID", strLinkedId);

            #endregion Set Connection & Command Object

            if (Request.QueryString["ContactID"] != null)
            {
                #region Update Record
                //Edit Mode
                objCmd.CommandText = "PR_Contact_UpdateByPK";
                objCmd.Parameters.AddWithValue("@ContactID", Request.QueryString["ContactID"].ToString().Trim());
               
                
                
                objCmd.ExecuteNonQuery();
                string FileExtention = Path.GetExtension(fuFile.FileName).ToLower();
                if (fuFile.HasFile)
                {
                    if (FileExtention == ".jpge" || FileExtention == ".jpg" || FileExtention == ".png" || FileExtention == ".gif")
                    {
                        UploadImage(Convert.ToInt32(Request.QueryString["ContactID"]), FileExtention);
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }

                Response.Redirect("~/MultiUserAddressBook/Admin Panel/Contact/ContactList.aspx", true);
                ddlCountryID.Focus();
                #endregion Update Record
            }
            else
            {
                #region Add record
                objCmd.CommandText = "PR_Contact_Insert";


                objCmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                objCmd.ExecuteNonQuery();

                SqlInt32 ContactID = 0;
                ContactId = Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                foreach (ListItem liContactCategoryID in cblContactCategory.Items)
                {
                    if (liContactCategoryID.Selected)
                    {
                        SqlCommand objCmdContactCategory = objConn.CreateCommand();
                        objCmdContactCategory.CommandType = CommandType.StoredProcedure;
                        objCmdContactCategory.CommandText = "PR_ContactWiseContactCategory_InsertUserID";
                        if (Session["UserID"] != null)
                            objCmdContactCategory.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                        objCmdContactCategory.Parameters.AddWithValue("@ContactID", ContactId);
                        objCmdContactCategory.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(liContactCategoryID.Value.ToString()));
                        objCmdContactCategory.ExecuteNonQuery();
                    }
                }
                //AddContactCategory(ContactId);
                string FileType = Path.GetExtension(fuFile.FileName).ToLower();

                if (fuFile.HasFile)
                {
                    if (FileType == ".jpge" || FileType == ".jpg" || FileType == ".png" || FileType == ".gif")
                    {
                        UploadImage(ContactId, "Image");
                    }
                    else
                    {
                        lblMessage.Text = "Please Upload Valid File(File must have .jpg or .jpge or .png or .gif extention).";
                        return;
                    }
                }
                #endregion Add record
                #region Insert Record
                //Add Mode
                //objCmd.CommandText = "PR_Contact_Insert";
                lblMessage.Text = "Data Inserted Successfully";
                ddlCountryID.SelectedIndex = 0;
                ddlStateID.SelectedIndex = 0;
                ddlCityID.SelectedIndex = 0;
                cblContactCategory.SelectedIndex = 0;
                txtEmail.Text = "";
                txtAddress.Text = "";
                txtContactName.Text = "";
                txtBirthdate.Text = "";
                txtWhatsappNo.Text = "";
                txtBloodGroup.Text = "";
                txtFacebookID.Text = "";
                txtLinkdINID.Text = "";
                txtAge.Text = "";
                ddlCountryID.Focus();
                #endregion Insert Record
            }

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


    #endregion Button : save


    #region Fill Drop Down State
    protected void FillDropDownStateList(SqlInt32 Id)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_State_SelectByCountry]";
        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        if (ddlCountryID.SelectedValue != "-1")
            objCmd.Parameters.AddWithValue("@CounrtyID", Id);

        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlStateID.DataSource = objSDR;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
        }

        ddlStateID.Items.Insert(0, new ListItem("- Select State -", "-1"));
        if (objConn.State == ConnectionState.Open)
            objConn.Close();


    }
    #endregion Fill Drop Down State


    #region Fill Drop Down Country
    protected void FillDropDownCountryList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_Country_SelectForDropDownList";
        if (Session["UserID"] != null)
        objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlCountryID.DataSource = objSDR;
            ddlCountryID.DataValueField = "CountryID";
            ddlCountryID.DataTextField = "CountryName";
            ddlCountryID.DataBind();
        }

        ddlCountryID.Items.Insert(0, new ListItem("- Select Country -", "-1"));

        if (objConn.State == ConnectionState.Open)
            objConn.Close();
    }
    #endregion Fill Drop Down Country


    #region Fill Drop Down City
    protected void FillDropDownCityList(SqlInt32 Id)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_City_SelectByState";
        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);

        if (ddlStateID.SelectedValue != "-1")
            objCmd.Parameters.AddWithValue("@StateID", Id);
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            ddlCityID.DataSource = objSDR;
            ddlCityID.DataValueField = "CityID";
            ddlCityID.DataTextField = "CityName";
            ddlCityID.DataBind();
        }

        ddlCityID.Items.Insert(0, new ListItem("- Select City -", "-1"));

        if (objConn.State == ConnectionState.Open)
            objConn.Close();
    }
    #endregion Fill Drop Down City


    #region Fill Drop Down Contact Category
    protected void FillDropDownContactCategoryList()
    {

        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
        if (Session["UserID"] != null)
            objCmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
        SqlDataReader objSDR = objCmd.ExecuteReader();

        if (objSDR.HasRows == true)
        {
            cblContactCategory.DataSource = objSDR;
            cblContactCategory.DataValueField = "ContactCategoryID";
            cblContactCategory.DataTextField = "ContactCategoryName";
            cblContactCategory.DataBind();
        }


        //cblContactCategory.Items.Insert(0, new ListItem("- Select Contact Category -", "-1"));

        if (objConn.State == ConnectionState.Open)
            objConn.Close();
    }
    #endregion Fill Drop Down Contact Category


    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MultiUserAddressBook/Admin Panel/Contact/ContactList.aspx", true);
    }
    #endregion Button : Cancel


    #region FillControl
    private void FillControlls(SqlInt32 Id)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("PR_Contact_SelectByPK", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactID", Id);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("UserID", Session["UserID"]);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (!objSDR["ContactName"].Equals(DBNull.Value))
                    {
                        txtContactName.Text = objSDR["ContactName"].ToString();
                    }
                    //if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                    //{
                    //   cblContactCategory.SelectedValue = objSDR["ContactCategoryID"].ToString();
                    //}
                    if (!objSDR["CityID"].Equals(DBNull.Value))
                    {
                        ddlCityID.SelectedValue = objSDR["CityID"].ToString();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString();
                    }
                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                    {
                        ddlCountryID.SelectedValue = objSDR["CountryID"].ToString();
                    }

                    if (!objSDR["WhatsappNo"].Equals(DBNull.Value))
                    {
                        txtWhatsappNo.Text = objSDR["WhatsappNo"].ToString();
                    }
                    if (!objSDR["BirthDate"].Equals(DBNull.Value))
                    {

                        txtBirthdate.Text = Convert.ToDateTime(objSDR["BirthDate"].ToString().Trim()).ToString("yyyy-MM-dd");
                    }
                    if (!objSDR["Email"].Equals(DBNull.Value))
                    {
                        txtEmail.Text = objSDR["Email"].ToString();
                    }
                    if (!objSDR["Age"].Equals(DBNull.Value))
                    {
                        txtAge.Text = objSDR["Age"].ToString();
                    }
                    if (!objSDR["BloodGroup"].Equals(DBNull.Value))
                    {
                        txtBloodGroup.Text = objSDR["BloodGroup"].ToString();
                    }
                    if (!objSDR["FacebookID"].Equals(DBNull.Value))
                    {
                        txtFacebookID.Text = objSDR["FacebookID"].ToString();
                    }
                    if (!objSDR["LinkedINID"].Equals(DBNull.Value))
                    {
                        txtLinkdINID.Text = objSDR["LinkedINID"].ToString();
                    }
                    if (!objSDR["Address"].Equals(DBNull.Value))
                    {
                        txtAddress.Text = objSDR["Address"].ToString();
                    }
                    if (!objSDR["FilePath"].Equals(DBNull.Value))
                    {
                        imgImage.ImageUrl = objSDR["FilePath"].ToString();
                    }
                    break;
                }
            }
            else
            {
                lblMessage.Text = "Contact Not Found!";
            }
            FillContactCategoryCheckBoxs(Id);
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
    #endregion FillControl


    #region Upload Image
    private void UploadImage(SqlInt32 Id, string FileExtention)
    {
        SqlString strFilePath = SqlString.Null;
        #region Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Connection

        try
        {
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            strFilePath = "~/MultiUserAddressBook/Admin Panel/SaveUploadedFile/" + Id + ".jpg";

            if (!Directory.Exists(Server.MapPath("~/MultiUserAddressBook/Admin Panel/SaveUploadedFile/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/MultiUserAddressBook/Admin Panel/SaveUploadedFile/"));
            }

            fuFile.SaveAs(Server.MapPath("~/MultiUserAddressBook/Admin Panel/SaveUploadedFile/" + Id + ".jpg"));
            long length = new FileInfo(Server.MapPath(strFilePath.ToString())).Length;


            SqlCommand objCmd = new SqlCommand("PR_Contact_UpdateImagePathByPKUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;



            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));

            objCmd.Parameters.AddWithValue("@ContactID", Id);
            objCmd.Parameters.AddWithValue("@FilePath", strFilePath);
            objCmd.Parameters.AddWithValue("@FileSize", Convert.ToString(FileExtention));
            objCmd.Parameters.AddWithValue("@FileExtention", Convert.ToString(length));
            objCmd.ExecuteNonQuery();


            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message + ex;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Upload Image

    #region Add Contact Category
    //private void AddContactCategory(SqlInt32 ID)
    //{
    //    #region Set Connection
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
    //    #endregion Set Connection
    //    try
    //    {


    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        foreach (ListItem item in cblContactCategory.Items)
    //        {
    //            if (item.Selected)
    //            {
    //                #region Create Command and Set Parameter
    //                SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_InsertUserID", objConn);
    //                objCmd.CommandType = CommandType.StoredProcedure;
    //                objCmd.Parameters.AddWithValue("@ContactCategoryID", Convert.ToInt32(item.Value));
    //                if (Session["UserID"] != null)
    //                    objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
    //                objCmd.Parameters.AddWithValue("@ContactID", ID);
    //                objCmd.ExecuteNonQuery();
    //                #endregion Create Command and Set Parameter
    //            }
    //        }

    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message + ex;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
    #endregion Add Contact Category

    #region CBL ContactCategory
    //private void FillCBLContactCategory ()
    //{
    //    SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
    //    try
    //    {
    //        if (objConn.State != ConnectionState.Open)
    //            objConn.Open();

    //        SqlCommand objCmd = new SqlCommand();
    //        objCmd.CommandType = CommandType.StoredProcedure;
    //        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";

    //        SqlDataReader objSDR = objCmd.ExecuteReader();
    //        if (objSDR.HasRows)
    //        {
    //            cblContactCategory.DataSource = objSDR;
    //            cblContactCategory.DataBind();
    //            cblContactCategory.DataTextField = "ContactCategoryName";
    //            cblContactCategory.DataValueField = "ContactCategoryID";
    //        }

    //       if (objConn.State == ConnectionState.Open)
    //            objConn.Close ();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message + ex;
    //    }
    //    finally
    //    {
    //        if (objConn.State == ConnectionState.Open)
    //            objConn.Close();
    //    }
    //}
    #endregion CBL ContactCategory

    #region Delete ContactCategory
    private void DeleteContactCategory(SqlInt32 ID)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultipalUserAddressBookconnectionSring"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            #region Create Command and Set Parameter
            SqlCommand objCmd = new SqlCommand("PR_ContactWiseContactCategory_DeleteByContactIDUserID", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@ContactId", ID);
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.ExecuteNonQuery();
            #endregion Create Command and Set Parameter

            lblMessage.Text = "Contact Deleted Successfully!";

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message + ex;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }
    #endregion Delete ContactCategory

     #region Fill Contact Category ChechBox
    private void FillContactCategoryCheckBoxs(SqlInt32 ID)
    {
        #region Set Connection
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString);
        #endregion Set Connection
        try
        {


            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = new SqlCommand("PR_ContactCategory_SelectOrNot", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            if (Session["UserID"] != null)
                objCmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
            objCmd.Parameters.AddWithValue("@ContactID", ID);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                    if (objSDR["SelectOrNot"].ToString() == "Selected")
                    {
                        cblContactCategory.Items.FindByValue(objSDR["ContactCategoryID"].ToString()).Selected = true;
                    }

                }
            }


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


    #endregion Fill Contact Category ChechBox
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlStateID.Items.Clear();
        FillDropDownStateList(Convert.ToInt32(ddlCountryID.SelectedValue));
    }

    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCityID.Items.Clear();
        FillDropDownCityList(Convert.ToInt32(ddlStateID.SelectedValue));
    }

}