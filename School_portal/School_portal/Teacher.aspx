<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="School_portal.Teacher1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Выбрать группу: "></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="Выбрать студента: "></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label7" runat="server" Text="Предмет: "></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="Отметка: "></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem Value="0">Н</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="Label4" runat="server" Text="Вписать дату и время оценки:  "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Width="162px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Примечание к оценке: "></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Width="329px"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Добавить запись в журнал" OnClick="Button1_Click" />
    
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="Label8" runat="server" Text="Домашнее задание"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Выбрать группу: "></asp:Label>
            <asp:DropDownList ID="DropDownList5" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label10" runat="server" Text="Выбрать предмет: "></asp:Label>
            <asp:DropDownList ID="DropDownList6" runat="server">
            </asp:DropDownList>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Выбрать дату и время" />
            <asp:DropDownList ID="DropDownList7" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label11" runat="server" Text="Домашнее задание: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Задать домашнее задание" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Написать сообщение" />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
