<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hae-tyontekijat-ilta.aspx.cs" Inherits="hae_tyontekijat_ilta" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Firman X työntekijät</title>
    <link rel="stylesheet" href="http://www.w3schools.com/lib/w3.css">
</head>
<body>
    <!-- Sivulla pitää olla aina ko. form, jonka sisään tulee featuret. -->
    <form id="form1" runat="server">
        <div id="nappulat">
            <asp:Button ID="btnHae" Class="w3-btn w3-green" runat="server" Text="Hae työntekijät" OnClick="btnHae_Click" />
        </div>
        <div id="esitys">
            <asp:GridView ID="gvData" Class="w3-green" runat="server"></asp:GridView>
        </div>
        <div id="footer">
            <asp:Label ID="lglMessage" Class="w3-container w3-teal" runat="server" Text="Label">...</asp:Label>
        </div>
    </form>
</body>
</html>
