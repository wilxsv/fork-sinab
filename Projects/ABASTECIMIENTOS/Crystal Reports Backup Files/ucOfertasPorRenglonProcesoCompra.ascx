<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucOfertasPorRenglonProcesoCompra.ascx.vb"
  Inherits="ucOfertasPorRenglonProcesoCompra" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td>
      <asp:Button ID="btnNoAdjudicar" runat="server" Text="No adjudicar a ningún proveedor" /></td>
  </tr>
  <tr>
    <td>
      <asp:Label ID="lblSeleccioneUnProveedor" runat="server" Font-Names="Verdana" Font-Size="X-Small"
        Text="Seleccione un proveedor:" /></td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvOfertas" runat="server" CssClass="Grid" CellPadding="4"
        GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPROVEEDOR,IDDETALLE,RENGLON">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:TemplateField>
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;" />
            </ItemTemplate>
              <ItemStyle Width="5%" />
          </asp:TemplateField>
          <asp:BoundField HeaderText="Proveedor" DataField="PROVEEDOR" >
              <ItemStyle HorizontalAlign="Left" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Oferta" DataField="ORDENLLEGADA" >
              <ItemStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Alt." DataField="CORRELATIVORENGLON" >
              <ItemStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Descripci&#243;n" DataField="DESCRIPCIONPROVEEDOR" >
              <ItemStyle HorizontalAlign="Left" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Vencimiento" DataField="VENCIMIENTO" Visible="False" />
          <asp:BoundField HeaderText="U. M." DataField="UNIDADMEDIDA" >
              <ItemStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="CANTIDADDECIMALES" Visible="False" />
          <asp:BoundField HeaderText="Cantidad" DataField="CANTIDAD" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Precio unitario" DataField="PRECIOUNITARIO" DataFormatString="{0:c4}" HtmlEncode="False" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Monto" DataField="MONTO" Visible="False" />
          <asp:BoundField DataField="PLAZOENTREGA" Visible="False" />
          <asp:BoundField HeaderText="Calificaci&#243;n" DataField="CALIFICACION" >
              <ItemStyle Font-Bold="True" HorizontalAlign="Right" Width="5%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Cantidad recomendada" DataField="CANTIDADRECOMENDADA" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Cantidad adjudicada" DataField="CANTIDADADJUDICADA" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField HeaderText="Cantidad adjudicada en firme" DataField="CANTIDADENFIRME" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
          Desierto</EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
</table>
