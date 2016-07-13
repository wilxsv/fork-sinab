<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleProcesoCompraRpt.ascx.vb"
    Inherits="Controles_ucVistaDetalleProcesoCompraRpt" %>
<h3>
            <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione el proceso de compra del siguiente listado:" />
            </h3>
    
            <asp:GridView ID="gvProcesosCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDTIPOCOMPRAEJECUTAR">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                        <asp:LinkButton runat="server" ID="lnkSelect" ToolTip="Ve" CommandName="Select" CssClass="GridDocumento"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso" />
                    <asp:BoundField DataField="LUGARRETIROBASE" HeaderText="Lugar de Retiro" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="FECHAPUBLICACION" HeaderText="Fecha de publicaci&#243;n"
                        DataFormatString="{0:d}" HtmlEncode="False" />
                    <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Código de Licitación" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>
                </Columns>
                <EmptyDataTemplate>
                    No existen procesos de compra para el establecimiento.</EmptyDataTemplate>
            </asp:GridView>
    