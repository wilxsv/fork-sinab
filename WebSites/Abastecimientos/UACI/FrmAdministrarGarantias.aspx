<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmAdministrarGarantias.aspx.vb"
  Inherits="FrmAdministrarGarantias" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="UACI -> Administrar garantías" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel2" runat="server" BorderColor="#404040" BorderStyle="Solid" BorderWidth="1px"
          HorizontalAlign="Center" Width="100%">
          <asp:Label ID="Label14" runat="server" BackColor="Navy" Font-Bold="True" ForeColor="White"
            Text="Filtros de búsqueda:" Width="100%" />
          <br />
          <asp:RadioButtonList ID="rbFiltros" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">Contrato</asp:ListItem>
            <asp:ListItem Value="1">Proceso de compra</asp:ListItem>
            <asp:ListItem Value="2">Proveedor</asp:ListItem>
            <asp:ListItem Value="3">Fecha vencimiento</asp:ListItem>
            <asp:ListItem Value="4">Tipo garant&#237;a</asp:ListItem>
            <asp:ListItem Value="5">N&#250;mero garant&#237;a</asp:ListItem>
          </asp:RadioButtonList>
          <br />
          <asp:Panel ID="pnFiltroContrato" runat="server" Width="100%">
            <asp:Label ID="Label9" runat="server" Text="Contrato:" />
            <asp:TextBox ID="txtContrato" runat="server" Width="96px" MaxLength="12" />
            <br />
            <asp:Button ID="btnBuscarContrato" runat="server" Text="Buscar" />
          </asp:Panel>
          <asp:Panel ID="pnFiltroProceso" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label10" runat="server" Text="Proceso compra:" />
            <asp:DropDownList ID="ddlProcesosCompra" runat="server" Width="248px" />
            <br />
            <asp:Button ID="btnBuscarPC" runat="server" Text="Buscar" />
          </asp:Panel>
          <asp:Panel ID="pnFiltroProveedor" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label11" runat="server" Text="Proveedor:" />
            <asp:DropDownList ID="ddlProveedores" runat="server" Width="520px" />
            <br />
            <asp:Button ID="btnBuscarProveedor" runat="server" Text="Buscar" />
            <asp:Button ID="btnrptProveedor" runat="server" Text="Reporte" />
          </asp:Panel>
          <asp:Panel ID="pnFiltroFechaVenc" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label6" runat="server" Text="Fecha vencimiento:" />
            <ew:CalendarPopup ID="cpFechaVenc" runat="server" Width="112px">
            </ew:CalendarPopup>
            <br />
            <asp:Button ID="btnBuscarFecha" runat="server" Text="Buscar" />
            <asp:Button ID="btnrptFecha" runat="server" Text="Reporte" />
          </asp:Panel>
          <asp:Panel ID="pnFiltroTipoGarantia" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label8" runat="server" Text="Tipo garantía:" />
            <asp:DropDownList ID="ddlTipoGarantia" runat="server" AutoPostBack="True" Width="256px" />
            <br />
            <asp:Button ID="btnTipoGarantia" runat="server" Text="Buscar" />
            <asp:Button ID="btnrptTipo" runat="server" Text="Reporte" />
          </asp:Panel>
          <asp:Panel ID="pnFiltroNumeroGarantia" runat="server" Visible="False" Width="100%">
            <asp:Label ID="Label7" runat="server" Text="Número garantía:" />
            <asp:TextBox ID="txtNumeroGarantia" runat="server" Width="96px" MaxLength="12" />
            <br />
            <asp:Button ID="btnNumGarantia" runat="server" Text="Buscar" />
          </asp:Panel>
          <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" />
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Contratos que cumplen con el criterio de búsqueda:" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvContratos2" runat="server" CellPadding="4" ForeColor="#333333"
          GridLines="None" AutoGenerateColumns="False" DataKeyNames="IdProcesoCompra,IDPROVEEDOR,IDCONTRATO,IDTIPOGARANTIA,IDESTABLECIMIENTO,CODIGOLICITACION,ORDENLLEGADA,NUMEROCONTRATO,NOMBRE,NUMEROGARANTIA,FECHAVENCIMIENTO,tipogarantia"
          AllowPaging="True">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False" />
            <asp:BoundField DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
            <asp:BoundField DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False" />
            <asp:BoundField DataField="IDTIPOGARANTIA" HeaderText="IDTIPOGARANTIA" Visible="False" />
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Proceso compra">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Oferta">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Contrato">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="tipogarantia" HeaderText="Tipo">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMEROGARANTIA" HeaderText="No. Garant&#237;a">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha de vencimiento" />
          </Columns>
        </asp:GridView>
        <asp:GridView ID="gvContratos" runat="server" CellPadding="4" ForeColor="#333333"
          GridLines="None" AutoGenerateColumns="False" DataKeyNames="IdProcesoCompra,IDPROVEEDOR,IDCONTRATO,CODIGOLICITACION,ORDENLLEGADA,NUMEROCONTRATO,NOMBRE"
          AllowPaging="True">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False" />
            <asp:BoundField DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
            <asp:BoundField DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False" />
            <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Proceso compra">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="ORDENLLEGADA" HeaderText="Oferta">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Contrato">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
          PermiteSeleccionar="false" BtnAnularProcesoEnabled="false" BtnQuitarSolicitudEnabled="false" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Renglones adjudicados:" /></td>
    </tr>
    <tr>
      <td align="center">
        <asp:GridView ID="gvRenglones" runat="server" CellPadding="4" DataKeyNames="renglon,cantidad,precio,monto"
          ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="renglon" HeaderText="Rengl&#243;n">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="cantidad" HeaderText="Cantidad">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Precio">
              <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("precio") %>' />
              </EditItemTemplate>
              <ItemStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <%# String.Format("{0:c}",Decimal.Round(Eval("precio"),2)) %>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Monto">
              <EditItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("monto") %>' />
              </EditItemTemplate>
              <ItemStyle HorizontalAlign="Right" />
              <ItemTemplate>
                <%# String.Format("{0:c}",Decimal.Round(Eval("monto"),2)) %>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvGarantias" runat="server" CellPadding="4" ForeColor="#333333"
          GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDTIPOGARANTIA,NOMBRE,FECHAENTREGA,FECHARECEPCION,FECHAVENCIMIENTO,MONTO,VIGENCIA,DESCRIPCION,IDGARANTIACONTRATO">
          <Columns>
            <asp:CommandField SelectText="Administrar" ShowSelectButton="True" />
            <asp:BoundField DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
            <asp:BoundField DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False" />
            <asp:BoundField DataField="idtipogarantia" HeaderText="idtipogarantia" Visible="False" />
            <asp:BoundField DataField="NOMBRE" HeaderText="Tipo Garant&#237;a">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHAENTREGA" HeaderText="Fecha de entrega" HtmlEncode="False" />
            <asp:BoundField DataField="FECHARECEPCION" HeaderText="Fecha de recepci&#243;n" />
            <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha de vencimiento" />
            <asp:BoundField DataField="MONTO" HeaderText="Monto" DataFormatString="{0:c}" HtmlEncode="False">
              <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Vigencia">
              <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VIGENCIA") %>' />
              </EditItemTemplate>
              <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Bind("VIGENCIA") %>' />
                días
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Estado">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <FooterStyle CssClass="GridListFooter" BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <HeaderStyle CssClass="GridListHeader" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Monto total del contrato:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblMonto" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Número del proceso de compra:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="lblProcesoCompra" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label18" runat="server" Text="Número de resolución:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="lblResolucion" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label20" runat="server" Text="Número de contrato:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="lblContrato" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label21" runat="server" Text="Proveedor:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label23" runat="server" Text="Persona:" />
              </td>
              <td class="DataCell">
                <asp:Label ID="lblPersona" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Estado:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblEstado" runat="server" ForeColor="Navy" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label24" runat="server" Text="Tipo de garantía:" /></td>
              <td class="DataCell">
                <asp:DropDownList ID="ddlTipoG" runat="server" Enabled="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label25" runat="server" Text="Número de garantía:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtNumGarantia" runat="server" MaxLength="20" Width="144px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNumGarantia"
                  ErrorMessage="El número de garantía es requerido">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Fecha de entrega:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaEntrega" runat="server" DisableTextBoxEntry="False"
                  Width="112px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label26" runat="server" Text="Fecha de recepción:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaRecepcion" runat="server" DisableTextBoxEntry="False"
                  Width="112px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label27" runat="server" Text="Vigencia:" /></td>
              <td class="DataCell">
                <ew:NumericBox ID="txtVigencia" runat="server" MaxLength="3" Width="16px" />
                <asp:Label ID="Label4" runat="server" Text="(Días calendario)" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVigencia"
                  ErrorMessage="Vigencia es requerido">*</asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtVigencia"
                  ErrorMessage="Vigencia debe ser mayor que cero" MaximumValue="5000" MinimumValue="1"
                  Type="Integer">*</asp:RangeValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Calcular fecha de vencimiento"
                  Width="200px" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label28" runat="server" Text="Fecha de vencimiento:" />
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechavencimiento" runat="server" DisableTextBoxEntry="False"
                  Width="112px" />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="CPFechaRecepcion"
                  ControlToValidate="cpFechavencimiento" ErrorMessage="Fecha de vencimiento debe ser mayor a fecha de recepción"
                  Operator="GreaterThanEqual" Type="Date">*</asp:CompareValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label29" runat="server" Text="Aseguradora:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtAseguradora" runat="server" MaxLength="75" Width="300px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAseguradora"
                  ErrorMessage="Aseguradora es requerido">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label30" runat="server" Text="Monto de la garantía:" /></td>
              <td class="DataCell">
                <ew:NumericBox ID="nbMontoGarantia" runat="server" MaxLength="12" Width="96px" AutoFormatCurrency="True"
                  TextAlign="Right" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="nbMontoGarantia"
                  ErrorMessage="Monto de la grantía es requerido">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                  RepeatLayout="Flow">
                  <asp:ListItem Selected="True" Value="0">Hacer efectiva</asp:ListItem>
                  <asp:ListItem Value="1">Devolver</asp:ListItem>
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblfefectiva" runat="server" Text="Fecha en que se hizo efectiva:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaEfectiva" runat="server" DisableTextBoxEntry="False"
                  Width="112px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblEfectiva" runat="server" Text="Justificación efectiva:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtEfectiva" runat="server" Height="48px" MaxLength="1000" TextMode="MultiLine"
                  Width="352px" />
                <asp:RequiredFieldValidator ID="rqdevolucion" runat="server" ControlToValidate="txtDevolucion"
                  Display="Dynamic">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblfdevolucion" runat="server" Text="Fecha de devolución:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFechadevolucion" runat="server" DisableTextBoxEntry="False"
                  Width="112px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDevolucion" runat="server" Text="Justificación devolución:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtDevolucion" runat="server" Height="48px" MaxLength="1000" TextMode="MultiLine"
                  Width="352px" />
                <asp:RequiredFieldValidator ID="rqefectiva" runat="server" ControlToValidate="txtEfectiva"
                  Display="Dynamic">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
              <td colspan="2" style="font-size: 10pt;">
                <nds:Button ID="btnRecibir" runat="server" Message="¿Desea guardar la información ingresada?"
                  ShowConfirmDialog="True" Text="Recibir/Modificar" />
                <nds:Button ID="btnEfectiva" runat="server" Message="¿Desea guardar la información ingresada?"
                  ShowConfirmDialog="True" Text="Hacer efectiva" />
                <nds:Button ID="btnDevolver" runat="server" Message="¿Desea guardar la información ingresada?"
                  ShowConfirmDialog="True" Text="Devolver" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td style="font-size: 10pt">
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" /></td>
    </tr>
  </table>
</asp:Content>
