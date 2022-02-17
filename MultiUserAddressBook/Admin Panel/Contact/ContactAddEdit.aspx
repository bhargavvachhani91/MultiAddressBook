<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                    <asp:DropDownList ID="ddlCountryID" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <br />
                <div class="col-md-4">
                    State:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlStateID" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="col-md-4">
                    City:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlCityID" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    Contact category:
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlContactCategoryID" CssClass="form-control" runat="server"></asp:DropDownList>

                </div>
                <div class="col-md-4">
                    Contact Name:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtContactName" runat="server" CssClass="form-control" />
                </div>
                <br />


                <div class="col-md-4">
                    Birthdate:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtBirthdate" runat="server" CssClass="form-control" />
                </div>
                <br />

                <div class="col-md-4">
                    Age:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" />
                </div>

                <div class="col-md-4">
                    Whatsapp Number
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtWhatsappNo" runat="server" CssClass="form-control" />
                </div>
                <br />

                <div class="col-md-4">
                    Email:
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
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
                </div>

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" EnableViewContact="False" CssClass="btn btn-success" OnClick="btnSave_Click" />
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" EnableViewContact="False" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
            </div>
        </div>
        <br />



    </div>
</asp:Content>

