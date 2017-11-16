<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentJournalASPNET.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="StudentAddButton" runat="server" OnClick="StudentAddButton_Click" Text="Dodaj Studenta" />
        <br />
    
        <asp:DropDownList ID="SelectClassList" runat="server" DataSourceID="SelectClasses" DataTextField="ClassName" DataValueField="ClassName" OnSelectedIndexChanged="SelectClassList_SelectedIndexChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Button ID="ShowAllButton" runat="server" Text="Pokaż wszystkich" AutoPostBack="false" OnClick="ShowAllButton_Click" />
    
        <asp:SqlDataSource ID="SelectClasses" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsConnectionString %>" SelectCommand="SELECT [ClassName] FROM [StudentClass]"></asp:SqlDataSource>
        <asp:GridView ID="StudentGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Pesel" DataSourceID="SelectStudentSQL" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="695px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Pesel" HeaderText="Pesel" SortExpression="Pesel" />
                <asp:BoundField DataField="Name" HeaderText="Imię" SortExpression="Name" />
                <asp:BoundField DataField="Surname" HeaderText="Nazwisko" SortExpression="Surname" />
                <asp:BoundField DataField="name1" HeaderText="Płeć" SortExpression="name1" />
                <asp:BoundField DataField="BirthDate" HeaderText="Data urodzenia" SortExpression="BirthDate" />
                <asp:BoundField DataField="CityName" HeaderText="Miasto" SortExpression="CityName" />
                <asp:BoundField DataField="ClassName" HeaderText="Klasa" SortExpression="ClassName" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SelectStudentSQL" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsConnectionString %>"></asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
