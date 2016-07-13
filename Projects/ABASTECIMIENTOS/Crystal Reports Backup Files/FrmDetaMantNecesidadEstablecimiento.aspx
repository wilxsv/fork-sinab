<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmDetaMantNecesidadEstablecimiento.aspx.vb"
  Inherits="FrmDetaMantNecesidadEstablecimiento" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucNecesidadesEstablecimientos.ascx" TagName="ucNecesidadesEstablecimientos"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucVistaDetalleNecesidadesEstablecimientos.ascx" TagName="ucVistaDetalleNecesidadesEstablecimientos"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td align="left" width="2%" bgcolor="#b5c7de">
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Programa de compras" /></td>
    </tr>
    <tr>
      <td style="width: 89%" align="left">
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td style="width: 89%" align="left">
        &nbsp;
        <asp:ImageButton ID="IbttObservaciones" runat="server" ImageUrl="~/Imagenes/Observaciones.gif" />
        <asp:Label ID="LblDoc" runat="server" Visible="False" />&nbsp;
        <asp:Label ID="LblPresupuesto" runat="server" Visible="False" />
        <asp:Label ID="LblMonto" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td width="2%">
        &nbsp;
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="CALCULO DE NECESIDADES" /></td>
    </tr>
    <tr>
      <td style="width: 89%">
        <uc3:ucNecesidadesEstablecimientos ID="UcNecesidadesEstablecimientos1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
