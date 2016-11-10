<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
<div class="w3-margin-left">
    <div class="w3-top w3-blue-grey">
        <h1 class="w3-margin-left">FINNKINO</h1>
    </div>
    <div class="w3-sidenav w3-collapse w3-white w3-animate-left" style="margin-top:65px;width:270px">
        <asp:ListBox ID="ListBox1" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" runat="server" style="width:250px;height:400px;overflow:scroll;"></asp:ListBox>
    </div>
    <div class="w3-main w3-container" style="margin-left:270px;margin-top:60px;">
        <h3>Leffat <asp:Label ID="lblHeader" runat="server" Text=""></asp:Label> <asp:Label ID="date" runat="server" Text=""></asp:Label></h3>
        <asp:Label ID="err" runat="server" Text=""></asp:Label>
        <div>
            <asp:Repeater ID="rptMovies" runat="server">
              <HeaderTemplate>
                <table>
                  <thead>
                    <tr>
                        <th></th>
                    </tr>
                  </thead>
                  <tbody>
              </HeaderTemplate>
              <ItemTemplate>
                <tr>
                  <td><img src="<%# Eval("RatingImageUrl") %>" alt="img" /></td>
                </tr>
              </ItemTemplate>
              <FooterTemplate>
                </tbody>
                </table>
              </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<br />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

