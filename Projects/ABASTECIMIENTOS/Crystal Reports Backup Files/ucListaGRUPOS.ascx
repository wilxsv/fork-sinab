<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaGRUPOS.ascx.vb"
  Inherits="ucListaGRUPOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      </td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" Enabled="False" Visible="False" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        CellPadding="4" GridLines="None" AllowPaging="True" DataKeyNames="IDGRUPO" Width="100%">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:HyperLinkField Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantGRUPOS.aspx?id={0}"
            DataNavigateUrlFields="IDGRUPO" Text="Seleccionar" />
          <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" />
          <asp:BoundField DataField="GRUPO" HeaderText="Grupo" />
          <asp:BoundField DataField="CORRELATIVO" HeaderText="Correlativo" />
          <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" />
          <asp:TemplateField>
            <ItemTemplate>
              <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
