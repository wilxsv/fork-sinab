<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmConsolidarOfertas.aspx.vb" Inherits="FrmConsolidarOfertas" MaintainScrollPositionOnPostback="True" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucVistaDetalleProcesoCompra" Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta" colspan="2">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="UACI -> Consolidación de Ofertas" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v2.0" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Código de bases o proceso compra:" /></td>
            <td class="DataCell">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Fecha en que se genera el cuadro:" /></td>
            <td class="DataCell">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" BackColor="Black" ForeColor="White" Width="144px" Text="HOJA DE ANALISIS"/></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDPRODUCTO,IDDETALLE,RENGLON">
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
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="Ver ofertas" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad Solicitada" DataFormatString="{0:n}" HtmlEncode="False" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField DataField="NUMEROENTREGAS" HeaderText="No. Entregas" ItemStyle-HorizontalAlign="Right"/>
                        <asp:TemplateField HeaderText="Porcentajes y tiempos" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <asp:Label ID="lblEntregas" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" ItemStyle-Font-Size="X-Small" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="35%" />
                        <asp:BoundField DataField="UM" HeaderText="U. M." />
                    </Columns>
                </asp:GridView></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Ver Hojas de Análisis ordenados por Precio" Width="262px" UseSubmitBehavior="False" /></td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Ver Hojas de Análisis ordenados por Oferta" Width="262px" UseSubmitBehavior="False" /></td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td class="TituloLeftCell">
                <asp:Label ID="Label7" runat="server" Visible="False" Text="OFERTAS:"/></td>
            <td></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvOfertas" runat="server" CssClass="Grid" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="80%">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:BoundField DataField="ordenllegada" HeaderText="No.Ofertante"/>
                        <asp:BoundField DataField="renglon" HeaderText="Rengl&#243;n Ofertado"/>
                        <asp:BoundField DataField="correlativorenglon" HeaderText="Alternativa"/>
                        <asp:BoundField DataField="producto" HeaderText="Descripci&#243;n" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="um" HeaderText="U/M"/>
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad Ofrecida" DataFormatString="{0:n}"/>
                        <asp:BoundField DataField="preciounitario" HeaderText="Precio Unitario" DataFormatString="{0:c4}" HtmlEncode="False"/>
                        <asp:BoundField DataField="valortotal" HeaderText="Valor Total" DataFormatString="{0:c}" HtmlEncode="False"/>
                        <asp:BoundField DataField="entrega" HeaderText="Plazo de entrega"/>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:" Visible="False" /></td>
            <td class="DataCell">
                <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Width="350px" Visible="False" /></td>
        </tr>
        <tr>
            <td class="LabelCell"></td>
            <td>
                <asp:Button ID="btnGuardarObservacion" runat="server" Text="Guardar Observación" Width="132px" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnImpresionPorRenglon" runat="server" Text="Impresión de renglón" Visible="False" UseSubmitBehavior="False" /></td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
