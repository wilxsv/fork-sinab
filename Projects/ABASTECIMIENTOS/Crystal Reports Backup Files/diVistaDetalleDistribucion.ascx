<%@ Control Language="VB" AutoEventWireup="false" CodeFile="diVistaDetalleDistribucion.ascx.vb"
    Inherits="Controles_diVistaDetalleDistribucion" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbl1" runat="server" Text="Buscar por : " AssociatedControlID="ddlFiltro" />
                    <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltro_SelectedIndexChanged" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlEstados" runat="server" Visible="False">
                        <asp:ListItem Value="Iniciada">Iniciada</asp:ListItem>
                        <asp:ListItem Value="En proceso">En proceso</asp:ListItem>
                        <asp:ListItem Value="Anulada">Anulada</asp:ListItem>
                        <asp:ListItem Value="Finalizada">Finalizada</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlOperadorBusqueda" runat="server" Visible="False">
                        <asp:ListItem Value="=">Igual (=)</asp:ListItem>
                        <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
                        <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
                        <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
                        <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
                        <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
                        <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="txtFiltro" runat="server" Visible="False" /></td>
                <td>
                    <asp:Button ID="btnFind" runat="server" Text="Buscar" Visible="False" /></td>
                <td>
                    <asp:Button ID="btnRemove" runat="server" Text="Quitar Filtro" Visible="false" /></td>
            </tr>
        </table>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDDISTRIBUCION, ESTADO">
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="#E0E0E0" />
            <Columns>
                <asp:TemplateField HeaderText="Detalle">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# String.Format("~/establecimientos/{0}", DataBinder.Eval(Container, "DataItem.IDDISTRIBUCION", "FrmDetaMantDistribucion.aspx?id={0}")) %>'
                            Text="Ver" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle  Width="5%" />
                </asp:TemplateField>
                <asp:BoundField DataField="PERIODO" HeaderText="Periodo">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="IDDISTRIBUCION" HeaderText="No.">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:BoundField>
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle  HorizontalAlign="Left" Width="20%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Especificaciones">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblnS" Text="Suministro: " />
                        <asp:Label runat="server" ID="Label2" Text='<%# DataBinder.Eval(Container.DataItem, "SUMINISTRO") %>' /><br />
                        <asp:Label runat="server" ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "ALMACEN") %>' />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle  HorizontalAlign="Left" Width="35%" />
                </asp:TemplateField>
                <asp:BoundField DataField="NESTADO" HeaderText="Estado">
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  HorizontalAlign="Center" Width="15%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Productos">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlP" runat="server" Target="_self" NavigateUrl='<%# String.Format("~/establecimientos/{0}",DataBinder.Eval(Container, "DataItem.IDDISTRIBUCION", "FrmDetaMantDistribucionProducto.aspx?id={0}")) %>'
                            Text="Editar" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle  HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estab.">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlE" runat="server" Target="_self" NavigateUrl='<%# String.Format("~/establecimientos/{0}",DataBinder.Eval(Container, "DataItem.IDDISTRIBUCION", "FrmDetaMantDistribucionEstablecimiento.aspx?id={0}")) %>'
                            Text="Editar" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Distribuir">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlD" runat="server" Target="_self" NavigateUrl='<%# String.Format("~/establecimientos/{0}",DataBinder.Eval(Container, "DataItem.IDDISTRIBUCION", "FrmDetaMantDistribucionProductoDetalle.aspx?id={0}")) %>'
                            Text="Editar" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No se encontraron distribuciones.</EmptyDataTemplate>
        </asp:GridView>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvLista" EventName="PageIndexChanging" />
        <asp:AsyncPostBackTrigger ControlID="gvLista" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
