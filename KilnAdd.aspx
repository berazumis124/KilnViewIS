<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KilnAdd.aspx.cs" Inherits="KilnView.KilnAdd" %>

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
        <asp:Button ID="btn_Submit" Text="Išsaugoti" class="btn btn-default" runat="server" OnClick="btn_Submit_Click" />
    </div>
    </form>
</body>
</html>
