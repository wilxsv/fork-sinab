<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmDetaMantConsumos.aspx.vb" Inherits="FrmDetaMantConsumos" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucVistaDetalleConsumo.ascx" TagName="ucVistaDetalleConsumo"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucConsumo.ascx" TagName="ucConsumo" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td align="left" width="2%" bgcolor="#b5c7de">
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Ingreso Consumos" /></td>
    </tr>
    <tr>
      <td width="5%">
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td width="2%">
        <asp:Label ID="LblDoc" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td width="2%">
        &nbsp;<asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="INGRESO DE CONSUMO, EXISTENCIA Y DEMANDA INSATISFECHA" /></td>
    </tr>
    <tr>
      <td width="90%">
        <uc3:ucConsumo ID="UcConsumo1" runat="server"></uc3:ucConsumo>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
