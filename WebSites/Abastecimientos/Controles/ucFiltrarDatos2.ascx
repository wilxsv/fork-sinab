<%@ Control Language="VB" CodeFile="ucFiltrarDatos2.ascx.vb" Inherits="Controles_ucFiltrarDatos2" %>
<asp:Panel ID="UpdatePanel1" runat="server" Width="100%">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblFiltro" runat="server" Text="Filtro:" />
                <asp:DropDownList ID="cboFiltro" runat="server" Width="176px" />
                <asp:TextBox ID="txtFiltro" runat="server" Width="200px" MaxLength="20" />
                <asp:Button ID="btnFiltrar" runat="server" Text="Actualizar" Width="80px" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Panel1" runat="server" Width="100%">
    <table style="text-align: left; width: 100%;">
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="12pt" Text="Filtro aplicado" Font-Bold="True"
                    Font-Underline="True" /></td>
        </tr>
        <tr>
            <td style="width: 140px;">
                <asp:Label ID="Label2" runat="server" Text="Columna filtrada:" Font-Bold="True" Font-Size="10pt" /></td>
            <td>
                <asp:Label ID="lblColumna" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="10pt" /></td>
        </tr>
        <tr>
            <td style="width: 140px;">
                <asp:Label ID="Label3" runat="server" Text="Filtro:" Font-Bold="True" Font-Size="10pt" /></td>
            <td>
                <asp:Label ID="lblTabla" runat="server" Font-Bold="False" Font-Italic="True" Font-Size="10pt" /></td>
        </tr>
    </table>
</asp:Panel>
<br />
