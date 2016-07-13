<%@ Page Language="VB" MasterPageFile="~/MasterPage.master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="false"  CodeFile="FrmDetMantDespachoRequisicionI.aspx.vb" Inherits="FrmDetMantDespachoRequisicionI" %>

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
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Almacén -> Despachar productos almacenes" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" ToolTip="Salir de la pantalla actual" />
                </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: left">
                                &nbsp;</td>
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
                    <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"  />
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
                                    NavigateUrl='<%# "FrmDetMantDespachoRequisicionII.aspx?IdReq=" + trim(str(DataBinder.Eval(Container.DataItem, "IDMOVIMIENTO"))) + "&IdEst=" + trim(str(DataBinder.Eval(Container.DataItem, "IDESTABLECIMIENTO"))) + "&IdAlm=" + trim(str(DataBinder.Eval(Container.DataItem, "IDALMACEN"))) %>' Text=">>">
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