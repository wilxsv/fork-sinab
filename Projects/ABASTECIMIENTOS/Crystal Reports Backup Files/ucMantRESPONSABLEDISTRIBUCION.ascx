<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantrESPONSABLEDIStrIBUCION.ascx.vb"
    Inherits="ucMantrESPONSABLEDIStrIBUCION" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaRESPONSABLEDISTRIBUCION" Src="ucListaRESPONSABLEDISTRIBUCION.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaRESPONSABLEDISTRIBUCION ID="ucListaRESPONSABLEDISTRIBUCION1" runat="server" />
        </td>
    </tr>
</table>
