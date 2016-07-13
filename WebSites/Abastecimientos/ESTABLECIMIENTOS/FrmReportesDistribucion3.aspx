<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReportesDistribucion3.aspx.vb" Inherits="FrmReportesDistribucion3" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
          Distribución -> Reportes</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plListaReportes" runat="server" Font-Bold="True" GroupingText="Distribuciones - Detalle de fechas de ejecución"
          Width="100%">
          <table class="CenteredTable" style="text-align: left; width: 100%;">
              <tr>
                  <td class="LabelCell">Distribución:</td>
                  <td class="DataCell">
                      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
                  </td>
              </tr>
            <tr>
                 <td class="LabelCell"></td>
              <td class="DataCell">
                  <asp:Button ID="Button1" runat="server" Text="Ver reporte" />
                </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
