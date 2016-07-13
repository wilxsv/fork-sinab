<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantFUENTEFINANCIAMIENTOS.ascx.vb"
  Inherits="ucMantFUENTEFINANCIAMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaFUENTEFINANCIAMIENTOS" Src="ucListaFUENTEFINANCIAMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaFUENTEFINANCIAMIENTOS ID="ucListaFUENTEFINANCIAMIENTOS1" runat="server" />
    </td>
  </tr>
</table>
