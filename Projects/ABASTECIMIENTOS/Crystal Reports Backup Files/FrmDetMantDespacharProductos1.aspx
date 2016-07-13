<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmDetMantDespacharProductos.aspx.vb" Inherits="FrmDetMantDespacharProductos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Despachar productos</td>
    </tr>
    <tr>
      <td>
        <asp:RadioButtonList ID="rbTipoDespacho" runat="server" AutoPostBack="True" BorderStyle="Double"
          CssClass="RadioButtonListLeftAligned" Visible="False">
          <asp:ListItem Value="1" Selected="True" Text="Despachar productos individualmente" />
          <asp:ListItem Value="2" Text="Despachar productos a partir del cuadro de distribuci&#243;n"
            Enabled="False" />
          <asp:ListItem Value="3" Text="Despachar productos a partir de una requisici&#243;n proveniente de otro almac&#233;n"
            Enabled="False" />
        </asp:RadioButtonList>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plEncabezado" runat="server" Width="100%" Visible="false" GroupingText=" ">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblSuministro" runat="server" Text="Suministro:" />
              </td>
              <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNroVale" runat="server" Text="Nro. de documento:" Visible="false" /></td>
              <td class="DataCell">
                <asp:Label ID="txtNroVale" runat="server" Visible="false" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblTipoDespachoIndividual" runat="server" Text="Tipo despacho:" /></td>
              <td class="DataCell">
                <cc1:ddlTIPOMOVIMIENTOS ID="ddlTIPOMOVIMIENTOS1" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblLugarDestino" runat="server" Text="Lugar destino:" /></td>
              <td class="DataCell">
                <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" AutoPostBack="True" />
                <asp:CheckBox ID="cbVerTodos" runat="server" AutoPostBack="true" Text="Ver todos" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblAlmacenDestino" runat="server" Text="Almacén destino:" /></td>
              <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" />
                <asp:Label ID="lblNoAlmacenAsociado" runat="server" Text="El lugar de destino no tiene ningún almacén asociado." /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha despacho:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaDespacho" runat="server" DisableTextBoxEntry="False" />
                <asp:RequiredFieldValidator ID="rfvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                  ErrorMessage="*" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                  ErrorMessage="La fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
                  Type="Date" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="100%" DataKeyNames="IDLOTE,IDDETALLEMOVIMIENTO,IDPRODUCTO,CANTIDAD"
          ShowFooter="true">
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
            <asp:TemplateField HeaderText="-Lote&lt;br /&gt; -Fecha vto.">
              <ItemTemplate>
                <%#Container.DataItem("CODIGODETALLE").ToString + "<br />" + Container.DataItem("FECHAVENCIMIENTOMMAAAA").ToString%>
              </ItemTemplate>
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financ." ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
            <asp:BoundField DataField="UBICACION" HeaderText="Ubicación" />
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio" DataFormatString="{0:c4}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False"
              ItemStyle-HorizontalAlign="Right" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" AlternateText="Elimina el registro"
                  CommandName="Delete" CausesValidation="False" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                  Visible='<%# Iif (Eval("IDESTADO") = 1, True, False) %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plAgregarProducto" runat="server" Width="100%" Visible="false" GroupingText=" ">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="0" Text="Búsqueda por código" />
                  <asp:ListItem Value="1" Text="Por selección" />
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnActivarFiltro" runat="server" CausesValidation="False" Text="Activar filtro para selección"
                  Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plFiltroSeleccion" runat="server" Width="100%" Visible="False">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        Tipo suministro:</td>
                      <td class="DataCell">
                        <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" Width="400px" AutoPostBack="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Grupo:</td>
                      <td class="DataCell">
                        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Width="400px" AutoPostBack="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Sub grupo:</td>
                      <td class="DataCell">
                        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" Width="400px" AutoPostBack="True" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Código:</td>
              <td class="DataCell">
                <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                  Visible="False" Width="400px" />
                <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Width="88px" />
                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                  ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Buscar" SetFocusOnError="True" />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="79px" ValidationGroup="Buscar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plBuscarDistribucion" runat="server" GroupingText="Buscar distribución"
          Width="100%" Visible="false">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Establecimiento:</td>
              <td class="DataCell">
                <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS2" runat="server" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fuente de financiamiento:</td>
              <td class="DataCell">
                <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnBuscarDistribucion" runat="server" Text="Busqueda" ToolTip="Permite buscar un cuadro de distribución." />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvProgramaDistribucion" runat="server" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Visible="false">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="Idproducto" ItemStyle-Width="5%" />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" ItemStyle-Width="5%" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" ItemStyle-Width="40%" />
            <asp:BoundField DataField="CANTIDADADJUDICADA" HeaderText="Cant. Asignada" ItemStyle-Width="5%" />
            <asp:BoundField DataField="CANTIDADENTREGADA" HeaderText="Cant. Entregada" ItemStyle-Width="5%" />
            <asp:BoundField DataField="CANTIDADPENDIENTE" HeaderText="Cant. Pendiente" ItemStyle-Width="5%" />
            <asp:BoundField DataField="CANTIDADDISPONIBLE" HeaderText="Cant. Disponible" ItemStyle-Width="5%" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Operaci&#243;n"
              ShowHeader="True" Text="Agregar" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plDatosProducto" runat="server" GroupingText="Datos del producto"
          Visible="false" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td style="text-align: left;">
                <asp:Label ID="lblCORRPRODUCTO" runat="server" Visible="False" />
                <asp:Label ID="lblDESCLARGO" runat="server" Visible="False" />
              </td>
            </tr>
            <tr>
              <td>
                <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="false" CellPadding="4"
                  GridLines="None" DataKeyNames="IDLOTE,CODIGO,IDPRODUCTO,CORRPRODUCTO,DESCLARGO"
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
                        <ew:NumericBox ID="nbCantidad" runat="server" DecimalPlaces='<%# Bind("CANTIDADDECIMAL") %>'
                          MaxLength="12" PositiveNumber="true" TextAlign="Right" /><br />
                        <asp:RangeValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                          Display="Dynamic" Font-Size="Smaller" MaximumValue='<%# Bind("CANTIDAD") %>' MinimumValue='<%#Math.Pow(10, -1 * Container.DataItem("CANTIDADDECIMAL"))%>'
                          Text="La cantidad debe ser mayor a cero y menor o igual a la disponible." Type="Double" />
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    No hay lotes disponibles.</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote(s)" ValidationGroup="GuardarLote" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plGenerales" runat="server" Width="100%" Visible="false" GroupingText=" ">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Preparó:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtEMPLEADOPREPARA" runat="server" MaxLength="75" Width="300px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nombre del transportista:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtTransportista" runat="server" MaxLength="75" Width="300px" />
                <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" ControlToValidate="txtTransportista"
                  ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Matricula del vehículo:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtMatricula" runat="server" MaxLength="10" Width="143px" />
                <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula"
                  ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Persona que recibe:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtRecibe" runat="server" MaxLength="75" Width="300px" />
                <asp:RequiredFieldValidator ID="rfvRecibe" runat="server" ControlToValidate="txtRecibe"
                  ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Documento de quien recibe:</td>
              <td class="DataCell">
                <cc1:ddlTIPOIDENTIFICACION ID="ddlTIPOIDENTIFICACION1" runat="server" />
                <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="15" Width="143px" />
                <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" ControlToValidate="txtNumeroDocumento"
                  ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Responsable almacén despacho:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtEmpleadoAlmacen" runat="server" MaxLength="150" Width="300px" />
                <asp:RequiredFieldValidator ID="rfvEmpleadoAlmacen" runat="server" ControlToValidate="txtEmpleadoAlmacen"
                  ErrorMessage="*" ValidationGroup="Cerrar" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtObservacion" runat="server" CssClass="TextBoxMultiLine" MaxLength="1000"
                  TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar despacho" />
                <asp:Button ID="btnCerrar" runat="server" Enabled="False" Text="Cerrar despacho"
                  ValidationGroup="Cerrar" />
                <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Vale Salida"
                  UseSubmitBehavior="False" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
