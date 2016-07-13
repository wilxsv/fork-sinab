<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantdOCUMENTOSBASE.ascx.vb"
    Inherits="ucMantdOCUMENTOSBASE" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaDOCUMENTOSBASE" Src="~/catalogos/controles/ucListaDOCUMENTOSBASE.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaDOCUMENTOSBASE ID="ucListaDOCUMENTOSBASE1" runat="server" />
        </td>
    </tr>
</table>
