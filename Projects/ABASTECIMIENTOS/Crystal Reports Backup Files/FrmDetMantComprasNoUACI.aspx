<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantComprasNoUACI.aspx.vb"
  Inherits="FrmDetMantComprasNoUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucDetFuenteFinanciamientoContratos.ascx"
  TagName="ucDetFuenteFinanciamientoContratos" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucDetResDistribucionContrato.ascx"
  TagName="ucDetResDistribucionContrato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Ingreso de documentos de compras y donaciones
      </td>
    </tr>
    <tr>
      <td style="text-align: left;" colspan="2">
        <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif"
          ToolTip="Actualiza la información del documento" />
        <asp:ImageButton ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Cerrar.gif"
          ToolTip="Permite cerrar un documento" />
        <asp:ImageButton ID="btnImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Almacén que recibe:
      </td>
      <td class="DataCell">
        <asp:Label ID="txtNombreAlmacen" runat="server" Font-Bold="True" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Documento:
      </td>
      <td class="DataCell">
        <cc1:ddlTIPODOCUMENTOCONTRATO ID="ddlTIPODOCUMENTOCONTRATO1" runat="server" />
        <asp:TextBox ID="txtDocumento" runat="server" Width="181px" MaxLength="20" />
        <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
          ErrorMessage="Requerido" SetFocusOnError="True" ValidationGroup="Continuar" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha del documento:
      </td>
      <td class="DataCell">
        <ew:CalendarPopup ID="cpFechaDocumento" runat="server" DisableTextBoxEntry="False"
          ShowClearDate="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:CompareValidator ID="cvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
          Display="Dynamic" ErrorMessage="La fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
          Type="Date" ValidationGroup="Continuar" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Proveedor:
      </td>
      <td class="DataCell">
        <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="400px" />
        <asp:Label ID="lblProveedor" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plDatosAdicionales" runat="server" GroupingText="Datos adicionales"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Modalidad de compra:
              </td>
              <td class="DataCell">
                <cc1:ddlMODALIDADESCOMPRA ID="ddlMODALIDADESCOMPRA1" runat="server" />
                <asp:TextBox ID="txtModalidad" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Resolución:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtResolucion" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Modificativa (contrato):
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtModificativa" runat="server" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnContinuar" runat="server" Text="Continuar >>" ValidationGroup="Continuar" />
      </td>
    </tr>
    <tr style="vertical-align: top;">
      <td style="width: 50%;">
        <asp:Panel ID="plFuentes" runat="server" Width="100%" GroupingText="Fuente de financiamiento">
          <uc1:ucDetFuenteFinanciamientoContratos ID="ucDetFuenteFinanciamientoContratos1"
            runat="server" />
        </asp:Panel>
      </td>
      <td>
        <asp:Panel ID="plResponsables" runat="server" GroupingText="Responsable de distribución"
          Width="100%">
          <uc2:ucDetResDistribucionContrato ID="ucDetResDistribucionContrato1" runat="server" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" ShowFooter="true" DataKeyNames="RENGLON,IDPRODUCTO" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Descripci&#243;n proveedor"
              HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
              HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="Precio uni." DataFormatString="{0:c4}"
              HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False"
              ItemStyle-HorizontalAlign="Right" />
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
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
        <asp:Panel ID="plFiltroSeleccion" GroupingText="Agregar producto" runat="server"
          Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Búsqueda:" />
              </td>
              <td class="DataCell">
                <asp:RadioButtonList ID="rbCriterio" runat="server" AutoPostBack="True" BackColor="White"
                  RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="0">Por c&#243;digo</asp:ListItem>
                  <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                </asp:RadioButtonList>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plSeleccionProducto" runat="server" Visible="False" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        Suministro:
                      </td>
                      <td class="DataCell">
                        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" Width="400px" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Grupo:
                      </td>
                      <td class="DataCell">
                        <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Sub grupo:
                      </td>
                      <td class="DataCell">
                        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
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
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblCodigo" runat="server" Text="Código" />
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Width="88px" />
                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="Buscar" />
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="Buscar" />
              </td>
            </tr>
            <tr>
              <td colspan="2" style="text-align: left;">
                <asp:Label ID="lblCodigoProducto" runat="server" />
                <asp:Label ID="lblDescripcionCompleta" runat="server" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="plDetalle" runat="server" GroupingText="Detalle del producto" Visible="false"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Renglón:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="txtRenglon" runat="server" PositiveNumber="True" RealNumber="false"
                  Width="61px" MaxLength="4" />
                <asp:RequiredFieldValidator ID="rfvRenglon" runat="server" ControlToValidate="txtRenglon"
                  ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Descripción según proveedor:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Unidad de medida:
              </td>
              <td class="DataCell">
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Width="200px" Enabled="False" />
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
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                  ErrorMessage="La cantidad debe ser mayor a cero." Display="Dynamic" Operator="GreaterThan"
                  Type="Double" ValueToCompare="0" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Precio Unitario:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbPrecioUnitario" runat="server" PositiveNumber="true" MaxLength="12"
                  TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvPrecioUnitario" runat="server" ControlToValidate="nbPrecioUnitario"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Número de entregas:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbNumeroEntregas" runat="server" MaxLength="1" PositiveNumber="True"
                  Width="61px" RealNumber="false" TextAlign="Right" />
                <asp:RequiredFieldValidator ID="rfvNumeroEntregas" runat="server" ControlToValidate="nbNumeroEntregas"
                  ErrorMessage="*" Display="Dynamic" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvNumeroEntregas" runat="server" ControlToValidate="nbNumeroEntregas"
                  ErrorMessage="Debe definir al menos una entrega." Display="Dynamic" Operator="GreaterThan"
                  Type="Double" ValueToCompare="0" ValidationGroup="Guardar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="PnlEntregasRenglon" runat="server" Width="100%" Visible="false" GroupingText="Definición de los plazos de entrega">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td>
                <asp:GridView ID="gvEntregas" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                  Width="100%">
                  <Columns>
                    <asp:BoundField DataField="IDDETALLE" HeaderText="Entrega" />
                    <asp:TemplateField HeaderText="Plazo (D&#237;as)" ItemStyle-HorizontalAlign="Right"
                      ItemStyle-Width="40%">
                      <ItemTemplate>
                        <ew:NumericBox ID="TxtPlazo" runat="server" Text='<%#container.dataitem("PLAZOENTREGA")%>'
                          MaxLength="3" PositiveNumber="True" RealNumber="false" TextAlign="Right" ValidationGroup="V1" />
                        <asp:RequiredFieldValidator ID="rfvPlazo" runat="server" ControlToValidate="TxtPlazo"
                          Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="V1" />
                      </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Porcentaje" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="40%">
                      <ItemTemplate>
                        <ew:NumericBox ID="TxtPorcentaje" runat="server" Text='<%#container.dataitem("PORCENTAJEENTREGA")%>'
                          MaxLength="5" PositiveNumber="True" TextAlign="Right" ValidationGroup="V1" />
                        <asp:RequiredFieldValidator ID="rfvPorcentaje" runat="server" ControlToValidate="TxtPorcentaje"
                          Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="V1" />
                        <asp:RangeValidator ID="rvPorcentaje" runat="server" ControlToValidate="TxtPorcentaje"
                          ErrorMessage="*" MinimumValue="1" MaximumValue="100" SetFocusOnError="True" Type="Double"
                          ValidationGroup="V1" />
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td>
                <asp:Button ID="btnGuardarEntregas" runat="server" Text="Guardar entregas" ToolTip="Guarda la definción de las entregas para el renglón"
                  ValidationGroup="V1" />
                  <br />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
