<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMensajeError.aspx.vb" Inherits="frmMensajeError" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td style="text-align: center; width: 50%;">
        <asp:Image ID="ImgError" runat="server" ImageUrl="~/Imagenes/exclam.gif" />
      </td>
      <td valign="middle" style="font-weight: bold; font-size: 10pt; color: navy; font-family: Verdana;
        text-align: left; width: 50%;">
        Se ha generado una excepción no controlada del Sistema.
        <br />
        <br />
        Por favor notificarlo a la Unidad de Informática.
        <br />
        <br />
        Puede continuar utilizando el Sistema mediante las opciones de Menú.</td>
    </tr>
  </table>
</asp:Content>
