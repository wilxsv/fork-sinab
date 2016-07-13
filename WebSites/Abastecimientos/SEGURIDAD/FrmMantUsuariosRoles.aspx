<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantUsuariosRoles.aspx.vb" Inherits="FrmMantUsuariosRoles" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Asignación de usuarios a roles</td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblRol" runat="server" Text="Rol:" />
      </td>
      <td class="DataCell">
        <cc1:ddlROLES ID="ddlROLES1" runat="server" Width="226px" AutoPostBack="True" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDUSUARIO">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:BoundField DataField="USUARIO" HeaderText="Usuario" HeaderStyle-HorizontalAlign="Left"
              HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="NOMBRE" HeaderText="Empleado" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="5%">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron usuarios asignados al rol seleccionado.
          </EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
