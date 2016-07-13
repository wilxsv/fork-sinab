<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantSUMINISTRODEPENDENCIAS.ascx.vb"
  Inherits="ucMantSUMINISTRODEPENDENCIAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaSUMINISTRODEPENDENCIAS" Src="ucListaSUMINISTRODEPENDENCIAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaSUMINISTRODEPENDENCIAS ID="ucListaSUMINISTRODEPENDENCIAS1" runat="server" />
    </td>
  </tr>
</table>
