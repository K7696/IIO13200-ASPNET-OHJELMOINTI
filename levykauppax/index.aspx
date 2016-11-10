<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
     <!-- XMLDATASOURCE MÄÄRITTELY -->
    <asp:XmlDataSource ID="srcAlbums" runat="server" DataFile="~/App_Data/LevykauppaX.xml" XPath="//record"></asp:XmlDataSource>

    <h1 class="w3-margin-left w3-blue-grey">LEVYKAUPPAX</h1>
    <asp:Repeater ID="Repeater1" DataSourceID="srcAlbums" runat="server">
        <ItemTemplate>
            <div class="w3-margin-left">
                 <div>
                    <img src="images/<%# Eval("Cover") %>" alt="img" width="200" height="200" />
                </div>
                <div>
                    <span class="w3-large"><%# Eval("Artist") %>: </span>
                    <span class="w3-large"><%# Eval("Title") %></span>
                    <br />
                    <span><span class="w3-large">ISBN: </span><a href="album.aspx?isbn=<%# Eval("ISBN") %>"><%# Eval("ISBN") %></a></span>
                    <br />
                    <span><span class="w3-large">Hinta: </span><%# Eval("Price") %></span>
                </div><hr />
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

