<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUserLoginPage.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_LoginPage_NewUserLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="../../Contect/css/Login.css" rel="stylesheet" />
    <link href="../../Contect/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Contect/js/bootstrap.bundle.min.js"></script>
    <style type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <h2>New User Login Page</h2><br>    
    <div class="login">    
    <form id="login" method="get" action="login.php">    
        <label><b>User Name     
        </b>    
        </label>    
        <input type="text" name="Uname" id="Uname" placeholder="Username">    
        <br><br>    
        <label><b>Password     
        </b>    
        </label>    
        <input type="Password" name="Pass" id="Pass" placeholder="Password">    
        <br><br>    
        <input type="button" name="log" id="log" value="Log In Here">       
        <br><br>    
        <input type="checkbox" id="check">    
        <span>Remember me</span>    
        <br><br>    
        Forgot <a href="#">Password</a>    
    </form>     
</div>    
        </div>
    </form>
</body>
</html>
