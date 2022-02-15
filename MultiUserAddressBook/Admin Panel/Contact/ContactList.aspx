<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="row" >
        <div class="col-md-12">
            <h2>Contact List Page
            </h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="False" Font-Italic="False" ForeColor="Black"></asp:Label>
        </div>
    </div>
    <div class="row" style="overflow-x:auto">
        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                <asp:HyperLink runat="server" ID="hlAddState" Text="Add new Contact" CssClass="btn btn-warning" NavigateUrl="~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx"></asp:HyperLink>
            </div>
            <div>
                <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" OnRowCommand="gvContact_RowCommand" Height="192px" Width="1121px">
                    <Columns>
                        
                        <asp:TemplateField HeaderText="Delete ">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord"
                                    CommandArgument='<%#Eval("ContactID").ToString() %>'>

                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/AddressBook/AdminPanel/Contact/ContactAddEdit.aspx?ContactID="+Eval("ContactID").ToString().Trim() %>'>
                                
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
</asp:Content>

