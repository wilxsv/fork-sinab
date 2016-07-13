<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaDOCUMENTOSBASE.ascx.vb"
    Inherits="ucListaDOCUMENTOSBASE" %>
<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>

<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<div style="margin: 20px 0">
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDDOCUMENTOBASE" Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantDOCUMENTOSBASE.aspx?id={0}"
            DataNavigateUrlFields="IDDOCUMENTOBASE" Text="Seleccionar" />
        <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo de Documento">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="GridBorrar"
                    AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                   OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        No se encontraron registros.</EmptyDataTemplate>
</asp:GridView>
    </div>

