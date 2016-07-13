<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantESTABLECIMIENTOS.ascx.vb"
  Inherits="ucMantESTABLECIMIENTOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaESTABLECIMIENTOS" Src="ucListaESTABLECIMIENTOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaESTABLECIMIENTOS ID="ucListaESTABLECIMIENTOS1" runat="server" />
    </td>
  </tr>
</table>
