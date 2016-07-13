<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaSUMINISTROS.ascx.vb"
    Inherits="ucListaSUMINISTROS" %>
<%@ Register Src="~/Controles/ucFiltrarDatos.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" runat="server"
    AllowPaging="True" CellPadding="4" GridLines="None" Width="100%">
    <HeaderStyle CssClass="GridListHeader" />
    <FooterStyle CssClass="GridListFooter" />
    <PagerStyle CssClass="GridListPager" />
    <RowStyle CssClass="GridListItem" />
    <SelectedRowStyle CssClass="GridListSelectedItem" />
    <EditRowStyle CssClass="GridListEditItem" />
    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
    <Columns>
        <asp:HyperLinkField HeaderText="Editar / Consultar" Target="_self" DataNavigateUrlFormatString="~/Catalogos/wfDetaMantSUMINISTROS.aspx?id={0}"
            DataNavigateUrlFields="IDSUMINISTRO" Text="Seleccionar" />
        <asp:BoundField DataField="IDSUMINISTRO" HeaderText="ID" />
        <asp:TemplateField HeaderText="Tipo de Suministro">
            <ItemTemplate>
                <asp:Label ID="Label_IDTIPOSUMINISTRO1" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDTIPOSUMINISTRO") %>' />
                <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS1" runat="server" AutoPostBack="true"
                    Enabled="False" CssClass="DDLClassDisabled" Width="147px" />
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label ID="Label_IDTIPOSUMINISTRO2" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDTIPOSUMINISTRO") %>' />
                <cc1:ddlTIPOSUMINISTROS ID="ddlTIPOSUMINISTROS2" runat="server" AutoPostBack="true"
                    Width="226px" />
            </EditItemTemplate>
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:TemplateField>
        <asp:BoundField DataField="CORRELATIVO" HeaderText="Correlativo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
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
