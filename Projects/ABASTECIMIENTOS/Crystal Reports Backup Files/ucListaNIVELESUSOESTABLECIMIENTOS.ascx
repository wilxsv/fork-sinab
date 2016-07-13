<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaNIVELESUSOESTABLECIMIENTOS.ascx.vb"
    Inherits="ucListaNIVELESUSOESTABLECIMIENTOS" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:GridView ID="gvLista" AutoGenerateColumns="False" runat="server" AllowPaging="True"
    CellPadding="4" GridLines="None" Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantNIVELESUSOESTABLECIMIENTOS.aspx?id={0}&IDNIVELUSO={1}"
            DataNavigateUrlFields="IDESTABLECIMIENTO,IDNIVELUSO" Text="Seleccionar" />
        <asp:BoundField DataField="IDESTABLECIMIENTO" HeaderText="ID" />
        <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Establecimiento">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="IDNIVELUSO" HeaderText="ID" />
        <asp:BoundField DataField="NOMBRECORTO" HeaderText="Nombre Corto">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="NIVELDEUSO" HeaderText="Nivel de Uso">
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
