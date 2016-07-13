<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaDEPARTAMENTOS.ascx.vb"
    Inherits="ucListaDEPARTAMENTOS" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    CellPadding="4" GridLines="None" DataKeyNames="IDDEPARTAMENTO">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantdEPARTAMENTOS.aspx?id={0}"
            DataNavigateUrlFields="IDDEPARTAMENTO" Text="Seleccionar" />
        <asp:BoundField DataField="CODIGODEPARTAMENTO" HeaderText="C&#243;digo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="LinkButton1" runat="server" AlternateText="Elimina el registro"
                    CausesValidation="False" CommandName="Delete" CssClass="GridImagenEliminarItem"
                    ImageUrl="~/Imagenes/Eliminar.gif" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
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
