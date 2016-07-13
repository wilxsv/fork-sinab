<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucEntregasCantidadesNoEntregadas.ascx.vb" Inherits="Controles_ucEntregasCantidadesNoEntregadas" %>
<table style="width: 866px">
    <tr>
        <td align="center" valign="top">
            <asp:Label ID="lblTitulo" runat="server" Text="NO HAY CANTIDADES SIN ENTREGAR PARA ESTA ENTREGA"
                Visible="False" />
            <asp:Label ID="estado" runat="server" Visible="False">False</asp:Label></td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <asp:DataGrid ID="dgLista1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" PageSize="5">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                <ItemStyle BackColor="#EFF3FB" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="cantidadalmacen" HeaderText="Lugar de asignaci&amp;oacuten">
                        <HeaderStyle Width="60%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="CANTIDAD" DataFormatString="{0:d}" HeaderText="Cantidad">
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Valor total">
                        <ItemTemplate>
                            <asp:Label ID="LblMonto" runat="server" /><asp:Label ID="lblcant" runat="server"
                                Visible="False" /><asp:Label ID="lblprecio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.preciounitario") %>'
                                    Visible="False" />
                            <asp:Label ID="lblCantAlmacen" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cantidadalmacen") %>'
                                Visible="False" />
                            <asp:Label ID="lblCantEnt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cantidadentregadaalmacen") %>'
                                Visible="False" />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid></td>
    </tr>
</table>
