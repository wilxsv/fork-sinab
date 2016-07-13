<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaSUMINISTRODEPENDENCIAS.ascx.vb"
    Inherits="ucListaSUMINISTRODEPENDENCIAS" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:GridView ID="gvLista" AutoGenerateColumns="False" runat="server" AllowPaging="True"
    CellPadding="4" GridLines="None">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantSUMINISTRODEPENDENCIAS.aspx?id={0}&IDSUMINISTRO={1}"
            DataNavigateUrlFields="IDDEPENDENCIA,IDSUMINISTRO" Text="Seleccionar" />
        <asp:BoundField DataField="IDDEPENDENCIA" HeaderText="ID" />
        <asp:BoundField DataField="DEPENDENCIA" HeaderText="Dependencia">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="IDSUMINISTRO" HeaderText="ID" />
        <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro">
            <ItemStyle HorizontalAlign="Left" />
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
