<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantGRUPOS.ascx.vb"
  Inherits="ucMantGRUPOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaGRUPOS" Src="~/Catalogos/Controles/ucListaGRUPOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td style="height: 65px">
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaGRUPOS ID="ucListaGRUPOS1" runat="server" />
    </td>
  </tr>
</table>
