<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaCRITERIOSEVALUACIONLG.ascx.vb"
    Inherits="ucListaCRITERIOSEVALUACIONLG" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDCRITERIOEVALUACION">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantCRITERIOSEVALUACIONLG.aspx?id={0}"
            DataNavigateUrlFields="IDCRITERIOEVALUACION" Text="Seleccionar" />
        <asp:BoundField DataField="TIPOCRITERIO" HeaderText="Tipo Criterio">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
            <HeaderStyle HorizontalAlign="Left" />
            <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="PORCENTAJE" HeaderText="Porcentaje">
            <HeaderStyle HorizontalAlign="Right" />
            <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Criterio global">
            <ItemTemplate>
                <asp:CheckBox ID="cbESGLOBAL" runat="server" Checked='<%# Iif (Eval("ESGLOBAL") = 1, True, False) %>'
                    Enabled="False" />
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
    <EmptyDataTemplate>
        No se encontraron registros.</EmptyDataTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
