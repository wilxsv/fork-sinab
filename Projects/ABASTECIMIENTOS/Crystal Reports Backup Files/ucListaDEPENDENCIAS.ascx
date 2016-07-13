<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaDEPENDENCIAS.ascx.vb"
    Inherits="ucListaDEPENDENCIAS" %>
<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    AllowPaging="True" CellPadding="4" GridLines="None" DataKeyNames="IDDEPENDENCIA">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantDEPENDENCIAS.aspx?id={0}"
            DataNavigateUrlFields="IDDEPENDENCIA" Text="Seleccionar" />
        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Dependencia">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                    AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                    ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('�Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerTemplate>
        <asp:LinkButton ID="LnkbPrimero" runat="server" OnClick="LnkbPrimero_Click" Text="Primero" />
        <asp:LinkButton ID="LnkbAnterior" runat="server" OnClick="LnkbAnterior_Click" Text="Anterior" />
        <asp:LinkButton ID="LnkbSiguiente" runat="server" OnClick="LnkbSiguiente_Click" Text="Siguiente" />
        <asp:LinkButton ID="LnkbUltimo" runat="server" OnClick="LnkbUltimo_Click" Text="Ultimo" />
    </PagerTemplate>
</asp:GridView>
<nds:MsgBox ID="MsgBox1" runat="server" />
