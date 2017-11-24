<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentList.aspx.cs" Inherits="StudentJournalASPNET.StudentList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 78%;
            height: 206px;
            margin-bottom: 0px;
        }
        .auto-style5 {
            height: 23px;
            width: 158px;
        }
        .auto-style2 {
            height: 23px;
            width: 414px;
        }
        .auto-style6 {
            width: 158px;
        }
        .auto-style10 {
            width: 414px;
        }
        .auto-style17 {
            width: 158px;
            height: 29px;
        }
        .auto-style18 {
            width: 414px;
            height: 29px;
        }
        .auto-style15 {
            width: 158px;
            height: 38px;
        }
        .auto-style16 {
            height: 38px;
            width: 414px;
        }
        .auto-style13 {
            width: 158px;
            height: 39px;
        }
        .auto-style14 {
            height: 39px;
            width: 414px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="StudentAddButton" runat="server" OnClick="StudentAddButton_Click" Text="Dodaj Studenta" />
                <br />
                <asp:DropDownList ID="SelectClassList" SelectCommand ="Select ClassName from StuentClass" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ClassName" DataValueField="ClassName" OnSelectedIndexChanged="SelectClassList_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsConnectionString %>" SelectCommand="SELECT [ClassName] FROM [StudentClass]"></asp:SqlDataSource>
                <asp:Button ID="ShowAllButton" runat="server" AutoPostBack="false" OnClick="ShowAllButton_Click" Text="Pokaż wszystkich" />
                <asp:GridView ID="StudentGridView" runat="server" AutoGenerateColumns="true" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="695px" OnSelectedIndexChanged="StudentGridView_SelectedIndexChanged" DataKeyNames="Pesel">
                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
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
                <asp:SqlDataSource ID="SelectStudentSQL" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsConnectionString %>"></asp:SqlDataSource>
                <br />
            </asp:View>
            <asp:View ID="View2" runat="server">


                <asp:Button ID="BackButton" runat="server" CausesValidation="false" OnClick="BackButton_Click" Text="Powrót" />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="PeselLabel" runat="server" Text="Pesel"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:Label ID="PeselLabelText" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="NameLabel" runat="server" Text="Imię"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="NameTextBox" runat="server" Width="240px" Font-Names="Arial"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Podaj Imię" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Podaj poprawne imię" ForeColor="Red" ValidationExpression="^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ]{1,}$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="SurnameLabel" runat="server" Text="Nazwisko"></asp:Label>
                        </td>
                        <td class="auto-style10">
                            <asp:TextBox ID="SurnameTextBox" runat="server" Width="240px" Font-Names="Arial"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="SurnameTextBox" ErrorMessage="Podaj Nazwisko" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="SurnameTextBox" ErrorMessage="Podaj poprawne nazwisko" ForeColor="Red" ValidationExpression="^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ]{1,}$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17">
                            <asp:Label ID="GenderLabel" runat="server" Text="Płeć"></asp:Label>
                        </td>
                        <td class="auto-style18">
                            <asp:DropDownList ID="GenderDropDownList" runat="server">
                                <asp:ListItem>Mężczyzna</asp:ListItem>
                                <asp:ListItem>Kobieta</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="CityLabel" runat="server" Text="Miasto"></asp:Label>
                        </td>
                        <td class="auto-style16">
                            <asp:TextBox ID="CityTextBox" runat="server" Width="240px" Font-Names="Arial"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="CityTextBox" ErrorMessage="Podaj Miasto" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="CityTextBox" ErrorMessage="Podaj poprawną miejscowość" ForeColor="Red" ValidationExpression="^[a-zA-ZąćęłńóśźżĄĘŁŃÓŚŹŻ]{1,}$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style13">
                            <asp:Label ID="BirthDateLabel" runat="server" Text="Data Urodzenia"></asp:Label>
                        </td>
                        <td class="auto-style14">
                            <asp:DropDownList ID="DayDropDownList" runat="server" Height="30px" Width="50px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="MonthDropDownList" runat="server" Height="30px" Width="50px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="YearDropDownList" runat="server" Height="30px" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            <asp:Label ID="StudentClass" runat="server" Text="Wybór Klasy"></asp:Label>
                        </td>
                        <td class="auto-style16">
                            <asp:DropDownList ID="ClassChoose" runat="server">
                                <asp:ListItem>A</asp:ListItem>
                                <asp:ListItem>B</asp:ListItem>
                                <asp:ListItem>C</asp:ListItem>
                                <asp:ListItem>D</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="StudentExistLabel" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <asp:Button ID="UpdateButton" runat="server" Height="30px" OnClick="UpdateButton_Click" Text="Zaktualizuj" Width="100px" />
                <asp:Button ID="DeleteStudent" runat="server" Height="30px" OnClick="DeleteStudent_Click" Text="Usuń" Width="100px" />
                <br />
                <br />
                <asp:Label ID="Test" runat="server"></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />


            </asp:View>
        </asp:MultiView>
        <br />
    
    </div>
    </form>
</body>
</html>
