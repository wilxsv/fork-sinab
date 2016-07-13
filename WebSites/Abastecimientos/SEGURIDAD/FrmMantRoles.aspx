﻿<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantRoles.aspx.vb" Inherits="FrmMantRoles" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Mantenimiento de roles</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
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
          CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDROL">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateField HeaderText="Editar / Consultar" HeaderStyle-HorizontalAlign="Left">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDROL", "FrmDetaMantRoles.aspx?id={0}") %>'
                  Text="Seleccionar" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Rol" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" ItemStyle-HorizontalAlign="Left"
              ItemStyle-Width="50%" HeaderStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="Habilitado">
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Iif (Eval("ESTAHABILITADO") = 1, True, False) %>'
                  Enabled="False" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AUFECHACREACION" HeaderText="Fecha de creaci&#243;n" DataFormatString="{0:d}"
              HtmlEncode="False" ItemStyle-Width="10%" />
            <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="5%">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl='~/Imagenes/Eliminar.gif' AlternateText="Eliminar el registro" CommandName="Delete"
                  CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "USUARIOS") %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron roles.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
