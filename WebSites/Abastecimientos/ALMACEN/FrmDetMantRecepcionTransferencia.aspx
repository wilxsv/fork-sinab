<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantRecepcionTransferencia.aspx.vb"
  Inherits="FrmDetMantRecepcionTransferencia" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Recepción por transferencia
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plEncabezado" runat="server" GroupingText=" " Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Suministro:
              </td>
              <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNroRecibo" runat="server" Text="Nro. de documento:" Visible="false" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtNroRecibo" runat="server" Visible="false" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Recepción:
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaRecepcion" runat="server" Culture="Spanish (El Salvador)"
                  DisableTextBoxEntry="False" />
                <asp:RequiredFieldValidator ID="rfvFechaRecepcion" runat="server" ControlToValidate="cpFechaRecepcion"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvFechaRecepcion" runat="server" ControlToValidate="cpFechaRecepcion"
                  Display="Dynamic" Operator="LessThanEqual" Text="La fecha de recepción no puede ser posterior a hoy."
                  Type="Date" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Almacén de origen:
              </td>
              <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                N° Vale:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtVale" runat="server" Width="181px" MaxLength="20" />
                <asp:RequiredFieldValidator ID="rfvVale" runat="server" ControlToValidate="txtVale"
                  ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Continuar" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" ShowFooter="true" Width="100%" DataKeyNames="IDLOTE,IDDETALLEMOVIMIENTO,IDUBICACION,IDPRODUCTO">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="SECUENCIA" HeaderText="Sec." />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="-Lote&lt;br /&gt; -Fecha vto." HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left">
              <ItemTemplate>
                <%#Container.DataItem("CODIGODETALLE").ToString + "<br />" + Container.DataItem("FECHAVENCIMIENTOMMAAAA").ToString%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financ." ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio" DataFormatString="{0:c6}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False"
              ItemStyle-HorizontalAlign="Right" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                  Visible='<%#IIf(Eval("IDESTADO") = 1, True, False)%>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plBusquedaSeleccion" runat="server" GroupingText="Selección del producto"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Búsqueda:
              </td>
              <td class="DataCell">
                <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" BackColor="White"
                  RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Text="Por código" Value="0" />
                  <asp:ListItem Text="Por selección" Value="1" />
                </asp:RadioButtonList>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="PnlFiltroSeleccion" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td colspan="2">
                        <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
                          <table class="CenteredTable" style="width: 100%;">
                            <tr>
                              <td class="LabelCell">
                                Grupo:
                              </td>
                              <td class="DataCell">
                                <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
                              </td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                Sub grupo:
                              </td>
                              <td class="DataCell">
                                <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" />
                              </td>
                            </tr>
                            <tr>
                              <td class="LabelCell">
                                Producto:
                              </td>
                              <td class="DataCell">
                                <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                                  Width="400px" />
                              </td>
                            </tr>
                          </table>
                        </asp:Panel>
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblCodigo" runat="server" Text="Código:" />
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Width="88px" />
                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                          ErrorMessage="*" ValidationGroup="Buscar" />
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="Buscar" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plDetalle" runat="server" Visible="False" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td colspan="2" style="text-align: left;">
                        <asp:Label ID="lblCodigoProducto" runat="server" />
                        <asp:Label ID="lblDescripcionCompleta" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Lote:
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtLote" runat="server" MaxLength="15" />
                        <asp:RequiredFieldValidator ID="rfvLote" runat="server" ControlToValidate="txtLote"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
                        <asp:CheckBox ID="cbLoteNA" runat="server" Text="N/A" AutoPostBack="True" />
                        <asp:TextBox ID="txtDETALLE" runat="server" MaxLength="10" Width="50px" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Fecha de vencimiento (MM/aaaa):
                      </td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtFechaVto" runat="server" MaxLength="7" />
                        <asp:RequiredFieldValidator ID="rfvFechaVto" runat="server" ControlToValidate="txtFechaVto"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
                        <asp:CheckBox ID="cbFechaVtoNA" runat="server" Text="N/A" AutoPostBack="True" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:RegularExpressionValidator ID="revFechVto" runat="server" ControlToValidate="txtFechaVto"
                          ValidationExpression="(((0?[123456789]|10|11|12)([/])(([2][0][0-9][0-9]))))" ValidationGroup="AgregarLote"
                          Display="Dynamic" Text="Formato incorrecto.  Debe ser MM/aaaa." />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Unidad de medida:
                      </td>
                      <td class="DataCell">
                        <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Enabled="False" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Grupo fuente financiamiento:
                      </td>
                      <td class="DataCell">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">GOES</asp:ListItem>
                          <asp:ListItem Value="2">Otras Fuentes</asp:ListItem>
                        </asp:RadioButtonList>
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
              <td class="LabelCell" style="height: 26px">
                Cantidad:
              </td>
              <td class="DataCell" style="height: 26px">
                <ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="true" MaxLength="12"
                  TextAlign="Right" />
                  
                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="nbCantidad"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="AgregarLote" />
              </td>
            </tr>
              <tr>
              <td colspan="2" style="height: 18px">
                  <asp:RegularExpressionValidator ID="revCantidad" runat="server" 
                  ErrorMessage="Cantidad debe ser mayor a cero" ControlToValidate="nbCantidad" 
                  ValidationExpression="^\s*(?=.*[1-9])\d*(?:\.\d{1,2})?\s*$" ValidationGroup="AgregarLote" Display="Dynamic"/>
               <%-- <asp:CustomValidator ID="cvCantidad" runat="server" ErrorMessage="La cantidad debe ser mayor a cero."
                  Display="Dynamic" ValidationGroup="AgregarLote" ClientValidationFunction="validarCantidades"
                  ControlToValidate="nbCantidad" />--%>
              </td>
            </tr>
              <tr>
              <td class="LabelCell">Precio unitario:
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
                        Ubicación:
                      </td>
                      <td class="DataCell">
                        <asp:TextBox runat="server" ID="txtUbicacion" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote" ValidationGroup="AgregarLote" />
                      </td>
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
      <td>
        <asp:Panel ID="plGenerales" runat="server" GroupingText=" " Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                Guardalmacén:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtGuardalmacen" runat="server" MaxLength="70" />
                <asp:RequiredFieldValidator ID="rfvGuardalmacen" runat="server" ControlToValidate="txtGuardalmacen"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Cerrar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Entrega:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtDelegadoProveedor" runat="server" MaxLength="75" />
                <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" ControlToValidate="txtDelegadoProveedor"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar recepción" ValidationGroup="Guardar" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar recepción" ValidationGroup="Cerrar"
                  Enabled="False" />
                <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Recibo" UseSubmitBehavior="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
