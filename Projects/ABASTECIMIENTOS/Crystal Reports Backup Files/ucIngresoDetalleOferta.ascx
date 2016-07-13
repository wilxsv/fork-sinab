<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucIngresoDetalleOferta.ascx.vb"
    Inherits="ucIngresoDetalleOferta" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Src="ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
    TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblWarning" runat="server" Font-Bold="True" ForeColor="Red" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="Panel3" runat="server" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label5" runat="server" Text="Listado de ofertas por orden de llegada"
                                Font-Bold="True" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:DataGrid ID="dgOfertaPresentada" runat="server" CellPadding="4" ForeColor="#333333"
                                GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                                Width="100%">
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#2461BF" />
                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle BackColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" />
                                    <asp:BoundColumn DataField="ORDENLLEGADA" ItemStyle-HorizontalAlign="Left" HeaderText="Orden" />
                                    <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Proveedor" />
                                    <asp:BoundColumn DataField="PERSONAENTREGA" ItemStyle-HorizontalAlign="Left" HeaderText="Persona entrega oferta" />
                                    <asp:BoundColumn DataField="FECHAENTREGA" ItemStyle-HorizontalAlign="Left" HeaderText="Hora de entrega" />
                                    <asp:BoundColumn DataField="IDPROVEEDOR" ItemStyle-HorizontalAlign="Left" Visible="False" />
                                </Columns>
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
                                <table class="CenteredTable" style="width: 100%">
                                    <tr>
                                        <td class="LabelClass">
                                            <asp:Label ID="Label6" runat="server" Text="Orden en que llegó la oferta:" /></td>
                                        <td class="DataCell">
                                            <asp:Label ID="lblOrden" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelClass">
                                            <asp:Label ID="Label7" runat="server" Text="Proveedor:" /></td>
                                        <td class="DataCell">
                                            <asp:DropDownList ID="ddlProveedorEntregaBase" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelClass">
                                            <asp:Label ID="Label8" runat="server" Text="Nombre de la persona que entrega la oferta:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtPersonaEntrega" runat="server" Width="353px" MaxLength="150" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPersonaEntrega"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label9" runat="server" Text="Hora de entrega:" /></td>
                                        <td class="DataCell">
                                            <ew:TimePicker ID="tpHoraEntrega" runat="server" MinuteInterval="FiveMinutes" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButtonList ID="rblCargaDisco" runat="server" AutoPostBack="True" Visible="False">
                                <asp:ListItem Value="S" Text="La informaci&#243;n se cargar&#225; del disco" />
                                <asp:ListItem Value="N" Text="El usuario no present&#243; el disco" />
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label40" runat="server" Text="A continuación debera cargar los archivos del disco proporcionado por el proveedor:"
                                Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label47" runat="server" Text="Archivos que deberá cargar: CDETOFERTA.DBF, CDETOFERTA.FPT, CFINAN.DBF"
                                Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label46" runat="server" Text="Lista de archivos que han sido cargados:"
                                Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="ListBox1" runat="server" Enabled="False" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload ID="MyFile" runat="server" Visible="false" />
                            <asp:Button ID="imbCargaDatos" runat="server" Text="Cargar archivos" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnLeerInformacion" runat="server" Text="Lectura de archivos" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Mensaje" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label48" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label49" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Button ID="LinkButton1" runat="server" Text="Datos Financieros" Visible="False"
                                CausesValidation="False" /></td>
                        <td class="DataCell">
                            <asp:Button ID="LinkButton2" runat="server" Text="Datos del Producto" Visible="False"
                                CausesValidation="False" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <uc2:ucBarraNavegacion ID="ucBarraNavegacion2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label13" runat="server" Text="Si el usuario no presenta el disco para cargar los datos, deberá ingresar los datos de la oferta"
                                Font-Bold="True" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="dgDetalleOferta" runat="server" CellPadding="4" GridLines="None"
                                Width="100%" AutoGenerateColumns="False" DataKeyNames="IDDETALLE,CORRELATIVORENGLON">
                                <HeaderStyle CssClass="GridListHeader" />
                                <FooterStyle CssClass="GridListFooter" />
                                <PagerStyle CssClass="GridListPager" />
                                <RowStyle CssClass="GridListItem" />
                                <EditRowStyle CssClass="GridListEditItem" />
                                <SelectedRowStyle CssClass="GridSelectedItem" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                <Columns>
                                    <asp:ButtonField CommandName="Select" Text="&gt;&gt;" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="MARCA" HeaderText="Marca" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Descripci&#243;n del Proveedor"
                                        ItemStyle-HorizontalAlign="Left" />
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
                            <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                                <table class="CenteredTable" style="width: 100%">
                                    <tr>
                                        <td colspan="2" style="text-align: left">
                                            <asp:ImageButton ID="imbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" />
                                            <asp:ImageButton ID="imbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg"
                                                CausesValidation="False" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label15" runat="server" Text="Número del proceso de compra:" /></td>
                                        <td class="DataCell">
                                            <asp:Label ID="lblProcesoCompra" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label14" runat="server" Text="Proveedor:" /></td>
                                        <td class="DataCell">
                                            <asp:Label ID="lblProveedor" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label16" runat="server" Text="Renglón:" /></td>
                                        <td class="DataCell">
                                            <asp:DropDownList ID="ddlRenglon" runat="server" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label17" runat="server" Text="Casa representada:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtCasaRepresentada" runat="server" Width="317px" MaxLength="75" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCasaRepresentada"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label19" runat="server" Text="Descripción:" /></td>
                                        <td class="DataCell">
                                            <asp:Label ID="lblDescripcionGenericaProducto" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label12" runat="server" Text="Descripción proporcionada por el proveedor:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtDescripcionProveedor" runat="server" Width="357px" Rows="5" TextMode="MultiLine" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcionProveedor"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label20" runat="server" Text="Marca:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtMarcaProductoOfertado" runat="server" Width="329px" MaxLength="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMarcaProductoOfertado"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label21" runat="server" Text="Origen:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtOrigen" runat="server" Width="323px" MaxLength="30" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOrigen"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label18" runat="server" Text="Vencimiento:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtVencimiento" runat="server" Width="237px" MaxLength="50" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVencimiento"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label22" runat="server" Text="Unidad de medida:" /></td>
                                        <td class="DataCell">
                                            <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Enabled="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label23" runat="server" Text="Cantidad:" /></td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtCantidad" runat="server" PositiveNumber="True" Width="107px"
                                                DecimalPlaces="2" MaxLength="15" TextAlign="Right" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label24" runat="server" Text="Precio unitario:" /></td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtPrecioUnitario" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
                                                Width="109px" DecimalPlaces="4" MaxLength="18" TextAlign="Right" />
                                            <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Calcular precio total" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrecioUnitario"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label25" runat="server" Text="Precio total (calculado):" /></td>
                                        <td class="DataCell">
                                            <ew:NumericBox ID="txtPrecioTotalCalculado" runat="server" ReadOnly="True" Width="125px"
                                                AutoFormatCurrency="True" DecimalPlaces="4" MaxLength="15" TextAlign="Right" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPrecioTotalCalculado"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label26" runat="server" Text="Plazo de entrega:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtPlazoEntrega" runat="server" Width="277px" MaxLength="100" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPlazoEntrega"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label27" runat="server" Text="Número CSSP (opcional):" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtCSSP" runat="server" Width="277px" MaxLength="20" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label28" runat="server" Text="Vigencia de la oferta:" /></td>
                                        <td class="DataCell">
                                            <asp:TextBox ID="txtVigenciaOferta" runat="server" Width="277px" MaxLength="100" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtVigenciaOferta"
                                                ErrorMessage="Requerido" /></td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            <asp:Label ID="Label29" runat="server" Text="Observaciones:" /></td>
                                        <td>
                                            <asp:TextBox ID="txtObservaciones" runat="server" Rows="5" TextMode="MultiLine" Width="429px" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="Panel5" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <uc2:ucBarraNavegacion ID="ucBarraNavegacion3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label30" runat="server" Text="Ingrese los Datos Financieros" Font-Bold="True" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label32" runat="server" Text="Número del proceso de compra:" /></td>
                        <td class="DataCell">
                            <asp:Label ID="lblNo" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label33" runat="server" Text="Proveedor:" /></td>
                        <td class="DataCell">
                            <asp:Label ID="lblNombreProveedor" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label31" runat="server" Text="Fecha:" /></td>
                        <td class="DataCell">
                            <asp:Label ID="lblFecha" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label11" runat="server" Text="Descripción del proceso de compra:" /></td>
                        <td class="DataCell">
                            <asp:Label ID="lblDescripcionProcesoCompra" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label37" runat="server" Text="Razón social:" /></td>
                        <td class="DataCell">
                            <asp:Label ID="lblRazonSocial" runat="server" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label34" runat="server" Text="Activo Circulante:" /></td>
                        <td class="DataCell">
                            <ew:NumericBox ID="txtActivoCirculante" runat="server" AutoFormatCurrency="True"
                                TextAlign="Right" DecimalPlaces="2" MaxLength="12">$0</ew:NumericBox>
                            <asp:Label ID="Label42" runat="server" ForeColor="Red" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label36" runat="server" Text="Pasivo Circulante:" /></td>
                        <td class="DataCell">
                            <ew:NumericBox ID="txtPasivoCirculante" runat="server" AutoFormatCurrency="True"
                                TextAlign="Right" DecimalPlaces="2" MaxLength="12">$0</ew:NumericBox>
                            <asp:Label ID="Label43" runat="server" ForeColor="Red" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label35" runat="server" Text="Activo total:" /></td>
                        <td class="DataCell">
                            <ew:NumericBox ID="txtActivoTotal" runat="server" AutoFormatCurrency="True" TextAlign="Right"
                                DecimalPlaces="2" PlacesBeforeDecimal="12">$0</ew:NumericBox>
                            <asp:Label ID="Label44" runat="server" ForeColor="Red" /></td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label38" runat="server" Text="Pasivo total:" /></td>
                        <td class="DataCell">
                            <ew:NumericBox ID="txtPasivoTotal" runat="server" AutoFormatCurrency="True" TextAlign="Right"
                                DecimalPlaces="2" PlacesBeforeDecimal="12">$0</ew:NumericBox>
                            <asp:Label ID="Label45" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="Label39" runat="server" Text="Referencias bancarias:" /></td>
                        <td class="DataCell">
                            <asp:RadioButtonList ID="rblReferenciaBancaria" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1" Text="Si" />
                                <asp:ListItem Value="0" Text="No" />
                            </asp:RadioButtonList></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblMsg" runat="server" />
        </td>
    </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
