<%@ Page Language="C#" AutoEventWireup="true" CodeFile="New User Registration  Page.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_LoginPage_New_User_Login_Page" %>

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
        <div class="container" style="background-color: #23463f; max-width: 540px">
            <div>
                <h2>New User Registration Page</h2>
                <br />
                <div class="Registration">
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                <b>User Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;     
                                </b>
                            </label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="txtUserName" type="text" name="Uname" placeholder="Username" Width="216px" />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <label>
                        <b>Password&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                    </label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPasswordLogin" type="password" name="Pass" placeholder="Password" Width="216px" />
                    <br />
                    <br />
                </div>
                <div class="row">
                    <div class="col-md-4">
                        <label>
                            <b>Display Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        </label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtDisplayName" type="text" name="DName" placeholder="DisplayName" Width="214px" />
                        <br />
                        <br />
                    </div>

                    <div class="col-md-4">
                        <label>
                            <b>Mobile Number&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        </label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtMobileNo" type="Number" name="MobileNo" placeholder="MobileNo" Width="216px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter Your Mobile Number" ControlToValidate="txtMobileNo" ForeColor="Red" ValidationExpression="^([1-9]{1})([234789]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                    </div>
                    <div class="col-md-4">
                        <label>
                            <b>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>
                        </label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox runat="server" ID="txtEmail" type="txt" name="Email" placeholder="Email" Width="214px" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter your Email" ControlToValidate="txtEmail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:Button runat="server" ID="btnLogin" Text="Save" CssClass="btn btn-dark btn-sm text-danger" BackColor="#08ffd1" textlight="" OnClick="btnLogin_Click" />

                       </div><br/><br/> 
                        <div style="padding-left: 120px; background-color: #fff!;">

                            <asp:HyperLink runat="server" ID="hlGoTOLoginPage" Text="Go To LoginPage" CssClass="btn  btn-sm text-center text-dark text-text-decoration-underline bg-white" Style="color: white; background-color: #fff!" NavigateUrl="~/MultiUserAddressBook/Admin Panel/LoginPage/LoginPage.aspx" />
                        </div>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col-md-col-12">
                                <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
