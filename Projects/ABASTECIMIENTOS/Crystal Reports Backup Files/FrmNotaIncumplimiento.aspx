<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmNotaIncumplimiento.aspx.vb" Inherits="FrmNotaIncumplimiento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td colspan="2" style="text-align: left;">
                <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label12" runat="server" CssClass="Titulo" Text="GENERAR NOTA DE INCUMPLIMIENTO" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblLicitacion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                    BorderStyle="Solid" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left;">
                <asp:Label ID="calFechaExamen" runat="server" Visible="False" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Proveedor" /></td>
            <td class="DataCell">
                <asp:Label ID="LblProveedor" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                    BorderStyle="Solid" BorderWidth="1px" />
                <asp:TextBox ID="TxtProceso" runat="server" Width="1px" Visible="False" />
                <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Visible="False" Width="16px" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="N° de oferta" /></td>
            <td class="DataCell">
                <asp:Label ID="LblOferta" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                    BorderStyle="Solid" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                Lista&nbsp; que pertenece</td>
            <td class="DataCell">
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:DropDownList ID="ddlIDRECTEC" runat="server">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnFind" runat="server" Text="Buscar" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Fecha limite para entregar documentaci&oacuten" /></td>
            <td class="DataCell">
                <ew:CalendarPopup ID="CalendarFechaLimite" runat="server" Width="91px" Culture="Spanish (El Salvador)" />
                <ew:TimePicker ID="TimeHoraLimite" runat="server" MilitaryTime="True" Width="91px"
                    MinuteInterval="TenMinutes" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="N&uacutemero de oficio" /></td>
            <td class="DataCell">
                <ew:MaskedTextBox ID="TxtOficio" runat="server" Mask="9999-9999-9999" />
                <asp:Label ID="Label10" runat="server" Text="(####-####-####)" />
                <asp:Label ID="lblerror" runat="server" ForeColor="#C00000" Text="*Requerido" Visible="False" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Observaciones" /></td>
            <td class="DataCell">
                <asp:TextBox ID="TxtObservaciones" runat="server" TextMode="MultiLine" Width="433px" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="Empleado que emite la nota" /></td>
            <td class="DataCell">
                <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="312px" AutoPostBack="True" />
                <asp:Label ID="LblEmpleado" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                    BorderStyle="Solid" BorderWidth="1px" Enabled="False" Visible="False" /></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Cargo" /></td>
            <td class="DataCell">
                <asp:Label ID="LblCargo" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                    BorderStyle="Solid" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #507cd1;">
                <asp:Label ID="Label8" runat="server" Text="Documentacion faltante del ofertante"
                    ForeColor="White" />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel2" runat="server" CssClass="ScrollPanel">
                    <asp:DataGrid ID="dgdocumentacionofertante" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" GridLines="None" PageSize="8">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" Mode="NumericPages" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo Documento">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DOCUMENTOBASE" HeaderText="Documentaci&#243;n">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color: #507cd1;">
                <asp:Label ID="Label9" runat="server" Text="Documentacion faltante de los renglones"
                    ForeColor="White" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.jpg" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel">
                    <asp:DataGrid ID="DgDocumentacionRenglon" runat="server" AutoGenerateColumns="False"
                        CellPadding="4" GridLines="None" PageSize="8">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" Mode="NumericPages" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundColumn DataField="RENGLON" HeaderText="Rengl&amp;oacuten">
                                <ItemStyle HorizontalAlign="Right" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IDDOCUMENTOBASE" HeaderText="C&#243;digo Documento">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DOCUMENTOBASE" HeaderText="Documentaci&#243;n">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
