<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaFUENTEFINANCIAMIENTOS.ascx.vb"
  Inherits="ucListaFUENTEFINANCIAMIENTOS" %>
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
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantFUENTEFINANCIAMIENTOS.aspx?id={0}"
      DataNavigateUrlFields="IDFUENTEFINANCIAMIENTO" Text="Seleccionar" />
    <asp:BoundField DataField="IDFUENTEFINANCIAMIENTO" HeaderText="ID" />
    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left"
      ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="GRUPO" HeaderText="Grupo" HeaderStyle-HorizontalAlign="Left"
      ItemStyle-HorizontalAlign="Left" />
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
