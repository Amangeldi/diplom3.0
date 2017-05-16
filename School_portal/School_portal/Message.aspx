<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="School_portal.Message" %>

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
        <asp:TextBox ID="TextBox1" runat="server" Height="88px" TextMode="MultiLine" Width="700px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Отправить сообщение"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="0">Все пользователи</asp:ListItem>
            <asp:ListItem Value="1">Администратор</asp:ListItem>
            <asp:ListItem Value="2">Преподователь</asp:ListItem>
            <asp:ListItem Value="3">Ученик</asp:ListItem>
            <asp:ListItem Value="4">Родитель</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Выбрать адресата" />
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Отправить" />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Непрочитанные"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Прочитанные"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Отправленные сообщения:"></asp:Label>
    
    </div>
    </form>
</body>
</html>
