<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucStaClausula.ascx.vb" Inherits="Controles_ucStaClausula" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2">
            <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="width: 100px">
            &nbsp;
        </td>
        <td style="width: 100px">
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="Lista de clausulas ingresadas" /></td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="Label2" runat="server" Text="Tipo:" Visible="False" /></td>
        <td style="width: 100px; text-align: left">
            <asp:DropDownList ID="ddlTipoClausula" runat="server" AutoPostBack="True" Visible="False">
                <asp:ListItem Selected="True" Value="1">Considerando</asp:ListItem>
                <asp:ListItem Value="2">Recomendaci&#243;n</asp:ListItem>
                <asp:ListItem Value="3">Clausula</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right">
        </td>
        <td style="width: 100px; text-align: left">
        </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: left">
            <asp:DataGrid ID="dgClausula" runat="server" AutoGenerateColumns="False" CellPadding="4"
                ForeColor="#333333" GridLines="None" Width="749px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Ver "></asp:ButtonColumn>
                    <asp:BoundColumn DataField="NOMBRE" HeaderText="Clausula">
                        <HeaderStyle Width="700px" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDCLAUSULA" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
</table>
