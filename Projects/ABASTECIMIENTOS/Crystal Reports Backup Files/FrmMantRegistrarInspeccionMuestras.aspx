<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmMantRegistrarInspeccionMuestras.aspx.vb" Inherits="FrmMantRegistrarInspeccionMuestras" MaintainScrollPositionOnPostBack="True" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="Laboratorio CC -> " />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False" GridLines="None" AllowPaging="true" PageSize="10" Width="100%" DataKeyNames="IDESTABLECIMIENTO,IDINFORME" Font-Size="Smaller">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="Editar / Consultar" ItemStyle-Width="10%">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDINFORME", "FrmDetaMantRegistrarInspeccionMuestras.aspx?id={0}") %>' Text="Seleccionar"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="TIPOINFORME" HeaderText="Tipo Informe" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="NUMEROINFORME" HeaderText="Número Informe" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="FECHAELABORACIONINFORME" HeaderText="Fecha de elaboración" DataFormatString="{0:d}" HtmlEncode="False" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%"/>
                        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código de Producto" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre del Producto" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"/>
                        <asp:BoundField DataField="LOTE" HeaderText="Lote" ItemStyle-Width="10%"/>
                        <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="5%">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem" ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDESTADO") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate><p style="font-size:small;">No se encontraron informes de inspección de muestras.</p></EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
