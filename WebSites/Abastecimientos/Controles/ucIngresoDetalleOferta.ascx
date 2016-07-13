<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucIngresoDetalleOferta.ascx.vb"
    Inherits="ucIngresoDetalleOferta" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Src="ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
    TagPrefix="uc1" %>
<div class="CenteredTable">
    <asp:Panel runat="server" ID="divError">
        <asp:Label ID="lblWarning" runat="server" Font-Bold="True" ForeColor="Red" />
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Width="100%">
        <h3>
                    <asp:Label ID="Label5" runat="server" Text="Listado de ofertas por orden de llegada"
                        Font-Bold="True" />
                </h3>
                    <asp:DataGrid ID="dgOfertaPresentada" CssClass="Grid" runat="server" CellPadding="4" 
                        GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="5"
                        Width="100%">
                       <EditItemStyle CssClass="GridListEditItem" />
                        <SelectedItemStyle CssClass="GridListSelectedItem" />
                        <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                        <ItemStyle CssClass="GridListItem" />
                        <HeaderStyle CssClass="GridListHeader" />
                        <FooterStyle CssClass="GridListFooter" />
                        <PagerStyle CssClass="GridListPager" HorizontalAlign="Center" Mode="NumericPages" />
                        
                        
                        <Columns>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CausesValidation="false" CommandName="Select" 
                                                    CssClass="GridIrA"/>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="ORDENLLEGADA" HeaderText="Orden" 
                                ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor" 
                                ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PERSONAENTREGA" HeaderText="Persona entrega oferta" 
                                ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FECHAENTREGA" HeaderText="Hora de entrega" 
                                ItemStyle-HorizontalAlign="Left">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDPROVEEDOR" ItemStyle-HorizontalAlign="Left" 
                                Visible="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
               
               
                    <asp:Panel ID="Panel1" runat="server" Visible="False" style="margin: 10px 0">
                        <table class="CenteredTable" style="width: 100%">
                            <tr>
                                <td class="LabelClass">
                                    <asp:Label ID="Label6" runat="server" Text="Orden en que llegó la oferta:" />
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="lblOrden" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelClass">
                                    <asp:Label ID="Label7" runat="server" Text="Proveedor:" />
                                </td>
                                <td class="DataCell">
                                    <asp:DropDownList ID="ddlProveedorEntregaBase" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelClass">
                                    <asp:Label ID="Label8" runat="server" Text="Nombre de la persona que entrega la oferta:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtPersonaEntrega" runat="server" Width="353px" MaxLength="150" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPersonaEntrega"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label9" runat="server" Text="Hora de entrega:" />
                                </td>
                                <td class="DataCell">
                                    <ew:TimePicker ID="tpHoraEntrega" runat="server" MinuteInterval="FiveMinutes" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                
            <div>
                    <asp:RadioButtonList ID="rblCargaDisco" runat="server" AutoPostBack="True" Visible="False">
                        <asp:ListItem Value="S" Text="La información se cargará del disco" />
                        <asp:ListItem Value="N" Text="El usuario no presentó el disco" />
                    </asp:RadioButtonList>
                </div>
                <div>
                <div>
                    <asp:Label ID="Label40" runat="server" Text="A continuación debera cargar los archivos del disco proporcionado por el proveedor:"
                        Visible="False" /></div>
            <div>
                    <asp:Label ID="Label47" runat="server" Text="Archivos que deberá cargar: CDETOFERTA.DBF, CDETOFERTA.FPT, CFINAN.DBF"
                        Visible="False" />
                </div>
                   
            </div>  
            <asp:Panel runat="server" GroupingText="Lista de archivos que han sido cargados" Visible="False" ID="Label46">
                    <asp:ListBox ID="ListBox1" runat="server" Enabled="False" 
            Visible="False" Width="400px" />
              </asp:Panel>  
            <div>
                    <asp:FileUpload ID="MyFile" runat="server" Visible="false" />
                    <asp:Button ID="imbCargaDatos" runat="server" Text="Cargar archivos" Visible="False" />
                </div>
            <div>
                    <asp:Button ID="btnLeerInformacion" runat="server" Text="Lectura de archivos" Visible="False" />
                </div>
            <div>
                    <asp:Label ID="Mensaje" runat="server" />
                </div>
            <div>
                    <asp:Label ID="Label48" runat="server" />
                </div>
            <div>
                    <asp:Label ID="Label49" runat="server" />
                </div>
            <asp:panel runat="server" ID="pMostarDatos" Visible="False" style="margin: 10px 0">
                    <asp:Button ID="LinkButton1" runat="server" Text="Datos Financieros" CausesValidation="False" />
                    <asp:Button ID="LinkButton2" runat="server" Text="Datos del Producto" CausesValidation="False" />
               </asp:panel>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
       
        <h3>
        <asp:Label ID="Label13" runat="server" Text="Si el usuario no presenta el disco para cargar los datos, deberá ingresar los datos de la oferta" /></h3>
                        <div class="ScrollPanel">
                        <asp:GridView ID="dgDetalleOferta" CssClass="Grid" runat="server" CellPadding="4" GridLines="None"
                        Width="100%" AutoGenerateColumns="False" DataKeyNames="IDDETALLE,CORRELATIVORENGLON">
                        <HeaderStyle CssClass="GridListHeader" />
                        <FooterStyle CssClass="GridListFooter" />
                        <PagerStyle CssClass="GridListPager" />
                        <RowStyle CssClass="GridListItem" />
                        <EditRowStyle CssClass="GridListEditItem" />
                        <SelectedRowStyle CssClass="GridSelectedItem" />
                        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                        <Columns>
                            <asp:TemplateField ShowHeader="False" ItemStyle-VerticalAlign="Top">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                        CommandName="Select" CssClass="GridIrA" ></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="RENGLON" HeaderText="Renglon" 
                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MARCA" HeaderText="Marca" 
                                ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" 
                                HeaderText="Descripción del Proveedor" ItemStyle-HorizontalAlign="Left">
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
    </div>
           <uc2:ucBarraNavegacion ID="ucBarraNavegacion2" runat="server" />
                    <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
                        <div class="NavBar">
                             <asp:LinkButton ID="imbGuardar" CssClass="opGuardar" runat="server" Text="Guardar" Width="50px" />
                           
                                    <asp:LinkButton ID="imbCancelar" runat="server" CssClass="opCancelar" Text="Cancelar" Width="50px" CausesValidation="False" />
                        </div>
                        <table class="CenteredTable" style="width: 100%">
                            <tr>
                                <td colspan="2" style="text-align: left">
                                   
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label15" runat="server" Text="Número del proceso de compra:" />
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="lblProcesoCompra" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label14" runat="server" Text="Proveedor:" />
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="lblProveedor" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label16" runat="server" Text="Renglón:" />
                                </td>
                                <td class="DataCell">
                                    <asp:DropDownList ID="ddlRenglon" runat="server" AutoPostBack="True" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label17" runat="server" Text="Casa representada:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtCasaRepresentada" runat="server" Width="317px" MaxLength="75" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCasaRepresentada"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label19" runat="server" Text="Descripción:" />
                                </td>
                                <td class="DataCell">
                                    <asp:Label ID="lblDescripcionGenericaProducto" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label12" runat="server" Text="Descripción proporcionada por el proveedor:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtDescripcionProveedor" runat="server" Width="357px" Rows="5" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcionProveedor"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label20" runat="server" Text="Marca:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtMarcaProductoOfertado" runat="server" Width="329px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMarcaProductoOfertado"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label21" runat="server" Text="Origen:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtOrigen" runat="server" Width="323px" MaxLength="30" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtOrigen"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label18" runat="server" Text="Vencimiento:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtVencimiento" runat="server" Width="237px" MaxLength="50" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVencimiento"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label22" runat="server" Text="Unidad de medida:" />
                                </td>
                                <td class="DataCell">
                                    <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label23" runat="server" Text="Cantidad:" />
                                </td>
                                <td class="DataCell">
                                    <ew:NumericBox ID="txtCantidad" runat="server" PositiveNumber="True" Width="107px"
                                        DecimalPlaces="2" MaxLength="15" TextAlign="Right" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label24" runat="server" Text="Precio unitario:" />
                                </td>
                                <td class="DataCell">
                                    <ew:NumericBox ID="txtPrecioUnitario" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
                                        Width="109px" DecimalPlaces="4" MaxLength="18" TextAlign="Right" />
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Calcular precio total" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPrecioUnitario"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label25" runat="server" Text="Precio total (calculado):" />
                                </td>
                                <td class="DataCell">
                                    <ew:NumericBox ID="txtPrecioTotalCalculado" runat="server" ReadOnly="True" Width="125px"
                                        AutoFormatCurrency="True" DecimalPlaces="4" MaxLength="15" TextAlign="Right" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPrecioTotalCalculado"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label26" runat="server" Text="Plazo de entrega:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtPlazoEntrega" runat="server" Width="277px" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPlazoEntrega"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label27" runat="server" Text="Número CSSP (opcional):" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtCSSP" runat="server" Width="277px" MaxLength="20" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label28" runat="server" Text="Vigencia de la oferta:" />
                                </td>
                                <td class="DataCell">
                                    <asp:TextBox ID="txtVigenciaOferta" runat="server" Width="277px" MaxLength="100" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtVigenciaOferta"
                                        ErrorMessage="Requerido" />
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label29" runat="server" Text="Observaciones:" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtObservaciones" runat="server" Rows="5" TextMode="MultiLine" Width="429px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
               
    </asp:Panel>
    <asp:Panel ID="Panel5" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
            <tr>
                <td colspan="2">
                    <uc2:ucBarraNavegacion ID="ucBarraNavegacion3" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label30" runat="server" Text="Ingrese los Datos Financieros" Font-Bold="True" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label32" runat="server" Text="Número del proceso de compra:" />
                </td>
                <td class="DataCell">
                    <asp:Label ID="lblNo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label33" runat="server" Text="Proveedor:" />
                </td>
                <td class="DataCell">
                    <asp:Label ID="lblNombreProveedor" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label31" runat="server" Text="Fecha:" />
                </td>
                <td class="DataCell">
                    <asp:Label ID="lblFecha" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label11" runat="server" Text="Descripción del proceso de compra:" />
                </td>
                <td class="DataCell">
                    <asp:Label ID="lblDescripcionProcesoCompra" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label37" runat="server" Text="Razón social:" />
                </td>
                <td class="DataCell">
                    <asp:Label ID="lblRazonSocial" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label34" runat="server" Text="Activo Circulante:" />
                </td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtActivoCirculante" runat="server" AutoFormatCurrency="True"
                        TextAlign="Right" DecimalPlaces="2" MaxLength="12">$0</ew:NumericBox>
                    <asp:Label ID="Label42" runat="server" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label36" runat="server" Text="Pasivo Circulante:" />
                </td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtPasivoCirculante" runat="server" AutoFormatCurrency="True"
                        TextAlign="Right" DecimalPlaces="2" MaxLength="12">$0</ew:NumericBox>
                    <asp:Label ID="Label43" runat="server" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label35" runat="server" Text="Activo total:" />
                </td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtActivoTotal" runat="server" AutoFormatCurrency="True" TextAlign="Right"
                        DecimalPlaces="2" PlacesBeforeDecimal="12">$0</ew:NumericBox>
                    <asp:Label ID="Label44" runat="server" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label38" runat="server" Text="Pasivo total:" />
                </td>
                <td class="DataCell">
                    <ew:NumericBox ID="txtPasivoTotal" runat="server" AutoFormatCurrency="True" TextAlign="Right"
                        DecimalPlaces="2" PlacesBeforeDecimal="12">$0</ew:NumericBox>
                    <asp:Label ID="Label45" runat="server" ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label39" runat="server" Text="Referencias bancarias:" />
                </td>
                <td class="DataCell">
                    <asp:RadioButtonList ID="rblReferenciaBancaria" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1" Text="Si" />
                        <asp:ListItem Value="0" Text="No" />
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div>
        <asp:Label ID="lblMsg" runat="server" />
    </div>
</div>
<%--<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
--%>