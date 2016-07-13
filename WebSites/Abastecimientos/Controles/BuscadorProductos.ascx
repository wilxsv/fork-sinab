<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscadorProductos.ascx.vb"
    Inherits="Controles_BuscadorProductos" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
    GridLines="None" CssClass="Grid" ShowFooter="true" DataKeyNames="RENGLON,IDPRODUCTO"
    Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:BoundField DataField="RENGLON" HeaderText="Renglón" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="DESCLARGO" HeaderText="Descripción" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100%" />
        <%--<asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Descripci&#243;n proveedor"
                HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />--%>
        <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
            HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="Precio uni." DataFormatString="{0:c4}"
            HtmlEncode="false" ItemStyle-HorizontalAlign="Right" HeaderStyle-Wrap="False" />
        <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False"
            ItemStyle-HorizontalAlign="Right" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="GridBorrar" ToolTip="Elimina el registro"
                    CommandName="Delete" CausesValidation="False" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<asp:MultiView runat="server" ID="mvMainProducto">
    <asp:View runat="server" ID="vAgregarProducto">
        <div style="margin: 10px 0">
            <asp:Button runat="server" ID="btnAgregarProducto" Text="Agregar Producto" />
        </div>
    </asp:View>
    <asp:View runat="server" ID="vFormProducto">
        <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Style="margin: 10px 0">
            <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0" Text="Búsqueda general" />
                <asp:ListItem Value="1" Text="Búsqueda por selección" />
            </asp:RadioButtonList>
            <asp:MultiView ID="mvProductos" runat="server">
                <asp:View ID="vCodigo" runat="server">
                    <div style="margin: 10px 0; padding: 0 10px 0 5px">
                        <asp:Label ID="LblCodigo" runat="server" Text="Producto: " AssociatedControlID="tbProductos" />
                        <asp:TextBox runat="server" ID="tbProductos" CssClass="autoProducto searchfield" Style="width: 100%;
                            min-width: 300px;" />
                        <asp:TextBox ID="lblDescripcionCompleta" runat="server" AutoPostBack="True" Style="visibility: hidden;
                            position: absolute; width: 0px;" />
                        <asp:HiddenField runat="server" ID="hfId" />
                    </div>
                </asp:View>
                <asp:View ID="vSeleccion" runat="server">
                    <table class="CenteredTable" style="width: 100%">
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label3" runat="server" Text="Suministro:" AssociatedControlID="ddlSUMINISTROS1" />
                            </td>
                            <td width="100%">
                                <asp:DropDownList runat="server" ID="ddlSUMINISTROS1" Width="450" AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="*"
                                    ControlToValidate="ddlSUMINISTROS1" Display="Dynamic" ValidationGroup="asp" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label5" runat="server" Text="Grupo:" AssociatedControlID="ddlGRUPOS1" />
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlGRUPOS1" Width="450" Enabled="False" AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlGRUPOS1"
                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label7" runat="server" Text="Subgrupo:" AssociatedControlID="ddlSUBGRUPOS1" />
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlSUBGRUPOS1" Width="450" Enabled="False" AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="ddlSUBGRUPOS1"
                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label8" runat="server" Text="Producto:" AssociatedControlID="DdlCATALOGOPRODUCTOS1" />
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlCATALOGOPRODUCTOS1" Width="450" Enabled="False"
                                    AutoPostBack="True" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="DdlCATALOGOPRODUCTOS1"
                                    Display="Dynamic" ErrorMessage="*" ValidationGroup="asp" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
        <asp:Panel ID="plProducto" runat="server" Visible="false" CssClass="formulario">
            <div class="formularioTitulo">
                <b>Detalle del Producto</b><br />
                <asp:Literal ID="lblDescripcionCompleta2" runat="server" />
            </div>
            <div class="formularioContenido">
                <asp:MultiView runat="server" ID="mvDetalleProducto">
                    <asp:View runat="server" ID="vDetalle">
                        <b>Datos del producto</b>
                        <table class="CenteredTable">
                            <tr>
                                <td class="LabelCell">
                                    Renglón:
                                </td>
                                <td style="width: 100%">
                                    <%--<ew:NumericBox ID="txtRenglon" runat="server" PositiveNumber="True" RealNumber="false"
                    Width="61px" MaxLength="4" />--%>
                                    <asp:TextBox runat="server" ID="txtRenglon" CssClass="numeric" />
                                    <asp:RequiredFieldValidator ID="rfvRenglon" runat="server" ControlToValidate="txtRenglon"
                                        ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Guardar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell" style="white-space: nowrap; vertical-align: top">
                                    <asp:Label runat="server" Text="Descripción según proveedor: " ID="lbl12" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                                        Height="80px" Width="100%" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Unidad de medida:
                                </td>
                                <td>
                                    <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Cantidad:
                                </td>
                                <td>
                                    <%--<ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="true" MaxLength="12"
                    TextAlign="Right" />--%>
                                    <asp:TextBox runat="server" ID="nbCantidad" MaxLength="12" />
                                    <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="nbCantidad"
                                        ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
                                         <asp:CompareValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                                        ErrorMessage="La cantidad debe ser mayor a cero." Display="Dynamic" Operator="GreaterThan"
                                        Type="Double" ValueToCompare="0" ValidationGroup="Guardar" />
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="LabelCell">
                                    Precio Unitario:
                                </td>
                                <td>
                                    <%--<ew:NumericBox ID="nbPrecioUnitario" runat="server" PositiveNumber="true" MaxLength="12"
                    TextAlign="Right" />--%>
                                    <asp:TextBox runat="server" ID="nbPrecioUnitario" CssClass="double" MaxLength="12" />
                                    <asp:RequiredFieldValidator ID="rfvPrecioUnitario" runat="server" ControlToValidate="nbPrecioUnitario"
                                        ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Número de entregas:
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="nbNumeroEntregas" MaxLength="2" CssClass="numeric" />
                                    <%--<ew:NumericBox ID="nbNumeroEntregas" runat="server" MaxLength="1" PositiveNumber="True"
                    Width="61px" RealNumber="false" TextAlign="Right" />--%>
                                    <asp:RequiredFieldValidator ID="rfvNumeroEntregas" runat="server" ControlToValidate="nbNumeroEntregas"
                                        ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
                                        <asp:CompareValidator ID="cvNumeroEntregas" runat="server" ControlToValidate="nbNumeroEntregas"
                                        ErrorMessage="Debe definir al menos una entrega." Display="Dynamic" Operator="GreaterThan"
                                        Type="Double" ValueToCompare="0" ValidationGroup="Guardar" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">Almacen de entrega: </td>
                                <td><asp:DropDownList runat="server" ID="ddlAlmacenesEntrega" Width="450px"/></td>
                            </tr>

                        </table>
                        <div style="margin-top: 10px">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar datos" ValidationGroup="Guardar" />
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="vEntregas">
                        <b>Definición de los plazos de entrega</b>
                        <asp:GridView ID="gvEntregas" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="IDDETALLE" HeaderText="Entrega" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Plazo (Días)" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtPlazo" runat="server" Text='<%#Eval("PLAZOENTREGA")%>' MaxLength="3"
                                            CssClass="numeric" TextAlign="Right" ValidationGroup="V1" />
                                        <asp:RequiredFieldValidator ID="rfvPlazo" runat="server" ControlToValidate="TxtPlazo"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="V1" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Porcentaje" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TxtPorcentaje" runat="server" Text='<%#Eval("PORCENTAJEENTREGA")%>'
                                            MaxLength="5" CssClass="double" ValidationGroup="V1" />
                                        <asp:RequiredFieldValidator ID="rfvPorcentaje" runat="server" ControlToValidate="TxtPorcentaje"
                                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="V1" />
                                        <asp:RangeValidator ID="rvPorcentaje" runat="server" ControlToValidate="TxtPorcentaje"
                                            ErrorMessage="*" MinimumValue="1" MaximumValue="100" SetFocusOnError="True" Type="Double"
                                            ValidationGroup="V1" Display="Dynamic" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Font-Bold="False" />
                        </asp:GridView>
                        <div style="margin-top: 10px">
                            <asp:Button ID="btnGuardarEntregas" runat="server" Text="Guardar entregas" ToolTip="Guarda la definción de las entregas para el renglón"
                                ValidationGroup="V1" />
                        </div>
                    </asp:View>
                </asp:MultiView>
            </div>
        </asp:Panel>
    </asp:View>
</asp:MultiView>
<script type="text/javascript">
    $(function () {
        $(".autoProducto").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "../ws/wsSINAB.asmx/ObtenerListaProductos",
                    data: "{'param':'" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                id: item.Id,
                                //label :
                                value: item.Descripcion
                            };
                        }));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            minLength: 2,
            select: function (event, ui) {
                $("#<%= hfId.ClientID%>").val(ui.item ? ui.item.id : "");
                if (ui.item) {
                    $("#<%=lblDescripcionCompleta.ClientID %>").val(ui.item.value);
                    __doPostBack('<%= lblDescripcionCompleta.ClientID  %>', "");
                }
            }
        });
    });
</script>
