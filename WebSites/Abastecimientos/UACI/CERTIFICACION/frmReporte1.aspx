<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte1.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte1" 
    title="Selección de Filtros" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Src="~/UACI/CERTIFICACION/Controles/ReportesFiltros.ascx" TagPrefix="uc1" TagName="ReportesFiltros" %>

<asp:content ContentPlaceHolderID="MenuContent" ID="cmenu" runat="server">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI - Certificación de Productos » Reportes » Selección de Filtros
</asp:content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

    <h3><%=Title %></h3>

    <uc1:ReportesFiltros runat="server" id="rFiltros" />
    
      
   <div style="margin: 10px 0">
      <asp:Button ID="btnBuscar" runat="server" Text="Buscar" ValidationGroup="1" />
       </div>
       <div class="LargeScrollPanel" style="margin: 20px 0">
           <div>
      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  CellPadding="5"  DataKeyNames="idproceso,idtipoproducto,IdProveedorProceso,id"
          CssClass="Grid" GridLines="None" Width="100%">
        <Columns>
          <asp:BoundField DataField="nit" HeaderText="NIT" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="proveedor" HeaderText="Raz&#243;n Social" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="tipoproducto" HeaderText="Tipo de Producto" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="CorrProducto" HeaderText="Código" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="DescLargo" HeaderText="Producto" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="marca" HeaderText="Marca" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="pais" HeaderText="Pa&#237;s de Origen" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="Certificado" HeaderText="Estado" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:TemplateField>
            <ItemTemplate>
              <asp:LinkButton ID="lnkDetalle" runat="server" ToolTip="Ver detalle" CssClass="GridOrden" OnClick="lnkDetalle_Click" />
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
        <EmptyDataTemplate> - No se encontraron registros - </EmptyDataTemplate>
      </asp:GridView>
               </div>
           </div>
  

    
</asp:Content>

