<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmEntregaDiscoBase.aspx.vb" Inherits="FrmEntregaDiscoOferta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucVistaDetalleEntregaDiscosBase.ascx" TagName="ucVistaDetalleEntregaDiscosBase"
    TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucVistaDetalleRecibirOferta.ascx" TagName="ucVistaDetalleRecibirOferta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2" style="background-color: #b5c7de; text-align: left">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Bases -> Entrega de Discos (Base)" /></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    </table>
    <uc3:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
</asp:Content>
