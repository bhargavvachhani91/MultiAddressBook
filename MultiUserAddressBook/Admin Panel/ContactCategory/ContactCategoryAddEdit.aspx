<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_ContactCategory_ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row">
        <div class="col-md-12">
            <h2>Contact Category Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessege" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Contact Category Name 
            
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtContactCategoryName" CssClass="form-control"  ></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save"  CssClass="btn btn-success" OnClick="btnSave_Click1"  />
             <asp:Button runat="server" ID="btnCancel" Text="Cancel"  CssClass="btn btn-danger" OnClick="btnCancel_Click1"  />
        </div>
    </div>
</asp:Content>

