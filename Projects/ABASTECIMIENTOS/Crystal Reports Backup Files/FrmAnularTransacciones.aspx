<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmAnularTransacciones.aspx.vb" Inherits="FrmAnularTransacciones" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Anular transacciones</td>
    </tr>
    <tr>
      <td class="LabelCell">
        Tipo transacción:
      </td>
      <td class="DataCell">
        <cc1:ddlTIPOTRANSACCIONES ID="ddlTIPOTRANSACCIONES1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="Número de documento:" Visible="False" /></td>
      <td class="DataCell">
        <asp:TextBox ID="txtNoDocumento" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label4" runat="server" Text="Fecha:" Visible="False" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarFechaInicio" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" Text="Buscar" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="100%" AllowPaging="True">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:HyperLinkField HeaderText="Seleccionar" DataNavigateUrlFormatString="~/ALMACEN/FrmAnularTransaccionesDetalle.aspx?idTT={0}&idM={1}"
              DataNavigateUrlFields="IDTIPOTRANSACCION,IDMOVIMIENTO" Text=">>" />
            <asp:BoundField DataField="TIPOTRANSACCION" HeaderText="Tipo transacci&#243;n" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="NUMERODOCUMENTO" HeaderText="N&#176; Documento" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="FECHAMOVIMIENTO" HeaderText="Fecha" DataFormatString="{0:d}"
              HtmlEncode="false" />
            <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
