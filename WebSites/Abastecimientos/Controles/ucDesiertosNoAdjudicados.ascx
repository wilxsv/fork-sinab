<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDesiertosNoAdjudicados.ascx.vb"
  Inherits="ucDesiertosNoAdjudicados" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione el proceso de compra del siguiente listado:" /></td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvProcesosCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        CellPadding="4" GridLines="None" Width="726px" AllowPaging="True" DataKeyNames="IDTIPOCOMPRAEJECUTAR">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:CommandField InsertVisible="False" SelectImageUrl="~/Imagenes/botones/flecha.jpg"
            ShowHeader="True" ShowSelectButton="True" SelectText="Seleccionar" />
          <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo de Licitaci&#243;n">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="LUGARRETIROBASE" HeaderText="Lugar de Retiro">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="FECHAPUBLICACION" HeaderText="Fecha de publicaci&#243;n"
            DataFormatString="{0:d}" HtmlEncode="False">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Comentario / Observaciones">
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:TemplateField HeaderText="Estado">
            <ItemTemplate>
              <%#IIf(Eval("IDESTADOPROCESOCOMPRA") = 1, "Proceso de Iniciado", IIf(Eval("IDESTADOPROCESOCOMPRA") = 2, "Base Generada", IIf(Eval("IDESTADOPROCESOCOMPRA") = 3, "Base Publicada", IIf(Eval("IDESTADOPROCESOCOMPRA") = 4, "Apertura de Oferta", IIf(Eval("IDESTADOPROCESOCOMPRA") = 5, "Consolidación de Oferta", IIf(Eval("IDESTADOPROCESOCOMPRA") = 6, "Examen preliminar", IIf(Eval("IDESTADOPROCESOCOMPRA") = 7, "Examen preliminar finalizado", IIf(Eval("IDESTADOPROCESOCOMPRA") = 8, "Comisión Ingresada", IIf(Eval("IDESTADOPROCESOCOMPRA") = 9, "Generar Recomendación", IIf(Eval("IDESTADOPROCESOCOMPRA") = 10, "Recurso de Revisión", IIf(Eval("IDESTADOPROCESOCOMPRA") = 11, "Anulado", IIf(Eval("IDESTADOPROCESOCOMPRA") = 12, "Resolución Adjudicación", IIf(Eval("IDESTADOPROCESOCOMPRA") = 13, "Comisión Alto Nivel", IIf(Eval("IDESTADOPROCESOCOMPRA") = 14, "Adjudicada", IIf(Eval("IDESTADOPROCESOCOMPRA") = 15, "Generar Contrato", IIf(Eval("IDESTADOPROCESOCOMPRA") = 16, "Distribución Contrato", "Contrato Distribuido"))))))))))))))))%>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
          No hay procesos de compra en el estado seleccionado.
        </EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
</table>
