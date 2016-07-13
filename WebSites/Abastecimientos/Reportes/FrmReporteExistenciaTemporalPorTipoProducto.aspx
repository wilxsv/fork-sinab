<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="true" CodeFile="FrmReporteExistenciaTemporalPorTipoProducto.aspx.vb"
    Inherits="FrmReporteExistenciaTemporalPorTipoProducto" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table>
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="Almacenes -> Reportes -> Existencia temporal por tipo de producto" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
