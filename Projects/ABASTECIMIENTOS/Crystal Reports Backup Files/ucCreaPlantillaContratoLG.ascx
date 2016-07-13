<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucCreaPlantillaContratoLG.ascx.vb" Inherits="Controles_ucCreaPlantillaContratoLG" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<table class="CenteredTable" style="width:100%;">
    <tr>
        <td colspan="2">
            <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Listado de plantillas generadas" /></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td class="LabelCell" style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="Tipo de Compra:"/></td>
        <td class="DataCell">
            <cc1:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server"/></td>
    </tr>
    <tr>
        <td class="LabelCell" style="text-align: right">
            <asp:Label ID="Label3" runat="server" Text="Suministro:"/></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server"/></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="btnConsultar" runat="server" Text="Ver plantillas" /></td>
    </tr>
    <tr>
        <td colspan="2"></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center" >
            <asp:DataGrid ID="dgPlantilla" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="80%">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
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
            </asp:DataGrid></td>
    </tr>
</table>
