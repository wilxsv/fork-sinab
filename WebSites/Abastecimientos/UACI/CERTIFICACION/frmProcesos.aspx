<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProcesos.aspx.vb" Inherits="UACI_CERTIFICACION_frmProcesos" Title=" UACI » Certificación de Productos » Procesos " %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controles/cert_proceso_nuevo.ascx" TagPrefix="uc1" TagName="cert_proceso_nuevo" %>

<asp:Content runat="server" ID="cpmneu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
    UACI » Certificación de Productos » Procesos
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>PROCESOS DE CERTIFICACIÓN</h3>

    <asp:Panel ID="Panel1" runat="server">
        <hr />
        <table class="CenteredTable">
            <tr>
                <td align="right">Tipo de Producto:</td>
                <td align="left">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right">Estado:</td>
                <td align="left">
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="-1">(Todos)</asp:ListItem>
                        <asp:ListItem Value="0">Abierto</asp:ListItem>
                        <asp:ListItem Value="1">Cerrado</asp:ListItem>
                    </asp:RadioButtonList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Filtrar" /></td>
            </tr>
        </table>

    </asp:Panel>


    <hr />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CssClass="Grid GridIzquierda" GridLines="None"
        CellPadding="4" DataKeyNames="IdProceso,IdTipoProducto">
        <Columns>
            <asp:BoundField HeaderText="Proceso" DataField="NumeroProceso">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Tipo de Producto" DataField="IdTipoProducto">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha de Inicio" DataField="FECHAINICIO" DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Fecha de Cierre" DataField="FECHAFIN" DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Estado" DataField="estado">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkConsultar" runat="server" ToolTip="Consultar" CssClass="GridIrA" OnClick="Consultar_Click" />
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:LinkButton ID="lnkEditar" runat="server" CssClass="GridEditar" ToolTip="Editar" OnClick="Editar_Click" />
                            </td>
                            <td>
                                <asp:LinkButton ID="lnkCerrar" runat="server" ToolTip="Cerrar" CssClass="GridCerrar" OnClick="Cerrar_Click" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <EmptyDataTemplate>- No hay Certificaciones de Productos registradas - </EmptyDataTemplate>
    </asp:GridView>
    <hr />
    <div style="margin: 10px 0">
        <asp:Button ID="Button2" runat="server" Text="Nuevo Proceso" Width="118px" />
    </div>

    <asp:HiddenField ID="hfShowPopup" runat="server"  />
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="ui-widget-overlay ui-front"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="hfShowPopup">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="pnlPopup" runat="server" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front" Style="display: none">
        <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title">Nuevo proceso</span>
        </div>
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <uc1:cert_proceso_nuevo runat="server" ID="NuevoProceso" />
                <div style="text-align: center; margin: 10px 0">
                    <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text="" />
                    <br />
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Guardar" ValidationGroup="1" />
                    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:HiddenField ID="hfShowPopup2" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="ui-widget-overlay ui-front"
        CancelControlID="btnClose2" PopupControlID="Panel12" TargetControlID="hfShowPopup2">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel12" runat="server"  CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front" Style="display: none">
         <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <span class="ui-dialog-title">Cerrar Proceso</span>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
                    <table class="CenteredTable">
                       
                        <tr>
                            <td align="right">Proceso:</td>
                            <td align="left">
                                <asp:Label ID="Label12" runat="server" Font-Bold="True"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Tipo de Producto:</td>
                            <td align="left">
                                <asp:Label ID="Label31" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Fecha de inicio:</td>
                            <td align="left">
                                <asp:Label ID="Label21" runat="server" Font-Bold="True"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">Fecha de Cierre:</td>
                            <td align="left">
                                <asp:TextBox ID="TextBox31" runat="server" MaxLength="10" Width="60px"></asp:TextBox>(dd/mm/aaaa)<asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator22" runat="server" ControlToValidate="TextBox31" Display="Dynamic"
                                    ErrorMessage="* Dato Requerido" ValidationGroup="2"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="TextBox31"
                                    Display="Dynamic" ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date"
                                    ValidationGroup="2"></asp:CompareValidator></td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 79px">Comentario:</td>
                            <td align="left" style="height: 79px">
                                <asp:TextBox ID="TextBox11" runat="server" Height="58px" TextMode="MultiLine" Width="450px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                
                <div align="center" style="width: 95%">
                    <br />
                    <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Guardar" Width="104px" ValidationGroup="2" />
                    <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="Cancelar"
                        Width="104px" />
                    <br />
                    <asp:Label ID="lblError2" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSave2" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
    <br />

</asp:Content>

