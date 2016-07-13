<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteOfertaEconomica.aspx.vb"
    Inherits="FrmReporteOfertaEconomica" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleProcesoCompraRpt" Src="~/Controles/ucVistaDetalleProcesoCompraRpt.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Reportes -> Oferta económica" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;<asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="Grid" DataKeyNames="IDPROVEEDOR" ForeColor="#333333"
                    GridLines="None">
                    <FooterStyle CssClass="GridListFooter" />
                    <Columns>
                        <asp:CommandField SelectText="Imprimir" ShowSelectButton="True">
                            <ItemStyle Font-Bold="True" />
                        </asp:CommandField>
                        <asp:BoundField DataField="OFERTA" HeaderText="OFERTA" />
                        <asp:BoundField DataField="CODIGO" HeaderText="C&#211;DIGO" />
                        <asp:BoundField DataField="PROVEEDOR" HeaderText="PROVEEDOR" />
                    </Columns>
                    <RowStyle CssClass="GridListItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <PagerStyle CssClass="GridListPager" />
                    <HeaderStyle CssClass="GridListHeader" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Imprimir todos" /></td>
        </tr>
    </table>
</asp:Content>
