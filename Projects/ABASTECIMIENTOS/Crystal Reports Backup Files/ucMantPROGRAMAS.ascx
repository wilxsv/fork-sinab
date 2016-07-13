<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantPROGRAMAS.ascx.vb"
  Inherits="ucMantPROGRAMAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaPROGRAMAS" Src="ucListaPROGRAMAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaPROGRAMAS ID="ucListaPROGRAMAS1" runat="server" />
    </td>
  </tr>
</table>
