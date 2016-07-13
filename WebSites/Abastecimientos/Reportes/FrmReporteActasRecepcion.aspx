<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmReporteActasRecepcion.aspx.vb" Inherits="FrmReporteActasRecepcion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>

<asp:Content runat="server" ID="cpmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Reportes » Actas de recepción
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
 
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
     <div style="margin: 20px 0">
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="100%"
          GridLines="None" DataKeyNames="IDESTABLECIMIENTOMOVIMIENTO,IDTIPOTRANSACCION,IDMOVIMIENTO,IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDALMACEN,ANIO,IDRECIBO"
          Visible="False">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div style="text-align: center">
                            <asp:LinkButton runat="server" ID="lbVer" ToolTip="Ver reporte" CssClass="GridOrden" Style="display: inline-block; cursor: pointer" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="NUMERORECIBO" HeaderText="Número acta" ItemStyle-Width="10%" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha recepción" ItemStyle-Width="10%" />
            <asp:BoundField DataField="TIPONUMERODOCUMENTO" HeaderText="Documento" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="20%" />
            <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="25%" />
            <asp:TemplateField HeaderText="Fuente financiamiento" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:GridView ID="gvDetalleFuentes" runat="server" AutoGenerateColumns="False" GridLines="None"
                  ShowHeader="false">
                  <Columns>
                    <asp:BoundField DataField="FUENTEFINANCIAMIENTO" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Responsable distribución" ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:GridView ID="gvDetalleResponsables" runat="server" AutoGenerateColumns="False"
                  GridLines="None" ShowHeader="false">
                  <Columns>
                    <asp:BoundField DataField="RESPONSABLEDISTRIBUCION" />
                  </Columns>
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" ItemStyle-Width="10%" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron actas de recepción.</EmptyDataTemplate>
        </asp:GridView>
     </div>
     
</asp:Content>
