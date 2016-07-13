<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantEMPLEADOSALMACEN.ascx.vb"
  Inherits="ucMantEMPLEADOSALMACEN" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaEMPLEADOSALMACEN" Src="ucListaEMPLEADOSALMACEN.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaEMPLEADOSALMACEN ID="ucListaEMPLEADOSALMACEN1" runat="server" />
    </td>
  </tr>
</table>
