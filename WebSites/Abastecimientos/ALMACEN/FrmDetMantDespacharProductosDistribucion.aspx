﻿<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmDetMantDespacharProductosDistribucion.aspx.vb" Inherits="ALMACEN_FrmDetMantDespacharProductosDistribucion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="ContentMenu" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén » Despachar productos
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="PageContent" runat="Server">
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:RadioButtonList ID="rbTipoDespacho" runat="server" AutoPostBack="True" Visible="false"
                CssClass="form">
                <asp:ListItem Value="1" Selected="True" Text="Despachar productos individualmente" />
                <asp:ListItem Value="2" Text="Despachar productos a partir del cuadro de distribuci&#243;n"
                    Enabled="False" />
                <asp:ListItem Value="3" Text="Despachar productos a partir de una requisici&#243;n proveniente de otro almac&#233;n"
                    Enabled="False" />
            </asp:RadioButtonList>
            <div class="CenteredTable">
                <asp:Panel ID="plEncabezado" runat="server" Visible="false">
                    <h1>
                        <asp:Literal ID="boton" runat="server" Text="Nuevo Documento" />
                        <asp:Literal ID="lblNroVale" runat="server" Text="Nro. de documento:" Visible="false" /><asp:Literal
                            ID="txtNroVale" runat="server" Visible="false" />
                    </h1>
                    <table style="width: 100%;">
                        <tr>
                            <td class="LabelCell" style="width: 200px">
                                <asp:Label ID="Label2" runat="server" Text="Año:"></asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="ddlAnioAbas" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell" style="width: 200px">
                                <asp:Label ID="Label1" runat="server" Text="Distribuciones:"></asp:Label>
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                                    <asp:ListItem Value="01">Enero</asp:ListItem>
                                    <asp:ListItem Value="02">Febrero</asp:ListItem>
                                    <asp:ListItem Value="03">Marzo</asp:ListItem>
                                    <asp:ListItem Value="04">Abril</asp:ListItem>
                                    <asp:ListItem Value="05">Mayo</asp:ListItem>
                                    <asp:ListItem Value="06">Junio</asp:ListItem>
                                    <asp:ListItem Value="07">Julio</asp:ListItem>
                                    <asp:ListItem Value="08">Agosto</asp:ListItem>
                                    <asp:ListItem Value="09">Septiembre</asp:ListItem>
                                    <asp:ListItem Value="10">Octubre</asp:ListItem>
                                    <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                    <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell" style="width: 200px">
                                <asp:Label ID="lblSuministro" runat="server" Text="Suministro:" />
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="ddlSUMINISTROS1" runat="server" AutoPostBack="true" Enabled="False" Width="300" />
                                <%-- <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" Width="300" />--%></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblTipoDespachoIndividual" runat="server" Text="Tipo despacho:" />
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="ddlTIPOMOVIMIENTOS1" runat="server" Width="300" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="lblLugarDestino" runat="server" Text="Lugar destino:" />
                            </td>
                            <td class="DataCell">
                                <asp:DropDownList ID="ddlESTABLECIMIENTOS1" runat="server" Width="300" AutoPostBack="True"/>
                                <%--<cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" AutoPostBack="True" Width="300px" />--%>
                                <asp:CheckBox ID="cbVerTodos" runat="server" AutoPostBack="true" Text="Ver todos" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell" nowrap="nowrap">
                                <asp:Label ID="lblAlmacenDestino" runat="server" Text="Almacén destino:" />
                            </td>
                            <td class="DataCell">
                                 <asp:DropDownList ID="ddlALMACENES1" runat="server" Width="300" />
                                <%--<cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="300" />--%>
                                <asp:Label ID="lblNoAlmacenAsociado" runat="server" Text="El lugar de destino no tiene ningún almacén asociado." />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label runat="server" Text="Fecha despacho" ID="lblfecha" />
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="cpFechaDespacho" CssClass="datefield" runat="server" DisableTextBoxEntry="False" />
                               
                                <asp:RequiredFieldValidator ID="rfvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                                    ErrorMessage="*" />
                                <asp:CompareValidator ID="cvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                                    ErrorMessage="La fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
                                    Type="Date" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" GroupingText="Productos">
                    <asp:Panel ID="plAgregarProducto" runat="server" Visible="false">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" CssClass="Grid" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPRODUCTO" Visible="False">
                             <HeaderStyle CssClass="GridListHeader" />
                        <FooterStyle CssClass="GridListFooter" />
                        <PagerStyle CssClass="GridListPager" />
                        <RowStyle CssClass="GridListItem" />
                        <SelectedRowStyle CssClass="GridListSelectedItem" />
                        <EditRowStyle CssClass="GridListEditItem" />
                        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="&gt;&gt;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" ItemStyle-Width="5%">
                                <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DESCLARGO" HeaderText="Descripción" ItemStyle-Width="40%">
                                <ItemStyle Width="40%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cantidaddistribuir" HeaderText="Cantidad a Distribuir">
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                </Columns>
                        </asp:GridView>
                        <br />
                        <asp:RadioButtonList ID="rdblCriterio" runat="server" CssClass="noblock" AutoPostBack="True"
                            RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem Selected="True" Value="0" Text="Búsqueda por código" />
                            <asp:ListItem Value="1" Text="Por selección" />
                        </asp:RadioButtonList>
                        <div>
                            <asp:Button ID="btnActivarFiltro" runat="server" CausesValidation="False" Text="Activar filtro para selección"
                                Visible="False" />
                            <asp:Panel ID="plFiltroSeleccion" runat="server" Width="100%" Visible="False">
                                <table style="width: 100%;">
                                    <tr>
                                        <td class="LabelCell">
                                            Tipo suministro:
                                        </td>
                                        <td class="DataCell">
                                            <%--<asp:DropDownList ID="ddlTIPOSUMINISTROS1" runat="server" Width="300" AutoPostBack="True"/>--%>
                                            <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" Width="400px" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            Grupo:
                                        </td>
                                        <td class="DataCell">
                                            <%--<asp:DropDownList ID="ddlGRUPOS1" runat="server" Width="300" AutoPostBack="True"/>--%>
                                            <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Width="400px" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="LabelCell">
                                            Sub grupo:
                                        </td>
                                        <td class="DataCell">
                                            <%--<asp:DropDownList ID="ddlSUBGRUPOS1" runat="server" Width="300" AutoPostBack="True"/>--%>
                                            <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" Width="400px" AutoPostBack="True" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                        <table>
                            <tr>
                                <td class="LabelCell">
                                    &nbsp;</td>
                                <td class="DataCell">
                                    <%--<asp:DropDownList ID="ddlCATALOGOPRODUCTOS1" runat="server" Width="300" AutoPostBack="True" Visible="False"/>--%>
                                    <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"  Visible="False" Width="400px" />
                                    <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Width="88px" Visible="False" />
                                    <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                                        ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Buscar" SetFocusOnError="True" />
                                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="79px" ValidationGroup="Buscar" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="plBuscarDistribucion" runat="server" GroupingText="Buscar distribución"
                        Visible="false">
                        <table style="width: 100%;">
                            <tr>
                                <td class="LabelCell">
                                    Establecimiento:
                                </td>
                                <td class="DataCell">
                                    <%--<asp:DropDownList ID="ddlESTABLECIMIENTOS2" runat="server" Width="300" />--%>
                                    <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS2" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Fuente de financiamiento:
                                </td>
                                <td class="DataCell">
                                    <%--<asp:DropDownList ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="300" />--%>
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
                    <asp:GridView ID="gvLista" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDLOTE,IDDETALLEMOVIMIENTO,IDPRODUCTO,CANTIDAD,FECHAVENCIMIENTO,CODIGODETALLE"
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
                                    <%#Eval("CODIGODETALLE").ToString + "<br />" + Eval("FECHAVENCIMIENTOMMAAAA").ToString%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="FUENTEFINANCIAMIENTO" HeaderText="Fuente financ." ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n2}"
                                HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" />
                            <asp:BoundField DataField="UBICACION" HeaderText="Ubicación" />
                            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio"  DataFormatString="{0:0.00}"
                                HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="TOTAL" HeaderText="Total"  DataFormatString="{0:0.00}" HtmlEncode="False"
                                ItemStyle-HorizontalAlign="Right" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" ToolTip="Eliminar registro" runat="server" AlternateText="Elimina el registro"
                                        CommandName="Delete" CausesValidation="False" CssClass="GridImagenEliminarItem"
                                        Text="Eliminar" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                                        Visible='<%# Iif (Eval("IDESTADO") = 1, True, False) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <!--ELEMENTOS DEL POPUP-->
                    <asp:Panel ID="plDatosProducto" runat="server" CssClass="pupform">
                        <asp:LinkButton ID="btnClose" runat="server" Text="X" CssClass="pupCerrar" />
                        <asp:Label ID="lblCORRPRODUCTO" runat="server" Visible="False" />
                        <asp:Label ID="lblDESCLARGO" runat="server" Visible="False" />
                        <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="false" CellPadding="4"
                            GridLines="None" CssClass="Grid" DataKeyNames="IDLOTE,CODIGO,IDPRODUCTO,CORRPRODUCTO,DESCLARGO"
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
                                        <asp:TextBox ID="nbCantidad" CssClass="cantidades" runat="server" DataFormatString="{0:n2}" /><br />
                                        <asp:RangeValidator ID="cvCantidad" runat="server" ControlToValidate="nbCantidad"
                                            ValidationGroup="vLote" Display="Dynamic" ForeColor="#B20000" MaximumValue='<%# Eval("CANTIDAD") %>'
                                            MinimumValue='<%#Math.Pow(10, -1 * Eval("CANTIDADDECIMAL"))%>' Text="La cantidad debe ser mayor a cero y menor o igual a la disponible."
                                            Type="Double" Font-Size="Smaller" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                No hay lotes disponibles.</EmptyDataTemplate>
                        </asp:GridView>
                        <hr noshade="noshade" />
                        <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote(s)" ValidationGroup="GuardarLote" />
                        <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
                    </asp:Panel>
                    <asp:HiddenField ID="pupTarget" runat="server" />
                    <asp:ModalPopupExtender ID="ModalPup" runat="server" PopupControlID="plDatosProducto"
                        BackgroundCssClass="PopUpBg" CancelControlID="btnClose" TargetControlID="pupTarget">
                    </asp:ModalPopupExtender>
                    <!--ELEMENTOS DEL POPUP-->
                </asp:Panel>
                <asp:Panel ID="plGenerales" runat="server" Width="100%" Visible="false">
                    <table style="width: 100%;">
                        <tr>
                            <td class="LabelCell" style="width: 200px">
                                Preparó:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtEMPLEADOPREPARA" runat="server" MaxLength="75" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                Nombre del transportista:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtTransportista" runat="server" MaxLength="75" Width="300px" />
                                <asp:RequiredFieldValidator ID="rfvTransportista" runat="server" ControlToValidate="txtTransportista"
                                    ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                Matricula del vehículo:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtMatricula" runat="server" MaxLength="10" Width="143px" />
                                <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula"
                                    ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                Persona que recibe:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtRecibe" runat="server" MaxLength="75" Width="300px" />
                                <asp:RequiredFieldValidator ID="rfvRecibe" runat="server" ControlToValidate="txtRecibe"
                                    ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
                            </td>
                        </tr>
                        <tr valign="middle">
                            <td class="LabelCell">
                                Documento de quien recibe:
                            </td>
                            <td class="DataCell">
                                 <asp:DropDownList ID="ddlTIPOIDENTIFICACION1" runat="server"  />
                                <%--<cc1:ddlTIPOIDENTIFICACION ID="ddlTIPOIDENTIFICACION1" runat="server" Width="143px" />--%>
                                <asp:TextBox ID="txtNumeroDocumento" Width="154" runat="server" MaxLength="15" />
                                <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" ControlToValidate="txtNumeroDocumento"
                                    ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell" nowrap="nowrap">
                                Responsable almacén despacho:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtEmpleadoAlmacen" runat="server" MaxLength="150" Width="300px" />
                                <asp:RequiredFieldValidator ID="rfvEmpleadoAlmacen" runat="server" ControlToValidate="txtEmpleadoAlmacen"
                                    ErrorMessage="*" ValidationGroup="Cerrar" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell" valign="top">
                                Observaciones:
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtObservacion" runat="server" CssClass="TextBoxMultiLine" MaxLength="1000"
                                    TextMode="MultiLine" Width="300" Height="50" />
                            </td>
                        </tr>
                    </table>
                    <div>
                        <hr noshade="noshade" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar despacho" />
                        <asp:Button ID="btnCerrar" runat="server" Enabled="False" Text="Cerrar despacho"
                            ValidationGroup="Cerrar" />
                        <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Vale Salida"
                            UseSubmitBehavior="False" />
                    </div>
                </asp:Panel>
                
            </div>
      <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
