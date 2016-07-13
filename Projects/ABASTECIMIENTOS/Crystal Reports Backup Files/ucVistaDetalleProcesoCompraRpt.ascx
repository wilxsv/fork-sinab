<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleProcesoCompraRpt.ascx.vb"
    Inherits="Controles_ucVistaDetalleProcesoCompraRpt" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td>
            <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione el proceso de compra del siguiente listado:" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvProcesosCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="726px" AllowPaging="True" DataKeyNames="IDTIPOCOMPRAEJECUTAR">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:CommandField InsertVisible="False" SelectImageUrl="~/Imagenes/botones/flecha.jpg"
                        SelectText="Ver" ShowHeader="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra" />
                    <asp:BoundField DataField="LUGARRETIROBASE" HeaderText="Lugar de Retiro" />
                    <asp:BoundField DataField="FECHAPUBLICACION" HeaderText="Fecha de publicaci&#243;n"
                        DataFormatString="{0:d}" HtmlEncode="False" />
                    <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo de Licitaci&#243;n" />
                </Columns>
                <EmptyDataTemplate>
                    No existen procesos de compra para el establecimiento.</EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
