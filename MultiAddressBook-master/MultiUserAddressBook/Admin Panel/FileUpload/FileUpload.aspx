<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUpload.aspx.cs" Inherits="MultiUserAddressBook_Admin_Panel_FileUpload_FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> Select File to Upoad <br />
            <asp:FileUpload ID="fuFile" runat="server" />
               <br />
            <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" />
            <br />
            <asp:Button runat="server" ID="btnDeletFile" Text="Delete the File" OnClick="btnDeletFile_Click" />
            <br />
            <asp:Label  runat="server" ID="lblMessage" EnableViewState="false" />
            </div>
    </form>
</body>
</html>
