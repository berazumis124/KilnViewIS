<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KilnAdd.aspx.cs" Inherits="KilnView.KilnAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h2><label>Naujas ciklas</label></h2>
        <div class="form-group">
            <label>Džiovykla</label>
            <asp:DropDownList ID="ddl_Kilns" class="form-control" runat="server" AppendDataBoundItems="true" >
                <asp:ListItem Text="<Select Subject>" Value="0" />
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label>Programa</label>
            <asp:DropDownList ID="ddl_Programa" class="form-control" runat="server" AppendDataBoundItems="true" >
                <asp:ListItem Text="<Select Subject>" Value="0" />
            </asp:DropDownList>
        </div>
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
        <asp:Button ID="btn_Submit" Text="Išsaugoti" class="btn btn-default" runat="server" OnClick="btn_Submit_Click" />
    </div>
    </form>
</body>
</html>
