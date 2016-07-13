<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSolicProcesCompra.ascx.vb"
  Inherits="Controles_ucVistaDetalleSolicProcesCompra" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td style="text-align: right;">
      <asp:Button ID="btnAnularProceso" runat="server" Text="Anular Proceso" Visible="False" />
      <asp:Button ID="btnQuitarSolicitud" runat="server" Text="Quitar solicitud del proceso"
        Visible="False" />
      <asp:Button ID="btnEliminaProceso" runat="server" Text="Eliminar proceso de compra"
        Visible="False" /></td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:DetailsView ID="dvProcesoCompra" runat="server" CssClass="Grid" AutoGenerateRows="False"
        CellPadding="4" GridLines="None" Visible="False">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListItem" />
        <FieldHeaderStyle CssClass="GridListHeader" />
        <Fields>
          <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Código" HeaderStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="FECHAFINEXAMEN" HeaderText="Fecha de finalización del examen preliminar"
            DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="FECHAFINRECOMENDACION" HeaderText="Fecha de finalización de la recomendación"
            DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="FECHAFIRMARESOLUCION" HeaderText="Fecha de firma de la resolución de adjudicación"
            DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="FECHAFIRMARESOLUCION" HeaderText="Fecha de elaboración de contratos"
            DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Left" />
        </Fields>
      </asp:DetailsView>
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Label ID="Label2" runat="server" Text="Solicitudes consolidadas en el proceso de compra seleccionado"
        Font-Bold="True" />
    </td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvSolicitudes" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        GridLines="None" DataKeyNames="IDESTABLECIMIENTO,IDSOLICITUD,IDCLASESUMINISTRO">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
          <asp:BoundField DataField="CORRELATIVO" HeaderText="Nro. de Solicitud" />
          <asp:BoundField DataField="DEPENDENCIASOLICITANTE" ItemStyle-HorizontalAlign="Left"
            HeaderText="Dependencia Solicitante" />
          <asp:BoundField DataField="CLASESUMINISTRO" ItemStyle-HorizontalAlign="Left" HeaderText="Clase de suministro" />
          <asp:TemplateField HeaderText="Fuente de Financiamiento">
            <ItemTemplate>
              <asp:GridView ID="gvFuentesFinanciamiento" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                GridLines="None" ShowHeader="false">
                <Columns>
                  <asp:BoundField DataField="NOMBRE" />
                </Columns>
              </asp:GridView>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="MONTOSOLICITADO" ItemStyle-HorizontalAlign="Right" HeaderText="Monto Solicitado"
            DataFormatString="{0:c}" HtmlEncode="False" />
          <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
          <asp:BoundField DataField="FECHASOLICITUD" HeaderText="Fecha" DataFormatString="{0:d}"
            HtmlEncode="False" />
        </Columns>
        <EmptyDataTemplate>
          No se encontraron solicitudes asociadas al proceso de compra. Debe eliminarlo o
          anularlo.</EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="pnlObservaciones" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Text="Observaciones:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right;">
              <asp:Button ID="btnQuitar" runat="server" Text="Quitar solicitud" />
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
