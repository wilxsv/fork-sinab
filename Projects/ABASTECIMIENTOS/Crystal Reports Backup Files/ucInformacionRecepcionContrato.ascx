<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucInformacionRecepcionContrato.ascx.vb"
  Inherits="ucInformacionRecepcionContrato" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:Panel ID="plModalidadCompra" runat="server" GroupingText=" " Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblModalidadCompra" runat="server" Text="Modalidad de Compra:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtModalidadCompra" runat="server" />
              <asp:Label ID="txtNoModalidadCompra" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFuenteFinanciamiento" runat="server" Text="Fuentes de Financiamiento:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtFuenteFinanciamiento" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblResponsableDistribucion" runat="server" Text="Responsable de Distribución:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtResponsableDistribucion" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblResolucionAdjudicacion" runat="server" Text="Resolución de Adjudicación:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtResolucionAdjudicacion" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNoContratoOrdenCompra" runat="server" Text="No. de Contrato/Orden de Compra:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtNoContratoOrdenCompra" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtProveedor" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFechaDistribucion" runat="server" Text="Fecha de Distribución:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtFechaDistribucion" runat="server" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
        AutoGenerateColumns="False" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDALMACENENTREGA,RENGLON,IDPRODUCTO,CORRPRODUCTO,DESCLARGO,PRECIOUNITARIO,DESCRIPCIONPROVEEDOR,IDUNIDADMEDIDA,UNIDADMEDIDA,CANTIDADPENDIENTE,CANTIDADDECIMAL"
        Width="100%">
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItemSmaller" />
        <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        <Columns>
          <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
          <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" />
          <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
          <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" ItemStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="CANTIDADPENDIENTE" HeaderText="Test" Visible="False" />
        </Columns>
        <EmptyDataTemplate>
          No existen renglones contratados pendientes de entregar.</EmptyDataTemplate>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="plRenglon" runat="server" GroupingText=" " Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNoRenglon" runat="server" Text="No. de Renglón:" Visible="False" /></td>
            <td class="DataCell">
              <asp:Label ID="txtNoRenglon" runat="server" Font-Bold="True" Visible="False" />
              <asp:Label ID="lblidDetalle" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCodigo" runat="server" Text="Código:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtCodigo" runat="server" Font-Bold="True" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Visible="False" /></td>
            <td class="DataCell">
              <asp:Label ID="txtNombre" runat="server" Font-Bold="True" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDescripcionProveedor" runat="server" Text="Descripción del producto:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtDescProv" runat="server" Font-Bold="True" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCantidadRecibir" runat="server" Text="Cantidad pendiente:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtCantidadRecibir" runat="server" Font-Bold="True" />
              <asp:Label ID="txtUM" runat="server" Font-Bold="True" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblPrecioUnitario" runat="server" Text="Precio Unitario:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtPrecioUnitario" runat="server" Font-Bold="True" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
