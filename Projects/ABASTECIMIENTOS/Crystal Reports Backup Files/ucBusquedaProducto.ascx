<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucBusquedaProducto.ascx.vb"
  Inherits="ucBusquedaProducto" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Búsqueda:" />
    </td>
    <td class="DataCell">
      <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
        <asp:ListItem Text="Por código" Selected="True" Value="0" />
        <asp:ListItem Text="Por selección" Value="1" />
      </asp:RadioButtonList>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plSeleccion" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              Tipo suministro:</td>
            <td class="DataCell">
              <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" AutoPostBack="True"
                Width="400px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Grupo:</td>
            <td class="DataCell">
              <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Sub grupo:</td>
            <td class="DataCell">
              <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" Width="400px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Producto:</td>
            <td class="DataCell">
              <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True"
                Width="400px" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plBusqueda" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCodigo" runat="server" Text="Código" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Width="88px" />
              <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="txtProducto"
                ErrorMessage="*" Display="Dynamic" ValidationGroup="Buscar" />
              <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" ValidationGroup="Buscar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: left;">
      <asp:Label ID="LblDescripcionCompleta" runat="server" /></td>
  </tr>
</table>
