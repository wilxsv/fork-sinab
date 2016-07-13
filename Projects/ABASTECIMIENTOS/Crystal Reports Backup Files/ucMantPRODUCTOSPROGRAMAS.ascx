<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantPRODUCTOSPROGRAMAS.ascx.vb"
    Inherits="ucMantPRODUCTOSPROGRAMAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaPRODUCTOSPROGRAMAS" Src="~/Catalogos/Controles/ucListaPRODUCTOSPROGRAMAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaPRODUCTOSPROGRAMAS ID="ucListaPRODUCTOSPROGRAMAS1" runat="server" />
        </td>
    </tr>
</table>
