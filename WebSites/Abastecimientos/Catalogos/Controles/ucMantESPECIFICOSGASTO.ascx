<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantESPECIFICOSGASTO.ascx.vb"
  Inherits="ucMantESPECIFICOSGASTO" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaESPECIFICOGASTO" Src="~/Catalogos/Controles/ucListaESPECIFICOGASTO.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaESPECIFICOGASTO ID="ucListaESPECIFICOGASTO1" runat="server" />
    </td>
  </tr>
</table>
