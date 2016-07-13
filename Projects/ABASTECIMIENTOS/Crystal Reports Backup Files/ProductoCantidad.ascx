<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProductoCantidad.ascx.vb"
    Inherits="Controles_LotesDespacho_ProductoCantidad" %>
<div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix"
    style="padding: 6px;">
    <span class="ui-dialog-title">
        <asp:Literal ID="lblCorrProducto" runat="server" />
        <asp:Literal ID="lblDescripcion" runat="server" />
    </span>
    <br />
    <span class="ui-dialog-title">Cantidad requerida: <b>
        <asp:Literal runat="server" ID="lblreqqty" /></b> </span>
        <asp:HiddenField runat="server" ID="hdCantidad" ClientIDMode="Static"/>
</div>
<asp:GridView ID="gvLotes" CssClass="Grid detalles" runat="server" AutoGenerateColumns="false"
    CellPadding="4" GridLines="None" DataKeyNames="IDLOTE,CODIGO,IDPRODUCTO,CORRPRODUCTO,DESCLARGO,UNIDADMEDIDA"
    Width="100%">
    <HeaderStyle CssClass="GridListHeaderSmaller" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financiamiento">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad disponible" DataFormatString="{0:n2}"
            HtmlEncode="False">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
        <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio unitario" DataFormatString="{0:c4}"
            HtmlEncode="False">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n" />
        <asp:BoundField DataField="CODIGODETALLE" HeaderText="Lote">
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha Vto.">
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Cantidad a despachar">
            <ItemTemplate>
                <asp:TextBox ID="nbCantidad" CssClass="cantidades"  runat="server" DataFormatString="{0:n2}" /><br />
                <asp:RangeValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                    ValidationGroup="vLote" Display="Dynamic" ForeColor="#B20000" MaximumValue='<%# Eval("CANTIDAD") %>'
                    MinimumValue='<%#Math.Pow(10, -1 * Eval("CANTIDADDECIMAL"))%>'
                    Text="La cantidad debe ser mayor a cero y menor o igual a la disponible." Type="Double"
                    Font-Size="Smaller" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No hay lotes disponibles.</EmptyDataTemplate>
</asp:GridView>
<script type="text/javascript">
    $(".detalles").keyup(function () {
        var req = parseInt($("#hdCantidad").val());
        var sum = 0;
        $(".detalles input[type=text].cantidades").each(function () {
            var valor = $(this).val();
            if(valor != "") sum += parseInt(valor);
        });
        
        if (sum > req) {
            alert("Cantidad superior a la requerida: ("+req+")");
            $(".detalles input[type=text].cantidades").each(function () {
                $(this).val("");
            });
        }
    });
        

</script>