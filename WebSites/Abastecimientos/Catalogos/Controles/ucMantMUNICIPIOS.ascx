<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantMUNICIPIOS.ascx.vb"
    Inherits="ucMantMUNICIPIOS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaMUNICIPIOS" Src="ucListaMUNICIPIOS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaMUNICIPIOS ID="ucListaMUNICIPIOS1" runat="server" />
        </td>
    </tr>
</table>
