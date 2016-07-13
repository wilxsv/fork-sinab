<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantRecibirProductos.aspx.vb"
  Inherits="FrmDetMantRecibirProductos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menucontent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Recepción
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
   <h3>
        RRecepcion de Producto</h3>
        <asp:Panel ID="plEncabezado" runat="server" >
          <table class="CenteredTable" >
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
          </table>
        </asp:Panel>
     
        <asp:Panel ID="plModalidadCompra" runat="server" >
            <hr />
        <h3>
            Detalle de contrato</h3>
          <table cellpadding="4" cellspacing="0" style="margin-bottom: 10px;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblModalidadCompra" runat="server" Text="Modalidad de Compra:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtModalidadCompra" runat="server" />
                <asp:Label ID="txtNoModalidadCompra" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFuenteFinanciamiento" runat="server" Text="Fuentes de Financiamiento:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtFuenteFinanciamiento" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblResponsableDistribucion" runat="server" Text="Responsable de Distribución:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtResponsableDistribucion" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblResolucionAdjudicacion" runat="server" Text="Resolución de Adjudicación:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtResolucionAdjudicacion" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNoContratoOrdenCompra" runat="server" Text="No. de Contrato/Orden de Compra:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtNoContratoOrdenCompra" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtProveedor" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblFechaDistribucion" runat="server" Text="Fecha de Distribución:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtFechaDistribucion" runat="server" />
              </td>
            </tr>
            </table>
                <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
                  AutoGenerateColumns="False" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDALMACENENTREGA,RENGLON,IDPRODUCTO,CORRPRODUCTO,DESCLARGO,PRECIOUNITARIO,DESCRIPCIONPROVEEDOR,IDUNIDADMEDIDA,UNIDADMEDIDA,CANTIDADPENDIENTE,CANTIDADDECIMAL,IDFUENTEFINANCIAMIENTO"
                  Width="100%">
                  <HeaderStyle CssClass="GridListHeaderSmaller" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItemSmaller" />
                  <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                  <Columns>
                    <asp:TemplateField>
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;" />
                      </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" />
                    <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
                    <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CANTIDADPENDIENTE" HeaderText="Test" Visible="False" />
                      <asp:BoundField DataField="NOMBRE" HeaderText="F.Financiamiento" />
                  </Columns>
                  <EmptyDataTemplate>
                    No existen productos pendientes de entregar.</EmptyDataTemplate>
                </asp:GridView>
             
        </asp:Panel>
    
    
        
    
        <asp:Panel ID="plRecepcion" runat="server" >
          <h3>
            Producto a recibir</h3>
             <table class="CenteredTable" >
            <tr>
              <td class="LabelCell">
                Descripción del producto:
              </td>
              <td class="DataCell">
                <asp:Label ID="txtDescProv" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad pendiente:
              </td>
              <td class="DataCell">
                <asp:Label ID="txtCantidadRecibir" runat="server" Font-Bold="True" />
                <asp:Label ID="txtUM" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Precio Unitario:
              </td>
              <td class="DataCell">
                <asp:Label ID="txtPrecioUnitario" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Documento:
              </td>
              <td class="DataCell">
                <cc1:ddlTIPODOCUMENTORECEPCION ID="ddlTIPODOCUMENTORECEPCION1" runat="server" />
                <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" />
                <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha del Documento:
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaDocumento" runat="server" Culture="Spanish (El Salvador)"
                  DisableTextBoxEntry="False" Nullable="True" />
                <asp:RequiredFieldValidator ID="rfvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                  Display="Dynamic" ErrorMessage="La fecha del documento no puede ser posterior a hoy."
                  Operator="LessThanEqual" Type="Date" ValidationGroup="AgregarLote" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad a recibir:
              </td>
              <td class="DataCell">
                <ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="True" Width="88px"
                  TextAlign="Right" MaxLength="9" TruncateLeadingZeros="True" />
                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="nbCantidad"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                  Display="Dynamic" ErrorMessage="La cantidad debe ser menor o igual a la pendiente de recibir."
                  Operator="LessThanEqual" Type="Double" ValidationGroup="AgregarLote" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvCantidad1" runat="server" ControlToValidate="nbCantidad"
                  Display="Dynamic" ErrorMessage="La cantidad debe ser mayor a cero." Operator="GreaterThan"
                  Type="Double" ValidationGroup="AgregarLote" ValueToCompare="0" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fuente de financiamiento:
              </td>
              <td class="DataCell">
                <cc1:ddlFUENTEFINANCIAMIENTOSCONTRATOS ID="ddlFUENTEFINANCIAMIENTOSCONTRATOS1" runat="server" Enabled="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblRESPONSABLEDISTRIBUCIONCONTRATO" runat="server" Text="Responsable de distribución:"
                  Visible="False" />
              </td>
              <td class="DataCell">
                <cc1:ddlRESPONSABLEDISTRIBUCIONCONTRATO ID="ddlRESPONSABLEDISTRIBUCIONCONTRATO1"
                  runat="server" Visible="False" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:GridView ID="gvLotesMuestreados" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" GridLines="None" DataKeyNames="IDINFORME,IDTIPOINFORME,NUMEROINFORME,LOTE,FECHAVENCIMIENTO,FECHAELABORACIONINFORME" Width="100%">
                  <HeaderStyle CssClass="GridListHeaderSmaller" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItemSmaller" />
                  <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                  <EditRowStyle CssClass="GridListEditItemSmaller" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                  <Columns>
                    <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                    <asp:BoundField DataField="LOTE" HeaderText="Lote y/o Serie" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vto." DataFormatString="{0:d}"
                      HtmlEncode="False" />
                    <asp:BoundField DataField="NUMEROINFORME" HeaderText="Informe CC" />
                    <asp:BoundField DataField="FECHAELABORACIONINFORME" HeaderText="Fecha Informe CC"
                      DataFormatString="{0:d}" HtmlEncode="False" />
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Cantidad" />
                    <asp:BoundField DataField="TIPOINFORME" HeaderText="Resultado" />
                  </Columns>
                  <EmptyDataTemplate>
                    <b>No hay lotes muestreados por Control de Calidad para este renglón.</b></EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="plLoteNoMuestreado" runat="server" Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                          Lote y/o Serie:
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
                          Display="Dynamic" ErrorMessage="Formato incorrecto.  Debe ser MM/aaaa." ValidationExpression="(((0?[123456789]|10|11|12)([/])(([2][0][0-9][0-9]))))"
                          ValidationGroup="AgregarLote" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblNumeroInformeCC" runat="server" Text="No. Informe CC:" />
                      </td>
                      <td class="DataCell">
                        <asp:TextBox runat="server" ID="txtNumeroInformeCC" MaxLength="15" />
                        <asp:RequiredFieldValidator ID="rfvNumeroInformeCC" runat="server" ControlToValidate="txtNumeroInformeCC"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
                        <asp:CheckBox ID="cbNumeroInformeCCNA" runat="server" Text="N/A" AutoPostBack="True" />
                      </td>
                    </tr>
                    <tr>
                   <td colspan="2">
                        <asp:RegularExpressionValidator ID="revNumeroInformeCC" runat="server" ControlToValidate="txtNumeroInformeCC"
                          Display="Dynamic" ErrorMessage="Formato incorrecto.  Debe ser 9999CC9999: 4 dígitos para el año, las letras CC indicando Control de Calidad y por último 4 dígitos correspondientes al número de informe."
                          ValidationExpression="[0-9][0-9][0-9][0-9][c,C][c,C][0-9][0-9][0-9][0-9]+" ValidationGroup="AgregarLote" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Fecha Informe CC:
                      </td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="cpFechaInformeCC" runat="server" Culture="Spanish (El Salvador)"
                          DisableTextBoxEntry="False" SelectedDate="" VisibleDate="" Nullable="True" />
                        <asp:RequiredFieldValidator ID="rfvFechaInformeCC" runat="server" ControlToValidate="cpFechaInformeCC"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="AgregarLote" />
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:CompareValidator ID="cvFechaInformeCC" runat="server" ControlToValidate="cpFechaInformeCC"
                          Display="Dynamic" ErrorMessage="La fecha del informe no puede ser posterior a hoy."
                          Operator="LessThanEqual" Type="Date" ValidationGroup="AgregarLote" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Ubicación:
              </td>
              <td class="DataCell">
                <asp:TextBox runat="server" ID="txtUbicacion" MaxLength="150" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote" ValidationGroup="AgregarLote" />
              </td>
            </tr>
          </table>
        </asp:Panel>
    
    <hr />
    <h3>
        Productos recibidos</h3>
    <asp:GridView ID="gvLista" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
          AutoGenerateColumns="False" DataKeyNames="RENGLON,CODIGO,DOCUMENTO,FECHADOCUMENTO,IDFUENTEFINANCIAMIENTO,CANTIDAD,IDLOTE,IDDETALLEMOVIMIENTO,IDUBICACION,IDPRODUCTO"
          ShowFooter="true" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="RENGLON" HeaderText="Renglón" />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="-Lote&lt;br /&gt; -Fecha vto." HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left">
              <ItemTemplate>
                <%#Container.DataItem("CODIGODETALLE").ToString + "<br />" + Container.DataItem("FECHAVENCIMIENTOMMAAAA").ToString%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Documento">
              <ItemTemplate>
                <%#Container.DataItem("DOCUMENTO").ToString + "<br />" + String.Format("{0:d}", Container.DataItem("FECHADOCUMENTO"))%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Informe CC">
              <ItemTemplate>
                <%#Container.DataItem("NUMEROINFORMECC").ToString + "<br />" + String.Format("{0:d}", Container.DataItem("FECHAINFORMECC"))%>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente fto." ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio" DataFormatString="{0:c4}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n" />
            <asp:BoundField DataField="TOTAL" HeaderText="Total" DataFormatString="{0:c4}" HtmlEncode="False"
              ItemStyle-HorizontalAlign="Right" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                  Visible='<%# Iif (Eval("IDESTADO") = 1, True, False) %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
     
        <asp:Panel ID="plGenerales" runat="server" >
            <hr />
        <h3>
            Responsables</h3>
          <table class="CenteredTable" >
            <tr>
              <td class="LabelCell">
                Guardalmacén:
              </td>
              <td class="DataCell" style="width: 100%">
                <asp:TextBox ID="txtGuardalmacen" Width="100%" runat="server"  />
                <asp:RequiredFieldValidator ID="rfvGuardalmacen" runat="server" ControlToValidate="txtGuardalmacen"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Cerrar" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="white-space: nowrap">
                Delegado del Proveedor:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtDelegadoProveedor" Width="100%" runat="server"  />
                <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" ControlToValidate="txtDelegadoProveedor"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
              </td>
            </tr>
              <tr>
                  <td class="LabelCell" style="white-space: nowrap">
                      Administrador de&nbsp; Contrato</td>
                  <td class="DataCell">
                      <asp:TextBox ID="txtAmdContrato" runat="server" Width="100%"></asp:TextBox>
                      <asp:CheckBox ID="cbAdmContrato" runat="server" Text="N/A" AutoPostBack="True" /></td>
              </tr>
            <tr>
              <td class="LabelCell" style=" vertical-align: top">
                Observaciones:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBoxMultiLine"  Width="100%" Height="100px" TextMode="MultiLine" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar recepción" ValidationGroup="Guardar" />
                <asp:Button ID="btnCerrar" runat="server" Enabled="False" Text="Cerrar recepción"
                  ValidationGroup="Cerrar" />
                <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Recibo" UseSubmitBehavior="False" />
              </td>
            </tr>
          </table>
        </asp:Panel>
    
  
</asp:Content>
