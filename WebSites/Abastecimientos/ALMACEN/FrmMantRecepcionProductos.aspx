<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostBack="true" AutoEventWireup="false" CodeFile="frmMantRecepcionProductos.aspx.vb" Inherits="frmMantRecepcionProductos" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>

<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>

<%@MasterType VirtualPath="~/MasterPage.master"%> 

<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="text-align: left; width:5%; background-color:#b5c7de">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Establecimientos -> Recepción de productos dependencia" /></td>
        </tr>
        <tr>
            <td style="width:100%; text-align: left;">
                <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
                    ToolTip="Salir de la pantalla actual y regresar al menú principal." /><asp:ImageButton ID="ImgbAgregarDocumento" runat="server" ImageUrl="~/Imagenes/botones/new.jpg" ToolTip="Permite crear un documento de recepción de productos." /></td>
        </tr>
    </table>
    <asp:Panel ID="PnlPrincipal" runat="server" Width="100%">
        <table style="width: 100%">
            <tr>
                <td style="width:100%">
                <asp:DataGrid id="dgLista" runat="server" Width="100%" ForeColor="#333333" AllowPaging="True" GridLines="None" CellPadding="4" AutoGenerateColumns="False" >
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True"  />
                    <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"  />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" Mode="NumericPages"  />
                    <ItemStyle BackColor="#EFF3FB"  />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="False" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"  />
                    <Columns>
                        <asp:BoundColumn DataField="IDMOVIMIENTO" HeaderText="N&#176; movimiento" Visible="False" >
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IDRECIBO" HeaderText="N&#176; recibo" >
                            <HeaderStyle Width="10%"  />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="FECHAMOVIMIENTO" HeaderText="Fecha recepci&#243;n" DataFormatString="{0:d}" >
                        <HeaderStyle Width="15%"  />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DESCRIPCIONTIPODOCREF" HeaderText="Tipo documento ref." >
                        <HeaderStyle Width="15%"  />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="NUMERODOCREF" HeaderText="N&#176; documento ref." >
                            <HeaderStyle Width="15%"  />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Modificar">
                            <HeaderStyle Width="10%"  />
                            <ItemTemplate>
                                <asp:HyperLink id="lnkModificar" runat="server"
                                    NavigateUrl='<%# "frmDetMantRecepcionDependencias.aspx?IdMov=" + trim(str(DataBinder.Eval(Container.DataItem, "IDMOVIMIENTO"))) + "&IdClas=" + trim(str(DataBinder.Eval(Container.DataItem, "CLASIFICACIONMOVIMIENTO"))) %>'
                                    Text=">>">
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