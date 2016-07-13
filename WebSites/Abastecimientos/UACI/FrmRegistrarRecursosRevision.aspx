<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmRegistrarRecursosRevision.aspx.vb" Inherits="FrmRegistrarRecursosRevision"
    MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    UACI » Registrar recursos de revisión
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div class="CenteredTable">
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
            PermiteSeleccionar="false" />
        <table class="CenteredTable" style="margin: 10px 0">
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label12" runat="server" Text="Proceso de compra:" />
                </td>
                <td class="LabelCell">
                    <asp:Label ID="lblNoProcesoCompra" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label3" runat="server" Text="Fecha de iniciado el proceso de compra:" />
                </td>
                <td class="LabelCell">
                    <asp:Label ID="FechaInicioProcCompra" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label4" runat="server" Text="Fecha de notificación a empresas:" />
                </td>
                <td class="LabelCell">
                    <asp:Label ID="FechaNotificacionEmpresas" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label13" runat="server" Text="Fecha límite para registrar:" />
                </td>
                <td class="LabelCell">
                    <asp:Label ID="FechaLimiteAceptacion" runat="server" />
                </td>
            </tr>
            </table>
             <div>
              <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
       <table class="CenteredTable" style="margin: 10px 0">
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Proveedores adjudicatarios:" />
                </td>
                <td class="DataCell">
                    <asp:Button ID="btnImprimirAdjudicatarios" runat="server" Text="Imprimir adjudicatarios"
                        CausesValidation="False" UseSubmitBehavior="False" Width="159px" />
                </td>
            </tr>
        </table>
       
        <asp:GridView ID="GridView2" runat="server" CssClass="Grid" CellPadding="4" GridLines="None"
            AutoGenerateColumns="False" DataKeyNames="oferta,proveedor,monto,acepta" Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:BoundField DataField="OFERTA" HeaderText="Oferta" />
                <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Monto Adjudicado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MONTO") %>' />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <%# String.Format("{0:c}",Decimal.Round(Eval("MONTO"),2)) %>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:BoundField DataField="ACEPTA" HeaderText="Nota Aceptaci&#243;n" />
            </Columns>
        </asp:GridView>
        <table class="CenteredTable" style="width: 100%">
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Recursos de revisión presentados:" />
                </td>
                <td class="DataCell">
                    <asp:Button ID="btnImprimirRecursos" runat="server" Text="Imprimir recursos" CausesValidation="False"
                        UseSubmitBehavior="False" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" CssClass="Grid" CellPadding="4" ForeColor="#333333"
            GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDPROVEEDOR,IDRECURSO,PROVEEDOR,FECHA,DESCRIPCION"
            Width="100%">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Ver/Modificar">
                    <ItemStyle Font-Bold="True" />
                </asp:CommandField>
                <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="FECHA" HeaderText="Fecha Recibido" DataFormatString="{0:c}" />
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar nuevo recurso" CausesValidation="False" />
        <asp:Panel ID="Panel1" runat="server">
            <table class="CenteredTable" style="width: 100%">
                <tr>
                    <td align="center" class="LabelCell" colspan="2">
                        <asp:Button ID="btnProveedoresAfectados" runat="server" Text="Imprimir proveedores afectados"
                            CausesValidation="False" Width="198px" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Proveedor:
                    </td>
                    <td class="DataCell">
                        <asp:DropDownList ID="ddlProvedores" runat="server" Visible="False" />
                        <asp:Label ID="lblProveedor" runat="server" ForeColor="Navy" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Fecha de recepción:
                    </td>
                    <td class="DataCell">
                        <ew:CalendarPopup ID="CPFechaRecepcion" runat="server" DisableTextBoxEntry="False"
                            Width="112px" Visible="False" Culture="Spanish (El Salvador)" />
                        <asp:Label ID="lblFechaRecepcion" runat="server" ForeColor="Navy" />
                        <asp:RangeValidator ID="rvFechaRecepcion" runat="server" ControlToValidate="CPFechaRecepcion"
                            ErrorMessage="La fecha de recepción esta fuera de rango" Font-Size="Large" Type="Date"
                            Text="*" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Renglón al que se aplica:
                    </td>
                    <td class="DataCell" valign="top">
                        <asp:DropDownList ID="ddlRenglon" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Descripción del recurso:
                    </td>
                    <td class="DataCell" valign="top">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="TextBoxMultiLine" MaxLength="500"
                            TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="rvDEscripcion" runat="server" ControlToValidate="txtDescripcion"
                            ErrorMessage="La descripción del recurso es requerida" Font-Size="Large" Text="*" />
                        <asp:Label ID="lblRecurso" runat="server" ForeColor="Navy" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Se acepta el recurso:
                    </td>
                    <td class="DataCell" valign="top">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        Motivo de aceptación o rechazo:
                    </td>
                    <td class="DataCell" valign="top">
                        <asp:TextBox ID="txtjustificacion" runat="server" CssClass="TextBoxMultiLine" MaxLength="500"
                            TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtjustificacion"
                            ErrorMessage="La justificación de aceptación o rechazo del recurso es requerida"
                            Font-Size="Large" Text="*" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div>
            <nds:Button ID="btnGuardar" runat="server" Message="¿Desea guardar la información ingresada?"
                ShowConfirmDialog="True" Text="Guardar" Visible="False" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False"
                Visible="False" /></div>
    </div>
</asp:Content>
