<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmDetaConsultaSolicitudUFI.aspx.vb" Inherits="FrmDetaConsultaSolicitudUFI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucSolicitudCompra.ascx" TagName="ucSolicitudCompra"
  TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucVistaDetalleSolicitudCompras.ascx" TagName="ucVistaDetalleSolicitudCompras"
  TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
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
      <td valign="top">
        <uc3:ucSolicitudCompra ID="UcSolicitudCompra1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
