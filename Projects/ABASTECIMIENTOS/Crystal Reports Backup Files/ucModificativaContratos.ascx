<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucModificativaContratos.ascx.vb" Inherits="Controles_ucModificativaContratos" %>
<%@ Register Src="ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Generar modificativa de contratos" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="Seleccione el proceso de compra con que desea trabajar" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <uc1:ucVistaDetalleListaProcesoCompra ID="UcVistaDetalleListaProcesoCompra1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
        </td>
        <td>
        </td>
    </tr>
</table>
