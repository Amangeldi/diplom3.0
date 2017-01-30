<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="School_portal.Admin1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Список пользователей: "></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Добавить пользователя"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Роль: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="1">Администратор</asp:ListItem>
            <asp:ListItem Value="2">Преподаватель</asp:ListItem>
            <asp:ListItem Value="3">Ученик</asp:ListItem>
            <asp:ListItem Value="4">Родитель</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label5" runat="server" Text=" Фамилия: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text=" Имя: "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Label ID="Label7" runat="server" Text=" Отчество: "></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Адрес"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:Label ID="Label9" runat="server" Text=" Логин: "></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:Label ID="Label10" runat="server" Text=" Пароль "></asp:Label>
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <asp:Label ID="Label11" runat="server" Text=" Дата рождения: "></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" />
        <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Добавить группу" />
    
    </div>
    </form>
</body>
</html>
