<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaSUMINISTROSHOMOGENEOS.ascx.vb"
    Inherits="ucListaSUMINISTROSHOMOGENEOS" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
    CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDSUMINISTRO,IDSUMINISTROHOMOGENEO">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" />
        <asp:BoundField DataField="SUMINISTROHOMOGENEO" HeaderText="Homogéneo" />
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                    CssClass="GridImagenEliminarItem" ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro"
                    OnClientClick="if(!window.confirm('¿Confirma que desea eliminar la relación?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No se encontraron suministros homogéneos.</EmptyDataTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
