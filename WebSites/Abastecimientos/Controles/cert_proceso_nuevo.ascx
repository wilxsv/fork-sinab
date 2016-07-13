<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cert_proceso_nuevo.ascx.vb" Inherits="Controles_cert_proceso_nuevo" %>


    <table class="CenteredTable" >
                       
                        <tr>
                            <td style="white-space: nowrap; text-align: right" valign="top">Proceso:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap; text-align: right">Tipo de Producto:</td>
                            <td style="text-align: left">
                                <asp:DropDownList ID="DD1" runat="server"/>
                                </td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap; text-align: right">Fecha de inicio:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="10"  CssClass="datefield"/>(dd/mm/aaaa)
                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" Display="Dynamic"
                                    ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox3"
                                    Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td style="white-space: nowrap; text-align: right" valign="top">Comentario:</td>
                            <td style="text-align: left">
                                <asp:TextBox ID="TextBox1" runat="server" Height="58px" TextMode="MultiLine" Width="450px"></asp:TextBox></td>
                        </tr>
                       
                    </table>
               