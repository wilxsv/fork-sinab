<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmReporteConsolidadoAbastecimiento.aspx.vb" Inherits="Reportes_FrmReporteConsolidadoAbastecimiento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menu" />
    Almacenes » Abastecimiento de Productos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>Consolidado de Abastecimiento de Productos</h3>
    <div style="margin: 10px 0">
            <asp:Label runat="server" ID="lblAnio" Text="Año :" AssociatedControlID="ddlAnio" />
        <asp:DropDownList runat="server" ID="ddlAnio" ValidationGroup="grpFiltros" AutoPostBack="True" />
        &nbsp; 
        <asp:Label runat="server" Text="Semana : " ID="lblSemana" AssociatedControlID="ddlSemana" />
        <asp:DropDownList runat="server" ID="ddlSemana" ValidationGroup="grpFiltros" AutoPostBack="True" />
    </div>
    <hr />
    <div style="margin: 10px 0">
        <asp:HyperLink runat="server" NavigateUrl="#" Text="Reporte Consolidado" ID="lbReporteConsolidado"/>
        <asp:HyperLink runat="server" NavigateUrl="#" Text="Reporte Productos Abastecidos" ID="lbReporteAbastecidos"/>
        <asp:HyperLink runat="server" NavigateUrl="#" Text="Reporte Productos Desabastecidos" ID="lbReporteDesabastecidos"/>
        &nbsp;&nbsp;
        <asp:HyperLink runat="server" NavigateUrl="#" Text="Reporte Cuadro Básico" ID="lbReporteConsolidadoDetallado"/>
    </div>
    <div style="margin: 10px 0px" class="LargeScrollPanel">
    <asp:GridView runat="server" ID="gvtest" Width="100%" CssClass="Grid" AutoGenerateColumns="False"
         GridLines="None" DataKeyNames="IdAlmacen">
        <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre">
            <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Cuadro Básico">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltCuba"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Sin Existencia">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltDes"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Con Existencia">
                <ItemTemplate>
                    <asp:Literal runat="server" ID="ltAbas"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            
           <%-- <asp:BoundField DataField="CuadroBasico" HeaderText="Cuadro Básico"/>
            <asp:BoundField DataField="Desabastecido" HeaderText="Sin Existencia"/>
            <asp:BoundField DataField="Abastecido" HeaderText="Con Existencia"/>--%>
        </Columns>
         <EmptyDataTemplate>
                No existen datos de abastecimiento en este momento.
            </EmptyDataTemplate>
    </asp:GridView></div>
</asp:Content>

