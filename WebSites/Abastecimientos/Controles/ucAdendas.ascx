<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAdendas.ascx.vb" Inherits="ucAdendas" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td align="left">
            <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione la Adenda:" /></td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvAdendas" runat="server" CssClass="Grid" AutoGenerateColumns="False" Width="726px" AllowPaging="True" DataKeyNames="IDADENDA">
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
                    <asp:BoundField DataField="NUMEROADENDA" HeaderText="Numero de Adenda" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAADENDA" HeaderText="Fecha de Adenda" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                         </Columns>
                <EmptyDataTemplate>
                    No hay Adendas para este Procesos.
                </EmptyDataTemplate>
            </asp:GridView>
        </td>
    </tr>
</table>
