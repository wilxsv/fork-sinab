<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="FrmMantDespachoDependencias.aspx.vb" Inherits="FrmMantDespachoDependencias" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>

<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>

<%@MasterType VirtualPath="~/MasterPage.master"%> 

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width:5%; background-color:#b5c7de; height: 18px;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Almacén -> Despachar productos dependencias" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" ToolTip="Salir de la pantalla actual" />
                <asp:ImageButton ID="ImgbAgregarDocumento" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" Visible="False" ToolTip="Permite agregar un vale de salida" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Button ID="BtMostrarRequisiciones" runat="server" BackColor="LightSteelBlue" Font-Bold="True"
                    ForeColor="Black" Text="Mostrar requisiciones pendientes" Width="239px" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: left">
                <asp:Panel ID="PnlValesSalida" runat="server" Width="100%" GroupingText="Lista de vales de salida pendientes de cierre" Font-Bold="True">
                    <table style="width: 100%">
                        <tr>
                            <td style="width:100%">
                                &nbsp;<asp:GridView ID="GvValesPendientes" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    CellPadding="4" DataKeyNames="IDTIPOTRANSACCION,IDMOVIMIENTO,IDESTABLECIMIENTODESTINO" EmptyDataText="                      NO EXISTE NINGUN VALE DE SALIDA PENDIENTE DE CIERRE."
                                    Font-Bold="False" Font-Size="8pt" GridLines="None">
                                    <HeaderStyle CssClass="GridListHeader" />
                                    <FooterStyle CssClass="GridListFooter" />
                                    <PagerStyle CssClass="GridListPager" />
                                    <RowStyle CssClass="GridListItem" />
                                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                                    <EditRowStyle CssClass="GridListEditItem" />
                                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                    <Columns>
                                        <asp:BoundField DataField="IDTIPOTRANSACCION" HeaderText="Tipo movimiento" Visible="False">
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="No vale">
                                            <HeaderStyle Width="10%" />
                                            <ItemTemplate>
                                                <asp:Label ID="LblNumeroVale" runat="server" Text='<%# str(container.dataitem("IDDOCUMENTO")) + "/" + trim(str(container.dataitem("ANIO"))) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha despacho" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                                            <HeaderStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IDESTABLECIMIENTODESTINO" HeaderText="IDESTABLECIMIENTO" Visible="False">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ESTABLECIMIENTODESTINO" HeaderText="Dependencia destino">
                                            <HeaderStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Modificar">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="lnkModificar" runat="server" NavigateUrl='<%# "FrmDetMantDespachoDependencias.aspx?IdMov=" + trim(str(DataBinder.Eval(Container.DataItem, "IDMOVIMIENTO"))) + "&IdTipTran=" + trim(str(DataBinder.Eval(Container.DataItem, "IDTIPOTRANSACCION"))) %>'
                                                    Text=">>">
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkbEliminar" runat="server" CausesValidation="False" CommandName='<%#container.dataitem("IDMOVIMIENTO")%>'
                                                    OnClick="EliminarMovimiento" Text=">>">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="5%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlPrincipal" runat="server" Width="100%" GroupingText="Lista de requisiciones pendientes de despacho" Visible="False" Font-Bold="True" ForeColor="Black">
        <table style="width: 100%">
            <tr>
                <td style="width:100%">
                <asp:DataGrid id="dgLista" runat="server" Width="100%" ForeColor="#333333" AllowPaging="True" GridLines="None" CellPadding="4" AutoGenerateColumns="False" Font-Bold="False">
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"  />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"  />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" Mode="NumericPages"  />
                    <ItemStyle BackColor="#EFF3FB"  />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  />
                    <Columns>
                        <asp:BoundColumn DataField="IDTIPOTRANSACCION" HeaderText="Tipo movimiento" Visible="False" >
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IDMOVIMIENTO" HeaderText="No requisici&#243;n" >
                            <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Right"  />
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Right" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FECHAMOVIMIENTO" HeaderText="Fecha movimiento" DataFormatString="{0:dd/MM/yyyy}" >
                            <HeaderStyle Width="25%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left"  />
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IDESTADO" HeaderText="IDESTADO" Visible="False">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DESCRIPCIONESTADO" HeaderText="Estado" >
                            <HeaderStyle Width="20%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left"  />
                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                Font-Underline="False" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Generar despacho">
                            <HeaderStyle Width="15%"  />
                            <ItemTemplate>
                                <asp:HyperLink id="lnkModificar" runat="server"
                                    NavigateUrl='<%# "FrmDetMantDespachoDependencias.aspx?IdReq=" + trim(str(DataBinder.Eval(Container.DataItem, "IDMOVIMIENTO"))) %>' Text=">>">
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <EditItemStyle BackColor="#2461BF"  />
                    <AlternatingItemStyle BackColor="White"  />
                </asp:DataGrid>
                </td>
            </tr>
        </table> 
    </asp:Panel>
    <nds:msgbox id="MsgBox1" runat="server"></nds:msgbox>
</asp:Content>