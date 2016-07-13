<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmModificativaContrato.aspx.vb" Inherits="frmModificativaContrato" %>

<%@ Register Src="~/Controles/ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc2" %>

<%@ Register Src="~/Controles/ucModificativaContratos.ascx" TagName="ucModificativaContratos"
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
                <uc2:ucVistaDetalleListaProcesoCompra ID="UcVistaDetalleListaProcesoCompra1" runat="server" />
                me&nbsp;
                
            </td>
        </tr>
    </table>
</asp:Content>

