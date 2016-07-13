<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_Paso4_CrearSolicitudCompra.ascx.vb" Inherits="Controles_Ctrl_Paso4_CrearSolicitudCompra" %>
<%@ Register Src="~/Controles/Uploader.ascx" TagName="Uploader" TagPrefix="uc2" %>
<%@ Register Src="~/Controles/BuscarProductosLight.ascx" TagName="BuscarProductosLight" TagPrefix="uc5" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<h3>PASO #4 - Productos</h3>
<div class="CenteredTable">
    <asp:Panel ID="PnlAgregarProducto" runat="server" Width="100%" Style="margin: 10px 0">
        <uc5:BuscarProductosLight ID="BuscarProducto" runat="server" />
        <div style="margin-top: 10px;">
            <asp:Button ID="BtnGuardar" runat="server" ValidationGroup="asp" Text="Agregar" ToolTip="Agrega el producto seleccionado al detalle de la requisición"
                Width="80px" />
        </div>
    </asp:Panel>
    <div class="LargeScrollPanel">
    <asp:GridView ID="gvProductosSolicitud" runat="server" GridLines="None"
        AutoGenerateColumns="False" CellPadding="4" CssClass="Grid" DataKeyNames="IdProducto,Entrega,RutaEspecificacion,Renglon,Cantidad,CorrProducto"
       Width="100%" HorizontalAlign="Center" EmptyDataText="[SIN REGISTROS]">
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooterSmaller" />
        <PagerStyle CssClass="GridListPagerSmaller" />
        <RowStyle CssClass="GridListItemSmaller" />
        <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
        <EditRowStyle CssClass="GridListEditItemSmaller" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        <Columns>
            <asp:BoundField DataField="CorrProducto" HeaderText="Código">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="IdProducto" HeaderText="C&#243;digo" Visible="False" />
            <asp:BoundField DataField="DescLargo" HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="100%" />
            </asp:BoundField>
            <asp:BoundField DataField="UnidadMedida" HeaderText="U/M">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Precio Unitario" HeaderStyle-Wrap="False">
                <ItemTemplate>
                    <asp:TextBox ID="txtPrecioUnitario" CssClass="double" runat="server" Width="75px"
                        Text='<%# String.Format("{0:#.0000}", Eval("PrecioActual"))%> ' />
                </ItemTemplate>
                <HeaderStyle Wrap="False"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Especificaciones Técnicas" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label runat="server" ID="LnkTarget" ClientIDMode="Static" />
                    <asp:LinkButton ID="lbAdd" CssClass="GridAgregar lnkCerrar" runat="server" OnClick="lbAdd_Click" />
                    <asp:HyperLink runat="server" ID="lbDown" CssClass="GridGuardar lnkCerrar" ClientIDMode="Static" />
                    <%--<asp:LinkButton ID="lbDown" CssClass="GridGuardar lnkCerrar" runat="server" OnClick="lbDown_Click" />--%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkActualizar" ToolTip="Actualizar" CssClass="GridActualizar"
                        CommandName="Update" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="lnkBorrar" ToolTip="Borrar" CssClass="GridBorrar"
                        CommandName="Delete" OnClientClick="return confirm('¿Esta seguro de querer borrar este registro?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <asp:Literal runat="server" ID="ltempty" Text="[No se han definido productos para la solicitud de compra]" />
        </EmptyDataTemplate>
    </asp:GridView>
        </div>
    <asp:Panel runat="server" ID="PnlUploader" CssClass="pupform" style="display: none">
        <asp:LinkButton ID="LinkButton1" runat="server" Text="X" CssClass="pupCerrar" OnClick="LinkButton1_Click" />
        <uc2:Uploader ID="UploaderEspecificacion" runat="server" />
    </asp:Panel>
    <asp:HiddenField ID="HfUploaderTarget" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="MpeUploader" runat="server" PopupControlID="PnlUploader"
        BackgroundCssClass="PopUpBg" TargetControlID="HfUploaderTarget">
    </ajaxToolkit:ModalPopupExtender>
</div>
