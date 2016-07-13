<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPODOCUMENTORECEPCION.ascx.vb"
  Inherits="ucMantTIPODOCUMENTORECEPCION" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaTIPODOCUMENTORECEPCION" Src="~/Catalogos/Controles/ucListaTIPODOCUMENTORECEPCION.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaTIPODOCUMENTORECEPCION ID="ucListaTIPODOCUMENTORECEPCION1" runat="server" />
    </td>
  </tr>
</table>
