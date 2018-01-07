<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="StudentJournalASPNET.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="LoginLabel" runat="server" Text="Login:"></asp:Label>
        <asp:TextBox ID="LoginTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="LogInButton" runat="server" OnClick="LogInButton_Click" Text="Zaloguj" />
    </form>
</body>
</html>
