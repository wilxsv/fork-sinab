<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="wfCatProducto.aspx.vb" Inherits="Catalogos_wfCatProducto" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td colspan="2" align="left" style="background-color: #b5c7de">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                <asp:Label ID="LblRuta" runat="server" Font-Bold="False" Text="Catálogos -> Mantenimiento de Cat&aacutelogo de Productos" /></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table class="CenteredTable" style="width: 100%;">
                    <tr>
                        <td colspan="2" align="left">
                            <asp:Button ID="Button4" runat="server" CausesValidation="False" Text="<< Regresar"
                                Width="96px" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 277px" align="right">
                <asp:Label ID="Label1" runat="server" Text="Suministro:" /></td>
            <td style="width: 100px" align="left">
                <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" AutoPostBack="True" Width="400px">
                </cc1:ddlSUMINISTROS></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 277px" align="right">
                <asp:Label ID="Label2" runat="server" Text="Grupo:" /></td>
            <td style="width: 100px" align="left">
                <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" AutoPostBack="True" Width="400px">
                </cc1:ddlGRUPOS></td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 277px" align="right">
                <asp:Label ID="Label3" runat="server" Text="Subgrupo:" /></td>
            <td style="width: 100px" align="left">
                <cc1:ddlSUBGRUPOS ID="DdlSUBGRUPOS1" runat="server" Width="400px">
                </cc1:ddlSUBGRUPOS></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button3" runat="server" CausesValidation="False" Text="Cancelar"
                    Width="96px" />
                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Continuar >>"
                    Width="96px" /></td>
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
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Ingrese el código del producto:" /></td>
                            <td align="left">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" /><ew:NumericBox ID="NumericBox1"
                                    runat="server" Width="41px" MaxLength="3" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        runat="server" ControlToValidate="NumericBox1" ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label7" runat="server" Text="Nombre Genérico:" Width="127px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="500px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label9" runat="server" Text="Concentración:" Width="62px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox2" runat="server" Width="500px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label10" runat="server" Text="Forma farmacéutica:" Width="152px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox3" runat="server" Width="500px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox3"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label11" runat="server" Text="Presentación:" Width="96px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine" Width="500px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox4"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" Text="Unidad de medida:" Width="124px" /></td>
                            <td align="left">
                                <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="177px">
                                </cc1:ddlUNIDADMEDIDAS></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label8" runat="server" Text="Nivel de Uso:" Width="88px" /></td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList1" runat="server" Width="500px" DataSourceID="ObjectDataSource1"
                                    DataTextField="NIVELUSO" DataValueField="IDNIVELUSO">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="DropDownList1"
                                    ErrorMessage="Requerido" />
                                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ObtenerNivelesUsoLetras"
                                    TypeName="ABASTECIMIENTOS.DATOS.dbNIVELESUSO">
                                    <SelectParameters>
                                        <asp:SessionParameter DefaultValue="false" Name="SOLOLETRAS" SessionField="Sololetras"
                                            Type="Boolean" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" Text="Prioridad:" Width="66px" /></td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList3" runat="server" Width="35px">
                                    <asp:ListItem Selected="True">1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label13" runat="server" Text="Precio actual:" Width="100px" /></td>
                            <td align="left">
                                <ew:NumericBox ID="NumericBox3" runat="server" Width="107px" CssClass="Textbox">0.00</ew:NumericBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="NumericBox3"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label14" runat="server" Text="Lote:" Width="48px" /></td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownList2" runat="server" Width="117px">
                                    <asp:ListItem Selected="True" Value="0">Aplica</asp:ListItem>
                                    <asp:ListItem Value="1">No Aplica</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label16" runat="server" Text="Codigo de las Naciones Unidas:" Width="218px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox5" runat="server" Width="143px" CssClass="Textbox" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox5"
                                    ErrorMessage="Requerido" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label17" runat="server" Text="Pertenece al Listado Oficial:" Width="188px" /></td>
                            <td align="left">
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" Text="Producto habilitado:" Width="138px" /></td>
                            <td align="left">
                                <asp:CheckBox ID="CheckBox2" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td align="left">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label19" runat="server" Text="Observación:" Width="48px" /></td>
                            <td align="left">
                                <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="500px" CssClass="Textbox" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label15" runat="server" Text="Existencias actuales:" Width="152px"
                                    Visible="False" /></td>
                            <td align="left">
                                <ew:NumericBox ID="NumericBox4" runat="server" Width="125px" Visible="False" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="NumericBox4"
                                    ErrorMessage="Requerido" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button2" runat="server" Text="Guardar" />
                                <nds:MsgBox ID="MsgBox1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 277px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 277px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 277px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
