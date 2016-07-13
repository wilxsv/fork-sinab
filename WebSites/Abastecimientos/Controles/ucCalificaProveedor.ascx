<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCalificaProveedor.ascx.vb"
  Inherits="Controles_ucCalificaProveedor" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td colspan="2">
      <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Califica Proveedores" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="Label2" runat="server" Text="Ingresar el período de consulta:" /></td>
  </tr>
  <tr>
    <td class="LabelCell" style="text-align: right; width: 335px;">
      <asp:Label ID="Label3" runat="server" Text="Fecha inicio:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="CalendarPopup1" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell" style="text-align: right; width: 335px;">
      <asp:Label ID="Label4" runat="server" Text="Fecha fin:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="CalendarPopup2" runat="server" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td class="LabelCell" style="text-align: right; width: 335px;">
      <asp:Label ID="Label5" runat="server" Text="Proveedor que desea calificar:" /></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlProveedor" runat="server" Width="459px">
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      &nbsp;
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Button ID="btnConsultarContratos" runat="server" Text="Consultar contratos" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:DataGrid ID="dgCalificacion" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        CellPadding="4" GridLines="None">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <ItemStyle CssClass="GridListItem" />
        <SelectedItemStyle CssClass="GridListSelectedItem" />
        <EditItemStyle CssClass="GridListEditItem" />
        <AlternatingItemStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:BoundColumn DataField="NUMEROCONTRATO" HeaderText="N&#250;mero de Contrato" />
          <asp:BoundColumn DataField="CODIGOLICITACION" HeaderText="Proceso de compra" />
          <asp:BoundColumn DataField="FECHAGENERACION" HeaderText="FECHAGENERACION" Visible="False" />
          <asp:BoundColumn DataField="DiasAtraso" HeaderText="D&#237;as de atraso" />
          <asp:BoundColumn DataField="Calificacion1" HeaderText="Calificaci&#243;n por Incumplimiento" />
          <asp:BoundColumn DataField="Rechazos" HeaderText="cantidad de Rechazos" />
          <asp:BoundColumn DataField="Calificacion2" HeaderText="Calificaci&#243;n de calidad del producto" />
          <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False" />
        </Columns>
      </asp:DataGrid></td>
  </tr>
</table>
