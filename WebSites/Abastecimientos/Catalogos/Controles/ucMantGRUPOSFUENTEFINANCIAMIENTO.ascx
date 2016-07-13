<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantGRUPOSFUENTEFINANCIAMIENTO.ascx.vb"
  Inherits="ucMantGRUPOSFUENTEFINANCIAMIENTO" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaGRUPOSFUENTEFINANCIAMIENTO" Src="ucListaGRUPOSFUENTEFINANCIAMIENTO.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaGRUPOSFUENTEFINANCIAMIENTO ID="ucListaGRUPOSFUENTEFINANCIAMIENTO1" runat="server" />
    </td>
  </tr>
</table>
