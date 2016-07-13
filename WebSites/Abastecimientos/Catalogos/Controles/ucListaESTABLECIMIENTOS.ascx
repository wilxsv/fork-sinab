<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaESTABLECIMIENTOS.ascx.vb"
  Inherits="ucListaESTABLECIMIENTOS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
  CellPadding="4" GridLines="None" AllowPaging="True" Width="100%" DataKeyNames="IDESTABLECIMIENTO">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantESTABLECIMIENTOS.aspx?id={0}"
      DataNavigateUrlFields="IDESTABLECIMIENTO" Text="Seleccionar" />
    <asp:BoundField DataField="CODIGOESTABLECIMIENTO" HeaderText="C&#243;digo" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="ZONA" HeaderText="Zona" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="MUNICIPIO" HeaderText="Municipio" ItemStyle-HorizontalAlign="Left" />
    <asp:BoundField DataField="TELEFONO" HeaderText="Tel&#233;fono" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="FAX" HeaderText="Fax" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="NIVEL" HeaderText="Nivel" ItemStyle-HorizontalAlign="Right" />
    <asp:BoundField DataField="TIPOCONSUMO" HeaderText="Tipo Consumo" />
    <asp:TemplateField HeaderText="Eliminar">
      <ItemTemplate>
        <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
          AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
          ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
  <EmptyDataTemplate>
    No se encontraron registros.</EmptyDataTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
