<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentPanel.aspx.cs" Inherits="StudentJournalASPNET.StudentPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="LogOutButton" runat="server" OnClick="LogOutButton_Click" Text="Wyloguj" />
        <br />
        <br />
        Witaj
        <asp:Label ID="NameLabel" runat="server" Text="Label" Width="200px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:DropDownList ID="SubjectIdDropDownList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="StudentMarkGridView" AutoGenerateColumns="true" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
    
    </div>
    </form>
</body>
</html>
