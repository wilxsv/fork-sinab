<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte8.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte8" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/UACI/CERTIFICACION/Controles/ReportesFiltros.ascx" TagPrefix="uc1" TagName="ReportesFiltros" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI - Certificación de Productos » Reportes » <%=Title%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3><%=Title%></h3>
     <uc1:ReportesFiltros runat="server" ID="rFiltros" />
      <asp:Button ID="Button1" runat="server" Text="Buscar" ValidationGroup="1" />
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CellPadding="4" 
        CssClass="Grid" Width="100%" GridLines="None"
        DataKeyNames="idproceso,idtipoproducto,idproveedor,Id">
        
        <Columns>
            <asp:BoundField DataField="nit" HeaderText="NIT">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="proveedor" HeaderText="Razón Social">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="tipoproducto" HeaderText="Tipo de Producto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="codigo" HeaderText="Código">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="producto" HeaderText="Producto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="marca" HeaderText="Marca">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="pais" HeaderText="País de Origen">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="EstadoProducto" HeaderText="Estado">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkReporte" runat="server" CssClass="GridOrden" ToolTip="Reporte" OnClick="lnkReporte_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
       <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <EmptyDataTemplate>- No se encontraron registros - </EmptyDataTemplate>
    </asp:GridView>

</asp:Content>

