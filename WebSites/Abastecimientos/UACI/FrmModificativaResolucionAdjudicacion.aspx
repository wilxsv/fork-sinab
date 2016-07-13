<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmModificativaResolucionAdjudicacion.aspx.vb" Inherits="FrmGenerarResolucionAdjudicacion" MasterPageFile="~/MasterPage.master" EnableEventValidation="true" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucRenglonesProcesoCompra" Src="~/Controles/ucRenglonesProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucOfertasPorRenglonProcesoCompra" Src="~/Controles/ucOfertasPorRenglonProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucPlazosEntregaProcesoCompra" Src="~/Controles/ucPlazosEntregaProcesoCompra.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table>
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton id="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;&nbsp;<asp:Label id="LblRuta" runat="server" Text="UACI -> Generar resolución de adjudicación" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucRenglonesProcesoCompra ID="UcRenglonesProcesoCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucOfertasPorRenglonProcesoCompra ID="UcOfertasPorRenglonProcesoCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucPlazosEntregaProcesoCompra ID="UcPlazosEntregaProcesoCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
</asp:Content>
