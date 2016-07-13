<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesAlmacenes1.aspx.vb" Inherits="FrmReportesAlmacenes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Reportes</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plListaReportes" runat="server" Font-Bold="True" GroupingText="Seleccione un reporte"
          Width="100%">
          <table class="CenteredTable" style="text-align: left; width: 100%;">
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton4" runat="server" Text="1 - Programación de entregas a la fecha por documento"
                  PostBackUrl="~/ALMACEN/FrmProgramaEntregasalaFechaXDocumento.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton5" runat="server" Text="2 - Cuadro de distribución, por proceso de compra"
                  PostBackUrl="~/Reportes/FrmReporteCuadroDistribucion.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton7" runat="server" Text="3 - Ingresos generales, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteIngresosGenerales.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton8" runat="server" Text="4 - Existencias a la fecha, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualTipoProducto.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton9" runat="server" Text="5 - Existencias a la fecha, por producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualProducto.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton20" runat="server" Text="6 - Próximos a vencer, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteProximosAVencerAlmacen.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton21" runat="server" Text="7 - Vencidos, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteVencidosAlmacen.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton15" runat="server" PostBackUrl="~/Reportes/FrmReporteDespachosMensualesProducto.aspx"
                  Text="8 - Despachos mensuales, por producto y establecimiento"></asp:LinkButton></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/Reportes/FrmReporteDespachosGenerales.aspx"
                  Text="9 - Despachos generales, por tipo de producto"></asp:LinkButton></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton14" runat="server" PostBackUrl="~/Reportes/FrmReporteDespachosMensualesTipoProducto.aspx"
                  Text="10 - Despachos mensuales, por tipo de producto y establecimiento"></asp:LinkButton></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton16" runat="server" Text="11 - Movimientos de un producto (Kardex)"
                  PostBackUrl="~/Reportes/FrmReporteMovimientosKardex.aspx" /></td>
            </tr>
            
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton17" runat="server" PostBackUrl="~/Reportes/FrmReporteAgotadosAlmacen.aspx" Text="12 - Agotados"/></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
