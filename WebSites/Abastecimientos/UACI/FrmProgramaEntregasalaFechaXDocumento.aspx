<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmProgramaEntregasalaFechaXDocumento.aspx.vb"
  Inherits="FrmProgramaEntregasalaFechaXDocumento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" />
        Programación de entregas a la fecha por documento
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
     <h3><asp:Label ID="Label5" runat="server" Text="Realizar búsqueda por:" /></h3>
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td style="text-align: right; width: 30%;">
        Lugar de entrega:</td>
      <td style="text-align: left; width: 40%;">
        <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="368px" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbAlmacen" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Tipo de documento:</td>
      <td style="text-align: left; width: 40%;">
        <cc1:ddlTIPODOCUMENTOCONTRATO ID="ddlTIPODOCUMENTOCONTRATO1" runat="server" Width="368px" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbTipoDocumento" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Número de documento:</td>
      <td style="text-align: left; width: 40%;">
        <asp:TextBox ID="txtContrato" runat="server" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbNumeroDocumento" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Modalidad de compra:</td>
      <td style="text-align: left; width: 40%;">
        <cc1:ddlTIPOCOMPRAS ID="ddlTIPOCOMPRAS1" runat="server" Width="368px" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbModalidadCompra" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Proveedor:</td>
      <td style="text-align: left; width: 40%;">
        <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="368px" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbProveedor" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Tipo de producto:</td>
      <td style="text-align: left; width: 40%;">
        <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="368px" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbTipoProducto" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%;">
        Código de producto:</td>
      <td style="text-align: left; width: 40%;">
        <asp:TextBox ID="txtProducto" runat="server" /></td>
      <td style="text-align: left;">
        <asp:CheckBox ID="cbCodigoProducto" runat="server" Text="Utilizar filtro" /></td>
    </tr>
    <tr>
      <td style="text-align: right; width: 30%; height: 46px;">
        Entregas:</td>
      <td style="text-align: left; height: 46px;">
        <asp:RadioButtonList ID="rblEntregas" runat="server" RepeatDirection="Horizontal">
          <asp:ListItem Text="Pendientes" Selected="True" Value="0" />
          <asp:ListItem Text="Completas" Value="1" />
        </asp:RadioButtonList></td>
      <td style="height: 46px">
      </td>
    </tr>
      </table>

    <div>
        Si no se selecciona ningún filtro se presentan todos los documentos.</div>
    
    <div>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
      </div>
   
        <asp:Panel ID="pnlgv1" runat="server" Width="100%">
          <asp:GridView ID="gvContratos" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO"
            GridLines="None" Width="100%">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooterSmaller" />
            <PagerStyle CssClass="GridListPagerSmaller" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
              <asp:TemplateField HeaderText="Tipo y Nro. Documento">
                <ItemTemplate>
                  <%#Container.DataItem("TIPODOCUMENTO").ToString + "<br />" + Container.DataItem("NUMERODOCUMENTO").ToString%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="TIPODOCUMENTO" HeaderText="Tipo" Visible="False" />
              <asp:BoundField DataField="NUMERODOCUMENTO" HeaderText="Nro. Documento" Visible="False">
              </asp:BoundField>
              <asp:BoundField DataField="FECHADOCUMENTO" HeaderText="Fecha de Distribuci&#243;n" />
              <asp:TemplateField HeaderText="Modalidad / Nro. Modalidad" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                  <%#Container.DataItem("TIPOCOMPRA").ToString + "<br />" + Container.DataItem("NUMEROCOMPRA").ToString%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="TIPOCOMPRA" HeaderText="Modalidad" Visible="False" />
              <asp:BoundField DataField="NUMEROCOMPRA" HeaderText="Nro. Modalidad" Visible="False" />
              <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
              <asp:TemplateField HeaderText="Tipo Producto">
                <ItemTemplate>
                  <asp:Label ID="lblTiposSuministro" runat="server" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Fuente de Financiamiento">
                <ItemTemplate>
                  <asp:Label ID="lblFuentesFinanciamiento" runat="server" />
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="MONTOCONTRATO" HeaderText="Monto" DataFormatString="{0:c}"
                HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            </Columns>
            <EmptyDataTemplate>
              No se encontraron documentos que cumplan con el criterio de búsqueda.</EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
   
   <div>
        <asp:Label ID="lblDetalle" runat="server" Font-Bold="True" Font-Size="Medium" /></div>
    
    
        <asp:GridView ID="gvRenglones" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,RENGLON"
          GridLines="None" Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
            <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
            <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Descripci&#243;n Proveedor"
              ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="UM" HeaderText="U.M." />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PORCENTAJEENTREGADO" HeaderText="% Entregado" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CANTIDADPENDIENTE" HeaderText="Pendiente" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PORCENTAJEPENDIENTE" HeaderText="% Pendiente" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
          </Columns>
        </asp:GridView>
    
    
    <div>
        <asp:Label ID="lblProgramadas" runat="server" Font-Bold="True" Font-Size="Medium" /></div>
    
    <div>
        <asp:GridView ID="gvProgramadas" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" CssClass="Grid" DataKeyNames="ENTREGA,IDALMACENENTREGA" GridLines="None"
          Width="100%">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="ALMACEN" HeaderText="Almacén" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="ENTREGA" HeaderText="Entrega" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PORCENTAJEENTREGA" HeaderText="% Entrega" DataFormatString="{0:n}"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PRECIOUNITARIO" DataFormatString="{0:c}" HeaderText="Precio unitario"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PRECIOTOTAL" DataFormatString="{0:c}" HeaderText="Precio total"
              HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="FECHAENTREGA" HeaderText="Fecha entrega" DataFormatString="{0:d}"
              HtmlEncode="False" />
            <asp:TemplateField HeaderText="Detalle de entregas">
              <ItemTemplate>
                <asp:GridView ID="gvDetalleEntregas" runat="server" AutoGenerateColumns="False" BorderColor="#999999"
                  BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                  <Columns>
                    <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha" DataFormatString="{0:d}"
                      HtmlEncode="False" />
                    <asp:BoundField DataField="NUMEROACTA" HeaderText="No. Acta" ItemStyle-HorizontalAlign="Right" />
                    <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" DataFormatString="{0:n}"
                      HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                  </Columns>
                  <HeaderStyle BackColor="Black" ForeColor="White" />
                  <RowStyle BackColor="White" ForeColor="Black" />
                </asp:GridView>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
    
      <div>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" UseSubmitBehavior="False" /></div>
  
</asp:Content>
