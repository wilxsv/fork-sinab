<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucContratosProcesoCompra.ascx.vb" Inherits="Controles_ucContratosProcesoCompra" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width:100%;">
    <tr>
        <td>
            <asp:Label ID="lblSeleccioneUnContrato" runat="server" Font-Names="Verdana" Font-Size="X-Small" Text="Seleccione un contrato:" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvContratos" runat="server" CssClass="Grid" AllowPaging="True" PageSize="10" AutoGenerateColumns="False" CellPadding="4" GridLines="None" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateField ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="N&#176; Contrato" DataField="NUMEROCONTRATO" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="25%"/>
                    <asp:BoundField HeaderText="Proveedor" DataField="PROVEEDOR" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70%" />
                </Columns>
                <EmptyDataTemplate>No se encontraron contratos para el proceso de compra seleccionado.</EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
