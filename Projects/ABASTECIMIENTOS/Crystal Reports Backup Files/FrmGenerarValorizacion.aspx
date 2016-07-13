<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmGenerarValorizacion.aspx.vb" Inherits="FrmGenerarValorizacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Generar Valorización" EnableViewState="False" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.2" />
            </td>
        </tr>
    </table>
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnInformeEvaluacionPorRenglon" runat="server" Text="Generar Reporte por Renglón"
                    UseSubmitBehavior="False" Width="228px" CausesValidation="False" EnableViewState="False" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnInformeEvaluacionPorOferta" runat="server" Text="Generar Reporte por Ofertante"
                    UseSubmitBehavior="False" Width="228px" CausesValidation="False" EnableViewState="False" /></td>
        </tr>
    </table>
</asp:Content>
