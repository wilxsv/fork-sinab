<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFiltroSolicitudCompra.ascx.vb" Inherits="Controles_ucFiltroSolicitudCompra" %>
<table style="width: 100%; height: 100%">
    <tr>
        <td style="width: 100px; height: 28px">
            <asp:DropDownList ID="DdlCriterio" runat="server" AutoPostBack="True" Width="134px">
                <asp:ListItem Value="1">No Solicitud</asp:ListItem>
                <asp:ListItem Value="2">Fecha Solicitud</asp:ListItem>
                <asp:ListItem Value="3">Dependencia</asp:ListItem>
                <asp:ListItem Value="4">Plazo de Entrega</asp:ListItem>
                <asp:ListItem Value="1">Estado</asp:ListItem>
            </asp:DropDownList><asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True"
                Width="141px">
                <asp:ListItem Value="=">Igual (=)</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
                <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
                <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
                <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
                <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
            </asp:DropDownList><asp:TextBox ID="TxtBuscar" runat="server"></asp:TextBox><asp:DropDownList
                ID="DdlPlazoentrega" runat="server" Width="95px">
                <asp:ListItem Value="1">0 Dias</asp:ListItem>
                <asp:ListItem Value="2">15 Dias</asp:ListItem>
                <asp:ListItem Value="3">30 Dias</asp:ListItem>
                <asp:ListItem Value="4">45 Dias</asp:ListItem>
                <asp:ListItem Value="5">60 dias</asp:ListItem>
                <asp:ListItem Value="6">75 Dias</asp:ListItem>
                <asp:ListItem Value="7">90 Dias</asp:ListItem>
                <asp:ListItem Value="8">105 Dias</asp:ListItem>
                <asp:ListItem Value="9">120 Dias</asp:ListItem>
            </asp:DropDownList><asp:Button ID="BttBuscar" runat="server" CausesValidation="False"
                Text="Buscar" /></td>
    </tr>
    <tr>
        <td style="width: 100px">
            <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False"
                BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3"
                CellSpacing="1" GridLines="None" Width="60%">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <SelectedItemStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" NextPageText="Siguiente &gt;&gt;"
                    PrevPageText="&lt;&lt; Anterior" />
                <ItemStyle BackColor="#DEDFDE" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <Columns>
                    <asp:HyperLinkColumn DataNavigateUrlField="IDSOLICITUD" DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id={0}"
                        DataTextField="CORRELATIVO" HeaderText="N&#176; Solicitud" SortExpression="CORRELATIVO"
                        Target="_self">
                        <HeaderStyle Width="20%" />
                    </asp:HyperLinkColumn>
                    <asp:BoundColumn DataField="FECHASOLICITUD" HeaderText="Fecha Creacion" SortExpression="FECHASOLICITUD">
                        <HeaderStyle Width="60%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="PLAZOENTREGA" HeaderText="Plazo Entrega" SortExpression="PLAZOENTREGA" />
                    <asp:BoundColumn DataField="IDESTADO" HeaderText="Estado" SortExpression="IDESTADO" />
                    <asp:TemplateColumn>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar el Registro' border='0' /></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle Width="20%" />
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
</table>
