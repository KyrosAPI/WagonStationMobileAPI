<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="WSMobileApp.UnitTest.ManageProfilePicture.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"></html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload runat="server" ID="fuTest" />&nbsp;<asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_OnClick" />
        </div>
        <div style="width: 100%;">
            <asp:Label runat="server" ID="lblTest"></asp:Label>
        </div>
    </form>
    <script>
        
    </script>
</body>
    