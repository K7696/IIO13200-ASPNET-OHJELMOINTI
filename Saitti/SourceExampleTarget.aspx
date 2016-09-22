<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SourceExampleTarget.aspx.cs" Inherits="SourceExampleTarget" %>
<%@ PreviousPageType VirtualPath="~/SourceExample.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data Transfer Demo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Target Page</h1>
            The message send to this page is: <div id="myText" runat="server" />
        </div>
        <br />
        <div>
            <asp:HyperLink runat="server" ID="hyperlink1" Text="Source Page" NavigateUrl="~/SourceExample.aspx"></asp:HyperLink>
        </div>
    </form>
</body>
</html>
