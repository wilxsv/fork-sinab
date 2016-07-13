<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesAlmacenes.aspx.vb" Inherits="FrmReportesAlmacenes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="contentMenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Reportes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
        <asp:Panel ID="plListaReportes" runat="server" CssClass="listLinks"  GroupingText="Seleccione un reporte"
          Width="100%">
          
                <asp:LinkButton ID="LinkButton1" runat="server" Text="1 - Informes de no aceptación de recepción"
                  PostBackUrl="~/Reportes/FrmReporteInformesNoAceptacion.aspx" />
            
                <asp:LinkButton ID="LinkButton2" runat="server" Text="2 - Recibos de recepción" PostBackUrl="~/Reportes/FrmReporteRecibosRecepcion.aspx" />
            
                <asp:LinkButton ID="LinkButton3" runat="server" Text="3 - Actas de recepción" PostBackUrl="~/Reportes/FrmReporteActasRecepcion.aspx" />
            
                <asp:LinkButton ID="LinkButton4" runat="server" Text="4 - Programación de entregas a la fecha por documento"
                  PostBackUrl="~/ALMACEN/FrmProgramaEntregasalaFechaXDocumento.aspx" />
           
                <asp:LinkButton ID="LinkButton5" runat="server" Text="5 - Asignación de productos al almacén, por proceso de compra"
                  PostBackUrl="~/Reportes/FrmReporteCuadroDistribucion.aspx" />
           
                <asp:LinkButton ID="LinkButton7" runat="server" Text="7 - Ingresos generales, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteIngresosGenerales.aspx" />
           
                <asp:LinkButton ID="LinkButton8" runat="server" Text="8 - Existencias a la fecha, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualTipoProducto.aspx" />
           
                <asp:LinkButton ID="LinkButton9" runat="server" Text="9 - Existencias a la fecha, por producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualProducto.aspx" />
            
                <asp:LinkButton ID="LinkButton10" runat="server" Text="10 - Existencia a una fecha dada, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaHistoricaPorTipoProducto.aspx" />
            
                <asp:LinkButton ID="LinkButton11" runat="server" Text="11 - Existencias en almacenamiento temporal a la fecha, por producto"
                  PostBackUrl="" Visible="False" />
                <asp:LinkButton ID="LinkButton12" runat="server" Text="12 - Vales de salida" PostBackUrl="~/Reportes/FrmReporteValesSalida.aspx" />

                <asp:LinkButton ID="LinkButton13" runat="server" Text="13 - Despachos generales, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteDespachosGenerales.aspx" />

                <asp:LinkButton ID="LinkButton14" runat="server" Text="14 - Despachos mensuales, por tipo de producto y establecimiento"
                  PostBackUrl="~/Reportes/FrmReporteDespachosMensualesTipoProducto.aspx" />

                <asp:LinkButton ID="LinkButton15" runat="server" Text="15 - Despachos mensuales, por producto y establecimiento"
                  PostBackUrl="~/Reportes/FrmReporteDespachosMensualesProducto.aspx" />

                <asp:LinkButton ID="LinkButton16" runat="server" Text="16 - Movimientos de un producto (Kardex)"
                  PostBackUrl="~/Reportes/FrmReporteMovimientosKardex.aspx" />

                <asp:LinkButton ID="LinkButton17" runat="server" Text="17 - Existencias históricas, por producto"
                  Visible="False" PostBackUrl="~/Reportes/FrmReporteExistenciaHistoricaPorProducto.aspx" />

                <asp:LinkButton ID="LinkButton18" runat="server" Text="18 - Reporte de contabilidad"
                  PostBackUrl="~/Reportes/FrmReporteContabilidad.aspx" />

                <asp:LinkButton ID="LinkButton19" runat="server" Text="19 - Correcciones de existencias"
                  PostBackUrl="~/Reportes/FrmReporteCorreccionesExistencia.aspx" />

                <asp:LinkButton ID="LinkButton20" runat="server" Text="20 - Próximos a vencer, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteProximosAVencerAlmacen.aspx" />

                <asp:LinkButton ID="LinkButton21" runat="server" Text="21 - Vencidos, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteVencidosAlmacen.aspx" />

                <asp:LinkButton ID="LinkButton22" runat="server" Text="22 - Agotados, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteAgotadosAlmacen.aspx" />

                <asp:LinkButton ID="LinkButton6" runat="server" Text="23 - Requisición de suministros"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaAlmacenesHospitales.aspx" Visible="False" />

                <asp:LinkButton ID="LinkButton23" runat="server" Text="24 - Vencimientos en un período determinado"
                  PostBackUrl="~/Reportes/FrmReporteVencidosHistoricosPorTipoProducto.aspx" />
        </asp:Panel>
     
</asp:Content>
