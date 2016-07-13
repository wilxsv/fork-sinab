<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetCreaPlantillaContrato.ascx.vb"
    Inherits="Controles_ucDetCreaPlantillaContrato" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc1" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
    TagPrefix="cc2" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
<div>
    <asp:Label ID="Label8" runat="server" Text="A contuación se presentan una serie de pasos que deben seguirse para la elaboración de las plantillas" /></td>
</div>
<div>
    <asp:Label ID="lblPlantillaModificativa" runat="server" />
</div>
<asp:Panel ID="Panel1" runat="server" Width="100%">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/paso 1 Crear Plantilla Contrato.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" Text="Ingrese la información que a continuación se solicita" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Tipo de compra:" />
            </td>
            <td class="DataCell">
                <cc1:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Suministro:" />
            </td>
            <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label3" runat="server" Text="Nombre:" />
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="398px" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Personeria Jurídica:" />
            </td>
            <td class="DataCell">
                <asp:TextBox ID="txtPersoneriaJuridica" runat="server" MaxLength="500" Rows="5" TextMode="MultiLine"
                    Width="398px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:LinkButton ID="LinkButton1" runat="server">Siguiente ></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/paso 2 Seleccionar clausulas plantilla.jpg" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Seleccione las clausulas que desea incluir en la plantilla" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <div class="ScrollPanel">
                    <div>
                <asp:DataGrid ID="dgClausula" CssClass="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4"
                     GridLines="None" Width="100%">
                    <EditItemStyle CssClass="GridListEditItem" />
<SelectedItemStyle CssClass="GridListSelectedItem" />
<AlternatingItemStyle CssClass="GridListAlternatingItem" />
<ItemStyle CssClass="GridListItem" />
<HeaderStyle CssClass="GridListHeader" />
<FooterStyle CssClass="GridListFooter" />
<PagerStyle CssClass="GridListPager" />
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkClausula" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Clausula">
                            <HeaderStyle Width="100%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="IDCLAUSULA" Visible="False" />
                        <asp:BoundColumn DataField="contenido" ItemStyle-HorizontalAlign="Left" Visible="False" />
                        <asp:BoundColumn DataField="ESTASINCRONIZADA" Visible="False" />
                    </Columns>
                </asp:DataGrid></div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;">
                <asp:LinkButton ID="LinkButton3" runat="server" Text="< Anterior" />
                <asp:LinkButton ID="LinkButton2" runat="server" Text="Siguiente >" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel3" runat="server" Width="100%" Visible="False">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/paso 3 edicion de clausulas.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                     CssClass="Grid" GridLines="None" Width="100%">
                    <EditItemStyle CssClass="GridListEditItem" />
<SelectedItemStyle CssClass="GridListSelectedItem" />
<AlternatingItemStyle CssClass="GridListAlternatingItem" />
<ItemStyle CssClass="GridListItem" />
<HeaderStyle CssClass="GridListHeader" />
<FooterStyle CssClass="GridListFooter" />
<PagerStyle CssClass="GridListPager" />
                    <Columns>
                        <asp:ButtonColumn CommandName="Select" Text="Editar" />
                        <asp:BoundColumn DataField="NOMBRE" HeaderText="Clausula">
                            <HeaderStyle Width="100%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Contenido" HeaderText="Clausula" Visible="False" />
                        <asp:BoundColumn DataField="Orden" HeaderText="Orden" Visible="False" />
                        <asp:BoundColumn DataField="IDCLAUSULA" Visible="False" />
                        <asp:ButtonColumn CommandName="Delete" Text="Eliminar" Visible="False" />
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right;">
                <asp:LinkButton ID="LinkButton5" runat="server" Text="< Anterior" />
                <asp:LinkButton ID="LinkButton4" runat="server" Visible="False" Text="Siguiente >" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="Panel4" runat="server" Visible="False" Width="100%">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/Imagenes/paso 4 listado de clausulas.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/guarda.gif" />
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/botones/delete.jpg" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNoClausulas" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label7" runat="server" Text="Ingrese la información que a continuación se solicita para cada clausula seleccionada" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Clausula:" />
            </td>
            <td class="DataCell">
                <asp:Label ID="lblClausula" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Orden de presentación:" />
            </td>
            <td class="DataCell">
                <asp:TextBox ID="txtOrden" runat="server" Width="93px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOrden"
                    ErrorMessage="Requerido" />
            </td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Contenido:" />
            </td>
            <td class="DataCell">
                <asp:TextBox ID="txtValidaOrden" runat="server" Visible="False" Width="93px" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right" valign="top">
                <asp:DataGrid ID="dgEtiqueta" CssClass="Grid" runat="server" AutoGenerateColumns="False" CellPadding="4"
                     GridLines="None" Width="50%">
                    <EditItemStyle CssClass="GridListEditItem" />
<SelectedItemStyle CssClass="GridListSelectedItem" />
<AlternatingItemStyle CssClass="GridListAlternatingItem" />
<ItemStyle CssClass="GridListItem" />
<HeaderStyle CssClass="GridListHeader" />
<FooterStyle CssClass="GridListFooter" />
<PagerStyle CssClass="GridListPager" />
                    <Columns>
                        <asp:ButtonColumn CommandName="Select" Text="&gt;&gt; " Visible="False" />
                        <asp:HyperLinkColumn NavigateUrl="javascript:cpS(&lt;% dgEtiqueta.selecteditem.cell(2).text %&gt;);"
                            Text="&gt;&gt;" Visible="False" />
                        <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundColumn DataField="Etiqueta" HeaderText="Etiqueta" />
                        <asp:ButtonColumn CommandName="Select" Text="Seleccionar" Visible="False" />
                    </Columns>
                </asp:DataGrid>
            </td>
            <td style="text-align: left;" valign="top">
                <cc2:RichTextEditor ID="rteContenido" runat="server" Height="100%" RTEResourcesUrl="../RTE_Resources/"
                    OverrideReturnKey="True" Width="100%" HideAbout="True" HideBackgroundColor="True"
                    HideBold="True" HideBulletedList="True" HideFontSelection="True" HideFontSizeSelection="True"
                    HideHeaderSelection="True" HideInsertDate="True" HideInsertImage="True" HideInsertLink="True"
                    HideInsertTable="True" HideItalic="True" HideOrderedList="True" HideRemoveFormatting="True"
                    HideStyleSheetSelection="True" HideToolBar2="True" HideToolBar3="True" HideViewHtml="True" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right;">
                <asp:LinkButton ID="LinkButton6" runat="server" Text="< Regresar a lista de clausulas" />
            </td>
        </tr>
    </table>
</asp:Panel>
<%--<nds:MsgBox ID="MsgBox1" runat="server" />--%>
