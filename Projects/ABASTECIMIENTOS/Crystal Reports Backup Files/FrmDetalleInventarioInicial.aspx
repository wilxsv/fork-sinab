<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetalleInventarioInicial.aspx.vb"
  Inherits="FrmDetalleInventarioInicial" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -&gt; Captura de Inventario Inicial
      </td>
    </tr>
    <tr>
      <td colspan="2" style="text-align: left;">
        <asp:ImageButton ID="ibConvertirInventario" runat="server" ImageUrl="~/Imagenes/botones/convertirInv.jpg" />
        <asp:ImageButton ID="ibImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Almacén:
      </td>
      <td class="DataCell">
        <asp:Label ID="txtNombreAlmacen" runat="server" Font-Bold="True" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Clase de Suministro:
      </td>
      <td class="DataCell">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha del inventario:
      </td>
      <td class="DataCell">
        <ew:CalendarPopup ID="cpFechaInventario" runat="server" DisableTextBoxEntry="False"
          ShowClearDate="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:CompareValidator ID="cvFechaInventario" runat="server" ControlToValidate="cpFechaInventario"
          Display="Dynamic" ErrorMessage="La fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
          Type="Date" ValidationGroup="Continuar" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnGuardarInventario" runat="server" Text="Guardar inventario" ValidationGroup="GuardarInventario" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvDetalleInventario" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" DataKeyNames="IDALMACEN,IDINVENTARIO,IDLOTE,IDPRODUCTO,IDUNIDADMEDIDA,CODIGO,FECHAVENCIMIENTO,FECHAVENCIMIENTOMMAAAA,IDFUENTEFINANCIAMIENTO,IDGRUPOFUENTEFINANCIAMIENTO,IDRESPONSABLEDISTRIBUCION,DETALLE,CANTIDADDECIMAL"
          GridLines="None" PageSize="15" ShowFooter="true" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="lbSeleccionar" runat="server" CommandName="Select" Text=">>" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
              <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
              <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDADDISPONIBLE" HeaderText="Cantidad disponible" DataFormatString="{0:n2}"
              HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDADNODISPONIBLE" HeaderText="Cantidad no disponible"
              DataFormatString="{0:n2}" HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDADVENCIDA" HeaderText="Cantidad vencida" DataFormatString="{0:n2}"
              HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio" DataFormatString="{0:c4}"
              HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="-Lote&lt;br /&gt; -Fecha vto.">
              <ItemTemplate>
                <%#Container.DataItem("CODIGODETALLE").ToString + "<br />" + Container.DataItem("FECHAVENCIMIENTOMMAAAA").ToString%>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
              <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField DataField="NOMBREFUENTEFINANCIAMIENTO" HeaderText="Fuente financiamiento">
              <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="lbEliminar" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="return window.confirm('¿Confirma que desea eliminar el registro?');" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plProductos" GroupingText="Buscar producto" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:Panel ID="plBusquedaProducto" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        Búsqueda por código o nombre:
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtProducto" runat="server" Width="250px" />
                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Buscar" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="Buscar" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Panel ID="plSeleccionProducto" runat="server" CssClass="ScrollPanel" Width="100%">
                  <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="Grid" DataKeyNames="IDPRODUCTO,IDUNIDADMEDIDA,CANTIDADDECIMAL" EmptyDataText="No se han encontrado productos que coincidan con el criterio de búsqueda especificado."
                    GridLines="None" Width="95%">
                    <HeaderStyle CssClass="GridListHeaderSmaller" />
                    <FooterStyle CssClass="GridListFooterSmaller" />
                    <PagerStyle CssClass="GridListPagerSmaller" />
                    <RowStyle CssClass="GridListItemSmaller" />
                    <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                    <EditRowStyle CssClass="GridListEditItemSmaller" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                    <Columns>
                      <asp:TemplateField>
                        <ItemTemplate>
                          <asp:LinkButton ID="lbSeleccionarProducto" runat="server" CommandName="Select" Text="&gt;&gt;" />
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="DESCGRUPO" HeaderText="Grupo">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="DESCSUBGRUPO" HeaderText="Subgrupo">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="DESCLARGO" HeaderText="Producto">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                    </Columns>
                  </asp:GridView>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plDetalle" runat="server" GroupingText="Detalle" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Lote:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtLote" runat="server" MaxLength="15" />
                <asp:RequiredFieldValidator ID="rfvLote" runat="server" ControlToValidate="txtLote"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="GuardarLote" />
                <asp:CheckBox ID="cbLoteNA" runat="server" AutoPostBack="True" Text="N/A" />
                <asp:TextBox ID="txtDetalle" runat="server" MaxLength="10" Width="50px" ToolTip="Texto adicional que ayuda a identificar el lote." />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de vencimiento (MM/aaaa):
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtFechaVto" runat="server" MaxLength="7" />
                <asp:RequiredFieldValidator ID="rfvFechaVto" runat="server" ControlToValidate="txtFechaVto"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="GuardarLote" />
                <asp:CheckBox ID="cbFechaVtoNA" runat="server" AutoPostBack="True" Text="N/A" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RegularExpressionValidator ID="revFechVto" runat="server" ControlToValidate="txtFechaVto"
                  Display="Dynamic" ErrorMessage="Formato incorrecto.  Debe ser MM/aaaa." ValidationExpression="(0[123456789]|10|11|12)(/)((19|20)[0-9][0-9])"
                  ValidationGroup="GuardarLote" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="true" MaxLength="12"
                  TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="nbCantidad"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="GuardarLote" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad no disponible (averiada):
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCantidad1" runat="server" MaxLength="12" PositiveNumber="true"
                  TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvCantidad1" runat="server" ControlToValidate="nbCantidad1"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="GuardarLote" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CustomValidator ID="cvCantidad" runat="server" ErrorMessage="La cantidad debe ser mayor a cero."
                  Display="Dynamic" ValidationGroup="GuardarLote" ClientValidationFunction="validarCantidades"
                  ControlToValidate="nbCantidad" />
                <asp:CustomValidator ID="cvCantidad1" runat="server" ErrorMessage="La cantidad debe ser mayor a cero."
                  Display="Dynamic" ValidationGroup="GuardarLote" ClientValidationFunction="validarCantidades"
                  ControlToValidate="nbCantidad1" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Precio unitario:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbPrecioUnitario" runat="server" PositiveNumber="true" MaxLength="12"
                  TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvPrecioUnitario" runat="server" ControlToValidate="nbPrecioUnitario"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="GuardarLote" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fuente de financiamiento:
              </td>
              <td class="DataCell">
                <cc1:ddlGRUPOSFUENTEFINANCIAMIENTO ID="ddlGRUPOSFUENTEFINANCIAMIENTO1" runat="server"
                  AutoPostBack="True" />
                <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Responsable de distribución:
              </td>
              <td class="DataCell">
                <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Ubicación:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtUbicacion" runat="server" MaxLength="150" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="GuardarLote" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
