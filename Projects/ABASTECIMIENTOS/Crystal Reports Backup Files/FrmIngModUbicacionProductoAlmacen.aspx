<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmIngModUbicacionProductoAlmacen.aspx.vb" Inherits="FrmIngModUbicacionProductoAlmacen" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucIngModUbicacionProductoAlmacen" Src="~/Controles/ucIngModUbicacionProductoAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacenes -> Modificar ubicación de un producto</td>
    </tr>
    <tr>
      <td>
        <uc1:ucIngModUbicacionProductoAlmacen ID="ucIngModUbicacionProductoAlmacen1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
