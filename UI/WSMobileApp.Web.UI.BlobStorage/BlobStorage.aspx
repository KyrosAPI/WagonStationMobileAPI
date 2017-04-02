<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlobStorage.aspx.cs" Inherits="WSMobileApp.Web.UI.BlobStorage.BlobStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload runat="server" ID="fuBlob"/>&nbsp;<asp:Button runat="server" ID="btnTest" Text="Upload" OnClick="btnTest_OnClick"/>
    </div>
        <div>
            <asp:Button runat="server" ID="btnDownload" Text="Download" OnClick="btnDownload_OnClick"/>&nbsp;<asp:Button runat="server" ID="btnList" Text="List" OnClick="btnList_OnClick"/>
        </div>
    </form>
</body>
</html>
