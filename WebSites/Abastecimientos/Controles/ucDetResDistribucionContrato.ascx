<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetResDistribucionContrato.ascx.vb"
    Inherits="ucDetResDistribucionContrato" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
    ShowHeader="False" GridLines="None" CssClass="Grid" DataKeyNames="IDRESPONSABLEDISTRIBUCION"
    Width="100%">
    <HeaderStyle CssClass="GridListHeaderSmaller" />
    <FooterStyle CssClass="GridListFooterSmaller" />
    <PagerStyle CssClass="GridListPagerSmaller" />
    <RowStyle CssClass="GridListItemSmaller" />
    <EditRowStyle CssClass="GridListEditItemSmaller" />
    <SelectedRowStyle CssClass="GridSelectedItemSmaller" />
    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
    <Columns>
        <asp:BoundField DataField="NOMBRECORTO" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100%" />
        <asp:TemplateField HeaderText="Eliminar">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="GridBorrar" ToolTip="Elimina el registro"
                    CommandName="Delete" CausesValidation="False" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="margin: 10px 0">
    <asp:MultiView runat="server" ID="mvAgregar">
        <asp:View runat="server" ID="vAgregar">
            <asp:Button ID="btnAgregarResponsable" runat="server" Text="Agregar responsable"
                Width="150px" />
        </asp:View>
        <asp:View runat="server" ID="vForm">
            <table class="CenteredTable" style="width: 100%;">
                <tr>
                    <td class="LabelCell" style="white-space: nowrap">
                        Responsable distribución:
                    </td>
                    <td style="width: 100%">
                        <asp:DropDownList runat="server" ID="ddlRESPONSABLEDISTRIBUCION1"/>
                       <%-- <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" />--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Agregar" ToolTip="Agrega un responsable de distribución al documento." />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" ToolTip="Cierra la definición del responsable de distribución." />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</div>
