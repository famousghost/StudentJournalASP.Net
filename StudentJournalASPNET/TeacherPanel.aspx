<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPanel.aspx.cs" Inherits="StudentJournalASPNET.TeacherPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="StudentToMarkId" runat="server" AutoGenerateColumns="true" DataSourceID="StudentsToMarkSQL" DataKeyNames="Pesel">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <RowStyle Font-Names="Arial" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" Font-Names="Arial" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:EntityDataSource ID="StudentsToMarkSQL" runat="server" ConnectionString="name=StudentsEntitiesModel" DefaultContainerName="StudentsEntitiesModel" EnableFlattening="False" EntitySetName="Student" Select="it.[Pesel], it.[Name], it.[Surname], it.[GenderId], it.[ClassId]">
        </asp:EntityDataSource>
    
    </div>
    </form>
</body>
</html>
