<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDesgloceArticulosInventarioFinal.ascx.vb" Inherits="Controles_ucDesgloceArticulosInventarioFinal" %>
<%@ Register Src="ucAjusteInventario.ascx" TagName="ucAjusteInventario" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table style="width: 100%; height: 100%">
    <tr>
        <td align="center" valign="top" width="100%" style="height: 219px">
            <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Italic="False" Font-Overline="False" Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" />
                <Columns>
                    <asp:TemplateColumn HeaderText="C&amp;oacutedigo / Lote">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtCodigoProducto" runat="server" ForeColor="Transparent" BackColor="Transparent" BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Width="74px" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>'></asp:TextBox><br />
                            <asp:TextBox ID="TxtLote" runat="server" Width="74px" BackColor="Transparent" BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" ReadOnly="True" Text='<%# DataBinder.Eval(Container, "DataItem.CODIGO") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Producto">
                        <ItemTemplate>
                            &nbsp;<asp:TextBox ID="TxtProducto" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                                BorderStyle="Solid" BorderWidth="1px" Height="55px" ReadOnly="True" TextMode="MultiLine"
                                Width="211px" Text='<%# DataBinder.Eval(Container, "DataItem.DESCLARGO") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="U/M">
                        <ItemTemplate>
                            &nbsp;<asp:TextBox ID="TxtUnidadMedida" runat="server" Height="19px" ReadOnly="True" Width="41px" BackColor="Transparent" BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.DESCRIPCION") %>'></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="PRECIO" DataFormatString="{0:c}" HeaderText="Precio">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Disponible Sistema / Captura / Diferencia">
                        <ItemTemplate>
                            <asp:Label ID="sdisp" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADDISPONIBLESISTEMA") %>' /><br />
                            <ew:numericbox id="TxtDisponibleCaptura" runat="server" backcolor="Transparent"
                                bordercolor="LightBlue" borderstyle="Solid" borderwidth="1px" text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADDISPONIBLECAPTURA") %>'
                                width="60px" MaxLength="12" TextAlign="Right"></ew:numericbox><br />
                            <asp:Label ID="dispdif" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADDISPONIBLEDIFERENCIA") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="No Disponible Sistema / Captura / Diferencia">
                        <ItemTemplate>
                            <asp:Label ID="snodisp" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADNODISPONIBLESISTEMA") %>' /><br />
                            <ew:NumericBox ID="TxtNoDisponibleCaptura" runat="server" BackColor="Transparent"
                                BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADNODISPONIBLECAPTURA") %>'
                                Width="60px" MaxLength="12" TextAlign="Right" /><br />
                            <asp:Label ID="nodispdif" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADNODISPONIBLEDIFERENCIA") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Vencida Sistema / Captura / Diferencia">
                        <ItemTemplate>
                            <asp:Label ID="svenc" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADVENCIDASISTEMA") %>' /><br />
                            <ew:NumericBox ID="TxtVencidaCaptura" runat="server" BackColor="Transparent"
                                BorderColor="LightBlue" BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADVENCIDACAPTURA") %>'
                                Width="60px" MaxLength="12" TextAlign="Right" /><br />
                            <asp:Label ID="vencdif" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDADVENCIDADIFERENCIA") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Right" VerticalAlign="Top" />
                        <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Ajustar">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImbAjustar" runat="server" CommandName="Edit" ImageUrl="~/Imagenes/Ajustar.gif" />
                            <asp:Label ID="id" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'
                                Visible="False" />
                            <asp:Label ID="lblExiste" runat="server" Visible="False" />
                            <asp:Label ID="idprod" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'
                                Visible="False" />
                            <asp:Label ID="idlote" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDLOTE") %>'
                                Visible="False" />
                            <asp:Label ID="lblprecio" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRECIO") %>'
                                Visible="False" />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Left" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Guardar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'>
								<img src="Imagenes/botones/save.jpg" alt='Guardar el Registro' border='0' /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDDETALLE") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar el Registro' border='0' /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                            Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>&nbsp;&nbsp;<br />
            <asp:Label ID="Label_CODIGOENZABEZADODOCUMENTO" runat="server" Visible="False" /></td>
    </tr>
    <tr>
        <td align="center" valign="top" width="100%">
            &nbsp;
            <asp:Label ID="lblAlmacen" runat="server" Visible="False" />
            <asp:Label ID="Lblsuminstro" runat="server" Visible="False" />
            <asp:Label ID="LblFuente" runat="server" Visible="False" />
            <asp:Label ID="LblResponsable" runat="server" Visible="False" />
            <asp:Label ID="cfuente" runat="server" Visible="False" />
            <asp:Label ID="cResponsable" runat="server" Visible="False" />
            <asp:Label ID="cVencidos" runat="server" Visible="False" />
            <asp:Label ID="cNodisponibles" runat="server" Visible="False" />
            <ew:CalendarPopup ID="Calendar" runat="server" Width="42px" Visible="False">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" width="100%">
            <uc1:ucAjusteInventario ID="UcAjusteInventario1" runat="server" />
        </td>
    </tr>
</table>
