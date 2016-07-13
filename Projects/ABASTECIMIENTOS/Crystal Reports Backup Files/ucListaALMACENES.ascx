<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaALMACENES.ascx.vb"
  Inherits="ucListaALMACENES" %>
<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
  AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDALMACEN">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <EditRowStyle CssClass="GridEditrow" />
  <SelectedRowStyle CssClass="GridSelectedItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantALMACENES.aspx?id={0}"
      DataNavigateUrlFields="IDALMACEN" Text="Seleccionar" />
    <asp:BoundField DataField="IDALMACEN" HeaderText="ID" />
    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="DIRECCION" HeaderText="Direcci&#243;n">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="TELEFONO" HeaderText="Tel&#233;fono">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="FAX" HeaderText="Fax">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="Farmacia">
      <ItemTemplate>
        <asp:CheckBox ID="CheckBox" runat="server" Checked='<%# Iif(Eval("ESFARMACIA") = 1, true, false) %>'
          Enabled="False" />
      </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Eliminar">
      <ItemTemplate>
        <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
          AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
          ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
