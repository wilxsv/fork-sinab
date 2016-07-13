<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmInventarioInicial.aspx.vb" Inherits="FrmInventarioInicial" %>

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
        Almacén -&gt; Inventario inicial
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvInventarios" runat="server" AutoGenerateColumns="False" CellPadding="4"
          EmptyDataText="No se han encontrado inventarios iniciales en proceso de carga."
          GridLines="None" DataKeyNames="IDINVENTARIO" Width="100%">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:HyperLinkField DataNavigateUrlFormatString="~/ALMACEN/FrmDetalleInventarioInicial.aspx?id={0}"
              DataNavigateUrlFields="IDINVENTARIO" Text="Seleccionar" />
            <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" />
            <asp:BoundField DataField="FECHAINVENTARIO" HeaderText="Fecha Inicio" DataFormatString="{0:d}"
              HtmlEncode="false" />
            <asp:BoundField DataField="AUFECHAMODIFICACION" DataFormatString="{0:d}" HtmlEncode="false"
              HeaderText="Última Actualización" />
            <asp:TemplateField HeaderText="Eliminar">
              <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                  AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                  ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="return window.confirm('¿Confirma que desea eliminar el inventario?');" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
