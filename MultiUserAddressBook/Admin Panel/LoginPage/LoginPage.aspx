<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_LoginPage_LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <link href="../../Contect/css/Login.css" rel="stylesheet" />
    <link href="../../Contect/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Contect/js/bootstrap.bundle.min.js"></script>
    <style type="text/css">
        .row {
            width: 293px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login Page</h2>
            <br />
            <div class="login">
                <label>
                    <b>User Name     
                    </b>
                </label>
                <asp:TextBox runat="server" ID="txtUserName" type="text" name="Uname" placeholder="Username" />
                <br />
                <br />
                <label>
                    <b>Password     
                    </b>
                </label>
                <asp:TextBox runat="server" ID="txtPasswordLogin" type="password" name="Pass" placeholder="Password" />
                <br />
                <br />
                <asp:Button runat="server" ID="btnLogin" Text="Log In Here" CssClass="btn btn-dark btn-sm text-danger" BackColor="#08ffd1" textlight="" OnClick="btnLogin_Click" />
                <br />
                <br />
                <div class="row">
                    <div class="col-md-col-12">
                        <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
