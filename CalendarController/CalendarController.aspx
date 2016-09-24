<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CalendarController.aspx.cs" Inherits="CalendarController" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CalendarController</title>
    <style>
        .hidden{
            visibility:hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="">
            <div>
                <h1><asp:Label ID="lblToday" runat="server" Text=""></asp:Label></h1>
            </div>
            <div>
                <span><b>Valittu päivämäärä:</b></span>
                <asp:Label ID="lblChosenDate" runat="server" Text=""></asp:Label>
                <br />
                <span><b>Valitun päivän ja tämän päivän erotus: </b></span>
                <span id="allDays" runat="server" class="hidden">
                    <asp:Label ID="lblAllDays" runat="server" Text=""></asp:Label>
                    <span> päivää</span>
                </span>               
                <br />
                <span><b>Päivää / Kuukautta / Vuotta</b></span>
                <br />
                <span id="otherDays" runat="server" class="hidden">
                    <asp:Label ID="lblDateDifference" runat="server" Text=""></asp:Label>
                    <span> päivää /</span>
                    <asp:Label ID="lblMonthDifference" runat="server" Text=""></asp:Label>
                    <span> kuukautta /</span>
                    <asp:Label ID="lblYearDifference" runat="server" Text=""></asp:Label>
                    <span> vuotta</span>
                </span>
            </div>
            <br />
            <div>
                <asp:Button ID="bntPrevious" runat="server" OnClick="bntPrevious_Click" Text="< Vuosi" />
                <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Vuosi >" />
                <br />
                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
                   
                </asp:Calendar>
            </div>
        </div>
        <br />
        <div>
            <asp:Label ID="lblSystemMessage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
