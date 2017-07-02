<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MegaChallengeCasino._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="Image2" runat="server" Height="150px" Width="150px" />
        <asp:Image ID="Image3" runat="server" Height="150px" Width="150px" />
    
    </div>
        <p>
            Your Bet:
            <asp:TextBox ID="betBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="leverButton" runat="server" OnClick="leverButton_Click" Text="Pull the Lever!" />
        </p>
        <asp:Label ID="betSummaryLabel" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="playersMoneyLabel" runat="server"></asp:Label>
        <br />
        <br />
        <span class="auto-style1">1 Cherry - 2X Your Bet</span><br class="auto-style1" />
        <span class="auto-style1">2 Cherries - 3X Your Bet</span><br class="auto-style1" />
        <span class="auto-style1">3 Cherries - 4X Your Bet</span><br class="auto-style1" />
        <span class="auto-style1">3 7&#39;s - JACKPOT - 100X Your Bet</span><br />
        <br />
        HOWEVER ... if there&#39;s even one BAR you win nothing</form>
</body>
</html>
