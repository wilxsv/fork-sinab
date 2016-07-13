<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cert_crudEstados.ascx.vb" Inherits="Controles_cert_crudEstados" %>

                <h4>Estado del producto</h4>
                  <div style="margin-bottom: 10px ">
                    Último Estado: <b>
                        <asp:Literal ID="Label7" runat="server" /></b>
                </div>
                <table class="CenteredTable">

                    <tr>
                        <td valign="top">Estado:</td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0">Certificado</asp:ListItem>
                                <asp:ListItem Value="1">No Certificado</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="RadioButtonList2"
                                ErrorMessage="* Dato requerido" ValidationGroup="3" Font-Size="Smaller" Display="Dynamic"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td>Fecha:</td>
                        <td>
                            <asp:TextBox ID="TextBox9" runat="server" CssClass="datefield"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                ControlToValidate="TextBox9" Display="Dynamic" ErrorMessage="* Dato requerido"
                                ValidationGroup="3" Font-Size="Smaller"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox9"
                                Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date"
                                ValidationGroup="3" Font-Size="Smaller"></asp:CompareValidator></td>
                    </tr>
                    <tr>
                        <td valign="top">Comentario:</td>
                        <td>
                            <asp:TextBox ID="TextBox10" runat="server" MaxLength="300" Height="58px" TextMode="MultiLine" Width="417px"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox10"
                                ErrorMessage="* Dato requerido" ValidationGroup="3" Font-Size="Smaller"></asp:RequiredFieldValidator></td>
                    </tr>

                </table>
                <div style="margin: 10px 0">
                    <asp:Button ID="btnAddStatus" runat="server" Text="Agregar Estado" ValidationGroup="3" />
                </div>
                <div style="margin:20px 0">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False"  CellPadding="4" 
                        GridLines="None" CssClass="Grid GridIzquierda">
                        <Columns>
                            <asp:BoundField HeaderText="Estado" DataField="Certificado" />
                            <asp:BoundField HeaderText="Fecha &#250;ltimo cambio" DataField="fecha" DataFormatString="{0:d}" />
                            <asp:BoundField HeaderText="Comentario" DataField="comentario" ItemStyle-HorizontalAlign="Left" />
                        </Columns>
                         <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                        <EmptyDataTemplate>- No hay registro de estados en la Base de Datos -</EmptyDataTemplate>
                    </asp:GridView>
                </div>