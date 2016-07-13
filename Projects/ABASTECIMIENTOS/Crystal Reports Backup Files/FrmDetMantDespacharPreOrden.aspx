<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmDetMantDespacharPreOrden.aspx.vb" Inherits="FrmDetMantDespacharPreOrden" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controles/LotesDespacho/ProductoCantidad.ascx" TagName="ProductoCantidad"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén -> Despachar productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <asp:Panel  runat="server" ID="buscador">
        <table width="100%" cellspacing="0" cellpadding="2" class="form">
            <tr>
                <td nowrap="nowrap">
                    <asp:Label runat="server" AssociatedControlID="tbBuscador" ID="lbl1" Text="Código de requisición:" />
                </td>
                <td width="100%">
                    <asp:TextBox runat="server" ID="tbBuscador" Width="100%" />
                </td>
                <td style="padding-left: 10px;">
                    <asp:Button runat="server" ID="Buscar" Text="Buscar" />
                </td>
            </tr>
        </table>
        <hr noshade="noshade" style="margin-top: 20px" />
    </asp:Panel>
    <div class="CenteredTable">
        
        <asp:MultiView ID="mvRequisicion" runat="server">
            <asp:View ID="vForm" runat="server">
                 <div style="margin-left: 20px">
                        <h1>
                            <asp:Literal ID="lblNroVale" runat="server" /><asp:Literal
                                ID="txtNroVale" runat="server" />
                        </h1>
                        <table style="width: 100%;">
                            <tr>
                                <td class="LabelCell" nowrap="nowrap">
                                    <asp:Label ID="lblSuministros" runat="server" Text="Suministro:" />
                                </td>
                                <td class="DataCell" width="100%">
                                    <asp:Label ID="lblSuministro" runat="server" Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell" nowrap="nowrap">
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
                                    <asp:Label Font-Bold="true" ID="lbEstablecimiento" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell" nowrap="nowrap">
                                    <asp:Label ID="lblAlmacenDestino" runat="server" Text="Almacén destino:" />
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="lblAlmacenAsociado" runat="server" Text="El lugar de destino no tiene ningún almacén asociado."
                                        Font-Bold="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Fecha despacho:
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="cpFechaDespacho" CssClass="datefield" runat="server" Width="100px" />
                                    <asp:CompareValidator ID="cvFechaDespacho" runat="server" ControlToValidate="cpFechaDespacho"
                                        ErrorMessage="Fecha debe ser menor o igual a la actual." Operator="LessThanEqual"
                                        Type="Date" />
                                </td>
                            </tr>
                           
                        </table>
                    </div>
                    
                    <asp:Panel ID="productosPanel" runat="server" GroupingText="Productos" >
                        
                        <asp:GridView ID="gvLista" CssClass="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            GridLines="None" Width="100%" DataKeyNames="IDLOTE,IDDETALLEMOVIMIENTO,IDPRODUCTO,CANTIDAD,CORRPRODUCTO"
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
                       
                    </asp:Panel>
                    <asp:Panel ID="panelPendientes" runat="server" GroupingText="Productos Pendientes">
                        <asp:Repeater runat="server" ID="rPreorden">
                            <HeaderTemplate>
                                <table class="Grid" cellpadding="5" cellspacing="0" width="100%">
                                    <tr class="GridListHeader">
                                        <th align="left">
                                            Código
                                        </th>
                                        <th width="100%">
                                            Nombre
                                        </th>
                                        <th>
                                            Cantidad
                                        </th>
                                        <td>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <AlternatingItemTemplate>
                                <tr class="GridListAlternatingItem" align="left">
                                    <td>
                                        <%# Eval("Codigo")%>
                                    </td>
                                    <td>
                                        <%# Eval("Nombre")%>
                                    </td>
                                    <td>
                                        <%# Eval("Cantidad")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="BtnProcesar" OnCommand="Procesar" CommandName="Procesar"
                                            CommandArgument='<%# Eval("Id").ToString()+","+Eval("Codigo")+","+Eval("Cantidad").ToString()%>' Text="Procesar" />
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <ItemTemplate>
                                <tr class="GridListItem" align="left">
                                    <td>
                                        <%# Eval("Codigo")%>
                                    </td>
                                    <td>
                                        <%# Eval("Nombre")%>
                                    </td>
                                    <td>
                                        <%# Eval("Cantidad")%>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" ID="BtnProcesar" OnCommand="Procesar" CommandName="Procesar"
                                            CommandArgument='<%# Eval("Id").ToString()+","+Eval("Codigo")+","+Eval("Cantidad").ToString() %>' Text="Procesar" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>

                        <asp:Panel ID="pPop" runat="server" CssClass="pupform">
                            <asp:LinkButton ID="btnClose" runat="server" Text="X" CssClass="pupCerrar" />
                            <uc1:ProductoCantidad ID="ProductosLotes" runat="server" />
                            <hr noshade="noshade" />
                            <asp:Button ID="btnAgregarLote" runat="server" Text="Guardar Lote(s)" ValidationGroup="vLote" />
                        </asp:Panel>

                        <asp:HiddenField ID="pupTarget" runat="server" />

                        <asp:ModalPopupExtender ID="ModalPup" runat="server" PopupControlID="pPop" BackgroundCssClass="PopUpBg" 
                        CancelControlID="btnClose" TargetControlID="pupTarget" >
                        </asp:ModalPopupExtender>

                    </asp:Panel>
                    <asp:Panel ID="plGenerales" runat="server" Width="100%">
                        <table style="width: 100%;">
                            <tr>
                                <td class="LabelCell">
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
                            <tr>
                                <td class="LabelCell">
                                    Documento de quien recibe:
                                </td>
                                <td class="DataCell">
                                    <asp:DropDownList ID="ddlTIPOIDENTIFICACION1" runat="server" />
                                    <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="15" Width="143px" />
                                    <asp:RequiredFieldValidator ID="rfvNumeroDocumento" runat="server" ControlToValidate="txtNumeroDocumento"
                                        ErrorMessage="*" ValidationGroup="Cerrar" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
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
                                        TextMode="MultiLine" Width="300px" />
                                </td>
                            </tr>
                            
                        </table>
                        <hr noshade="noshade"/>
                        <div>
                             <asp:Button ID="btnGuardar" runat="server" Text="Guardar despacho" />
                                    <asp:Button runat="server" ID="btnProcesar" Text="Procesar despacho" ValidationGroup="Cerrar"
                            Visible="False" />
                                    <asp:Button ID="btnCerrar" runat="server" Enabled="False" Text="Cerrar despacho"
                                        ValidationGroup="Cerrar" />
                                    <asp:Button ID="btnImprimir" runat="server" Enabled="False" Text="Ver Vale Salida"
                                        UseSubmitBehavior="False" />
                        </div>
                    </asp:Panel>
            </asp:View>
             <asp:View ID="vError" runat="server">
                <div class="error">
                    <asp:Literal runat="server" ID="errorMsj"/>
                </div>
            </asp:View>
        </asp:MultiView>
               
         
    </div>
</asp:Content>
