<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantMENSAJES.ascx.vb"
  Inherits="ucMantMENSAJES" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaMENSAJES" Src="ucListaMENSAJES.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <uc1:ucListaMENSAJES ID="ucListaMENSAJES1" runat="server" />
    </td>
  </tr>
</table>
