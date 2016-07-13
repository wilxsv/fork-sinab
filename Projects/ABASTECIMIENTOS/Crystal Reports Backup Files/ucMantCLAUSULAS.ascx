<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMantCLAUSULAS.ascx.vb"
    Inherits="ucMantCLAUSULAS" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucListaCLAUSULAS" Src="~/catalogos/controles/ucListaCLAUSULAS.ascx" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <uc1:ucListaCLAUSULAS ID="ucListaCLAUSULAS1" runat="server" />
        </td>
    </tr>
</table>
