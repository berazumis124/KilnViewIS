<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KilnMod.aspx.cs" Inherits="KilnView.KilnMod" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" runat="server">
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
        <h2><asp:Label ID="lbl_kilnName" runat="server" /><asp:Label ID="lbl_kilnID" Visible="false" runat="server" /></h2>
        <label>Starto Data/Laikas</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_startDate" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_startDate" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_startDate_Click" />
            </span>
        </div>
        <label>Stopo Data/Laikas</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_stopDate" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_stopDate" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_stopDate_Click" />
            </span>
        </div>
        <div class="checkbox">
            <label>
            <asp:CheckBox ID="chk_AtnaujintaM3" runat="server"/>Atnaujinta M3</label>
        </div>
        <label>Iškrovimo/Pakrovimo Normatyvas</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_forkNorm" CssClass="form-control" runat="server" />
        </div>
        <label>Iškrovimo Pradžia</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_unloadStart" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_unloadStart" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_unloadStart_Click" />
            </span>
        </div>
        <label>Iškrovimo Pabaiga</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_unloadStop" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_unloadStop" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_unloadStop_Click" />
            </span>
        </div>
        <label>Pakrovimo Pradžia</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_loadStart" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_loadStart" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_loadStart_Click" />
            </span>
        </div>
        <label>Pakrovimo Pabaiga</label>
        <div class="input-group">
            
            <asp:TextBox ID="txt_loadStop" class="form-control" runat="server" />
            <span class="input-group-btn">
                <asp:Button ID="btn_loadStop" Text="Data/Laikas" class="btn btn-default" runat="server" OnClick="btn_loadStop_Click" />
            </span>
        </div>
        <asp:Button ID="btn_Submit" Text="Atnaujinti" class="btn btn-default" runat="server" OnClick="btn_Submit_Click" />
    </div>
    </form>
</body>
</html>
