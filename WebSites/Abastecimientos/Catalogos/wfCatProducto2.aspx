<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="wfCatProducto2.aspx.vb" Inherits="Catalogos_wfCatProducto2" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta" colspan="2">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
                    Catálogos -> Productos no médicos
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button4" runat="server" CausesValidation="False" Text="<< Regresar"
                    Width="96px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Suministro:" /></td>
            <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Grupo:" /></td>
            <td class="DataCell">
                <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Subgrupo:" /></td>
            <td class="DataCell">
                <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Button ID="Button3" runat="server" CausesValidation="False" Text="Cancelar" /></td>
            <td class="DataCell">
                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Continuar >>" /></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="False">
                    <table class="CenteredTable" style="width: 100%;">
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label4" runat="server" Text="Ingrese el código del producto:" /></td>
                            <td class="DataCell">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" />
                                <ew:NumericBox ID="NumericBox1" runat="server" Width="40px" MaxLength="3" />
                                <asp:TextBox ID="TextBox7" runat="server" MaxLength="8" Visible="False" Width="40px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NumericBox1"
                                    ErrorMessage="Requerido" Display="Dynamic" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox7"
                                    Display="Dynamic" ErrorMessage="Requerido" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label7" runat="server" Text="Nombre Genérico:" /></td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtNOMBRE" runat="server" TextMode="MultiLine" Width="400px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label6" runat="server" Text="Unidad de medida:" /></td>
                            <td class="DataCell">
                                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Width="177px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label13" runat="server" Text="Precio actual:" /></td>
                            <td class="DataCell">
                                <ew:NumericBox ID="nbPRECIOACTUAL" runat="server" Width="107px" CssClass="Textbox"
                                    AutoFormatCurrency="True" DecimalPlaces="2" TextAlign="Right">$0.00</ew:NumericBox>
                                <asp:RequiredFieldValidator ID="rfvPRECIOACTUAL" runat="server" ControlToValidate="nbPRECIOACTUAL"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label14" runat="server" Text="Aplica lote:" /></td>
                            <td class="DataCell">
                                <asp:CheckBox ID="cbAPLICALOTE" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label18" runat="server" Text="Producto habilitado:" /></td>
                            <td class="DataCell">
                                <asp:CheckBox ID="cbESTADOPRODUCTO" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label19" runat="server" Text="Observación:" /></td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtOBSERVACION" runat="server" TextMode="MultiLine" Width="400px"
                                    CssClass="Textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button2" runat="server" Text="Guardar" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
