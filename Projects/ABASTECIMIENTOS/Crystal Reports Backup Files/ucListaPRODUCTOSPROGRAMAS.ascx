<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaPRODUCTOSPROGRAMAS.ascx.vb"
  Inherits="ucListaPRODUCTOSPROGRAMAS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
  AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDPRODUCTO,IDPROGRAMA"
  Width="100%">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantPRODUCTOSPROGRAMAS.aspx?id={0}&IDPROGRAMA={1}"
      DataNavigateUrlFields="IDPRODUCTO,IDPROGRAMA" Text="Seleccionar" />
    <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" ItemStyle-Width="10%" />
    <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" HeaderStyle-HorizontalAlign="Left"
      ItemStyle-HorizontalAlign="Left" ItemStyle-Width="55%" />
    <asp:BoundField DataField="PROGRAMA" HeaderText="Programa" HeaderStyle-HorizontalAlign="Left"
      ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" />
    <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="5%">
      <ItemTemplate>
        <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
          AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
          ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
