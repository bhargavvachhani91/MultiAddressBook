<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>City List Page
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
                    <asp:HyperLink runat="server" ID="hlAddState" Text="Add new City" CssClass="btn btn-warning" NavigateUrl="~/AdminPanel/CityAdd"></asp:HyperLink>
                </div>
                <div class="col-md-10">
                </div>
            </div>
            <div>
                <asp:GridView ID="gvCity" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand" Width="1121px">
                    <Columns>
                        <%--<asp:BoundField DataField="CityID" HeaderText="CityID" />
                        <asp:BoundField DataField="StateID" HeaderText="StateID" />--%>
                        <asp:BoundField DataField="CityName" HeaderText="CityName" />


                        <asp:TemplateField HeaderText="Delete ">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm ('Are You Sure You Want To Delete?')"  CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord"
                                    CommandArgument='<%#Eval("CityID").ToString() %>'>
                                
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/AdminPanel/CityEdit?CityID="+Eval("CityID").ToString().Trim() %>'>
                                
                                </asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

