<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucInformacionRecepcionRenglon.ascx.vb"
  Inherits="ucInformacionRecepcionRenglon" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:GridView ID="gvTemp" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
        AutoGenerateColumns="False" DataKeyNames="RENGLON,LOTE,DOCUMENTO,FECHADOCUMENTO,IDFUENTEFINANCIAMIENTO,CANTIDAD,IDLOTE"
        Width="100%">
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItemSmaller" />
        <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
        <EditRowStyle CssClass="GridListEditItemSmaller" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        <Columns>
          <asp:BoundField DataField="RENGLON" HeaderText="Renglón" />
          <asp:BoundField DataField="LOTE" HeaderText="Lote" ItemStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="FECHAVENCIMIENTOMMAAAA" HeaderText="Fecha Vto." ItemStyle-HorizontalAlign="Right" />
          <asp:BoundField DataField="DOCUMENTO" HeaderText="Documento" />
          <asp:BoundField DataField="FECHADOCUMENTO" DataFormatString="{0:d}" HeaderText="Fecha"
            HtmlEncode="False" />
          <asp:BoundField DataField="NUMEROINFORMECC" HeaderText="Informe CC" />
          <asp:BoundField DataField="FECHAINFORMECC" DataFormatString="{0:d}" HeaderText="Fecha Informe CC"
            HtmlEncode="False" />
          <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
            HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
          <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente Fto." />
          <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n" />
          <asp:TemplateField>
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
    <td>
      <asp:Panel ID="plRecepcion" runat="server" GroupingText="Productos a recibir" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              Documento:</td>
            <td class="DataCell">
              <cc1:ddlTIPODOCUMENTORECEPCION ID="ddlTIPODOCUMENTORECEPCION1" runat="server" />
              <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" />
              <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" Display="dynamic" ControlToValidate="txtDocumento"
                ValidationGroup="AgregarLote" Text="*" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Fecha del Documento:</td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFechaDocumento" runat="server" Culture="Spanish (El Salvador)"
                DisableTextBoxEntry="False" Nullable="True" />
              <asp:RequiredFieldValidator ID="rfvFechaDocumento" runat="server" Display="dynamic"
                ControlToValidate="cpFechaDocumento" ValidationGroup="AgregarLote" Text="*" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                Display="Dynamic" Operator="LessThanEqual" Text="La fecha del documento no puede ser posterior a hoy."
                Type="Date" ValidationGroup="AgregarLote" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Cantidad a recibir:</td>
            <td class="DataCell">
              <ew:NumericBox ID="nbCantidad" runat="server" PositiveNumber="True" Width="88px"
                TextAlign="Right" MaxLength="9" TruncateLeadingZeros="True" />
              <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ControlToValidate="nbCantidad"
                Display="Dynamic" ValidationGroup="AgregarLote" Text="*" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                Display="Dynamic" Operator="LessThanEqual" Type="Double" ValidationGroup="AgregarLote"
                Text="La cantidad debe ser menor o igual a la pendiente de recibir." /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvCantidad1" runat="server" ControlToValidate="nbCantidad"
                Display="Dynamic" Operator="GreaterThan" Text="La cantidad debe ser mayor a cero."
                Type="Double" ValidationGroup="AgregarLote" ValueToCompare="0" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFUENTEFINANCIAMIENTOSCONTRATOS1" runat="server" Text="Fuente de financiamiento:" /></td>
            <td class="DataCell">
              <cc1:ddlFUENTEFINANCIAMIENTOSCONTRATOS ID="ddlFUENTEFINANCIAMIENTOSCONTRATOS1" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblRESPONSABLEDISTRIBUCIONCONTRATO" runat="server" Text="Responsable de distribución:"
                Visible="False" /></td>
            <td class="DataCell">
              <cc1:ddlRESPONSABLEDISTRIBUCIONCONTRATO ID="ddlRESPONSABLEDISTRIBUCIONCONTRATO1"
                runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:GridView ID="gvLotesMuestreados" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" DataKeyNames="IDINFORME,IDTIPOINFORME,NUMEROINFORME,LOTE,FECHAVENCIMIENTO,FECHAELABORACIONINFORME"
                AllowPaging="false">
                <HeaderStyle CssClass="GridListHeaderSmaller" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItemSmaller" />
                <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                <EditRowStyle CssClass="GridListEditItemSmaller" />
                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                <Columns>
                  <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                  <asp:BoundField DataField="LOTE" HeaderText="Lote" />
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
                      Lote:</td>
                    <td class="DataCell">
                      <asp:TextBox runat="server" ID="txtLote" MaxLength="15" />
                      <asp:RequiredFieldValidator ID="rfvLote" runat="server" Display="dynamic" ControlToValidate="txtLote"
                        ValidationGroup="AgregarLote" Text="*" />
                      <asp:TextBox ID="txtDETALLE" runat="server" MaxLength="10" Visible="False" />
                      <asp:CheckBox ID="cbLoteNA" runat="server" Text="N/A" AutoPostBack="True" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      Fecha Vencimiento (MM/aaaa):</td>
                    <td class="DataCell">
                      <asp:TextBox ID="txtFechaVto" runat="server" MaxLength="7" />
                      <asp:RequiredFieldValidator ID="rfvFechaVto" runat="server" Display="dynamic" ControlToValidate="txtFechaVto"
                        ValidationGroup="AgregarLote" Text="*" />
                      <asp:CheckBox ID="cbFechaVtoNA" runat="server" Text="N/A" AutoPostBack="True" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:RegularExpressionValidator ID="revFechVto" runat="server" ControlToValidate="txtFechaVto"
                        ValidationExpression="(((0?[123456789]|10|11|12)([/])(([2][0][0-9][0-9]))))" ValidationGroup="AgregarLote"
                        Display="Dynamic" Text="Formato incorrecto.  Debe ser MM/aaaa." /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="lblNumeroInformeCC" runat="server" Text="No. Informe CC:" /></td>
                    <td class="DataCell">
                      <asp:TextBox runat="server" ID="txtNumeroInformeCC" MaxLength="15" />
                      <asp:RequiredFieldValidator ID="rfvNumeroInformeCC" runat="server" Display="dynamic"
                        ControlToValidate="txtNumeroInformeCC" ValidationGroup="AgregarLote" Text="*" />
                      <asp:CheckBox ID="cbNumeroInformeCCNA" runat="server" Text="N/A" AutoPostBack="True" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="2">
                      <asp:RegularExpressionValidator ID="revNumeroInformeCC" runat="server" ControlToValidate="txtNumeroInformeCC"
                        Display="Dynamic" Text="Formato incorrecto.  Debe ser 9999CC9999: 4 dígitos para el año, las letras CC indicando Control de Calidad y por último 4 dígitos correspondientes al número de informe."
                        ValidationExpression="[0-9][0-9][0-9][0-9][c,C][c,C][0-9][0-9][0-9][0-9]+" ValidationGroup="AgregarLote" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      Fecha Informe CC:</td>
                    <td class="DataCell">
                      <ew:CalendarPopup ID="cpFechaInformeCC" runat="server" Culture="Spanish (El Salvador)"
                        DisableTextBoxEntry="False" SelectedDate="" VisibleDate="" Nullable="True" />
                      <asp:RequiredFieldValidator ID="rfvFechaInformeCC" runat="server" Display="dynamic"
                        ControlToValidate="cpFechaInformeCC" ValidationGroup="AgregarLote" Text="*" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="3">
                      <asp:Label ID="lblInformesErr" runat="server" ForeColor="Red" Text="*Dato Requerido"
                        Visible="False" />
                    </td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Ubicación:</td>
            <td class="DataCell">
              <asp:TextBox runat="server" ID="txtUbicacion" MaxLength="150" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote" ValidationGroup="AgregarLote" /></td>
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
              <asp:Label ID="lblNoReciboRecepcion" runat="server" Text="No. de Recibo de Recepción:"
                Visible="False" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtNoRecepcion" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Fecha de Recepción:</td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFechaRecepcion" runat="server" Culture="Spanish (El Salvador)"
                DisableTextBoxEntry="False" />
              <asp:RequiredFieldValidator ID="rfvFechaRecepcion" runat="server" Display="dynamic"
                ControlToValidate="cpFechaRecepcion" ValidationGroup="Guardar" Text="*" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFechaRecepcion" runat="server" ControlToValidate="cpFechaRecepcion"
                Display="Dynamic" Operator="LessThanEqual" Text="La fecha de recepción no puede ser posterior a hoy."
                Type="Date" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Guardalmacén:</td>
            <td class="DataCell">
              <asp:TextBox ID="txtGuardalmacen" runat="server" MaxLength="70" />
              <asp:RequiredFieldValidator ID="rfvGuardalmacen" runat="server" Display="dynamic"
                ControlToValidate="txtGuardalmacen" ValidationGroup="Cerrar" Text="*" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Delegado del Proveedor:</td>
            <td class="DataCell">
              <asp:TextBox ID="txtDelegadoProveedor" runat="server" MaxLength="75" />
              <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" Display="dynamic"
                ControlToValidate="txtTransportista" ValidationGroup="Cerrar" Text="*" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Observaciones:</td>
            <td class="DataCell">
              <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar recepción" ValidationGroup="Guardar" />
              <asp:Button ID="btnCerrar" runat="server" Text="Cerrar recepción" ValidationGroup="Cerrar" Enabled="False" />
              <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Recibo" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
