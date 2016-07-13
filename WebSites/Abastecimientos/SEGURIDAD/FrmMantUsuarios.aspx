<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantUsuarios.aspx.vb" Inherits="FrmMantUsuarios" MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Mantenimiento de usuarios</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td style="text-align: right;">
        <asp:LinkButton ID="lbVerEliminados" runat="server" Text="Ver usuarios eliminados" /></td>
    </tr>
    <tr>
      <td>
        <uc2:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
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
            <asp:TemplateField HeaderText="Editar / Consultar" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-Width="10%">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDUSUARIO", "FrmDetaMantUsuarios.aspx?id={0}") %>'
                  Text="Seleccionar" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="USUARIO" HeaderText="Usuario" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" ItemStyle-Width="25%" />
            <asp:BoundField DataField="NOMBRE" HeaderText="Empleado" HeaderStyle-HorizontalAlign="Left"
              ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45%" />
            <asp:TemplateField HeaderText="Habilitado" ItemStyle-Width="5%">
              <ItemTemplate>
                <asp:CheckBox ID="CheckBox" runat="server" Checked='<%# Iif(Eval("ESTAHABILITADO") = 1, true, false) %>'
                  Enabled="False" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="AUFECHACREACION" HeaderText="Fecha creaci&#243;n" DataFormatString="{0:d}"
              HtmlEncode="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
            <asp:BoundField DataField="AUUSUARIOELIMINACION" HeaderText="Usuario que lo elimin&#243;"
              HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="AUFECHAELIMINACION" HeaderText="Fecha eliminaci&#243;n"
              DataFormatString="{0:d}" HtmlEncode="False" HeaderStyle-HorizontalAlign="Center"
              ItemStyle-Width="10%" />
            <asp:TemplateField HeaderText="Eliminar" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete"
                  CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ROLES") %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se encontraron usuarios.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>
</asp:Content>
