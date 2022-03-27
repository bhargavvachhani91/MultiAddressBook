<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessege" ForeColor="Red" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-md-4">
                    State
                    <span style="color:red">*</span>
                </div>
                <div class="col-md-8">
                    <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    City Name 
                    <span style="color:red">*</span>
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    Pin Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    STD Code
                </div>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control"></asp:TextBox>
                </div>

            </div>
            <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-8">
                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    <asp:Button runat="server" ID="btnCancel" Text="cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

