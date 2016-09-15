<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TarjousLaskuri.aspx.cs" Inherits="TarjousLaskuri" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link 
        rel="stylesheet" 
        href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" 
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" 
        crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-12">
            <h1>IKKUNAN TARJOUSLASKURI</h1>
        </div>
        <div class="col-md-3">
            <div class="col-md-offset-1">
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl1" class="" runat="server" Text="Ikkunan Leveys (L):"></asp:Label>
                    </div>
                    <div class="">
                        <asp:TextBox ID="tbWindowWidth" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>       
                </div>
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl2" class="" runat="server" Text="Ikkunan korkeus (H):"></asp:Label>
                    </div>
                    <div class="">
                        <asp:TextBox ID="tbWindowHeight" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl3" class="" runat="server" Text="Karmipuun leveys (W):"></asp:Label>
                    </div>
                    <div class="">
                        <asp:TextBox ID="tbFrameWidth" class="form-control input-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="text-info"><b>Huom.</b> Syötä ikkunan ja karmin mitat millimetreinä.</div>
                <br />
                <div class="row form-group">
                    <div>
                        <asp:Button ID="btnCalculateOffer" class="btn btn-primary btn-lg" runat="server" Text="Laske tarjoushinta" OnClick="btnCalculateOffer_Click" />
                    </div>
                </div>
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl4" class="" runat="server" Text="Ikkunan pinta-ala:"></asp:Label>
                    </div>
                    <div class="bg-info">
                        <asp:Label ID="lblWindowArea" class=""  runat="server" Text="..."></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl5" class="" runat="server" Text="Karmin piiri:"></asp:Label>
                    </div>
                    <div class="bg-info">
                        <asp:Label ID="lblFrameCircuit" class=""  runat="server" Text="..."></asp:Label>
                    </div>
                </div>
                <div class="row form-group">
                    <div class="">
                        <asp:Label ID="lbl6" class="" runat="server" Text="Tarjoushinta (ilman ALV)"></asp:Label>
                    </div>
                    <div class="bg-info">
                        <asp:Label ID="lblPrice" class=""  runat="server" Text="..."></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <asp:Image ID="imgWindow" runat="server" />
        </div>
        <div class="row col-md-12">
            <div class="col-md-offset-1">
                <asp:Label ID="lblSystemMessage" class="text-warning" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
<script 
    src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" 
    integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" 
    crossorigin="anonymous"></script>
</body>
</html>
