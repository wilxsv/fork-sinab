<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaEMPLEADOSALMACEN.ascx.vb"
  Inherits="ucListaEMPLEADOSALMACEN" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
  AllowPaging="True" CellPadding="4" GridLines="None" Width="100%">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantEMPLEADOSALMACEN.aspx?id={0}&amp;IDEMPLEADO={1}"
      DataNavigateUrlFields="IDALMACEN,IDEMPLEADO" Text="Seleccionar" />
    <asp:BoundField DataField="IDALMACEN" HeaderText="ID" />
    <asp:BoundField DataField="ALMACEN" HeaderText="Almac&#233;n" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="IDEMPLEADO" HeaderText="ID" />
    <asp:BoundField DataField="EMPLEADO" HeaderText="Empleado" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" ItemStyle-HorizontalAlign="Left" />
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
