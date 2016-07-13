<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmGenerarNotasIncumplimientos.aspx.vb" Inherits="FrmGenerarNotasIncumplimientos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="uc3" Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
                    ID="LblRuta" runat="server" Text="UACI -> Generar notas de incumplimiento" /></td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    GridLines="None" Width="100%" AllowPaging="True">
                    <HeaderStyle CssClass="GridListHeaderSmaller" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItemSmaller" />
                    <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFormatString="FrmGenerarNotaIncumplimientoPaso2.aspx?id={0}"
                            DataNavigateUrlFields="IdProcesoCompra" HeaderText="Consultar" Target="_self"
                            Text="Seleccionar" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Código" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="FECHAINICIOPROCESOCOMPRA" DataFormatString="{0:d}" HeaderText="Inicio Proceso"
                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="LUGARAPERTURABASE" HeaderText="Lugar de Apertura" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField HeaderText="Estado" DataField="ESTADO" HeaderStyle-HorizontalAlign="Left"
                            ItemStyle-HorizontalAlign="Left" />
                    </Columns>
                    <EmptyDataTemplate>
                        No hay procesos de compra en el estado seleccionado.</EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
