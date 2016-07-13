<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" AutoEventWireup="false"
  CodeFile="FrmError.aspx.vb" Inherits="FrmError" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td>
        <asp:Image ID="ImgError" runat="server" ImageUrl="~/Imagenes/exclam.gif" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="LblError" runat="server" Text="Intenta hacer una operaci&oacuten no permitida" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:LinkButton ID="LnkbLoguin" runat="server" Text="Autenticarse en el sistema" /></td>
    </tr>
  </table>
</asp:Content>
