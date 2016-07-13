<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSeleccionDocumentoRecepcionTransferencia.ascx.vb"
  Inherits="ucSeleccionDocumentoRecepcionTransferencia" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:Panel ID="plAlmacen" runat="server" GroupingText="SubAlmacén:" Width="100%">
        <cc1:ddlALMACENESESTABLECIMIENTOS ID="ddlALMACENESESTABLECIMIENTOS1" runat="server"
          AutoPostBack="True" />
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="plSeleccionarDocumento" runat="server" GroupingText="Documentos pendientes:"
        CssClass="ScrollPanel" Height="360px">
        <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4"
          DataKeyNames="IDALMACEN,ANIO,IDRECIBO,IDDOCUMENTO,IDMOVIMIENTO" GridLines="None"
          Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:HyperLinkField HeaderText="No. Documento" DataNavigateUrlFormatString="~/ALMACEN/FrmDetMantRecepcionTransferencia.aspx?IdM={0}&IdA={1}"
              DataNavigateUrlFields="IDMOVIMIENTO,IDALMACEN" DataTextField="NUMERORECIBO" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" Visible="False" />
          </Columns>
          <EmptyDataTemplate>
            No se encontro ningún documento para este almacén.</EmptyDataTemplate>
        </asp:GridView>
      </asp:Panel>
    </td>
  </tr>
</table>
