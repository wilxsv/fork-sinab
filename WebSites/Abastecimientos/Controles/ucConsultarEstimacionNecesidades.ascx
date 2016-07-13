<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucConsultarEstimacionNecesidades.ascx.vb" Inherits="Controles_ucConsultarEstimacionNecesidades" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<table style="width: 100%">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label14" runat="server" Text="Año de la compra:" />
        </td>
        <td class="DataCell">
            <ew:NumericBox ID="txtAnnio" runat="server" PositiveNumber="true" MaxLength="4" Width="76px" RealNumber="False" />&nbsp;
            <asp:RangeValidator ID="RgvValidacionAño" runat="server" ErrorMessage="El año de la compra no es valido."
                MaximumValue="3000" MinimumValue="2000" SetFocusOnError="True" ControlToValidate="txtAnnio">El año de la compra no es valido.</asp:RangeValidator></td> 
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Suministro:" Width="80px" /></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" AutoPostBack="True" Width="295px">
            </cc1:ddlSUMINISTROS></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label10" runat="server" Text="Propuesta:" Visible="False" />&nbsp;
        </td>
        <td class="DataCell">    
            <asp:DropDownList ID="DdlPROPUESTASDISPONIBLES1" runat="server" Width="43px">
                <asp:ListItem Value="1">A</asp:ListItem>
                <asp:ListItem Value="2">B</asp:ListItem>
                <asp:ListItem Value="3">C</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="BtnValidarAnio" runat="server" Text="Buscar" Width="100px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Realiza la busqueda de las propuestas disponibles para el año y suministro seleccionado." />
            <asp:Button ID="BtnIniciar" runat="server" Text="Iniciar revisión" Width="112px" Visible="False" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Inicia el proceso de revisión para el año y el suministro seleccionado." /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: left; background: #b5c7de ">
            <asp:Label ID="Label2" runat="server" Text="Seleccione la forma en que desea ver el listado de necesidades" Font-Bold="True" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:RadioButtonList ID="ddlTipoListado" runat="server" AutoPostBack="True" BackColor="Transparent" BorderColor="#507CD1" BorderStyle="Solid" Visible="False" BorderWidth="1px">
                <asp:ListItem Value="1">Por Regi&#243;n</asp:ListItem>
                <asp:ListItem Value="2">Establecimiento</asp:ListItem>
                <asp:ListItem Value="3">Consolidado a nivel nacional</asp:ListItem> 
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center" >
            <asp:Panel ID="PnlNecesidades" runat="server" Width="100%">
                        
            <asp:DataGrid ID="dgListadoNecesidades" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Establecimiento"></asp:BoundColumn>
                    <asp:BoundColumn DataField="FECHAELABORACION" HeaderText="Fecha Elaboraci&#243;n"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Anno" HeaderText="A&#241;o de la compra"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDESTABLECIMIENTO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDNECESIDAD" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PRESUPUESTOASIGNADO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADREAL" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADAJUSTADA" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADFINAL" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid>
            </asp:Panel>
            <asp:Panel ID="PnlConsolidadoSibasi" runat="server" Width="100%">
                        
            <asp:DataGrid ID="dgConsolidadoPorSibasi" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Establecimiento"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Anno" HeaderText="A&#241;o de la compra"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Estado" HeaderText="Estado"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPADRE" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PRESUPUESTOASIGNADO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADREAL" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADAJUSTADA" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTONECESIDADFINAL" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></asp:Panel>
        </td>
    </tr>
</table>
        
<asp:Panel ID="PnlDetalleNecesidad" runat="server" Width="100%" Visible="false" >
    <table style="width: 100%">
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Fecha:" /></td>
            <td class="DataCell">
                <asp:Label ID="lblFechaEnvio" runat="server" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Estado:" /></td>
            <td class="DataCell">
                <asp:Label ID="LblEstado" runat="server" Width="120px" />
                <cc1:ddlESTADOSNECESIDADES ID="DdlESTADOSNECESIDADES1" runat="server" AutoPostBack="True"
                    Visible="False">
                </cc1:ddlESTADOSNECESIDADES></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="Establecimiento:" /></td>
            <td class="DataCell">
                <asp:Label ID="lblEstablecimiento" runat="server" Width="305px" />
                <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" AutoPostBack="True"
                    Width="121px" Visible="False">
                </cc1:ddlESTABLECIMIENTOS></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Lugar de entrega:" /></td>
            <td class="DataCell">
                <asp:Label ID="lblLugarEntrega" runat="server" Width="305px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="Dirección del almacen:" /></td>
            <td class="DataCell">
                <asp:Label ID="lblDireccionAlmacen" runat="server" Width="305px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Observaciones del proceso de compra:" /></td>
            <td class="DataCell">
                <asp:Label ID="lblObservaciones" runat="server" Width="305px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="BtnAsesoria" runat="server" Text="Ir a asesoria" Width="191px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Salir de la pantalla actual y abrir la pantalla de asesoría a establecimientos." />
                <asp:Button ID="BtnIrconsultasinventario" runat="server" Text="Ir a consultas al inventario" Width="183px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Sale de la pantalla actual y abre la pantalla de consultas al inventario." />&nbsp;
                </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="PnlListadoFiltrosProductos" runat="server" Width="80%" Visible="false" BorderColor="Transparent" Font-Bold="True" ForeColor="DarkBlue" GroupingText="Filtro de productos" HorizontalAlign="Center"   >
    <table style="width: 100%">
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Criterio:" Font-Bold="True" Width="77px" />
            </td>
            <td class="DataCell">
                <asp:DropDownList ID="DdlPresentacion" runat="server" AutoPostBack="True" Width="183px">
                    <asp:ListItem Value="1">Grupo</asp:ListItem>
                    <asp:ListItem Value="2">Subgrupo</asp:ListItem>
                    <asp:ListItem Value="3">Producto especifico</asp:ListItem>
                </asp:DropDownList>
                <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Width="286px">
                </cc1:ddlGRUPOS>
                <cc1:ddlGRUPOS ID="DdlGRUPOS2" runat="server" AutoPostBack="True"
                    Visible="False" Width="270px">
                </cc1:ddlGRUPOS>&nbsp;<cc1:ddlSUBGRUPOS ID="DdlSUBGRUPOS1" runat="server" Visible="False"
                    Width="260px">
                </cc1:ddlSUBGRUPOS>
                <asp:TextBox ID="TxtBuscar" runat="server" Width="105px" Visible="False"></asp:TextBox>
                <asp:Button ID="BtnFiltrar" runat="server" CausesValidation="False" Text="Filtrar" Width="71px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Aplica el filtro seleccionado." />
                <asp:Button ID="BtnRestaurar" runat="server" CausesValidation="False" Text="Restaurar" Width="71px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Restaura la información del detalle de productos." />
            </td>
        </tr>   
    </table>
</asp:Panel>
<asp:Panel ID="PnlListadoProductos" runat="server" Width="100%" Visible="false" >
    <table width="100%">
        <tr>
            <td colspan="2" style="width:100%; text-align: center">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Detalle de presupuestos" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Asignado:" /></td>
            <td class="DataCell">
                $<asp:Label ID="LblPresupuestoAsignado" runat="server" Text="0" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Real:" />
            </td>
            <td class="DataCell">
                $<asp:Label ID="LblPresupuestoRealTotal" runat="server" Text="0" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label15" runat="server" Text="Ajustado:" />&nbsp;</td>
            <td class="DataCell">
                $<asp:Label ID="LblPresupuestoAjustadoTotal" runat="server" Text="0" />&nbsp;</td>
            
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Final:" />&nbsp;</td>
            <td class="DataCell">
                $<asp:Label ID="LblPresupuestoFinalTotal" runat="server" Text="0" />        
            </td>             
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="BtnImprimirReporteDeficit" runat="server" Text="Imprimir reporte deficit" Width="180px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Imprime el reporte de deficit de la estimación de necesidades." />
                <asp:Button ID="BtnImprimir" runat="server" Text="Imprimir reporte general" Width="185px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Imprime el reporte general de la estimación de necesidades." />
                <asp:Button ID="BtnMostrarFiltro" runat="server" Text="Mostrar filtro productos" Width="183px" BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Permite filtrar el detalle de productos." /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 21px; text-align: center;">
                <asp:DataGrid ID="dgDetalleProductos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                    AutoGenerateColumns="False" AllowPaging="True" PageSize="7" Width="100%" Font-Bold="False">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" HorizontalAlign="Left" />
                    <EditItemStyle BackColor="#2461BF" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <ItemStyle BackColor="#EFF3FB" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                    <Columns>
                        <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" Visible="False">
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="False" />
                        </asp:ButtonColumn>
                        <asp:BoundColumn DataField="IDPRODUCTO" HeaderText="IdProducto" Visible="False" >
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="False" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="False" VerticalAlign="Top"/>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DESCLARGO" HeaderText="Nombre">
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="False" VerticalAlign="Top" Width="400px"  />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="PRECIOUNITARIO" HeaderText="Precio" DataFormatString="{0:C}">
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="False" VerticalAlign="Top" />
                        </asp:BoundColumn>
                                                
                        <asp:TemplateColumn HeaderText="Consumo&#160;anual&lt;br /&gt; Demanda&#160;insatis.&lt;br /&gt; Reserva&lt;br /&gt;Total">
                            <ItemTemplate>
                                <asp:Label ID="LblConsumoAnual" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CONSUMOANUAL") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblDemandaInsatisfecha" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DEMANDAINSATISFECHA") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblReservaEstablecimiento" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RESERVAESTABLECIMIENTO") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblTotal" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TOTAL") %>'
                                    Visible="True" />
                            </ItemTemplate>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateColumn>
                        
                        <asp:BoundColumn DataField="EXISTENCIAESTIMADA" HeaderText="Existencia estimada">
                            <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" Wrap="True" VerticalAlign="Top"/>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" VerticalAlign="Top" />
                        </asp:BoundColumn>
                        
                        <asp:TemplateColumn HeaderText="Necesidad&lt;br /&gt; -Real&lt;br /&gt; -Ajustada&lt;br /&gt;-Final">
                            <ItemTemplate>
                                <asp:Label ID="LblNecesidadReal" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADREAL") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblNecesidadAjustada" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADAJUSTADA") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblNecesidadFinal" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NECESIDADFINAL") %>'
                                    Visible="True" />
                            </ItemTemplate>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="Presupuesto&lt;br /&gt; -Real&lt;br /&gt;-Ajustado&lt;br /&gt;-Final">
                            <ItemTemplate>
                                <asp:Label ID="LblPresupuestoReal" runat="server" Text='<%# Format(DataBinder.Eval(Container, "DataItem.PRESUPUESTOARTICULO"), "C") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblPresupuestoAjustado" runat="server" Text='<%# Format(DataBinder.Eval(Container, "DataItem.PRESUPUESTOARTICULOAJUSTADO"), "C") %>'
                                    Visible="True" /><br />
                                <asp:Label ID="LblPresupuestoFinal" runat="server" Text='<%# Format(DataBinder.Eval(Container, "DataItem.PRESUPUESTOARTICULOFINAL"), "C") %>'
                                    Visible="True" />
                            </ItemTemplate>
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Ayuda Externa">
                            <ItemTemplate>
                                <asp:LinkButton ID="LnkbAyudaExterna" OnClick="MostrarAyudaExterna" runat="server" CausesValidation="False" 
                                    CommandName='<%#container.dataitem("IDPRODUCTO")%>' CommandArgument='<%#container.dataitem("NECESIDADFINAL")%>'  text=">>">
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" VerticalAlign="Top"  />
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                        </asp:TemplateColumn>
                        
                    </Columns>
                 </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Panel>

<nds:MsgBox ID="MsgBox1" runat="server" />
