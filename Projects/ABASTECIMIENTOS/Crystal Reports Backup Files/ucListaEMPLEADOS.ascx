<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaEMPLEADOS.ascx.vb"
  Inherits="ucListaEMPLEADOS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
  CellPadding="4" GridLines="None" AllowPaging="True" Width="100%" DataKeyNames="IDEMPLEADO">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:HyperLinkField Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantEMPLEADOS.aspx?id={0}"
      DataNavigateUrlFields="IDEMPLEADO" Text="Seleccionar" />
    <asp:BoundField DataField="IDEMPLEADO" HeaderText="ID">
      <ItemStyle Width="5%" />
    </asp:BoundField>
    <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Establecimiento">
      <ItemStyle HorizontalAlign="Left" Width="20%" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="DEPENDENCIA" HeaderText="Dependencia">
      <ItemStyle HorizontalAlign="Left" Width="20%" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="CARGO" HeaderText="Cargo">
      <ItemStyle HorizontalAlign="Left" Width="10%" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="NOMBRECORTO" HeaderText="C&#243;digo MSPAS">
      <ItemStyle HorizontalAlign="Left" Width="20%" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="NOMBREAPELLIDO" HeaderText="Nombre">
      <ItemStyle HorizontalAlign="Left" Width="10%" />
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
  <EmptyDataTemplate>
    No se encontraron registros.</EmptyDataTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
