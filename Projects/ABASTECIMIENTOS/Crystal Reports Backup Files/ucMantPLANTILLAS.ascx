<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantPLANTILLAS.ascx.vb"
    Inherits="ucMantPLANTILLAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaPLANTILLAS" Src="ucListaPLANTILLAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaPLANTILLAS ID="ucListaPLANTILLAS1" runat="server" />
        </td>
    </tr>
</table>
