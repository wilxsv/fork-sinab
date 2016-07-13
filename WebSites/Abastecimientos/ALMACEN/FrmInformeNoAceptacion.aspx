<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" 
  AutoEventWireup="false" CodeFile="FrmInformeNoAceptacion.aspx.vb" Inherits="FrmInformeNoAceptacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucSeleccionContratoRecepcion" Src="~/Controles/ucSeleccionContratoRecepcion.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="menuContent">
     <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacenes » Informe de No Aceptación
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
 
        <uc1:ucSeleccionContratoRecepcion ID="ucSeleccionContratoRecepcion1" runat="server"
          Visible="true" />
     
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Visible="False"
          Text="<< Regresar al listado de proveedores" />
     
        <asp:Panel ID="plInformacionNoAceptacionContrato" runat="server" Visible="false"
          Width="100%">
         
                <asp:Panel ID="plModalidadCompra" runat="server" GroupingText=" " Width="100%">
                  <table class="CenteredTable" style="width: 100%;">
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblModalidadCompra" runat="server" Text="Modalidad de Compra:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtModalidadCompra" runat="server" />
                        <asp:Label ID="txtNoModalidadCompra" runat="server" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblFuenteFinanciamiento" runat="server" Text="Fuentes de Financiamiento:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtFuenteFinanciamiento" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblResponsableDistribucion" runat="server" Text="Responsable de Distribución:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtResponsableDistribucion" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblResolucionAdjudicacion" runat="server" Text="Resolución de Adjudicación:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtResolucionAdjudicacion" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblNoContratoOrdenCompra" runat="server" Text="No. de Contrato/Orden de Compra:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtNoContratoOrdenCompra" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtProveedor" runat="server" />
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="lblFechaDistribucion" runat="server" Text="Fecha de Distribución:" /></td>
                      <td class="DataCell">
                        <asp:Label ID="txtFechaDistribucion" runat="server" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
         
                <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
                  AutoGenerateColumns="False" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDALMACENENTREGA,RENGLON,IDPRODUCTO,CORRPRODUCTO,DESCLARGO,PRECIOUNITARIO,DESCRIPCIONPROVEEDOR,IDUNIDADMEDIDA,UNIDADMEDIDA,CANTIDADPENDIENTE,CANTIDADDECIMAL"
                  Width="100%">
                  <HeaderStyle CssClass="GridListHeaderSmaller" />
                  <FooterStyle CssClass="GridListFooter" />
                  <PagerStyle CssClass="GridListPager" />
                  <RowStyle CssClass="GridListItemSmaller" />
                  <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                  <EditRowStyle CssClass="GridListEditItem" />
                  <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                  <Columns>
                    <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="False" />
                    <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" />
                    <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" />
                    <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="CANTIDADPENDIENTE" HeaderText="Test" Visible="False" />
                    <asp:TemplateField HeaderText="">
                      <ItemTemplate>
                        <asp:CheckBox ID="cbSeleccionado" runat="server" Checked="False" />
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    No existen renglones contratados pendientes de entregar.</EmptyDataTemplate>
                </asp:GridView>
         
                <asp:Panel ID="plDatosInforme" runat="server" GroupingText=" " Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td class="LabelCell">
                        Fecha de no aceptación:</td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="cpFechaNoAceptacion" runat="server" Culture="Spanish (El Salvador)" />
                        <asp:RequiredFieldValidator ID="rfvFechaNoAceptacion" runat="server" ControlToValidate="cpFechaNoAceptacion"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:CompareValidator ID="cvFechaNoAceptacion" runat="server" ControlToValidate="cpFechaNoAceptacion"
                          Display="Dynamic" ErrorMessage="La fecha de no aceptación no puede ser posterior a hoy."
                          Operator="LessThanEqual" Type="Date" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Documento del proveedor:</td>
                      <td class="DataCell">
                        <cc1:ddlTIPODOCUMENTORECEPCION ID="ddlTIPODOCUMENTORECEPCION1" runat="server" />
                        <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" />
                        <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="txtDocumento"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Fecha del documento:</td>
                      <td class="DataCell">
                        <ew:CalendarPopup ID="cpFechaDocumento" runat="server" Culture="Spanish (El Salvador)"
                          DisableTextBoxEntry="False" />
                        <asp:RequiredFieldValidator ID="rfvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:CompareValidator ID="cvFechaDocumento" runat="server" ControlToValidate="cpFechaDocumento"
                          Display="Dynamic" ErrorMessage="La fecha del documento no puede ser posterior a hoy."
                          Operator="LessThanEqual" Type="Date" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Guardalmacén:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtGuardalmacen" runat="server" MaxLength="70" />
                        <asp:RequiredFieldValidator ID="rfvGuardalmacen" runat="server" ControlToValidate="txtGuardalmacen"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Motivo(s):</td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" />
                        <asp:RequiredFieldValidator ID="rfvMotivo" runat="server" ControlToValidate="txtMotivo"
                          Display="Dynamic" ErrorMessage="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Delegado del proveedor:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtDelegado" runat="server" MaxLength="75" />
                        <asp:RequiredFieldValidator ID="rfvDelegado" runat="server" ControlToValidate="txtDelegado"
                          Display="Dynamic" ErrorMessage="*" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar informe" ValidationGroup="Guardar" />
                        <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver informe" UseSubmitBehavior="False" />
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
           
        </asp:Panel>
      
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
