<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmReporteInformesNoAceptacion.aspx.vb"
  Inherits="FrmReporteInformesNoAceptacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrosReportesAlmacen" Src="~/Controles/ucFiltrosReportesAlmacen.ascx" %>
<asp:Content runat="server" ID="c2" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Reportes » Informes de no aceptación
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  
        <uc1:ucFiltrosReportesAlmacen ID="ucFiltrosReportesAlmacen1" runat="server" />
    <div style="margin: 20px 0">
     <div class="ScrollPanel">
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          GridLines="None" DataKeyNames="IdEstablecimientoMovimiento,IdMovimiento,IdAlmacen,IdEstablecimiento,IdProveedor,IdContrato"
          Visible="False" Width="100%">
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
            <asp:BoundField DataField="NumeroInforme" HeaderText="N&#250;mero informe" />
            <asp:BoundField DataField="FechaMovimiento" HeaderText="Fecha informe" />
            <asp:BoundField DataField="TipoNumeroDocumento" HeaderText="Documento" />
            <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
        
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
          </Columns>
          <EmptyDataTemplate>
            No se encontraron informes de no aceptación.</EmptyDataTemplate>
        </asp:GridView>
     </div>
     </div>
</asp:Content>
