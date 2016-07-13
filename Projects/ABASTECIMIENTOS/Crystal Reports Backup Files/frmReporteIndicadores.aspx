<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporteIndicadores.aspx.vb" Inherits="Reportes_frmReporteIndicadores" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<center>
    <table border=0>
        <tr>
            <td colspan="2">
                <span style="font-size: 18pt; color: #3366ff">
                REPORTE DE INDICADORES</span></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Reportes/Visores/frmRptContratosAnioMes.aspx"
                    Width="144px">Indicador 1 y 2</asp:HyperLink></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Reportes/Visores/frmRptPedidoMedicamentoAnioMes.aspx"
                    Width="144px">Indicador 3</asp:HyperLink></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Reportes/Visores/frmRptIndicador4.aspx"
                    Width="144px">Indicador 4</asp:HyperLink></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 18px">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Reportes/Visores/frmRptIndicador5.aspx"
                    Width="144px">Indicador 5</asp:HyperLink></td>
            <td style="width: 100px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Reportes/Visores/frmRptIndicador6.aspx"
                    Width="144px">Indicador 6</asp:HyperLink></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    </center>
</asp:Content>

