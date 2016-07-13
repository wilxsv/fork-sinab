<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmDetaMantSolicitudCompra.aspx.vb" Inherits="FrmDetaMantSolicitudCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc3" Src="~/Controles/ucSolicitudCompra.ascx" TagName="ucSolicitudCompra" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucVistaDetalleSolicitudCompras.ascx"
  TagName="ucVistaDetalleSolicitudCompras" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        <asp:Label ID="lblRuta" runat="server" Text="Establecimientos -> Solicitud de compras" /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="LblDoc" runat="server" Visible="False" />
        <asp:Label ID="LblMonto" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="SOLICITUD DE COMPRA" />&nbsp;</td>
    </tr>
    <tr>
      <td>
        <uc3:ucSolicitudCompra ID="UcSolicitudCompra1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
