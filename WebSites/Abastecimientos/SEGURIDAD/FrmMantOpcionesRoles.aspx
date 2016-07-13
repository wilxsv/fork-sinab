<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantOpcionesRoles.aspx.vb" Inherits="FrmMantOpcionesRoles" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Asignación de opciones de menú a roles</td>
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
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plLista" runat="server" CssClass="ScrollPanel" Height="400px">
          <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" DataKeyNames="IDOPCIONSISTEMA" Width="95%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="Opci&#243;n del sistema" HeaderStyle-HorizontalAlign="Left"
                HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="Left" />
              <asp:BoundField DataField="PADRE" HeaderText="Depende de" HeaderStyle-HorizontalAlign="Left"
                HeaderStyle-Width="40%" ItemStyle-HorizontalAlign="Left" />
              <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                  <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                    AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                    ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se encontraron opciones asignadas al rol seleccionado.</EmptyDataTemplate>
          </asp:GridView>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
