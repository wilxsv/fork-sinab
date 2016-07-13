<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmMantGenerarCertificadoControlCalidad.aspx.vb" Inherits="FrmMantGenerarCertificadoControlCalidad" MaintainScrollPositionOnPostBack="True" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="Laboratorio CC -> Generar certificado de control de calidad" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False" GridLines="None" AllowPaging="True" PageSize="10" Width="100%" DataKeyNames="IDESTABLECIMIENTO,IDINFORME" Font-Size="Smaller">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:TemplateField HeaderText="Certificar / Corregir" ItemStyle-Width="10%"> 
                            <ItemTemplate> 
                                <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDINFORME", "FrmDetaMantGenerarCertificadoControlCalidad.aspx?id={0}") %>' Text="Seleccionar" />
                            </ItemTemplate> 
                        </asp:TemplateField> 
                        <asp:BoundField DataField="TIPOINFORME" HeaderText="Tipo Informe" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="NUMEROINFORME" HeaderText="Número Informe" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="FECHAELABORACIONINFORME" HeaderText="Fecha de elaboración" DataFormatString="{0:d}" HtmlEncode="False" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="INSPECTOR" HeaderText="Inspector" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="15%"/>
                        <asp:BoundField DataField="RENGLON" HeaderText="Renglón" ItemStyle-Width="5%"/>
                        <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código de Producto" ItemStyle-Width="10%"/>
                        <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre del Producto" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"/>
                    </Columns>
                    <EmptyDataTemplate><p style="font-size:small;">No se encontraron informes de inspección de muestras sin certificar.</p></EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
