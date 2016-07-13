<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmIniciarConsultaContrato.aspx.vb" Inherits="FrmIniciarConsultaContrato" %>

<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td>
                <uc1:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
