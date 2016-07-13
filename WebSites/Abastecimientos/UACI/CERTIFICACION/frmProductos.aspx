<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmProductos.aspx.vb" 
    Inherits="UACI_CERTIFICACION_frmProductos" Title="UACI » Certificación de Productos »  Productos Registrados" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cpmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
    UACI » Certificación de Productos » Productos Registrados
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>Productos Registrados</h3>

    <div>
        <h4 style="margin: 0px">Proceso de Certificación: 
        <asp:Literal ID="Label3" runat="server" />
        </h4>
        <h4 style="margin: 0px">NIT:
        <asp:Literal ID="Label1" runat="server" /></h4>
        <h4 style="margin: 0px">Razón Social:
        <asp:Literal ID="Label2" runat="server" /></h4>
    </div>
    <hr style="margin-top: 20px" />

    <asp:MultiView runat="server" ID="mvProducto">
        <asp:View runat="server" ID="vGrid">
            <table class="CenteredTable">
                <tr>
                    <td align="right">Producto:</td>
                    <td align="left">
                        <asp:TextBox ID="TextBoxFiltro" runat="server" Width="321px" MaxLength="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonListFiltro" runat="server" Style="TEXT-ALIGN: left" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="0">C&#243;digo</asp:ListItem>
                            <asp:ListItem Value="1">Nombre</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="ButtonFiltro" runat="server" Text="Filtrar" /></td>
                </tr>
            </table>
            <hr />
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" CssClass="Grid GridIzquierda"
                DataKeyNames="Id,IdProducto">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="CorrProducto">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Producto" DataField="DescLargo">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Marca" DataField="Marca">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="País de Origen" DataField="Pais">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Certificado" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="lnkEditar" CssClass="GridEditar" runat="server" ToolTip="Editar" OnClick="Editar_Click" /></td>
                                   
                                    <td>
                                        <asp:LinkButton ID="lnkBorrar"
                                            OnClientClick="return confirm('Al eliminar este producto, se eliminarán todos los aspectos que ya han sido evaluados.\n\n¿Esta seguro de esta acción?')"
                                            CssClass="GridBorrar" runat="server" ToolTip="Eliminar" OnClick="Borrar_Click" /></td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <EmptyDataTemplate>- No hay Productos registrados - </EmptyDataTemplate>
            </asp:GridView>
            <hr />

            <asp:Button ID="btnAdd" runat="server" Text="Agregar Producto" />

            <hr />
            <asp:Button ID="btnVformBack" runat="server" Text="« Regresar" />
        </asp:View>
        <asp:View runat="server" ID="vAdd">
            <h4 style="margin: 0px">
                <asp:Literal ID="lblNuevoProducto" runat="server" Text="Nuevo Producto:" />
            </h4>

            <asp:Panel ID="Panel1" runat="server">
                <table class="CenteredTable">

                    <tr>

                        <td align="left">
                            <asp:TextBox ID="tbBuscar" runat="server" Width="321px"></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td>
                            <asp:RadioButtonList ID="rblBuscarPor" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="0">Código</asp:ListItem>
                                <asp:ListItem Value="1">Nombre</asp:ListItem>
                            </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Buscar" /></td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Label ID="Label8" runat="server" />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="IdProducto"
                GridLines="None" CssClass="Grid GridIzquierda">
                <Columns>
                    <asp:BoundField DataField="CorrProducto" HeaderText="Código">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DescLargo" HeaderText="Nombre">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UnidadMedida" HeaderText="U/M" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSave" runat="server" OnClick="btnSave_Click" ToolTip="Agregar" CssClass="GridAgregar" ValidationGroup="1" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <EmptyDataTemplate>- No se encontro el producto - </EmptyDataTemplate>
            </asp:GridView>
            <hr />
            <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="« Cancelar y regresar" />

        </asp:View>
       
    </asp:MultiView>




















</asp:Content>

