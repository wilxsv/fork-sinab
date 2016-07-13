<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmNuevaContrasena.aspx.vb"
  Inherits="FrmNuevaContrasena" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link href="~/Style.css" rel="stylesheet" type="text/css" />

  <script type="text/javascript"> 
//Script para que no funcione el boton atras del navegador
if (history.forward(1)){location.replace(history.forward(1))} 
  </script>

</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table class="CenteredTable" style="width: 100%;">
        <tr>
          <td>
            <asp:Panel ID="Panel1" runat="server" Width="100%">
              <table class="CenteredTable" style="width: 100%;">
                <tr>
                  <td colspan="2" style="font-weight: bold; background-color: GrayText">
                    Cambio de contraseña</td>
                </tr>
                <tr>
                  <td colspan="2">
                  </td>
                </tr>
                <tr>
                  <td class="LabelCell">
                    <asp:Label ID="Label3" runat="server" Text="Usuario:" /></td>
                  <td class="DataCell">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" /></td>
                </tr>
                <tr>
                  <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server" Text="Nueva contraseña:" /></td>
                  <td class="DataCell">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" MaxLength="8" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                      Display="Dynamic" ErrorMessage="Dato requerido" Text="*" /></td>
                </tr>
                <tr>
                  <td class="LabelCell">
                    Re-escriba nueva contraseña:</td>
                  <td class="DataCell">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" MaxLength="8" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                      Display="Dynamic" ErrorMessage="Dato requerido" Text="*" />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1"
                      ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden"
                      Text="*" /></td>
                </tr>
                <tr>
                  <td colspan="2">
                  </td>
                </tr>
                <tr>
                  <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Guardar" />
                  </td>
                </tr>
              </table>
            </asp:Panel>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="Label2" runat="server" ForeColor="Red" /></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
