<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmMantDistribucionDetalle2.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantDistribucionDetalle2" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="contentMenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Establecimientos » Distribución
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">

    <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />

    <table width="100%" cellpadding="5" cellspacing="0" style="margin: 10px 0">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Distribución:" /></td>
            <td>
                <asp:Label ID="lblDistro" runat="server" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Almacén:" />
            </td>
            <td>
                <asp:Label ID="lblAlmacen" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Suministro:" />
            </td>
            <td>
                <asp:Label ID="lblSuministro" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                <asp:Label ID="Label4" runat="server" Text="Producto:" Font-Size="12px" /></td>
            <td>
                <asp:Label ID="lblProducto" runat="server" /></td>
        </tr>

    </table>

    <div class="LargeScrollPanel">
    <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        CellPadding="4" GridLines="None" DataKeyNames="IDDISTRIBUCION,IDESTABLECIMIENTODISTRIBUCION,IDPRODUCTO,CANTIDADREAL"
        BorderColor="Silver" BorderStyle="Solid" AllowPaging="False"> 
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
            <asp:BoundField DataField="CODIGOESTABLECIMIENTO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="7%" />
            </asp:BoundField>
            <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="34%" />
            </asp:BoundField>
            <asp:BoundField DataField="CPMA" HeaderText="CPM Ajustado">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" Width="12%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Incons.">
                <ItemTemplate>
                    <asp:Image runat="server" ID="img1" ImageUrl='<%# DetectTipo(Eval("INCONSISTENCIA")) %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Incomp">
                <ItemTemplate>
                    <asp:Image runat="server" ID="img2" ImageUrl='<%# DetectTipo(Eval("REPORTECOMPLETO")) %>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="8%" />
            </asp:TemplateField>
            <asp:BoundField DataField="EXISTENCIAFARMACIA" HeaderText="Existencia Farmacia">
                <ItemStyle HorizontalAlign="Right" Width="9%" />
            </asp:BoundField>
            <asp:BoundField DataField="EXISTENCIA" HeaderText="Existencia Almacén">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" Width="9%" />
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDADDISTRIBUIR" HeaderText="Cantidad Calculada">
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle HorizontalAlign="Right" Width="10%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Cantidad Distribuir">
                <ItemTemplate>
                    <ew:NumericBox ID="txtCANTIDADENTREGAR" runat="server" Columns="8" TextAlign="Right"
                        DecimalPlaces="0" RealNumber="false"></ew:NumericBox>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Right" />
                <ItemStyle Width="15%" HorizontalAlign="Right" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No se han definido productos para la distribucion.
        </EmptyDataTemplate>
    </asp:GridView>
    </div>

    <hr />

    <div style="text-align: right; margin: 10px 0;">
        Cantidad a Distribuir:
        <asp:Label runat="server" ID="lblCantDist" Font-Bold="true" Text="" />
    </div>

    <div style="text-align: right; margin: 10px 0;">
        Cantidad en Almacén:
        <asp:Label runat="server" ID="lblCantAlm" Font-Bold="true" Text="" />
    </div>


</asp:Content>
