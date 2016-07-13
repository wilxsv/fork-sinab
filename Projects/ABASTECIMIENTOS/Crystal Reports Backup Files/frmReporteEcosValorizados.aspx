<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporteEcosValorizados.aspx.vb" Inherits="ESTABLECIMIENTOS_frmReporteEcosValorizados" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Región -> Reporte de Consumos a ECOS valorizado</td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
  <tr>
    <td>
      Región:<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Selected="True" Value="1">Occidental</asp:ListItem>
        <asp:ListItem Value="2">Central</asp:ListItem>
        <asp:ListItem Value="3">Paracentral</asp:ListItem>
        <asp:ListItem Value="4">Oriental</asp:ListItem>
        <asp:ListItem Value="5">Metropolitana</asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td>
      Mes/Año:<asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem Selected="True" Value="1">Enero</asp:ListItem>
        <asp:ListItem Value="2">Febrero</asp:ListItem>
        <asp:ListItem Value="3">Marzo</asp:ListItem>
        <asp:ListItem Value="4">Abril</asp:ListItem>
        <asp:ListItem Value="5">Mayo</asp:ListItem>
        <asp:ListItem Value="6">Junio</asp:ListItem>
        <asp:ListItem Value="7">Julio</asp:ListItem>
        <asp:ListItem Value="8">Agosto</asp:ListItem>
        <asp:ListItem Value="9">Septiembre</asp:ListItem>
        <asp:ListItem Value="10">Octubre</asp:ListItem>
        <asp:ListItem Value="11">Noviembre</asp:ListItem>
        <asp:ListItem Value="12">Diciembre</asp:ListItem>
      </asp:DropDownList>
      /
      <asp:DropDownList ID="DropDownList3" runat="server">
        <asp:ListItem Selected="True">2010</asp:ListItem>
        <asp:ListItem>2011</asp:ListItem>
        <asp:ListItem>2012</asp:ListItem>
        <asp:ListItem>2013</asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td>
      <asp:Button ID="Button1" runat="server" Text="Ver reporte" /></td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
    </table>
</asp:Content>

