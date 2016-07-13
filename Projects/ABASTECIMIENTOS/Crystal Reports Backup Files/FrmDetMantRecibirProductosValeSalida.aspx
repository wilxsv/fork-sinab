<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmDetMantRecibirProductosValeSalida.aspx.vb"
  Inherits="FrmDetMantRecibirProductosValeSalida" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"
          PostBackUrl="~/FrmPrincipal.aspx" />
        Almacén -> Recepción de productos a partir de un vale de salida
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvVales" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" DataKeyNames="IDESTABLECIMIENTO,IDMOVIMIENTO,IDTIPOTRANSACCION,IDESTADO"
          Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:CommandField HeaderText="Seleccionar" SelectText=">>" ShowSelectButton="true" />
            <asp:BoundField DataField="IDDOCUMENTO" HeaderText="N&#176; vale" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha despacho" DataFormatString="{0:d}"
              HtmlEncode="False" />
            <asp:BoundField DataField="NOMBREALMACEN" HeaderText="Procedencia" ItemStyle-HorizontalAlign="Left" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron vales de salida destinados a este almacén.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          DataKeyNames="IDDETALLEMOVIMIENTO,IDLOTE,IDPRODUCTO,PRECIOLOTE,IDUNIDADMEDIDA,IDRESPONSABLEDISTRIBUCION,IDFUENTEFINANCIAMIENTO,FECHAVENCIMIENTO,IDESTABLECIMIENTOCONTROLCALIDAD,IDINFORMECONTROLCALIDAD,NUMEROINFORMECONTROLCALIDAD,FECHAINFORMECONTROLCALIDAD"
          GridLines="None">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CODIGO" HeaderText="Lote" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha Vto." ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad despachada" DataFormatString="{0:n2}"
              HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio unitario" DataFormatString="{0:c4}"
              HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financiamiento"
              ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" HeaderText="Responsable distribución"
              ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Cantidad a recibir" ItemStyle-HorizontalAlign="Left">
              <ItemTemplate>
                <ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="true" MaxLength="12"
                  Text='<%# Bind("CANTIDAD") %>' TextAlign="Right" /><br />
                <asp:CompareValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                  Display="Dynamic" Operator="LessThanEqual" Text="La cantidad debe ser menor o igual a la disponible."
                  Type="Double" ValidationGroup="AgregarLote" ValueToCompare='<%# Bind("CANTIDAD") %>' /><br />
                <asp:CompareValidator ID="cvCantidad1" runat="server" ControlToValidate="nbCantidad"
                  Display="Dynamic" Operator="GreaterThan" Text="La cantidad debe ser mayor a cero."
                  Type="Double" ValidationGroup="AgregarLote" ValueToCompare="0" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plGenerales" runat="server" GroupingText=" " Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNoReciboRecepcion" runat="server" Text="No. de Recibo de Recepción:"
                  Visible="False" />
              </td>
              <td class="DataCell">
                <asp:Label ID="txtNoRecepcion" runat="server" Visible="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Recepción:
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaRecepcion" runat="server" Culture="Spanish (El Salvador)" />
                <asp:RequiredFieldValidator ID="rfvFechaRecepcion" runat="server" ControlToValidate="cpFechaRecepcion"
                  Display="Dynamic" ErrorMessage="*" ValidationGroup="Cerrar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvFechaRecepcion" runat="server" ControlToValidate="cpFechaRecepcion"
                  Display="Dynamic" ErrorMessage="La fecha de recepción no puede ser posterior a hoy."
                  Operator="LessThanEqual" Type="Date" ValidationGroup="Cerrar" />
              </td>
            </tr>
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
                Delegado:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtTransportista" runat="server" MaxLength="75" />
                <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" ControlToValidate="txtTransportista"
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
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar recepción" ValidationGroup="Guardar"
                  Enabled="False" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar recepción" Enabled="False"
                  ValidationGroup="Cerrar" />
                <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Recibo" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
