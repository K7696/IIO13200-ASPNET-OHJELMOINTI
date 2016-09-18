<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lotto.aspx.cs" Inherits="Lotto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lotto</title>
    <link 
        rel="stylesheet" 
        href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" 
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" 
        crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script 
    src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" 
    integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" 
    crossorigin="anonymous"></script>
    <style>
        th{
           background-color: #286090;
           border-color: #204d74;
           color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>ARVO LOTTORIVIT</h1>        
            <div>
                <ul class="nav nav-tabs">
                  <li role="presentation" id="tab1" runat="server">
                      <a href="#lottoDiv" data-toggle="tab">Perinteinen lotto</a>
                  </li>
                  <li role="presentation" id="tab2" runat="server">
                      <a href="#vikingDiv" data-toggle="tab">Viking-lotto</a>
                  </li>
                </ul>
            </div> <!-- tabs end -->
            <div class="tab-content">
                <div id="lottoDiv" runat="server" class="">
                    <div class="row form-group col-md-pull-1">
                        <br />
                        <asp:Label ID="lblLotto" runat="server" Text="Rivien lukumäärä: "></asp:Label>
                        <asp:TextBox ID="txtLottoRows" size="2" class="input-lg" runat="server"></asp:TextBox>
                        <asp:Button ID="btnLotto" class="btn btn-primary btn-lg" runat="server" Text="Arvo rivit" OnClick="btnLotto_Click" />
                    </div>
                    <div class="col-md-4">
                        <p><b>Arvotut rivit</b></p>
                        <asp:GridView ID="gvLottoRows" class="table" runat="server"></asp:GridView>
                    </div>
                </div>
                <div id="vikingDiv" runat="server" class="">
                    <div class="row form-group col-md-pull-1">
                        <br />
                        <asp:Label ID="lblVikingLotto" runat="server" Text="Rivien lukumäärä: "></asp:Label>
                        <asp:TextBox ID="txtVikingLottoRows" size="2" class="input-lg" runat="server"></asp:TextBox>
                        <asp:Button ID="btnViking" class="btn btn-primary btn-lg" runat="server" Text="Arvo rivit" OnClick="btnViking_Click" />
                    </div>
                    <div class="col-md-4">
                        <p><b>Arvotut rivit</b></p>
                        <asp:GridView ID="gvVikingRows" class="table" runat="server"></asp:GridView>
                    </div>
                </div> 
                <br />
                <div class="col-md-12">
                    <asp:Label ID="lblSystemMessage" class="text-warning" runat="server" Text=""></asp:Label>
                </div>
            </div> <!-- tab-content end -->
       </div> <!-- container end -->
    </form>
</body>
</html>
