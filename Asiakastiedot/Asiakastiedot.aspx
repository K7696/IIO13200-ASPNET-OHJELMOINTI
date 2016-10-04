<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Asiakastiedot.aspx.cs" Inherits="Asiakastiedot" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <div class="w3-margin-left datatable">
        <asp:SqlDataSource 
        ID="srcCustomers" 
        runat="server" 
        ConnectionString='<%$ ConnectionStrings:Asiakkaat %>' 
        SelectCommand="SELECT TOP 10 [astunnus], [asnimi], [yhteyshlo], [postitmp] FROM [asiakas]"></asp:SqlDataSource>
        <h2>DATASOURCE 1</h2>
        <asp:GridView ID="gvCustomers" DataSourceID="srcCustomers" 
            runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="astunnus" HeaderText="Asiakastunnus" SortExpression="astunnus" />
                <asp:BoundField DataField="asnimi" HeaderText="Asiakas" SortExpression="asnimi" />
                <asp:BoundField DataField="yhteyshlo" HeaderText="Yhteyshenkilö" SortExpression="yhteyshlo" />
                <asp:BoundField DataField="postitmp" HeaderText="Postitoimipaikka" SortExpression="postitmp" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="w3-margin-left datatable">
        <h2>DATASOURCE 2</h2>
        <asp:GridView ID="sqlCustomers" runat="server"></asp:GridView>
    </div>
    <div>
        <asp:Label ID="lblSystemMessage" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>