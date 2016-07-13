<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
    AutoEventWireup="false" CodeFile="FrmAutorizarSolicitudesCompra.aspx.vb" Inherits="FrmAutorizarSolicitudesCompra" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
                &nbsp;<asp:Label ID="LblRuta" runat="server" Text="UFI -> Reserva de fondos" /></td>
        </tr>
        <tr>
            <td>
                <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="RESERVA DE FONDOS SOLICITUD  DE COMPRAS" /></td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="dgLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" Width="60%">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" Mode="NumericPages" />
                    <ItemStyle CssClass="GridListItem" />
                    <SelectedItemStyle CssClass="GridListSelectedItem" />
                    <EditItemStyle CssClass="GridListEditItem" />
                    <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:HyperLinkColumn DataNavigateUrlField="IDSOLICITUD" DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id={0}&amp;flag=autorizar"
                            HeaderText="Autorizar" Text="Autorizar" />
                        <asp:BoundColumn DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" SortExpression="CORRELATIVO" />
                        <asp:BoundColumn DataField="FECHASOLICITUD" DataFormatString="{0:d}" HeaderText="Fecha Creaci&amp;oacuten"
                            HeaderStyle-Width="60%" />
                        <asp:TemplateColumn HeaderText="Dependencia">
                            <ItemTemplate>
                                <cc1:ddlDEPENDENCIAS ID="DdlDEPENDENCIAS1" runat="server" Visible="False" Width="26px" />
                                <asp:Label ID="lbldep" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDDEPENDENCIASOLICITANTE") %>'
                                    Visible="False" />
                                <asp:Label ID="lblDependencia" runat="server" Width="160px" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                                    Visible="False" />
                                <asp:DropDownList ID="ddlEstado" runat="server" Height="15px" Visible="False" Width="89px" />
                                <asp:TextBox ID="TxtEstado" runat="server" ReadOnly="True" BackColor="Transparent"
                                    BorderColor="Transparent" BorderStyle="None" ForeColor="Transparent"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="MONTOSOLICITADO" HeaderText="Monto Solicitado" SortExpression="MONTOSOLICITADO"
                            DataFormatString="{0:c}"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Rechazar Solicitud">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                    ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'>
                                    <asp:Image ID="Image1" runat="server" CssClass="GridImagenEliminarItem" ImageUrl="~/Imagenes/Eliminar.gif"
                                        AlternateText="Rechazar la solicitud" />
                                </asp:LinkButton>
                                <asp:Label ID="lbld" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'
                                    Visible="False" />
                                <asp:Label ID="lblnum" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CORRELATIVO") %>'
                                    Visible="False" />
                            </ItemTemplate>
                            <HeaderStyle Width="20%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Aprobar fondos">
                            <ItemTemplate>
                                <asp:Label ID="lblObservaciones" runat="server" Font-Size="X-Small" />
                                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                                    ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'>
                                    <asp:Image ID="Image2" runat="server" CssClass="GridImagenEliminarItem" ImageUrl="~/Imagenes/enviar.gif"
                                        AlternateText="Aprobar fondos" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlObservaciones" runat="server" Visible="False" Width="100%">
                    <table class="CenteredTable" style="width: 100%">
                        <tr>
                            <td class="LabelCell">
                            </td>
                            <td class="DataCell">
                                <asp:Label ID="lblObservacion" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label2" runat="server" Text="Solicitud:" /></td>
                            <td class="DataCell">
                                <asp:Label ID="LblSolicitud" runat="server" BorderColor="LightBlue" BorderStyle="Solid"
                                    BorderWidth="1px" Width="104px" /></td>
                        </tr>
                        <tr>
                            <td class="LabelCell">
                                <asp:Label ID="Label4" runat="server" Text="Observaciones:" />
                            </td>
                            <td class="DataCell">
                                <asp:TextBox ID="txtObservaciones" runat="server" Rows="5" TextMode="MultiLine" Width="615px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblid" runat="server" Visible="False" />
                                <asp:Label ID="lbltipo" runat="server" Visible="False" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: right">
                                <asp:Button ID="BttGuardarObservacion" runat="server" Text="Guardar Observaciones" />
                                <asp:Button ID="BttCancelar" runat="server" Text="Cancelar" /></td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
