<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>Country List Page
            </h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="False" Font-Italic="False" ForeColor="Black"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="row">
                <div class="col-md-2">
                    <asp:HyperLink runat="server" ID="hlAddState" Text="Add new Country" CssClass="btn btn-warning" NavigateUrl="~/AdminPanel/Country/Add"></asp:HyperLink>
                </div>
                <div class="col-md-10">
                </div>
            </div>
            <div>
                <asp:GridView ID="gvCountry" runat="server" CssClass="table table-hover" OnRowCommand="gvCountry_RowCommand" AutoGenerateColumns="false" Width="1121px" OnSelectedIndexChanged="gvCountry_SelectedIndexChanged">

                    <Columns>
                        <%--<asp:BoundField DataField="CountryID" HeaderText="CountryID" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" />--%>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />

                        <asp:TemplateField HeaderText="Delete ">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm ('Are You Sure You Want To Delete?')" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord"
                                    CommandArgument='<%# Eval("CountryID").ToString() %>'></asp:Button>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/AdminPanel/Country/Edit/"+EncryptionDecryption.Encode(Eval("CountryID").ToString().Trim()) %>'>
                                
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>



        </div>
    </div>
</asp:Content>

