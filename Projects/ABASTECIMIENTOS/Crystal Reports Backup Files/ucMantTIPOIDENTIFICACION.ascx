<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantTIPOIDENTIFICACION.ascx.vb"
  Inherits="ucMantTIPOIDENTIFICACION" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaTIPOIDENTIFICACION" Src="ucListaTIPOIDENTIFICACION.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaTIPOIDENTIFICACION ID="ucListaTIPOIDENTIFICACION1" runat="server" />
    </td>
  </tr>
</table>
