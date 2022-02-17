<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_ContactCategory_ContactCategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>
                Contact Category List Page
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
                     <asp:HyperLink runat="server" ID="hlAddState" Text="Add new ContactCategory" CssClass="btn btn-warning" NavigateUrl="~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx"></asp:HyperLink>
                </div>
                <div class="col-md-10">
                   
                </div>
            </div>
            <div>
                <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand" Width="1121px">

                    <Columns>
                        <asp:BoundField DataField="ContactCategoryID" HeaderText="ContactCategoryID" />
                        <asp:BoundField DataField="ContactCategoryName" HeaderText="Contact Category Name" />

                        <asp:TemplateField HeaderText="Delete ">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" 
                                    CommandArgument='<%#Eval("ContactCategoryID").ToString() %>'>
                               
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/MultiUserAddressBook/Admin Panel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID="+Eval("ContactCategoryID").ToString().Trim() %>'>
                                
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>
            </div>
        </div>
        
        
    </div>
</asp:Content>

