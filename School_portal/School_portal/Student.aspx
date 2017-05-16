<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="School_portal.Student1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Здравствуйте "></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Написать сообщение" />
    
    </div>
    </form>
</body>
</html>
