<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPanel.aspx.cs" Inherits="StudentJournalASPNET.TeacherPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="LogOutButton" runat="server" OnClick="LogOutButton_Click" Text="Wyloguj" />
                <br />
                <br />
                <asp:Label ID="TeacherNameLabel" runat="server" Text="Label" Width="90px"></asp:Label>
                <asp:Label ID="TeacherSurnameLabel" runat="server" Text="Label" Width="100px"></asp:Label>
                <asp:Label ID="TeacherSubjectName" runat="server" Text="Label" Width="100px"></asp:Label>
                <br />
                <br />
                <asp:DropDownList ID="ListOfClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListOfClasses_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:GridView ID="StudentToMarkId" runat="server" OnSelectedIndexChanged="StudentToMarkId_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="Tan" />
                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                    <RowStyle Font-Names="Arial" />
                    <SelectedRowStyle BackColor="DarkSlateBlue" Font-Names="Arial" ForeColor="GhostWhite" />
                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                </asp:GridView>
                <asp:EntityDataSource ID="StudentsToMarkSQL" runat="server" ConnectionString="name=StudentsEntitiesModel" DefaultContainerName="StudentsEntitiesModel" EnableFlattening="False" EntitySetName="Student" Select="it.[Pesel], it.[Name], it.[Surname], it.[GenderId], it.[ClassId]">
                </asp:EntityDataSource>
                <br />
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Powrót" />
                <br />
                <br />
                <asp:DropDownList ID="MarkListDropDownList" runat="server">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Oceń" />
            </asp:View>
        </asp:MultiView>
    
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
