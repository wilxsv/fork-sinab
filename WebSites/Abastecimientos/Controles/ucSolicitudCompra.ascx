<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSolicitudCompra.ascx.vb"
  Inherits="Controles_ucSolicitudCompra" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="ucDetalleFuenteFinanciamientoSolicitud.ascx" TagName="ucDetalleFuenteFinanciamientoSolicitud"
  TagPrefix="uc3" %>
<%@ Register Src="ucVistaDetalleSolicitudCompras.ascx" TagName="ucVistaDetalleSolicitudCompras"
  TagPrefix="uc1" %>
<%@ Register Src="ucDesgloceArticulosSolicituCompra.ascx" TagName="ucDesgloceArticulosSolicituCompra"
  TagPrefix="uc2" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td align="left">
      <uc1:ucVistaDetalleSolicitudCompras ID="UcVistaDetalleSolicitudCompras1" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:ImageButton ID="BttFuente" runat="server" ImageUrl="~/Imagenes/botones/AgregarFFS.gif"
        Visible="False" /></td>
  </tr>
  <tr>
    <td>
      <uc3:ucDetalleFuenteFinanciamientoSolicitud ID="UcDetalleFuenteFinanciamientoSolicitud1"
        runat="server" />
    </td>
  </tr>
  <tr>
    <td bgcolor="#b5c7de">
      <asp:Label ID="Label1" runat="server" Text="Desglose de productos" /></td>
  </tr>
  <tr>
    <td align="left">
      <asp:ImageButton ID="BttProductos" runat="server" ImageUrl="~/Imagenes/AgregarPS.gif"
        Visible="False" /></td>
  </tr>
  <tr>
    <td align="left">
      <uc2:ucDesgloceArticulosSolicituCompra ID="UcDesgloceArticulosSolicituCompra1" runat="server" />
    </td>
  </tr>
  <tr>
    <td align="left">
      <asp:Label ID="LblMonto" runat="server" Visible="False" />
      <asp:Label ID="Label_CODIGOENCABEZADODOCUMENTO" runat="server" Visible="False" />
      <asp:Label ID="lblSuministro" runat="server" Visible="False" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
