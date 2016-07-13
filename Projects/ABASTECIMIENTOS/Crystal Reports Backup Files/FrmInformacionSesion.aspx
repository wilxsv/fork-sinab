<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" AutoEventWireup="false"
  CodeFile="FrmInformacionSesion.aspx.vb" Inherits="FrmInformacionSesion" %>

<%@ MasterType VirtualPath="~/Mastersinmenu.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        C&oacutedigo Usuario:</td>
      <td class="DataCell">
        <asp:Label ID="lblCodigoUsuario" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Nombre Usuario:</td>
      <td class="DataCell">
        <asp:Label ID="lblNombreUsuario" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Rol Usuario:</td>
      <td class="DataCell">
        <asp:Label ID="lblRolUsuario" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Cargo Usuario:</td>
      <td class="DataCell">
        <asp:Label ID="lblCargo" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Zona:</td>
      <td class="DataCell">
        <asp:Label ID="lblZona" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Dependencia:</td>
      <td class="DataCell">
        <asp:Label ID="lblDependencia" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Establecimiento:</td>
      <td class="DataCell">
        <asp:Label ID="lblEstablecimientos" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Tipo Establecimiento:</td>
      <td class="DataCell">
        <asp:Label ID="lblTipoEstablecimiento" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Nivel:</td>
      <td class="DataCell">
        <asp:Label ID="lblNivel" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Almacén:</td>
      <td class="DataCell">
        <asp:Label ID="lblAlmacen" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        Suministro:</td>
      <td class="DataCell">
        <asp:Label ID="lblSuministro" runat="server" /></td>
    </tr>
  </table>
</asp:Content>
