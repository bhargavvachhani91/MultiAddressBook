<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_State_SateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>State Add Edit Page</h2>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">

            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>

        </div>

    </div>
    <br />
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    Country
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    State Name 
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-4">
                    State Code 
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtStateCode" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btncancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btncancel_Click" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>

