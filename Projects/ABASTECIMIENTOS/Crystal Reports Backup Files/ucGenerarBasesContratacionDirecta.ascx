<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucGenerarBasesContratacionDirecta.ascx.vb" Inherits="Controles_ucGenerarBasesContratacionDirecta" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
&nbsp;<table class="CenteredTable" style="width: 100%">
    <tr>
        <td style="text-align: right;">
            <asp:Label ID="lblMensaje" runat="server" />&nbsp; &nbsp;<asp:ImageButton
                ID="imbGuardar" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" />
            <asp:Panel ID="pnlPaso1" runat="server"  Visible="False">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 1 Generar Datos.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="width: 356px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 356px; text-align: right">
                            <asp:Label ID="Label1" runat="server" Text="Número de la solicitud de cotización:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtCODIGOLICITACION" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCODIGOLICITACION"
                                ErrorMessage="Requerido"></asp:RequiredFieldValidator>
                            <asp:Label ID="lblPrefijoBase" runat="server" Visible="False" /></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; text-align: right">
                            <asp:Label ID="Label16" runat="server" Text="Nombre de la Compra Directa:" /></td>
                        <td style="text-align: left">
                            <asp:TextBox ID="txtTITULOLICITACION" runat="server" Width="285px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTITULOLICITACION"
                                ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; text-align: right">
                            <asp:Label ID="Label4" runat="server" Text="Entidad que realiza la Compra Directa:" /></td>
                        <td style="text-align: left">
                            <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Enabled="False">
                            </cc1:ddlESTABLECIMIENTOS>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label5" runat="server" Text="Descripción de la Compra Directa:" /></td>
                        <td style="height: 21px; text-align: left">
                            <asp:TextBox ID="txtDESCRIPCIONLICITACION" runat="server" Width="364px" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDESCRIPCIONLICITACION"
                                ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label22" runat="server" Text="Fecha y hora inicio para retiro de bases:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFechaInicioRetiroBases" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;
                            <ew:TimePicker ID="txtHoraInicioRetiroBases" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label23" runat="server" Text="Fecha y hora fin de retiro de bases:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFechaFinRetiroBases" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;
                            <ew:TimePicker ID="txtHoraFinRetiroBases" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFechaFinRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label8" runat="server" Text="Fecha y hora inicio para recepción de ofertas:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFECHAINICIORECEPCION" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;&nbsp;&nbsp;<ew:TimePicker ID="txtHORAINICIORECEPCION" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label9" runat="server" Text="Fecha y hora fin para recepción de ofertas:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFECHAFINRECEPCION" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;&nbsp;&nbsp;<ew:TimePicker ID="txtHORAFINRECEPCION" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label10" runat="server" Text="Fecha y hora inicio para apertura de ofertas:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFECHAINICIOAPERTURA" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;&nbsp;&nbsp;<ew:TimePicker ID="txtHORAINICIOAPERTURA" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFECHAINICIOAPERTURA"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label18" runat="server" Text="Fecha y hora fin para apertura de ofertas:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFECHAFINAPERTURA" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;&nbsp;&nbsp;<ew:TimePicker ID="txtHORAFINAPERTURA" runat="server" DisplayUnselectableTimes="True"
                                MinuteInterval="FiveMinutes" NumberOfColumns="3" Width="53px">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFECHAFINAPERTURA"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label6" runat="server" Text="Fecha y hora inicio para solicitar aclaraciones:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFechaInicioConsultasAclaraciones" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;
                            <ew:TimePicker ID="TimePicker1" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label7" runat="server" Text="Fecha y hora fin para solicitar aclaraciones:" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:CalendarPopup ID="txtFechaFinConsultasAclaraciones" runat="server" Width="84px">
                            </ew:CalendarPopup>
                            &nbsp;
                            <ew:TimePicker ID="TimePicker2" runat="server" Width="53px" MinuteInterval="FiveMinutes">
                            </ew:TimePicker>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                                ErrorMessage="Requerido" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label11" runat="server" Text="Dirección de UACI:" /></td>
                        <td style="height: 21px; text-align: left;">
                            <asp:Label ID="lblUACI" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label12" runat="server" Text="Municipio:" /></td>
                        <td style="height: 21px; text-align: left;">
                            <asp:Label ID="lblMunicipio" runat="server" /></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label17" runat="server" Text="Tiempo de entrega (días):" /></td>
                        <td style="height: 21px; text-align: left;">
                            <ew:NumericBox ID="txtTiempoEntrega" runat="server" Width="88px" />&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTiempoEntrega"
                                ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label13" runat="server" Text="Vigencia de la cotización (días):" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVIGENCIA" runat="server" Width="88px" />&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVIGENCIA"
                                ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label14" runat="server" Text="Garantía de cumplimiento de orden de compra (%):" /></td>
                        <td style="height: 21px; text-align: left">
                            <asp:TextBox ID="txtGarantiaCumplimientoOrdenCompra" runat="server" Width="87px"></asp:TextBox>&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtGarantiaCumplimientoOrdenCompra"
                                Display="Dynamic" ErrorMessage="Requerido"></asp:RequiredFieldValidator><ew:RangeValidator
                                    ID="RangeValidator2" runat="server" ControlToValidate="txtGarantiaCumplimientoOrdenCompra"
                                    Display="Dynamic" ErrorMessage="El valor debe estar en el rango adecuado" MaximumValue="99.99"
                                    MinimumValue="0.01"></ew:RangeValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                            <asp:Label ID="Label15" runat="server" Text="Garantía de buena calidad (%):" /></td>
                        <td style="height: 21px; text-align: left">
                            <ew:NumericBox ID="txtGARANTIACALIDADVALOR" runat="server" Width="88px" />&nbsp;
                            <ew:RangeValidator
                                    ID="RangeValidator1" runat="server" ControlToValidate="txtGARANTIACALIDADVALOR"
                                    Display="Dynamic" ErrorMessage="El valor debe estar en el rango adecuado" MaximumValue="99.99"
                                    MinimumValue="0.01"></ew:RangeValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                        </td>
                        <td style="height: 21px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 356px; height: 21px; text-align: right">
                        </td>
                        <td style="height: 21px; text-align: right">
                            <asp:LinkButton ID="LinkButton1" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Panel ID="pnlPaso2" runat="server"  Visible="False" Width="0px">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Imagenes/paso 2 Detalle productos.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 26px; text-align: right">
                            <asp:Panel ID="Panel1" runat="server" Height="300px" Width="125px" ScrollBars="Vertical">
                                <asp:DataGrid ID="dgDetalleProductos" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="746px">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditItemStyle BackColor="#2461BF" />
                                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingItemStyle BackColor="White" />
                                    <ItemStyle BackColor="#EFF3FB" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Renglon" HeaderText="Renglon"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Codigo" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Nombre" HeaderText="Producto"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ESPECIFICACIONESTECNICAS" HeaderText="Especificaciones">
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CANTIDAD" HeaderText="Cantidad"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="DESCRIPCION" HeaderText="Unidad de medida"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="NUMEROENTREGAS" HeaderText="N&#250;mero de entregas"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdProcesoCompra" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IDESTABLECIMIENTO" Visible="False"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Valor garant&#237;a" Visible="False">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValorGarantia" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 332px; height: 21px; text-align: right">
                        </td>
                        <td style="height: 21px; text-align: right">
                            <asp:LinkButton ID="LinkButton4" runat="server">< Atras</asp:LinkButton>&nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Panel ID="pnlPaso3" runat="server"  Visible="False" Width="125px">
                <table style="width: 748px">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Imagenes/paso 3 Lugares y plazos de entrega.jpg" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            &nbsp;
                            <asp:Panel ID="pnlE1" runat="server"  Visible="False" Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label2" runat="server" Text="Para una entrega" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dg1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" Width="525px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="DIAS" HeaderText="Plazo"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE2" runat="server"  Visible="False" Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label3" runat="server" Text="Para dos entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dg2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" Width="523px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="DIAS" HeaderText="Plazo"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE3" runat="server"  Visible="False" Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label56" runat="server" Text="Para tres entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dg3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" Width="517px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Dias" HeaderText="Plazo"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Porcentaje" HeaderText="Porcentaje de entrega"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE4" runat="server"  Visible="False" Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label58" runat="server" Text="Para cuatro entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dg4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" Width="519px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="Dias" HeaderText="Plazo"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de Entrega"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="pnlE5" runat="server"  Visible="False" Width="125px">
                                <table style="width: 748px">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label59" runat="server" Text="Para cinco entregas" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="text-align: center">
                                            <asp:DataGrid ID="dg5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" Width="529px">
                                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#2461BF" />
                                                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" />
                                                <ItemStyle BackColor="#EFF3FB" />
                                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="DIAS" HeaderText="Plazo"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega"></asp:BoundColumn>
                                                </Columns>
                                            </asp:DataGrid></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right">
                            <asp:LinkButton ID="LinkButton5" runat="server">< Atras</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton3" runat="server">Siguiente ></asp:LinkButton></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:Panel ID="pnlPaso5" runat="server"  Visible="False" Width="0px">
                <table class="CenteredTable" style="width: 100%">
                    <tr>
                        <td colspan="2">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 5 Generar Documento para compra directa.jpg" /></td>
                    </tr>
                    <tr>
                        <td style="width: 484px; text-align: left">
                        </td>
                        <td style="height: 26px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="Label24" runat="server" Text="A continuación debe guardar la información ingresada" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 21px; text-align: center" colspan="2">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="False" />&nbsp;
                            <asp:Button ID="btnGeneraDocumento" runat="server" Text="Generar documento" />&nbsp;
                            <asp:Button ID="btnContinuar" runat="server" Text="Liberar Base de Compra Directa" Visible="False" />&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: center">
                            <asp:Label ID="lblBaseGenerada" runat="server" Text="Base generada satisfactorimente:"
                                Visible="False" />
                            &nbsp;
                            <asp:LinkButton ID="lbBase" runat="server" Visible="False">Ver archivo</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="width: 484px; height: 21px; text-align: right">
                            &nbsp;</td>
                        <td style="height: 21px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: center">
                            <nds:MsgBox ID="MsgBox1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 21px; text-align: right">
                            <asp:LinkButton ID="LinkButton6" runat="server">< Anterior</asp:LinkButton>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
