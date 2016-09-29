<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MoviesXML.aspx.cs" Inherits="MoviesXML" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <!-- XMLDATASOURCE MÄÄRITTELY -->
    <asp:XmlDataSource ID="srcMovies" runat="server" DataFile="~/App_Data/Movies.xml" XPath="//Movie"></asp:XmlDataSource>
    <!-- GRIDVIEW-KONTROLLI ESITTÄÄ DATAN -->
    <h1>Movies from xml file</h1>
    <!-- <p>Tähän sisältöä...</p> -->
    <asp:GridView ID="gvMovies" DataSourceID="srcMovies" 
        HeaderStyle-BackColor="Blue" HeaderStyle-ForeColor="White"
        runat="server"></asp:GridView>

    <!-- Datan esittäminen HTML:ssa -->
    <h1>Elokuvat listattuna</h1>
    <asp:Repeater ID="Repeater1" DataSourceID="srcMovies" runat="server">
        <ItemTemplate>
            <p><%# Eval("Name") %> ohjaaja: <%# Eval("Director") %></p>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Repeater ID="Repeater2" DataSourceID="srcMovies" runat="server">
        <HeaderTemplate>
            <table border="1" style="width:50%;">
                <tr>
                    <td>Elokuva</td>
                    <td>Ohjaaja</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("Director") %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>