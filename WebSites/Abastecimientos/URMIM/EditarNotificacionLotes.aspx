<%@ Page Title="Editar Notificación" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EditarNotificacionLotes.aspx.vb" Inherits="URMIM_EditarNotificacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/Notificacion_NuevaNotificacion.ascx" TagPrefix="uc1" TagName="Notificacion_NuevaNotificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Menú</asp:LinkButton>
   
    <a href="NotificacionLotes.aspx" >Notificación de lotes sujetos a inspección</a> »
    Editar Notificación de lotes sujetos a inspección
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <h3><%=Title %></h3>
    <hr />
    <div style="margin: 10px 0">
        <span class="notificacion">
            <asp:Literal runat="server" ID="ltNotificacion" />
            <asp:Literal runat="server" ID="ltPreNotificacion" />
        </span>
    </div>
    <span>Proceso de Compra:
        <asp:Literal runat="server" ID="ltProcesoCompra" /></span>
    <hr />
    <span>Proveedor:
        <asp:Literal runat="server" ID="ltProveedor" /></span>
    <hr />
    <span>Contrato:
        <asp:Literal runat="server" ID="ltContrato" /></span>
    <hr />
    <div style="margin-top: 10px">

        <asp:Panel ID="pnlLotes" runat="server" CssClass="ScrollPanel">
            <div>
                <asp:GridView ID="gvLotes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    CssClass="Grid" Width="100%"
                    GridLines="None" DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UnidadMedida,CorrProducto">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="Lote">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Select" Text='<%# bind("LOTE") %>'></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Nombre Comercial" DataField="NOMBRECOMERCIAL">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Laboratorio Fabricante" DataField="LABORATORIOFABRICANTE">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tamaño Lote" DataField="NUMEROUNIDADES">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Fabricación" DataField="FECHAFABRICACION" DataFormatString="{0:MM/yyyy}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Vencimiento" DataField="FECHAVENCIMIENTO" DataFormatString="{0:MM/yyyy}">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Cantidad a entregar " DataField="CANTIDADAENTREGAR">
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="GridBorrar" ToolTip="Borrar"
                                    OnClientClick="return confirm('¿Está seguro de borrar este renglón de la notifiación?')" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        No hay lotes registrados actualmente
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:Panel>
    </div>
    <asp:Panel runat="server" ID="pnlRenglones" Visible="False" Style="margin-top: 10px">
        <asp:Label ID="Label1" runat="server" Text="Renglón Adjudicado" AssociatedControlID="ddlRenglones" /><br />
        <asp:DropDownList runat="server" ID="ddlRenglones" data-placeholder="Seleccione un renglón" CssClass="filterlist" AutoPostBack="True" Style="max-width: 500px" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevaNotifiacion" Visible="false">

        <uc1:Notificacion_NuevaNotificacion runat="server" ID="nnForm" />
        <div style="margin: 10px 0">
            <hr />
            <asp:Button ID="btnSave" runat="server" Text="Guardar Notificación" ValidationGroup="nuevanota" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
        </div>
    </asp:Panel>

</asp:Content>

