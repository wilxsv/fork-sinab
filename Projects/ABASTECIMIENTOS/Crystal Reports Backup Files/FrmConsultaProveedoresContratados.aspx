<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmConsultaProveedoresContratados.aspx.vb" Inherits="FrmConsultaProveedoresContratados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="Laboratorio -> Consulta Proveedores Contratados" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucFiltrarDatos ID="UcFiltrarDatos1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvContratos" runat="server" CssClass="Grid" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" GridLines="None" DataKeyNames="IDPROVEEDOR,IDCONTRATO" Width="80%">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="5%" >
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select" Font-Bold="True" Font-Size="Small" Text="Ver detalle" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CODIGOLICITACION" HeaderText="Código de licitación" />
                        <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No. Contrato"/>
                        <asp:BoundField DataField="CODIGOPROVEEDOR" HeaderText="Código proveedor"/>
                        <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="MONTOCONTRATO" HeaderText="Monto contratado" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="FECHADISTRIBUCION" HeaderText="Fecha de liberación"/>
                    </Columns>
                </asp:GridView></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" CssClass="Grid" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Font-Size="X-Small" Width="80%">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:BoundField DataField="RENGLON" HeaderText="RENGLON" />
                        <asp:BoundField DataField="ENTREGAS" HeaderText="No. ENTREGAS" />
                        <asp:BoundField DataField="MONTOENTREGA" HeaderText="MONTO DE LA ENTREGA" DataFormatString="{0:c}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="CODIGO DEL PRODUCTO" />
                        <asp:BoundField DataField="DESCLARGO" HeaderText="DESCRIPCION" ItemStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD CONTRATADA" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateField HeaderText="DETALLE DE LOTES">
                            <ItemTemplate>
                                <asp:GridView ID="GridView3" runat="server" CssClass="Grid" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Font-Size="X-Small">
                                    <Columns>
                                        <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                                        <asp:BoundField DataField="FECHAVENCIMIENTO" HeaderText="Fecha Vencimiento" />
                                        <asp:BoundField DataField="RESULTADOINSPECCIONMUESTRA" HeaderText="Resultado inspecci&#243;n" />
                                        <asp:BoundField DataField="RESULTADOANALISIS" HeaderText="Resultado An&#225;lisis" />
                                    </Columns>
                                    <EmptyDataTemplate>No se han registrado informes.</EmptyDataTemplate>
                                </asp:GridView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" Visible="False" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
</asp:Content>
