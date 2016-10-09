<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AsemapaikanJunat.aspx.cs" Inherits="AsemapaikanJunat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
    <div class="w3-margin-left w3-green">
        <h1>HAE LÄHTEVIÄ JUNIA <small><asp:Label ID="lblNow" runat="server"></asp:Label></small></h1>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
    <div class="w3-margin-left">
        <asp:Label ID="lblStation" Text="Liikenneasema:" runat="server"></asp:Label>
        <asp:DropDownList ID="dpStations" runat="server"></asp:DropDownList>
        <asp:Button ID="btnGetTrains" runat="server" Text="Hae lähtevät junat" OnClick="btnGetTrains_Click" />
    </div>
    <div class="w3-margin-left">
        <h2><asp:Label ID="lblTrains" runat="server" Text=""></asp:Label></h2>
        <asp:GridView ID="gvTrains" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="trainNumber" HeaderText="Numero" />
                <asp:BoundField DataField="trainType" HeaderText="Tyyppi" />
                <asp:BoundField DataField="departureDate" HeaderText="Lähtöpäivä" />
                <asp:TemplateField>
                    <HeaderTemplate>
                        <header>Peruttu</header>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkRow" runat="server" CssClass="w3-margin-left" Checked='<%# Convert.ToBoolean(Eval("cancelled")) %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
    <div class="w3-margin-left">
        <br />
        <asp:Label ID="lblSystemMessage" runat="server" Text=""></asp:Label>
    </div>
    <hr />
</asp:Content>