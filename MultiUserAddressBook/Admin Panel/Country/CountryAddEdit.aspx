<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" ForeColor="Red" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            Country Name :-
            <span style="color:red">*</span>
        </div>
        <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control"  ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Enter CountryName" ControlToValidate="txtCountryName"></asp:RequiredFieldValidator>
        </div>
         <div class="col-md-4">
            Country Code :-
            <span style="color:red">*</span>
        </div>
         <div class="col-md-8">
            <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control"  ></asp:TextBox>
             <asp:RequiredFieldValidator runat="server" ErrorMessage="Enter Country Code" ControlToValidate="txtCountryCode"></asp:RequiredFieldValidator>
        </div>
        
    </div>
    <div class="row">
        <div class="col-md-4">

        </div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
            <asp:HyperLink NavigateUrl="~/MultiUserAddressBook/Admin Panel/Country/CountryList.aspx" runat="server" ID="btnCancel" Text="Cancel"  CssClass="btn btn-danger" OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>

