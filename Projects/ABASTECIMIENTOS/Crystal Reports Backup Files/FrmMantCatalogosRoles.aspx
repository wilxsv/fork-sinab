<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantCatalogosRoles.aspx.vb" Inherits="FrmMantCatalogosRoles" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" style="height: 16px">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Permisos por Catálogo</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblROL" runat="server" Text="Rol:" />
        <cc1:ddlROLES ID="ddlROLES1" runat="server" Width="226px" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td>
        <uc2:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="80%" AllowPaging="True" DataKeyNames="IDOPCIONSISTEMA,PERMITEEDITAR,AUUSUARIOCREACION,AUFECHACREACION">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Opci&#243;n del sistema" HeaderStyle-HorizontalAlign="Left"
              HeaderStyle-Width="80%" ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Permite editar">
              <ItemTemplate>
                <asp:CheckBox ID="cbPermiteEditar" runat="server" Checked='<%# Iif (Eval("PERMITEEDITAR") = 1, True, False) %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron opciones asignadas al rol seleccionado.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
