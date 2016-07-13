<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesAlmacenesGerencial.aspx.vb" Inherits="FrmReportesAlmacenesGerencial" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Reportes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <h1>Seleccione un reporte</h1>
        <div style="padding: 10px; margin-bottom: 20px;">
          

                <asp:HyperLink ID="LinkButton8" runat="server" Text="»  Existencias a la fecha, por tipo de producto"
                                NavigateUrl="~/Reportes/FrmReporteExistenciaActualTipoProductoTodos.aspx" /><br /><br />
                <asp:HyperLink ID="LinkButton9" runat="server" Text="» Existencias a la fecha, por producto"
                  NavigateUrl="~/Reportes/FrmReporteExistenciaActualProductoTodos.aspx" /><br /><br />
                <asp:HyperLink ID="LinkButton20" runat="server" Text="» Próximos a vencer, por tipo de producto"
                  NavigateUrl="~/Reportes/FrmReporteProximosAVencerAlmacenTodos.aspx" /><br /><br />
                <asp:HyperLink ID="LinkButton21" runat="server" Text="» Vencidos, por tipo de producto"
                  NavigateUrl="~/Reportes/FrmReporteVencidosAlmacenTodos.aspx" />
           
        </div>
     
</asp:Content>
