<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="FrmEditarPlantillaProcesoCompra.aspx.vb" Inherits="FrmEditarPlantillaProcesoCompra"
    MaintainScrollPositionOnPostback="True" Debug="true" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="rte" Namespace="ExportTechnologies.WebControls.RTE" Assembly="ExportTechnologies.WebControls.RTE" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Editar Plantillas Proceso Compra" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
            </td>
        </tr>
    </table>
    <table style="text-align: left; vertical-align: top; width: 100%">
        <tr>
            <td>
                <asp:GridView ID="gvEtiquetas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                    CellPadding="4" GridLines="None">
                    <HeaderStyle CssClass="GridListHeader" />
                    <FooterStyle CssClass="GridListFooter" />
                    <PagerStyle CssClass="GridListPager" />
                    <RowStyle CssClass="GridListItem" />
                    <SelectedRowStyle CssClass="GridListSelectedItem" />
                    <EditRowStyle CssClass="GridListEditItem" />
                    <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    <Columns>
                        <asp:BoundField DataField="ETIQUETA" HeaderText="Etiqueta">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
            <td style="width: 90%;" align="center">
                <asp:Panel ID="Panel4" runat="server" BorderWidth="0px" Height="50px" HorizontalAlign="Center"
                    Visible="False" Width="125px">
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
                        Width="480px">
                        <asp:ListItem Selected="True" Value="0">Todo</asp:ListItem>
                        <asp:ListItem Value="1">MSPAS</asp:ListItem>
                        <asp:ListItem Value="114">FOSALUD</asp:ListItem>
                        <asp:ListItem Value="499">ISSS</asp:ListItem>
                    </asp:RadioButtonList></asp:Panel>
                <br />
                <br />
                <rte:RichTextEditor ID="rtePlantilla" runat="server" OverrideReturnKey="True" HideAbout="True"
                    HideViewHtml="True" Width="100%" Height="100%" HideBackgroundColor="True" HideBold="True"
                    HideBulletedList="True" HideFontSelection="True" HideFontSizeSelection="True"
                    HideHeaderSelection="True" HideInsertDate="True" HideInsertImage="True" HideInsertLink="True"
                    HideInsertTable="True" HideItalic="True" HideOrderedList="True" HideRemoveFormatting="True"
                    HideStyleSheetSelection="True" HideToolBar2="True" HideToolBar3="True" RTEResourcesUrl="../RTE_Resources/" />
              <asp:Button ID="Button1" runat="server" Text="Cerrar" /></td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
