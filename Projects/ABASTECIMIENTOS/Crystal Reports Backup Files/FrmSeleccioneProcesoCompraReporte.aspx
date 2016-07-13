<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="True" CodeFile="FrmSeleccioneProcesoCompraReporte.aspx.vb"
    Inherits="FrmSeleccioneProcesoCompraReporte" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleProcesoCompraRpt" Src="~/Controles/ucVistaDetalleProcesoCompraRpt.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta" style="height: 18px">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Reportes -> " />
            </td>
           </tr>
           <tr></tr>
        <tr>
            <td align="right">
              <asp:LinkButton ID="linkBtnSeguimiento" runat="server" BorderStyle="Double" ToolTip="Ver documentos PDF"
                Width="200px">Descargar PDF Seguimiento de Contratos</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetalleProcesoCompraRpt ID="UcVistaDetalleProcesoCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
