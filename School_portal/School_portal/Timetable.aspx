<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timetable.aspx.cs" Inherits="School_portal.Timetable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
    </div>
        <asp:Panel ID="Panel1" runat="server">
            <div>
                <asp:Label ID="Label2" runat="server" Text="Выберите предмет: "></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" Text="Выберите препода: "></asp:Label>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
                <asp:Label ID="Label4" runat="server" Text="Выберите группу: "></asp:Label>
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
                <asp:Label ID="Label5" runat="server" Text="Выберите время: "></asp:Label>
                <asp:DropDownList ID="DropDownList4" runat="server">
                    <asp:ListItem>8:30</asp:ListItem>
                    <asp:ListItem>10:00</asp:ListItem>
                    <asp:ListItem>11:40</asp:ListItem>
                    <asp:ListItem>13:00</asp:ListItem>
                    <asp:ListItem>15:00</asp:ListItem>
                    <asp:ListItem>16:40</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Button2" runat="server" Text="Добавить расписание" OnClick="Button2_Click" />
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                <br />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
