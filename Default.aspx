<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="KilnView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_new" class="btn btn-default" runat="server" Text="Naujas Ciklas" OnClick="btn_new_Click" /><br />
    <asp:PlaceHolder ID ="phKilnView" runat="server" />
    </div>
    </form>
</body>
</html>
