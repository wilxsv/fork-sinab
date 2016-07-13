<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaESPECIFICOGASTO.ascx.vb"
  Inherits="ucListaESPECIFICOGASTO" %>
<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" AutoGenerateColumns="False" runat="server" AllowPaging="True"
  CellPadding="4" GridLines="None" DataKeyNames="IDESPECIFICOGASTO" Width="100%">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantESPECIFICOSGASTO.aspx?id={0}"
      DataNavigateUrlFields="IDESPECIFICOGASTO" Text="Seleccionar" />
    <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo">
      <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
      <ItemStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="Eliminar">
      <ItemTemplate>
        <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
          AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
          ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="return window.confirm('¿Confirma que desea eliminar el registro?');" />
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
