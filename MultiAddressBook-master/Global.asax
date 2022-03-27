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

        routes.MapPageRoute("AdminPanelCountryList", "AdminPanel/CountryList", "~/MultiUserAddressBook/Admin Panel/Country/CountryList.aspx");
        routes.MapPageRoute("AdminPanelCountryAdd", "AdminPanel/Country/{operationName}", "~/MultiUserAddressBook/Admin Panel/Country/CountryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCountrEdit", "AdminPanel/CountryEdit", "~/MultiUserAddressBook/Admin Panel/Country/CountryAddEdit.aspx");

          routes.MapPageRoute("AdminPanelStateList", "AdminPanel/StateList", "~/MultiUserAddressBook/Admin Panel/State/StateList.aspx");
        routes.MapPageRoute("AdminPanelStateAdd", "AdminPanel/StateAdd", "~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx");
        routes.MapPageRoute("AdminPanelStateEdit", "AdminPanel/StateEdit", "~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx");

          routes.MapPageRoute("AdminPanelCityList", "AdminPanel/CityList", "~/MultiUserAddressBook/Admin Panel/City/CityList.aspx");
        routes.MapPageRoute("AdminPanelCityAdd", "AdminPanel/CityAdd", "~/MultiUserAddressBook/Admin Panel/City/CityAddEdit.aspx");
        routes.MapPageRoute("AdminPanelCityEdit", "AdminPanel/CityEdit", "~/MultiUserAddressBook/Admin Panel/City/CityAddEdit.aspx");

          routes.MapPageRoute("AdminPanelContactCategoryList", "AdminPanel/ContactCategoryList", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryList.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryAdd", "AdminPanel/ContactCategoryAdd", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactCategoryEdit", "AdminPanel/ContactCategoryEdit", "~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx");

          routes.MapPageRoute("AdminPanelContactList", "AdminPanel/ContactList", "~/MultiUserAddressBook/Admin Panel/Contact/ContactList.aspx");
        routes.MapPageRoute("AdminPanelContactAdd", "AdminPanel/ContactAdd", "~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx");
        routes.MapPageRoute("AdminPanelContactEdit", "AdminPanel/ContactEdit", "~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx");
    }

</script>
