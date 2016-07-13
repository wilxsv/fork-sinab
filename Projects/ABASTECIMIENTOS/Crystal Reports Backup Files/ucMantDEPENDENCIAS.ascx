<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantdEPENDENCIAS.ascx.vb"
  Inherits="ucMantdEPENDENCIAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaDEPENDENCIAS" Src="ucListaDEPENDENCIAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaDEPENDENCIAS ID="ucListaDEPENDENCIAS1" runat="server" />
    </td>
  </tr>
</table>
