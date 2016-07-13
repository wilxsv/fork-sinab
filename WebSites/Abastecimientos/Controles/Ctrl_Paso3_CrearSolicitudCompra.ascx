<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso3_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso3_CrearSolicitudCompra" %>
<%@ Register src="BuscarLugarEntrega.ascx" tagname="BuscarLugarEntrega" tagprefix="uc1" %>
<h3>PASO #3 - Lugares de Entrega</h3>
                    <div class="CenteredTable">
                        <div class="CenteredTable" style="margin-bottom: 10px;">
                           
                            <uc1:BuscarLugarEntrega ID="BuscarLugarEntrega" runat="server" />
                            <div style="margin-top: 10px">
                             <asp:Button ID="Button4" runat="server" Text="Agregar" />
                                </div>
                        </div>
                        <div class="GridHeader">
                            <table>
                                <tr >
                                    <th style="width: 100%; text-align: left;" > Lugares de Entrega</th>
                                    <td>
                                        <asp:LinkButton runat="server" CssClass="GridActualizar" ID="lnkUpdateGrid" OnClick="lnkUpdateGrid_Click"/>
                                    </td>
                                </tr>
                            </table>
                           
                        </div>
                        <asp:GridView ID="gvLugarEntregas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                            CellPadding="4" GridLines="None" DataKeyNames="Key" Width="100%" ShowHeader="False">
                           
                            <FooterStyle CssClass="GridListFooterSmaller" />
                            <PagerStyle CssClass="GridListPagerSmaller" />
                            <RowStyle CssClass="GridListItemSmaller" />
                            <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                            <EditRowStyle CssClass="GridListEditItemSmaller" />
                            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                            <Columns>
                                <asp:BoundField DataField="Value" HeaderText="Lugares de Entrega" ItemStyle-Width="100%">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteButton" runat="server" CssClass="GridBorrar" CommandName="Delete"
                                            OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Literal runat="server" ID="edtpl" Text="No hay Lugares de Entrega registrados" />
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>