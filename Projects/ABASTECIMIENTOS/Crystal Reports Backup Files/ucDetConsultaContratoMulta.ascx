<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetConsultaContratoMulta.ascx.vb" Inherits="Catalogos_ucDetConsultaContratoMulta" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: left">
            </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Información del Contrato seleccionado" Font-Bold="True" /></td>
    </tr>
    <tr>
        <td style="width: 180px; text-align: right">
        </td>
        <td style="width: 380px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label2" runat="server" Text="Dependencia solicitante:" /></td>
        <td style="width: 380px; text-align: left; background-color: #f5f5f5;">
            <asp:Label ID="lblDependenciaSolicitante" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label3" runat="server" Text="Clase de suministro:" /></td>
        <td style="width: 380px; text-align: left; background-color: #f5f5f5;">
            <asp:Label ID="lblClaseSuministro" runat="server" /></td>
    </tr>
    <tr>
        <td style="width: 180px; text-align: right">
        </td>
        <td style="width: 380px">
           
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center; background-color: #e8f7ff;">
            <asp:Label ID="Label4" runat="server" Text="Fuente de financiamiento" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:DataGrid ID="dgFuenteFinanciamiento" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>&nbsp;</td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label5" runat="server" Text="Código de bases:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblCodigoBase" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label6" runat="server" Text="Fecha en que se dejo la resolución en firme o su modificativa:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblFechaResolucion" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label7" runat="server" Text="Fecha de distribución:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblFechaDistribucion" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label8" runat="server" Text="Número de contrato:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblNumeroContrato" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label9" runat="server" Text="Número de la oferta:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblNumeroOferta" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label10" runat="server" Text="Nombre del proveedor:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblNombreProveedor" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label11" runat="server" Text="Tipo de persona:" /></td>
        <td style="width: 380px; height: 21px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblTipoPersona" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right; background-color: #f5f5f5;">
            <asp:Label ID="Label12" runat="server" Text="Monto total:" /></td>
        <td style="width: 380px; background-color: #f5f5f5; text-align: left;">
            <asp:Label ID="lblMontoTotal" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: right">
            &nbsp; &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center; background-color: #e8f7ff;">
            <asp:Label ID="Label13" runat="server" Text="Garantías" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:DataGrid ID="dgGarantias" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            </asp:DataGrid>&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center; background-color: #e8f7ff;">
            &nbsp;<asp:Label ID="Label14" runat="server" Text="Listado de productos" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:DataGrid ID="dgProductos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Ver"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="RENGLON" HeaderText="N&#250;mero del rengl&#243;n"></asp:BoundColumn>
                    <asp:BoundColumn DataField="idproducto" HeaderText="C&#243;digo"></asp:BoundColumn>
                    <asp:BoundColumn DataField="nombre" HeaderText="Descripci&#243;n"></asp:BoundColumn>
                    <asp:BoundColumn DataField="cantidadfirme" HeaderText="Cantidad"></asp:BoundColumn>
                    <asp:BoundColumn DataField="preciounitario" HeaderText="Precio Unitario"></asp:BoundColumn>
                    <asp:BoundColumn DataField="monto" HeaderText="Monto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="descripcion" HeaderText="Unidad medida"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="background-color: #e8f7ff; text-align: center">
            <asp:Label ID="Label15" runat="server" Text="Detalle de Plazos, lugares y cantidad de entrega" Visible="False" /></td>
    </tr>
    <tr>
        <td colspan="2" style="background-color: #e8f7ff; text-align: center">
            <asp:Label ID="lblRenglon" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:DataGrid ID="dgDetalleProducto" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="IDENTREGA" HeaderText="Entrega"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Dias" HeaderText="Plazos (d&#237;as)"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Cantidad" HeaderText="Cantidad a entregar"></asp:BoundColumn><asp:BoundColumn DataField="descripcion" HeaderText="Unidad medida"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Almacen" HeaderText="Lugar de entrega"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
</table>
