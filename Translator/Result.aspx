<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Translator.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="grid">
            <div class="header">
            </div>
            <div class="main-section">
                <asp:Label ID="LabelText" CssClass="lblTxtTranslate" runat="server">Your final translation is: </asp:Label>
                <asp:Label ID="lblResult" CssClass="lblTxtRes" runat="server"></asp:Label>
<%--                <asp:Button ID="btnDownload" CssClass="btnOk" runat="server" Text="Dowload xml file" OnClick="BtnDownload_Click" />--%>
            </div>
        </div>
    </form>
</body>
</html>
