<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesAlmacenesGerencial.aspx.vb" Inherits="FrmReportesAlmacenesGerencial" %>

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
                </td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton8" runat="server" Text=" -->  Existencias a la fecha, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualTipoProductoTodos.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton9" runat="server" Text="--> Existencias a la fecha, por producto"
                  PostBackUrl="~/Reportes/FrmReporteExistenciaActualProductoTodos.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton20" runat="server" Text="--> Próximos a vencer, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteProximosAVencerAlmacenTodos.aspx" /></td>
            </tr>
            <tr>
              <td>
                <asp:LinkButton ID="LinkButton21" runat="server" Text="--> Vencidos, por tipo de producto"
                  PostBackUrl="~/Reportes/FrmReporteVencidosAlmacenTodos.aspx" /></td>
            </tr>
            <tr>
              <td>
                </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
