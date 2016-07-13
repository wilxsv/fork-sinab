<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucConsultarProcesoCompra.ascx.vb" Inherits="Controles_ucConsultarProcesoCompra" %>
<table class="CenteredTable" style="width:100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Seleccione el estado para filtrar:"/></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlEstado" runat="server" Width="280px"/></td>
        <td rowspan="2" style="text-align:center;">
            <asp:CheckBox ID="cbTodos" runat="server" Text="Desactivar filtros" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label2" runat="server" Text="Seleccione el analista para filtrar:"/></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlAnalista" runat="server" Width="280px"/></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" /></td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:GridView ID="gvProcesosCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False" CellPadding="4" GridLines="None" AllowPaging="True" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:BoundField DataField="IdProcesoCompra" HeaderText="No. Proceso" >
                        <HeaderStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TIPOCOMPRA" HeaderText="Modalidad" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo" >
                        <HeaderStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TITULOLICITACION" HeaderText="T&#237;tulo" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRE_ESTADO" HeaderText="Estado" >
                        <HeaderStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMBRE_ANALISTA" HeaderText="Analista" >
                        <ItemStyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAPROCESO" HeaderText="Fecha inicio" DataFormatString="{0:d}" HtmlEncode="False" >
                        <HeaderStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>No se encontraron procesos de compra.</EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
