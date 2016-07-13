<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso6_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso6_CrearSolicitudCompra" %>
<h3><asp:Literal runat="server" ID="ltTitle" Text="PASO #6 - Distribución" /></h3>
                    <div style="width: 100%" class="CenteredTable">
                        Solalmente puede finalizar una solicitud hasta que todos los productos que la conforman tengan programada su distribución.
                       
                        <asp:Label ID="Label10" runat="server" ForeColor="Red" />
                        <div class="ScrollPanel">
                            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CellPadding="4" ShowFooter="True"
                                CssClass="Grid" DataKeyNames="IdProducto,Renglon,IdUnidadMedida,Capturado,RutaEspecificacion,PrecioActual,DescLargo,Entrega,Correlativo"
                                GridLines="None" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged" Width="100%">
                                <HeaderStyle CssClass="GridListHeader" />
                                <FooterStyle CssClass="GridListFooter" />
                                <PagerStyle CssClass="GridListPager" />
                                <RowStyle CssClass="GridListItem" />
                                <SelectedRowStyle CssClass="GridListSelectedItem" />
                                <EditRowStyle CssClass="GridListEditItem" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Panel runat="server" ID="divChecked" ToolTip="Listo!" Style="width: 24px; height: 24px; display: block; border: none">
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Correlativo" HeaderText="Renglón" />
                                    <asp:BoundField DataField="CorrProducto" HeaderText="Código">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DescLargo" HeaderText="Producto">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UnidadMedida" HeaderText="U/M">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Entrega" HeaderText="No.Entregas">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PrecioActual" DataFormatString="{0:#.0000}" HeaderText="Precio">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Monto (US$)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMonto" runat="server" Text='<%# Bind("MontoRenglon", "{0:#.0000}")%>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Label runat="server" ID="lblTotalMonto" />
                                        </FooterTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkselect" ToolTip="Agregar / Editar distribución" runat="server" CausesValidation="False" CommandName="Select"  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                                <%--<PagerSettings FirstPageText="<<" LastPageText=">>" Mode="NumericFirstLast" />--%>
                                <EmptyDataTemplate>
                                    <asp:Literal runat="server" ID="ltvacio" Text="No existen productos con el parámetro de búsqueda especificado." />
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                       
                       
                    </div>