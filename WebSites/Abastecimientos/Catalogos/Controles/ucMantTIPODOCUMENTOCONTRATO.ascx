<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPODOCUMENTOCONTRATO.ascx.vb"
  Inherits="ucMantTIPODOCUMENTOCONTRATO" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaTIPODOCUMENTOCONTRATO" Src="~/Catalogos/Controles/ucListaTIPODOCUMENTOCONTRATO.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaTIPODOCUMENTOCONTRATO ID="ucListaTIPODOCUMENTOCONTRATO1" runat="server" />
    </td>
  </tr>
</table>
