<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Album.aspx.cs" Inherits="Album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">

    <%
        var id = Request.QueryString["isbn"];

        string xpathi = "//record[@ISBN='" + id + "']";

        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
        doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/LevykauppaX.xml"));

        System.Xml.XmlNode album;
        System.Xml.XmlNode root = doc.DocumentElement;

        album=root.SelectSingleNode(xpathi);
     %>
        
    <h1 class="w3-margin-left"><%=album.Attributes["Artist"].Value %> : <%=album.Attributes["Title"].Value %></h1> 
    <div class="w3-margin-left">
         <div>
            <img src="images/<%=album.Attributes["Cover"].Value %>" />
        </div>
        <div>
            <span><span class="w3-large">ISBN: </span><%=album.Attributes["ISBN"].Value %></span>
            <br />
            <span><span class="w3-large">Hinta: </span><%=album.Attributes["Price"].Value %></span>
        </div>
        <div>
            <h3>BIISIT</h3>
            <% foreach (System.Xml.XmlNode node in album.ChildNodes)
               { %>
            <div><span class="w3-large">Numero: </span><span><%=node.Attributes["num"].Value %></span></div>
            <div><span class="w3-large">Nimi: </span><span><%=node.Attributes["name"].Value %></span></div>
            <div><span class="w3-large">Sanat: </span><span><%=node.InnerText %></span></div>
            <hr />
            <% } %>
        </div>
        <div>
            <a href="index.aspx">&lt;- Takaisin listalle</a>
        </div>
    </div>   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

