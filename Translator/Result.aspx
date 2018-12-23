<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Translator.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Translation: 
            <asp:Label ID="lblResult" runat="server"></asp:Label>
            <asp:Button ID="btnDownload" CssClass="btnOk" runat="server" Text="Dowload xml file" OnClick="BtnDownload_Click" />
        </div>
    </form>
</body>
</html>
