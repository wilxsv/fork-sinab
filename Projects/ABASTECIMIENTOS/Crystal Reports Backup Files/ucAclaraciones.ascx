<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAclaraciones.ascx.vb" Inherits="ucAclaraciones" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td align="left">
            <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione la Aclaración:" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvAclaraciones" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="726px" AllowPaging="True" DataKeyNames="IDACLARACION">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:CommandField InsertVisible="False" SelectImageUrl="~/Imagenes/botones/flecha.jpg" ShowHeader="True" ShowSelectButton="True" />
                    <asp:BoundField DataField="IdProcesoCompra"  HeaderText="Proceso de compra" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROACLARACION" HeaderText="Numero de Aclaraci&#243;n" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAACLARACION" HeaderText="Fecha de Aclaraci&#243;n" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                         </Columns>
                <EmptyDataTemplate>
                    No hay Aclaraciones para este Procesos.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
