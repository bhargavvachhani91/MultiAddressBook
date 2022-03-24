<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_Contact_ContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
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
    <div class="row" style="overflow-x: auto">
        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-10">
                <asp:HyperLink runat="server" ID="hlAddState" Text="Add new Contact" CssClass="btn btn-warning" NavigateUrl="~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx"></asp:HyperLink>
            </div>
            <div>
                <asp:GridView ID="gvContact" runat="server" CssClass="table table-hover" OnRowCommand="gvContact_RowCommand" Height="192px" Width="1121px" AutoGenerateColumns="False">
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
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/MultiUserAddressBook/Admin Panel/Contact/ContactAddEdit.aspx?ContactID="+Eval("ContactID").ToString().Trim() %>'>
                                
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image runat="server" ID="imgImage" CssClass="img-fluid" hight="50" ImageUrl='<%# Eval("Filepath") %>'></asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ImageDelete">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lbtnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteImage" CommandArgument='<%#Eval("ContactID").ToString() %>'>

                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="FileExtention" HeaderText="File Type" />
                        <asp:BoundField DataField="FileSize" HeaderText="File Size" />--%>
                        
                        <asp:BoundField DataField="CityName" HeaderText="City Name" />
                        <asp:BoundField DataField="StateName" HeaderText="State Name" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                        <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
                        <asp:BoundField DataField="WhatsappNo" HeaderText="Whatsapp No" />
                        <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" />
                        <asp:BoundField DataField="Email" HeaderText="Email Id" />
                        <asp:BoundField DataField="Age" HeaderText="Age" />
                        <asp:BoundField DataField="BloodGroup" HeaderText="Blood Group" />
                        <asp:BoundField DataField="FacebookID" HeaderText="Facebook Id" />
                        <asp:BoundField DataField="LinkedINID" HeaderText="Linkedin Id" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="ContactCategoryNames" HeaderText="CategoryName" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

