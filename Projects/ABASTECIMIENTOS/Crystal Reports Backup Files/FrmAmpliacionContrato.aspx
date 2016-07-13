<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmAmpliacionContrato.aspx.vb" Inherits="FrmAmpliacionContrato" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucAmpliacionContrato.ascx" TagName="ucAmpliacionContrato"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucVistaDetalleListaProcesoCompra.ascx" TagName="ucVistaDetalleListaProcesoCompra"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Ampliación de Contrato" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <uc2:ucVistaDetalleListaProcesoCompra ID="UcVistaDetalleListaProcesoCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                    <table class="CenteredTable" style="width: 100%">
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" Text="Listado de Reglones adjudicados " /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label7" runat="server" Text="Cuando seleccione un renglon debe asegurarse de seleccionarlo para todos los proveedores" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Vertical" Visible="False" Width="100%">
                                    <asp:DataGrid ID="dgRenglones" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" Width="743px">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditItemStyle BackColor="#2461BF" />
                                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingItemStyle BackColor="White" />
                                        <ItemStyle BackColor="#EFF3FB" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundColumn DataField="RENGLON" HeaderText="Renglon" SortExpression="ASC"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PROVEEDOR" HeaderText="Proveedor"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CODIGO" HeaderText="C&#243;digo"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="DESCRIPCION" HeaderText="Descripci&#243;n"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="UNIDADMEDIDA" HeaderText="Unidad de medida"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="PRECIOUNITARIO" HeaderText="Precio unitario"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CANTIDADFIRME" HeaderText="Cantidad"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="MONTORENGLON" HeaderText="Monto por renglon"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False" />
                                            <asp:BoundColumn DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False" />
                                            <asp:BoundColumn DataField="IDCONTRATO" HeaderText="Contrato"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False"></asp:BoundColumn>
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSeleccionado" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid></asp:Panel>
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label6" runat="server" Text="Código de Licitación:" /></td>
                            <td style="text-align: left">
                                <asp:Label ID="lblCodigoLicitacion" runat="server" Text="Código de Licitación:" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label2" runat="server" Text="Monto total:" /></td>
                            <td style="width: 100px; text-align: left">
                                <asp:TextBox ID="txtMontoTotal" runat="server" ReadOnly="True"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label3" runat="server" Text="Monto autorizado:" /></td>
                            <td style="text-align: left">
                                <ew:NumericBox ID="txtMontoAutorizado" runat="server" Width="107px"></ew:NumericBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMontoAutorizado"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label4" runat="server" Text="Porcentaje de aumento:" /></td>
                            <td style="text-align: left">
                                <ew:NumericBox ID="txtPorcentajeAumento" runat="server" Width="107px" DecimalPlaces="6"
                                    PlacesBeforeDecimal="15" PositiveNumber="True"></ew:NumericBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPorcentajeAumento"
                                    ErrorMessage="Requerido" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="Button1" runat="server" Text="Calcular" /></td>
                        </tr>
                    </table>
                    &nbsp;
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" Width="100%" Visible="False">
                    <table class="CenteredTable" style="width: 100%">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label8" runat="server" Text="Listado de renglones con ampliación de contrato" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataGrid ID="dgRenglonesAmpliacion" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="743px">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditItemStyle BackColor="#2461BF" />
                                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingItemStyle BackColor="White" />
                                    <ItemStyle BackColor="#EFF3FB" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <Columns>
                                        <asp:ButtonColumn CommandName="Select" Text="Seleccionar"></asp:ButtonColumn>
                                        <asp:BoundColumn DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" SortExpression="ASC"
                                            Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IdProcesoCompra" HeaderText="IdProcesoCompra" Visible="False">
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="RENGLON" HeaderText="Renglon"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="NOMBRERENGLON" HeaderText="Descripci&#243;n"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="PROVEEDOR" HeaderText="Proveedor"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IDAMPLIACIONCONTRATO" HeaderText="IDAMPLIACIONCONTRATO"
                                            Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CANTIDADAMPLIADA" HeaderText="Cantidad ampliada"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False"></asp:BoundColumn>
                                    </Columns>
                                </asp:DataGrid></td>
                        </tr>
                        <tr>
                            <td style="width: 100px; height: 18px;">
                            </td>
                            <td style="width: 100px; height: 18px;">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
                                    <table class="CenteredTable" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="Button2" runat="server" Text="Detalle de Entregas" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: right">
                                            </td>
                                            <td style="width: 100px; text-align: left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Label ID="Label9" runat="server" Text="Realizar distribución de entregas para ampliación de productos" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="Button3" runat="server" Text="Distribución" /></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
    <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
