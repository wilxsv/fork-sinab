<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="frmRecepcionAnticipos.aspx.vb" Inherits="frmRecepcionAnticipos" %>

<%@ Register Src="~/Controles/ucInformacionRecepcionRenglon.ascx" TagName="ucInformacionRecepcionRenglon"
    TagPrefix="uc3" %>
<%@ Register Src="~/Controles/ucInformacionRecepcionAnticipo.ascx" TagName="ucInformacionRecepcionAnticipo"
    TagPrefix="uc2" %>
<%@ Register Src="~/Controles/ucSeleccionContratoAnticipo.ascx" TagName="ucSeleccionContratoAnticipo"
    TagPrefix="uc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">
    <table class="Table">
        <tr>
            <td class="LinkMenuRuta" colspan="2" style="height: 18px">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú">
                </asp:LinkButton>&nbsp;&nbsp;<asp:Label ID="LblRuta" runat="server" Text="Almacenes -> Recepción de Anticipos" />
            </td>
        </tr>
    </table>
    <table class="Table">
        <tr>
            <td colspan="2">
                <asp:Panel ID="Pane2" runat="server" Visible="true">
                    <uc1:ucSeleccionContratoAnticipo ID="UcSeleccionContratoAnticipo1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Visible="False"><< Regresar al listado de proveedores</asp:LinkButton><br />
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <br />
                    <uc2:ucInformacionRecepcionAnticipo ID="UcInformacionRecepcionAnticipo1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="font-weight: bold; background-color: #dcdcdc">
                <asp:Label ID="titReng" runat="server" Text="Productos a recibir" Visible="false">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="background-color: #f5f5f5">
                <asp:GridView ID="gvTemp" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    CellPadding="4" DataKeyNames="NOFACTURA,NOENVIO,FCHDOCUMENTO,RENGLON,LOTE,FCHVENCIMIENTO,NOINFCC,FECHAELABORACIONINFORME,CANTIDAD,UBICACION,IDESTCC,IDINFCC,IDTIPCC,PROVIENE,IMPORTE,idproducto,um,precio"
                    GridLines="None">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True">
                            <ItemStyle Font-Size="10px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:CommandField>
                        <asp:BoundField DataField="NOFACTURA" HeaderText="NoFactura" Visible="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOENVIO" HeaderText="NoEnvio" Visible="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FCHDOCUMENTO" DataFormatString="{0:d}" HeaderText="FchDocumento"
                            HtmlEncode="False" Visible="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LOTE" HeaderText="Lote">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FCHVENCIMIENTO" DataFormatString="{0:d}" HeaderText="Vencimiento"
                            HtmlEncode="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOINFCC" HeaderText="No. Informe CC">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHAELABORACIONINFORME" DataFormatString="{0:d}" HeaderText="Fecha Informe CC"
                            HtmlEncode="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UBICACION" HeaderText="Ubicaci&#243;n">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PROVIENE" HeaderText="Proviene" Visible="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTE" HeaderText="Proviene" Visible="False">
                            <ItemStyle Font-Size="9px" />
                            <HeaderStyle Font-Size="9px" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Image" CommandName="eliminar" ImageUrl="~/Imagenes/cancel.jpg"
                            Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                <asp:Label ID="Label1" runat="server" Font-Size="10px" ForeColor="Red" Text="* Ya ha recibido el máximo para ese producto"
                    Visible="False" />
            </td>
        </tr>
        <tr>
            <asp:Panel ID="pnlInfReg" runat="server" Visible="false">
                <uc3:ucInformacionRecepcionRenglon ID="UcInformacionRecepcionRenglon1" runat="server" />
            </asp:Panel>
        </tr>
    </table>
    <asp:Panel ID="pnUltimo" runat="server" Visible="False" Width="534px">
        <asp:Label ID="Label2" runat="server" Height="35px" Text="Observaciones:" />
        <asp:TextBox ID="TextBox1" runat="server" Height="53px" TextMode="MultiLine" Width="303px"></asp:TextBox>
        <br />
        <br />
        <tr>
        </tr>
            <td style="vertical-align: middle; height: 18px" valign="middle">
            </td>
                <asp:Button ID="Button1" runat="server" Text="Guardar recepción" />
                <asp:Button ID="Button2" runat="server" Text="Cerrar recepción" />
                <asp:Button ID="Button3" runat="server" Enabled="False" Text="Impresión de Recibo" />
                <nds:MsgBox ID="MsgBox1" runat="server" />
    </asp:Panel>
</asp:Content>
