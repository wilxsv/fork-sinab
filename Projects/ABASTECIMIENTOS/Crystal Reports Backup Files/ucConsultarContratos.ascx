<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucConsultarContratos.ascx.vb" Inherits="Controles_ucConsultarContratos" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="A continuación se presenta una serie de parametros por los cuales puede realizar la búsqueda" /></td>
    </tr>
    <tr>
        <td style="width: 100px; text-align: right">
        </td>
        <td style="width: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label5" runat="server" Text="Realizar busqueda por:" /></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:RadioButtonList ID="rblParametro" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem Value="0">N&#250;mero de contrato</asp:ListItem>
                <asp:ListItem Value="1">Proveedor</asp:ListItem>
                <asp:ListItem Value="2">Producto</asp:ListItem>
                <asp:ListItem Value="3">C&#243;digo de Proceso de Compra</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblNoContrato" runat="server" Text="Número de Contrato:" Visible="False" /></td>
        <td style="width: 100px">
            <asp:TextBox ID="txtNoContrato" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right; height: 24px;">
            <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" Visible="False" /></td>
        <td style="width: 100px; height: 24px;">
            <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Visible="False" Width="389px">
            </cc1:ddlPROVEEDORES></td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblProducto" runat="server" Text="Producto:" Visible="False" /></td>
        <td style="width: 100px">
            <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" AutoPostBack="True" Width="387px" Visible="False">
            </cc1:ddlCATALOGOPRODUCTOS></td>
    </tr>
    <tr>
        <td style="text-align: right">
            <asp:Label ID="lblCodProceso" runat="server" Text="Proceso de compra:" Visible="False" /></td>
        <td style="width: 100px">
            <asp:TextBox ID="txtCodProceso" runat="server" Visible="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: center" colspan="2">
            <asp:Label ID="lblNombreProducto" runat="server" /></td>
    </tr>
    <tr>
        <td style="text-align: right">
        </td>
        <td style="width: 100px">
            </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" /></td>
    </tr>
    <tr>
        <td style="text-align: right">
        </td>
        <td style="width: 100px">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:DataGrid ID="dgContrato" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="722px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:ButtonColumn CommandName="Select" Text="Ver"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="CODIGOLICITACION" HeaderText="N&#250;mero de Licitaci&#243;n">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NUMEROOFERTA" HeaderText="N&#250;mero de Oferta">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDESTABLECIMIENTO" HeaderText="IDESTABLECIMIENTO" Visible="False">
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IDPROVEEDOR" HeaderText="IDPROVEEDOR" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="IDCONTRATO" HeaderText="IDCONTRATO" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NUMEROCONTRATO" HeaderText="N&#250;mero de Contrato">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NOMBREPROVEEDOR" HeaderText="Proveedor">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RENGLONESADJUDICADOS" HeaderText="Renglones adjudicados">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="IdProcesoCompra" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
</table>
