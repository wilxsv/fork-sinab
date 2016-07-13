<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" AutoEventWireup="false" CodeFile="frmChangePassword.aspx.vb" Inherits="SEGURIDAD_frmChangePassword" title="Inicio Psw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <div>
        <table class="CenteredTable" style="width: 100%">
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                        <table class="CenteredTable" style="width: 100%">
                            <tr>
                                <td colspan="2" style="font-weight: bold; background-color: graytext">
                                    Cambio de contraseña</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label3" runat="server" Text="Usuario:"></asp:Label></td>
                                <td class="DataCell">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    <asp:Label ID="Label4" runat="server" Text="Nueva contraseña:"></asp:Label></td>
                                <td class="DataCell">
                                    <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                        Display="Dynamic" ErrorMessage="Dato requerido" Text="*"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="LabelCell">
                                    Re-escriba nueva contraseña:</td>
                                <td class="DataCell">
                                    <asp:TextBox ID="TextBox2" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                        Display="Dynamic" ErrorMessage="Dato requerido" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1"
                                        ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden"
                                        Text="*"></asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button1" runat="server" Text="Guardar" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">
                    <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></asp:HyperLink></td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

