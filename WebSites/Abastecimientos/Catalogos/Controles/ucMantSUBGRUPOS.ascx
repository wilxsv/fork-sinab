<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantSUBGRUPOS.ascx.vb"
  Inherits="ucMantSUBGRUPOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaSUBGRUPOS" Src="ucListaSUBGRUPOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc2:ucListaSUBGRUPOS ID="ucListaSUBGRUPOS1" runat="server" />
    </td>
  </tr>
</table>
