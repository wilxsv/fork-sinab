<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmDetaMantDespacharProductosPreOrdenados.aspx.vb" Inherits="ALMACEN_frmDetaMantDespacharProductosPreOrdenados" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén -> Despachar productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div class="form">
        <asp:Panel runat="server" ID="divBuscaReq" GroupingText="Busqueda de Requisición:">
            <asp:Label runat="server" AssociatedControlID="tbBuscador" ID="lbl1" Text="Código de requisición:" />
            <asp:TextBox runat="server" ID="tbBuscador" />
            <asp:Button runat="server" ID="Buscar" Text="Buscar" />
            <asp:Panel ID="plEncabezado" runat="server" >
                <table style="width: 100%;">
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="lblSuministros" runat="server" Text="Suministro:" />
                        </td>
                        <td class="DataCell">
                        <asp:Label ID="lblSuministro" runat="server" Font-Bold="true"/>                          
                        </td>
                    </tr>
                    <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNroVale" runat="server" Text="Nro. de documento:" /></td>
              <td class="DataCell">
                <asp:Label ID="txtNroVale" Font-Bold="true" runat="server" /></td>
            </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="lblTipoDespachoIndividual" runat="server" Text="Tipo despacho:" />
                        </td>
                        <td class="DataCell">
                        <asp:DropDownList ID="ddlMovimientos" runat="server" />
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="lblLugarDestino" runat="server" Text="Lugar destino:" />
                        </td>
                        <td class="DataCell">
                        <asp:label Font-Bold="true" ID="lbEstablecimiento" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            <asp:Label ID="lblAlmacenDestino" runat="server" Text="Almacén destino:" />
                        </td>
                        <td class="DataCell">
                          <asp:Label ID="lblAlmacenAsociado" runat="server" Text="El lugar de destino no tiene ningún almacén asociado." Font-Bold="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="LabelCell">
                            Fecha despacho:
                        </td>
                        <td class="DataCell">
                            <asp:TextBox ID="cpFechaDespacho" runat="server" />
                            <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="cpFechaDespacho" runat="server">
                            </asp:CalendarExtender>
                           
                           <%-- <asp:RequiredFieldValidator ID="rfvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                                ErrorMessage="*" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <asp:CompareValidator ID="cvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                  ErrorMessage="La fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
                  Type="Date" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="Panel1" runat="server" GroupingText="Productos">
    
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
            <%--<asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" AlternateText="Elimina el registro"
                  CommandName="Delete" CausesValidation="False" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                  Visible='<%# Iif (Eval("IDESTADO") = 1, True, False) %>' />
              </ItemTemplate>
            </asp:TemplateField>--%>
          </Columns>
        </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="plGenerales" runat="server" Width="100%" >
          <table style="width: 100%;">
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
              <asp:ComboBox ID="ddlTIPOIDENTIFICACION1" runat="server" />
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
        </asp:Panel>
    </div>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
