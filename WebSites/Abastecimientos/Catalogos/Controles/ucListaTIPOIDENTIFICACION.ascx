<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaTIPOIDENTIFICACION.ascx.vb"
  Inherits="ucListaTIPOIDENTIFICACION" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" AllowPaging="True"
  GridLines="None" DataKeyNames="IDTIPOIDENTIFICACION">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantTIPOIDENTIFICACION.aspx?id={0}"
      DataNavigateUrlFields="IDTIPOIDENTIFICACION" Text="Seleccionar" />
    <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
      <ItemStyle HorizontalAlign="Left" Width="230px" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
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
