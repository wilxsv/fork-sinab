<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso2_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso2_CrearSolicitudCompra" %>

                    <h3>PASO #2 - Fuentes de Financiamiento</h3>
                    <div class="CenteredTable">
                                <asp:DropDownList runat="server" ID="ddlMasterFuentes" AutoPostBack="True" OnSelectedIndexChanged="ddlMasterFuentes_SelectedIndexChanged"/>
                                <asp:DropDownList ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" style="min-width: 300px"  />
                                  <asp:Button ID="btnAgregarFuente" runat="server" Text="Agregar" />
                        <div style="margin-top: 10px">
                            <div class="GridHeader">
                            <table>
                                <tr >
                                    <th style="width: 100%; text-align: left;" > Grupo/Fuente Financiamiento</th>
                                    <td>
                                        <asp:LinkButton runat="server" CssClass="GridActualizar" ID="lnkUpdateSources" OnClick="lnkUpdateSources_Click" />
                                    </td>
                                </tr>
                            </table>
                           
                        </div>
                            <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                                CellPadding="4" GridLines="None" DataKeyNames="Key" Width="100%" ShowHeader="False">
                                <FooterStyle CssClass="GridListFooterSmaller" />
                                <PagerStyle CssClass="GridListPagerSmaller" />
                                <RowStyle CssClass="GridListItemSmaller" />
                                <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
                                <EditRowStyle CssClass="GridListEditItemSmaller" />
                                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
                                <Columns>
                                    <asp:BoundField DataField="Value" HeaderText="Grupo/Fuente Financiamiento" ItemStyle-Width="100%">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="deleteButton" ToolTip="Borrar" CssClass="GridBorrar"
                                                CommandName="Delete" OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <asp:Literal runat="server" ID="ltempty" Text="[No hay Fuentes de Financiamiento registradas]" />
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                                 
                    </div>
