<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewFeedback.aspx.cs" Inherits="NewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" Runat="Server">
    <div class="w3-margin-left">
        <h1>Anna palaute</h1>
        <div>
            <table>
                <tr>
                    <td>Pvm:</td>
                    <td>
                        <asp:TextBox ID="tbDate" runat="server" Text=""></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator0"
                    ControlToValidate="tbDate"
                    Display="Static"
                    ErrorMessage="* Syötä pvm"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Nimi:</td>
                    <td>
                        <asp:TextBox ID="tbName" runat="server" Text=""></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator1"
                    ControlToValidate="tbName"
                    Display="Static"
                    ErrorMessage="* Syötä nimi"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Opintojakso:</td>
                    <td>
                        <asp:TextBox ID="tbCourse" runat="server" Text=""></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator2"
                    ControlToValidate="tbCourse"
                    Display="Static"
                    ErrorMessage="* Syötä opintojakso"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Olen oppinut:</td>
                    <td>
                        <asp:TextBox ID="tbLearned" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator3"
                    ControlToValidate="tbLearned"
                    Display="Static"
                    ErrorMessage="* Syötä olen oppinut tekstiä"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Haluan oppia:</td>
                    <td>
                        <asp:TextBox ID="tbWantToLearn" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator4"
                    ControlToValidate="tbWantToLearn"
                    Display="Static"
                    ErrorMessage="* Syötä haluan oppia tekstiä"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Hyvää:</td>
                    <td>
                        <asp:TextBox ID="tbGood" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator5"
                    ControlToValidate="tbGood"
                    Display="Static"
                    ErrorMessage="* Syötä hyvää tekstiä"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Parannettavaa:</td>
                    <td>
                        <asp:TextBox ID="tbToDoBetter" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator id="validator6"
                    ControlToValidate="tbToDoBetter"
                    Display="Static"
                    ErrorMessage="* Syötä paranettavaa tekstiä"
                    runat="server"/> 
                    </td>
                </tr>
                <tr>
                    <td>Muuta:</td>
                    <td>
                        <asp:TextBox ID="tbOther" runat="server" Text="" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td><asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Lähetä palaute" /></td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <a href="Index.aspx">&lt;- Takaisin palautteisiin</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" Runat="Server">
</asp:Content>

