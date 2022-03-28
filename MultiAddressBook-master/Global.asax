<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(System.Web.Routing.RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    public static void RegisterRoutes(System.Web.Routing.RouteCollection routes)
    {
        routes.Ignore("{resource}..axd/{*pathINFO}");

        routes.MapPageRoute("AdminPanelCountryList", "AdminPanel/Country/List", "~/MultiUserAddressBook/Admin Panel/Country/CountryList.aspx");
        routes.MapPageRoute("AdminPanelCountryAdd", "AdminPanel/Country/Add", "~/MultiUserAddressBook/Admin Panel/Country/CountryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCountrEdit", "AdminPanel/Country/Edit/{CountryID}", "~/MultiUserAddressBook/Admin Panel/Country/CountryAddEdit.aspx");

          routes.MapPageRoute("AdminPanelStateList", "AdminPanel/State/List", "~/MultiUserAddressBook/Admin Panel/State/StateList.aspx");
        routes.MapPageRoute("AdminPanelStateAdd", "AdminPanel/State/Add", "~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx");
        routes.MapPageRoute("AdminPanelStateEdit", "AdminPanel/State/Edit/{StateID}", "~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx");

          routes.MapPageRoute("AdminPanelCityList", "AdminPanel/City/List", "~/MultiUserAddressBook/Admin Panel/City/CityList.aspx");
        routes.MapPageRoute("AdminPanelCityAdd", "AdminPanel/City/Add", "~/MultiUserAddressBook/Admin Panel/City/CityAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCityEdit", "AdminPanel/City/Edit/{CityID}", "~/MultiUserAddressBook/Admin Panel/City/CityAddEdit.aspx");

          routes.MapPageRoute("AdminPanelContactCategoryList", "AdminPanel/ContactCategory/List", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryList.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryAdd", "AdminPanel/ContactCategory/Add", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryEdit", "AdminPanel/ContactCategory/Edit/{ContactCategoryID}", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx");

          routes.MapPageRoute("AdminPanelContactList", "AdminPanel/Contact/List", "~/MultiUserAddressBook/Admin Panel/Contact/ContactList.aspx");
        routes.MapPageRoute("AdminPanelContactAdd", "AdminPanel/Contact/Add", "~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactEdit", "AdminPanel/Contact/Edit/{ContactID}", "~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx");
    }

</script>
