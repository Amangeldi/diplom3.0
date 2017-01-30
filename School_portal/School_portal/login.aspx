<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="School_portal.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:RadioButton ID="RadioButton1" runat="server" GroupName="a" AutoPostBack="true" Text="Администратор"/>
        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="a" Text="Преподаватель" />
        <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" GroupName="a" Text="Ученик" />
        <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" GroupName="a" Text="Родитель" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Логин: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Пароль: "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Войти" />
        <asp:Button ID="Button2" runat="server" Text="Гость" />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
