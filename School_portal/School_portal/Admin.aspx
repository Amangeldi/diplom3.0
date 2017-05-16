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
        <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Имя класса "></asp:Label>
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <asp:Label ID="Label13" runat="server" Text="Курс класса "></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label14" runat="server" Text="Классный руководитель "></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Добавить класс" />
    
        <br />
        <asp:TextBox ID="TextBox9" runat="server" OnTextChanged="TextBox9_TextChanged" AutoPostBack="true" ></asp:TextBox>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Удалить пользователя" />
        <asp:TextBox ID="TextBox10" runat="server" OnTextChanged="TextBox10_TextChanged"></asp:TextBox>
        <asp:Button ID="Button4" runat="server" Text="Удалить класс" OnClick="Button4_Click" />
    
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Расписание" />
    
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Написать сообщение" />
    
    </div>
    </form>
</body>
</html>
