<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmObservacionRechazo.aspx.vb"
  Inherits="LABORATORIO_FrmObservacionRechazo" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table class="CenteredTable" style="width: 100%">
        <tr>
          <td class="LabelCell" style="font-size: x-small" align="center" colspan="2">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
              Text="Rechazo de informes" /></td>
        </tr>
        <tr>
          <td class="LabelCell" style="font-size: x-small" align="right">
            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="X-Small"
              Text="Observacion:" /></td>
          <td class="DataCell">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
        </tr>
        <tr>
          <td class="LabelCell" style="font-size: x-small" align="center" colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
            <asp:Button ID="Button2" runat="server" Text="Cerrar" />
            <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Font-Size="Small" ForeColor="Red" /></td>
        </tr>
        <tr>
          <td align="center" class="LabelCell" colspan="2" style="font-size: x-small">
          </td>
        </tr>
        <tr>
          <td align="center" class="LabelCell" colspan="2" style="font-size: x-small">
          </td>
        </tr>
        <tr>
          <td align="center" class="LabelCell" colspan="2" style="font-size: x-small">
          </td>
        </tr>
      </table>
    </div>
    <nds:MsgBox ID="MsgBox1" runat="server" />
  </form>
</body>
</html>
