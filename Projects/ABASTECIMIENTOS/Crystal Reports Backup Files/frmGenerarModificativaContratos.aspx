<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmGenerarModificativaContratos.aspx.vb" Inherits="frmGenerarModificativaContratos" %>

<%@ Register Src="~/Controles/ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="A continuación se presentan una serie de pasos para la generación de modificativa de contratos" /></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Selecciona proceso compra.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucVistaDetalleListaProcesoCompra ID="UcVistaDetalleListaProcesoCompra2" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
