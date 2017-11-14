<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherPage.aspx.cs" Inherits="StudentJournalASPNET.TeacherPage" %>

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
        .auto-style2 {
            height: 23px;
            width: 414px;
        }
        .auto-style5 {
            height: 23px;
            width: 158px;
        }
        .auto-style6 {
            width: 158px;
        }
        .auto-style10 {
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
        .auto-style15 {
            width: 158px;
            height: 38px;
        }
        .auto-style16 {
            height: 38px;
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
    </style>

    <script type="text/javascript">
        function PeselValidate(oSrc, args) {
      if (studentRepository.PeselChecker(PeselTextBox.Text)) {
          args.IsValid = false;
      }
      else {
          args.IsValid = true;
      }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <asp:Button ID="ShowStudentListButton" runat="server" Text="Pokaż Studentów" OnClick="ShowStudentListButton_Click" />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="PeselLabel" runat="server" Text="Pesel"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="PeselTextBox" runat="server" Width="240px"></asp:TextBox>
                            <asp:Label ID="PeselValidatord" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="NameLabel" runat="server" Text="Imię"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="NameTextBox" runat="server" Width="240px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Podaj Imię" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NameTextBox" ErrorMessage="Podaj poprawne imię" ForeColor="Red" ValidationExpression="^[a-zA-z]{1,}$">*</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">
                            <asp:Label ID="SurnameLabel" runat="server" Text="Nazwisko"></asp:Label>
                        </td>
                        <td class="auto-style10">
                            <asp:TextBox ID="SurnameTextBox" runat="server" Width="240px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="SurnameTextBox" ErrorMessage="Podaj Nazwisko" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="SurnameTextBox" ErrorMessage="Podaj poprawne nazwisko" ForeColor="Red" ValidationExpression="^[a-zA-z]{1,}$">*</asp:RegularExpressionValidator>
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
                            <asp:TextBox ID="CityTextBox" runat="server" Width="240px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="CityTextBox" ErrorMessage="Podaj Miasto" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="CityTextBox" ErrorMessage="Podaj poprawną miejscowość" ForeColor="Red" ValidationExpression="^[a-zA-z]{1,}$">*</asp:RegularExpressionValidator>
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
                </table>
                <br />
               <asp:Button ID="SaveStudentButton" runat="server" Height="30px" OnClick="SaveStudentButton_Click" Text="Dodaj" Width="100px" />
    
                <br />
                <asp:Label ID="Test" runat="server"></asp:Label>



                <br />
    
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </asp:View>
            <asp:View ID="View2" runat="server">


                <asp:GridView ID="StudentList" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="Pesel" HeaderText="Pesel" SortExpression="Pesel" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="Surname" />
                        <asp:BoundField DataField="name1" HeaderText="name1" SortExpression="name1" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" />
                        <asp:BoundField DataField="CityName" HeaderText="CityName" SortExpression="CityName" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudentsConnectionString %>"></asp:SqlDataSource>
                <br />
                <asp:Button ID="BackToAddStudentButton" runat="server" OnClick="BackToAddStudentButton_Click" Text="Powrót" />


            </asp:View>
        </asp:MultiView>
    <div>
    
    </div>
    </form>
</body>
</html>
