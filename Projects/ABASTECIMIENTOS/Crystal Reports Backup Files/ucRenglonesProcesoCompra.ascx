<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucRenglonesProcesoCompra.ascx.vb"
  Inherits="ucRenglonesProcesoCompra" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td>
      <asp:Label ID="lblSeleccioneUnRenglon" runat="server" Font-Names="Verdana" Font-Size="X-Small"
        Text="Seleccione un renglón:" />
    </td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" AllowPaging="True" CellPadding="4" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPRODUCTO,IDDETALLE">
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
          <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" >
              <ItemStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" >
              <ItemStyle HorizontalAlign="Center" Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre" >
              <ItemStyle HorizontalAlign="Left" Width="40%" />
          </asp:BoundField>
          <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U. M." >
              <ItemStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="PRECIOACTUAL" HeaderText="Precio Unitario" DataFormatString="{0:c4}" HtmlEncode="False" >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="CANTIDADSOLICITADA" HeaderText="Cantidad"    >
              <ItemStyle HorizontalAlign="Right" Width="10%" />
          </asp:BoundField>
          <asp:BoundField DataField="NUMEROENTREGAS" HeaderText="Entregas" >
              <ItemStyle HorizontalAlign="Right" Width="5%" />
          </asp:BoundField>
          <asp:BoundField DataField="DESCRIPCION" HeaderText="Estado" >
              <ItemStyle Font-Bold="True" HorizontalAlign="Center" Width="10%" />
          </asp:BoundField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>
