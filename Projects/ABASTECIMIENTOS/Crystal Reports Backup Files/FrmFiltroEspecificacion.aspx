<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmFiltroEspecificacion.aspx.vb" Inherits="ESTABLECIMIENTOS_FrmFiltroEspecificacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:Panel ID="Panel1" runat="server" Height="100px" Width="700px">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <table style="width: 700px; border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
          <tr>
            <td colspan="2" style="text-align: center">
              <strong><span style="font-family: Arial">Ver Solicitud de Compra</span></strong></td>
          </tr>
          <tr>
            <td style="width: 100px; text-align: right">
              <span style="font-family: Arial">Especificación Técnica</span>:</td>
            <td style="width: 100px">
              <br />
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">Si</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">No</asp:ListItem>
              </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: center">
              <asp:Button ID="Button1" runat="server" Text="Continuar >" /></td>
          </tr>
          <tr>
            <td style="width: 100px; height: 21px">
            </td>
            <td style="width: 100px; height: 21px">
            </td>
          </tr>
        </table>
      </asp:Panel>
    
    </div>
    </form>
</body>
</html>
