<%@ Page Title="" Language="C#" MasterPageFile="~/MultiUserAddressBook/Contect/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2>State List Page
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
                    <asp:HyperLink runat="server" ID="hlAddState" Text="Add new State" CssClass="btn btn-warning" NavigateUrl="~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx"></asp:HyperLink>
                </div>
                <div class="col-md-10">
                </div>
            </div>
            <div>
                <br />
                <asp:GridView ID="gvState" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand" Width="1121px">
                    <Columns>
                        <asp:BoundField DataField="StateID" HeaderText="StateID" />
                        <asp:BoundField DataField="CountryID" HeaderText="CountryID" />
                        <asp:BoundField DataField="CountryName" HeaderText="Country" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="StateCode" HeaderText="Code" />
                        <asp:TemplateField HeaderText="Delete ">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord"
                                    CommandArgument='<%#Eval("StateID").ToString() %>'>
                               
                                </asp:LinkButton>

                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" CssClass="btn btn-info btn btn-sm" NavigateUrl='<%#"~/MultiUserAddressBook/Admin Panel/State/StateAddEdit.aspx?StateID="+Eval("StateID").ToString().Trim() %>'>
                                
                                </asp:HyperLink>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

