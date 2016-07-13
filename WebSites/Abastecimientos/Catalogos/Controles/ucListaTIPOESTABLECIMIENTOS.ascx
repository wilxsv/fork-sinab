<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaTIPOEStableCIMIENTOS.ascx.vb"
    Inherits="ucListaTIPOEStableCIMIENTOS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
    AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDTIPOESTABLECIMIENTO">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantTIPOESTABLECIMIENTOS.aspx?id={0}"
            DataNavigateUrlFields="IDTIPOESTABLECIMIENTO" Text="Seleccionar" />
        <asp:BoundField DataField="NOMBRECORTO" HeaderText="Identificador" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" />
        <asp:TemplateField HeaderText="Eliminar" Visible="False">
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
