<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmMantSolicitudProcesoCompra.aspx.vb" Inherits="FrmMantSolicitudProcesoCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Adjudicación -> Consulta de proceso de compra" /></td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
