<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmDistribuirContratosLG.aspx.vb" MaintainScrollPositionOnPostback="true"
    Inherits="FrmDistribuirContratosLG" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta" colspan="2">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
                UACI -> Distribuir Orden de compra</td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="Ofertas adjudicadas:" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucFiltrarDatos ID="UcFiltrarDatos1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvOfertas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                    CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDPROVEEDOR,IDCONTRATO">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:ButtonField CommandName="Select" Text="&gt;&gt;" />
                        <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Proceso de Compras">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="No. Oferta" DataField="NumOferta" />
                        <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Orden de compra">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Proveedor" DataField="Proveedor">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Renglones Adjudicados" DataField="Renglon">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Estado de orden de compra" DataField="IDESTADOCONTRATO" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="lblFechaDistribucion" runat="server" Text="Fecha de Distribución:" /></td>
            <td class="DataCell">
                <ew:CalendarPopup ID="cpFechaDistribucion" runat="server" Culture="Spanish (El Salvador)" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="cpFechaDistribucion"
                    ErrorMessage="La fecha de distribución debe ser posterior a la fecha de aprobación del contrato"
                    Type="Date" Operator="GreaterThanEqual" Display="Dynamic" Enabled="False" Visible="False" />
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="cpFechaDistribucion"
                    ErrorMessage="La fecha de distribución no debe ser mayor a la fecha actual."
                    Type="Date" Operator="LessThanEqual" Display="Dynamic" Visible="False" /></td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Distribuir Orden de compra" />
                <asp:Button ID="Button2" runat="server" Text="Finalizar distribución" Width="156px" />
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
    <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
