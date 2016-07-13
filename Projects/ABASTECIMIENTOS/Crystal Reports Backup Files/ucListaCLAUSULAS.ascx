<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaCLAUSULAS.ascx.vb"
    Inherits="ucListaCLAUSULAS" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDCLAUSULA"
    Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantCLAUSULAS.aspx?IdMod={0}&id={1}"
            DataNavigateUrlFields="IDMODALIDADCOMPRA,IDCLAUSULA" Text="Seleccionar" />
        <asp:BoundField DataField="IDCLAUSULA" HeaderText="ID" ItemStyle-HorizontalAlign="Right" />
        <asp:BoundField DataField="NOMBRE" HeaderText="Cláusula" ItemStyle-HorizontalAlign="Left"
            ItemStyle-Width="80%" />
        <asp:TemplateField HeaderText="Modificativa">
            <ItemTemplate>
                <asp:CheckBox ID="cbMODIFICATIVA" runat="server" Checked='<%# Iif (Eval("MODIFICATIVA") = 1, True, False) %>'
                    Enabled="false" />
            </ItemTemplate>
        </asp:TemplateField>
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
