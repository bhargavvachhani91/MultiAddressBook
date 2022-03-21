<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Contact Add/Edit Page</h2>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12  d-flex justify-content-center">
                <asp:Label runat="server" ID="lblMessage" EnableViewContact="False" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="row">
                <div class="col-md-4">
                    Country:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCountryID" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Country" ControlToValidate="ddlCountryID" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="col-md-4">
                    State:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select State" ControlToValidate="ddlStateID" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-4">
                    City:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCityID" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select City" ControlToValidate="ddlCityID" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-4">
                    Contact category:
                </div>
                <div class="col-md-8">
                    <asp:CheckBoxList runat="server" ID="cblContactCategory" />
                    <%--<asp:DropDownList ID="ddlContactCategoryID" CssClass="form-control" runat="server"></asp:DropDownList>--%>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select ContactCategory" ControlToValidate="cblContactCategory" Display="Dynamic" ValidationGroup="Cform" InitialValue="0"></asp:RequiredFieldValidator>----%>
                </div>
                <div class="col-md-4">
                    Contact Name:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Contact Name" ControlToValidate="txtContactName" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>
                <br />


                <div class="col-md-4">
                    Birthdate:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBirthdate" runat="server" CssClass="form-control" TextMode="Date" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Your BirthDate" ControlToValidate="txtBirthdate" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>
                <br />

                <div class="col-md-4">
                    Age:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Your Age" ControlToValidate="txtAge" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-4">
                    Whatsapp Number
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtWhatsappNo" runat="server" CssClass="form-control" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Check Your Mobile Number" ControlToValidate="txtWhatsappNo" ValidationGroup="Cform" ValidationExpression="^([1-9]{1})([234789]{1})([0-9]{8})$"></asp:RegularExpressionValidator>
                </div>
                <br />

                <div class="col-md-4">
                    Email:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Check your Email" ControlToValidate="txtEmail" ValidationGroup="Cform" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <br />


                <div class="col-md-4">
                    Blood Group:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBloodGroup" runat="server" CssClass="form-control" />
                </div>
                <br />
                <div class="col-md-4">
                    Facebook ID:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtFacebookID" runat="server" CssClass="form-control" />
                </div>
                <br />
                <div class="col-md-4">
                    LinkdIN ID:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtLinkdINID" runat="server" CssClass="form-control" />
                </div>
                <br />
                <div class="col-md-4">
                    Address:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Your Address" ControlToValidate="txtAddress" Display="Dynamic" ValidationGroup="Cform"></asp:RequiredFieldValidator>
                </div>
                <br />
                <div class="col-md-4">
                    Upload File:
                </div>
                <div class="col-md-8">
                    <asp:FileUpload ID="fuFile" runat="server" CssClass="" BackColor="#ccffff" BorderColor="White" BorderStyle="Double" />
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" EnableViewContact="False" CssClass="btn btn-success" OnClick="btnSave_Click" ValidationGroup="Cform" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
        <br />



    </div>
</asp:Content>

