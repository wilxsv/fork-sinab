<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucNecesidadesEstablecimientos.ascx.vb"
  Inherits="Controles_ucNecesidadesEstablecimientos" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="ucVistaDetalleNecesidadesEstablecimientos.ascx" TagName="ucVistaDetalleNecesidadesEstablecimientos"
  TagPrefix="uc1" %>
<%@ Register Src="ucDesgloceNecesidadesEstablecimientos.ascx" TagName="ucDesgloceNecesidadesEstablecimientos"
  TagPrefix="uc2" %>
<table width="100%">
  <tr>
    <td width="1%" align="left">
      <uc1:ucVistaDetalleNecesidadesEstablecimientos ID="UcVistaDetalleNecesidadesEstablecimientos1"
        runat="server" />
      &nbsp;
      <asp:ImageButton ID="BttCalcularNecesidades" runat="server" ImageUrl="~/Imagenes/botones/CalularNecesidad.gif"
        Visible="False" /></td>
  </tr>
  <tr>
    <td align="left" width="1%">
      &nbsp;<asp:ImageButton ID="BttProductos" runat="server" ImageUrl="~/Imagenes/botones/AgregarPPC.gif" /></td>
  </tr>
  <tr>
    <td align="center" valign="top">
      <uc2:ucDesgloceNecesidadesEstablecimientos ID="UcDesgloceNecesidadesEstablecimientos1"
        runat="server"></uc2:ucDesgloceNecesidadesEstablecimientos>
    </td>
  </tr>
  <tr>
    <td align="center" width="100%" valign="top">
      &nbsp;<asp:Label ID="lblsuministro" runat="server" Visible="False" />
      &nbsp;<asp:Label ID="lblID" runat="server" />
      <asp:Label ID="LblMontoReal" runat="server" Visible="False" />
      <asp:Label ID="LblMontoAjustado" runat="server" Visible="False" />
      <asp:Label ID="lblidestado" runat="server" /></td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
