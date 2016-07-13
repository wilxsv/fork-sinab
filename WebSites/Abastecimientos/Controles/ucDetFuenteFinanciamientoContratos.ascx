<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetFuenteFinanciamientoContratos.ascx.vb"
    Inherits="ucDetFuenteFinanciamientoContratos" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
    CssClass="Grid" GridLines="None" Width="100%" DataKeyNames="IDFUENTEFINANCIAMIENTO"
    ShowHeader="False">
    <HeaderStyle CssClass="GridListHeaderSmaller" />
    <EmptyDataTemplate>
        <asp:Literal runat="server" ID="lempty" Text="[No se han agregado fuentes de financiamiento.]" />
    </EmptyDataTemplate>
    <FooterStyle CssClass="GridListFooterSmaller" />
    <PagerStyle CssClass="GridListPagerSmaller" />
    <RowStyle CssClass="GridListItemSmaller" />
    <EditRowStyle CssClass="GridListEditItemSmaller" />
    <SelectedRowStyle CssClass="GridSelectedItemSmaller" />
    <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
    <Columns>
        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            <ItemStyle HorizontalAlign="Left" Width="100%"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="MONTOCONTRATADO" Visible="False" HeaderText="Monto" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="GridBorrar" ToolTip="Elimina el registro"
                    CommandName="Delete" CausesValidation="False" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<div style="margin: 10px 0;">
    <asp:MultiView runat="server" ID="mvFuentes">
        <asp:View runat="server" ID="vAgregar">
            <asp:Button ID="btnAgregarFuente" runat="server" Text="Agregar Fuente" />
             
        </asp:View>
        <asp:View runat="server" ID="vForm">
            <table class="CenteredTable" style="width: 100%;">
                <tr>
                    <td class="LabelCell" style="vertical-align: top; white-space: nowrap">
                        Grupo fuente financiamiento:
                    </td>
                    <td style="width: 100%">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                            RepeatLayout="Flow">
                            <asp:ListItem Selected="True" Value="1">GOES</asp:ListItem>
                            <asp:ListItem Value="2">Otras Fuentes</asp:ListItem>
                        </asp:RadioButtonList>
                        <div style="padding-top: 5px;">
                            <asp:DropDownList runat="server" ID="ddlFUENTEFINANCIAMIENTOS1" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="LabelCell">
                        <asp:Label ID="LblMonto" runat="server" Visible="False">Monto Participación ($):</asp:Label>
                    </td>
                    <td>
                        <ew:NumericBox ID="TxtMontoContratado" runat="server" AutoPostBack="True" PositiveNumber="True"
                            Width="156px" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Agregar" ToolTip="Agrega la fuente de financiamiento al documento." />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" ToolTip="Cierra la definición de la fuente de financiamiento." />
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</div>
