<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KilnMod.aspx.cs" Inherits="KilnView.KilnMod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txt_startDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%Y-%m-%d %H:%M",
            daFormat: "%l;%M %p, %e %m, %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
            });
        });
</script>
</head>

<body>
    <form id="form1" runat="server">
    <div class="container">
        <h2><asp:Label ID="lbl_kilnName" runat="server" /></h2>
        <div class="form-group">
            <label>Starto Data/Laikas</label>
            <asp:TextBox ID="txt_startDate" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>Stopo Data/Laikas</label>
            <asp:TextBox ID="txt_stopDate" class="form-control" runat="server" />
        </div>
        <div class="checkbox">
            <label>
            <asp:CheckBox ID="chk_AtnaujintaM3" runat="server"/>Atnaujinta M3</label>
        </div>
        <div class="form-group">
            <label>Iškrovimo Pradžia</label>
            <asp:TextBox ID="txt_unloadStart" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>Iškrovimo Pabaiga</label>
            <asp:TextBox ID="txt_unloadStop" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>Pakrovimo Pradžia</label>
            <asp:TextBox ID="txt_loadStart" class="form-control" runat="server" />
        </div>
        <div class="form-group">
            <label>Iškrovimo Pabaiga</label>
            <asp:TextBox ID="txt_loadStop" class="form-control" runat="server" />
        </div>
        <asp:Button ID="btn_Submit" Text="Atnaujinti" class="btn btn-default" runat="server" OnClick="btn_Submit_Click" />
    </div>
    </form>
</body>
</html>
