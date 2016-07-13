<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmInventarioFisico.aspx.vb" Inherits="FrmInventarioFisico" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Inventario físico
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" DataKeyNames="IDINVENTARIO" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:HyperLinkField DataNavigateUrlFormatString="~/ALMACEN/FrmDetaMantInventario.aspx?id={0}&estado={1}"
              DataNavigateUrlFields="IDINVENTARIO,ESTACERRADO" Text="Seleccionar" />
            <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" />
            <asp:BoundField DataField="FECHAINICIO" HeaderText="Fecha Inicio" DataFormatString="{0:d}"
              HtmlEncode="false" />
            <asp:BoundField DataField="AUFECHAMODIFICACION" DataFormatString="{0:d}" HtmlEncode="false"
              HeaderText="Última Actualización" />
            <asp:BoundField DataField="FECHACIERRE" DataFormatString="{0:d}" HtmlEncode="false"
              HeaderText="Fecha Cierre" />
            <asp:TemplateField HeaderText="Cerrado">
              <ItemTemplate>
                <asp:CheckBox ID="cbCerrado" runat="server" Checked='<%# Iif (Eval("ESTACERRADO") = 1, True, False) %>'
                  Enabled="False" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}"
                  Visible='<%# Iif (Eval("ESTACERRADO") = 1, False, True) %>' />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
