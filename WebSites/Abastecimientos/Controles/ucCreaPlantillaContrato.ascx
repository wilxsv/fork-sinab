<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCreaPlantillaContrato.ascx.vb"
    Inherits="Controles_ucCreaPlantillaContrato" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
<h3>
    <asp:Label ID="Label1" runat="server" Text="Listado de plantillas generadas" /></h3>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell" style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="Tipo de Compra:" />
        </td>
        <td class="DataCell">
            <cc1:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell" style="text-align: right">
            <asp:Label ID="Label3" runat="server" Text="Suministro:" />
        </td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnConsultar" runat="server" Text="Ver plantillas" />
        </td>
    </tr>
</table>
<div class="ScrollPanel">
    <div>
        <asp:DataGrid ID="dgPlantilla" runat="server" AutoGenerateColumns="False" CellPadding="4"
            CssClass="Grid" GridLines="None" Width="100%">
            <EditItemStyle CssClass="GridListEditItem" />
            <SelectedItemStyle CssClass="GridListSelectedItem" />
            <AlternatingItemStyle CssClass="GridListAlternatingItem" />
            <ItemStyle CssClass="GridListItem" />
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <Columns>
                <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;"></asp:ButtonColumn>
                <asp:BoundColumn DataField="IDPLANTILLA" HeaderText="C&#243;digo">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="IDSUMINISTRO" HeaderText="IDSUMINISTRO" Visible="False">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="NOMBRE" HeaderText="Plantilla">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                        Font-Underline="False" HorizontalAlign="Left" />
                </asp:BoundColumn>
                <asp:BoundColumn DataField="PERSONERIAJURIDICA" Visible="False"></asp:BoundColumn>
                <asp:BoundColumn DataField="IDTIPOCOMPRA" HeaderText="IDTIPOCOMPRA" Visible="False">
                </asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
    </div>
</div>
