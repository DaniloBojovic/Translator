<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Translator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Assets/css/style.css" rel="stylesheet" />
</head>
<body">
    <form id="form1" runat="server">      
        <div class="grid">
            <div class="header">
            </div>
            <div class="main-section">
                <div class="comment-section">
                    <asp:TextBox ID="txtInput" CssClass="txtInput" runat="server" onKeyUp="javascript:userInputTimer(this)"></asp:TextBox>
                </div>
                    <asp:Label ID="lblText" CssClass="lblTxt" runat="server">Translated text: </asp:Label>
                    <asp:Button ID="btnOk" CssClass="btnOk" runat="server" Text="OK - continue" OnClick="BtnOk_Click" />
            </div>
        </div>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="Assets/js/script.js"></script>
</body>
</html>
