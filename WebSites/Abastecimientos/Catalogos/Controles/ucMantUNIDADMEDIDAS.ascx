<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantUNIDADMEDIDAS.ascx.vb"
  Inherits="ucMantUNIDADMEDIDAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaUNIDADMEDIDAS" Src="~/Catalogos/Controles/ucListaUNIDADMEDIDAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaUNIDADMEDIDAS ID="ucListaUNIDADMEDIDAS1" runat="server" />
    </td>
  </tr>
</table>
