using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    #region Country DropeDown List
    public static void FillDropeDownListCountry(DropDownList ddl, object User)
    {
        #region Local variable
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());
        #endregion Local Variable
        //SqlInt32 StrUserID = SqlInt32.Null;
        try
        {
            #region Connection Open & Command Object
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            if (User != null)
                objCmd.Parameters.AddWithValue("UserID", User);
            SqlDataReader objSDR = objCmd.ExecuteReader();


            if (objSDR.HasRows == true)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "CountryID";
                ddl.DataTextField = "CountryName";
                ddl.DataBind();

            }
            ddl.Items.Insert(0, new ListItem("Select Country", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();

            #endregion Connection Open & Command Object
        }
        catch (Exception ex)
        {


        }
        finally { objConn.Close(); }

    }
    #endregion Country DropeDown List

    #region State DropeDown List
    public static void FillDropeDownListState(DropDownList ddl, object User)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }

            SqlCommand objCmd = objConn.CreateCommand();

            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            if (User != null)
                objCmd.Parameters.AddWithValue("UserID", User);
            SqlDataReader objSDR = objCmd.ExecuteReader();

            if (objSDR.HasRows == true)
            {
                ddl.DataSource = objSDR;
                ddl.DataValueField = "StateID";
                ddl.DataTextField = "StateName";
                ddl.DataBind();

            }
            ddl.Items.Insert(0, new ListItem("Select State", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {


        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
            {
                objConn.Close();
            }
        }

    }
    #endregion State DropeDown List

    #region  Fill DropeDown List State By CountryID
    public static void FillDropeDownListStateByCountryID(DropDownList ddlStateID, DropDownList ddlCountryID, object User, object Id)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "[PR_State_SelectByCountry]";
        if (User != null)
            objCmd.Parameters.AddWithValue("UserID", User);
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
    #endregion Fill  DropeDown List State By CountryID

    #region Fill DropeDown List City By StateID
    public static void FillDropeDownListCityByStateID(DropDownList ddlStateID, DropDownList ddlCityID, object User, object Id)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_City_SelectByState";
        if (User != null)
            objCmd.Parameters.AddWithValue("UserID", User);

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
    #endregion Fill DropeDown List City By StateID

    #region Fill CBL ContactCategoryList
    public static void FillCBLContactCategory(CheckBoxList cblContactCategory, object User)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MultiUserAddressBookConnectionString"].ConnectionString.Trim());

        if (objConn.State != ConnectionState.Open)

            objConn.Open();

        SqlCommand objCmd = objConn.CreateCommand();
        objCmd.CommandType = CommandType.StoredProcedure;
        objCmd.CommandText = "PR_ContactCategory_SelectForDropDownList";
        if (User != null)
            objCmd.Parameters.AddWithValue("@UserID", User);
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
    #endregion Fill CBL ContactCategoryList
}