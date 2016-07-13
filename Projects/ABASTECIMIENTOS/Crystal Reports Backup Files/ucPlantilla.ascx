<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucPlantilla.ascx.vb" Inherits="Controles_ucPlantilla" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<%@ Register Src="ucCreaPlantilla.ascx" TagName="ucCreaPlantilla" TagPrefix="uc2" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Lista de plantillas generadas" /></td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: justify">
            <asp:DataGrid ID="dgPlantilla" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="743px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;&gt;"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Plantilla">
                        <HeaderStyle Width="700px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPLANTILLA" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <uc2:ucCreaPlantilla ID="UcCreaPlantilla1" runat="server" />
        </td>
    </tr>
</table>
