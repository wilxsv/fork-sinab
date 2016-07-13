<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmAsignacionProveedoresAnalista.aspx.vb" Inherits="FrmAsignacionProveedoresAnalista" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Asignación de proveedores a analista v1.0</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblANALISTA" runat="server" Text="Analista:" /></td>
      <td class="DataCell">
        <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="223px" AutoPostBack="True" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblPROVEEDORES" runat="server" Text="Proveedor:" /></td>
      <td class="DataCell">
        <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Width="223px" />
        <asp:Label ID="lblProveedoresAsignados" runat="server" Text="Todos los proveedores han sido asignados." /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnAsociar" runat="server" Text="Asociar" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="80%" AllowPaging="True" DataKeyNames="IDPROVEEDOR">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
              </ItemTemplate>
              <ItemStyle Width="5%" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han asignado proveedores al analista seleccionado.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
