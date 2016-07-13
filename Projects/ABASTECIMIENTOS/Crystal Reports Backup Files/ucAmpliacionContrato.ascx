<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAmpliacionContrato.ascx.vb" Inherits="Controles_ucAmpliacionContrato" %>
<%@ Register Src="ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Ampliación de Contra" /></td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <uc1:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra2" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            &nbsp;
        </td>
    </tr>
</table>
