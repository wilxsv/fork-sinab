<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucEntregasConAtraso.ascx.vb" Inherits="Controles_ucEntregasConAtraso" %>
<table style="width: 866px">
    <tr>
        <td align="center" valign="top">
            <asp:Label ID="lblTitulo" runat="server" Text="NO HAY CANTIDADES CON ATRASO PARA ESTA ENTREGA"
                Visible="False" />
            <asp:Label ID="estado" runat="server" Visible="False">False</asp:Label></td>
    </tr>
    <tr>
        <td valign="top" align="left">
            <asp:DataGrid ID="dgLista1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="100%" PageSize="5">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="almacen" HeaderText="Lugar de asignaci&amp;oacuten">
                        <HeaderStyle Width="60%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="cantidadatrasoalmacen" DataFormatString="{0:d}" HeaderText="Cantidad">
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="tiempoatraso" HeaderText="Dias Atraso">
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Valor total">
                        <ItemTemplate>
                            &nbsp;
                            <asp:Label ID="LblMonto" runat="server" />
                            <asp:Label ID="lblcant" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cantidadatrasoalmacen") %>'
                                Visible="False" />
                            <asp:Label ID="lblprecio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.preciounitario") %>'
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

