<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleCLAUSULAS.ascx.vb"
    Inherits="ucVistaDetalleCLAUSULAS" %>
<%@ Register TagPrefix="cc1" Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtNOMBRE" runat="server" Width="300px" MaxLength="100" />
            <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
                ErrorMessage="*" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblESREQUERIDA" runat="server" Text="Es requerida:" /></td>
        <td class="DataCell">
            <asp:CheckBox ID="cbESREQUERIDA" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblMODIFICATIVA" runat="server" Text="Es modificativa:" /></td>
        <td class="DataCell">
            <asp:CheckBox ID="cbMODIFICATIVA" runat="server" /></td>
    </tr>
    <tr style="text-align: left; vertical-align: top;">
        <td>
            <asp:GridView ID="gvEtiqueta" runat="server" AutoGenerateColumns="False" CellPadding="4"
                GridLines="None">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:BoundField DataField="ETIQUETA" HeaderText="Etiqueta" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:GridView>
        </td>
        <td style="width: 90%;">
            <cc1:RichTextEditor ID="rteCONTENIDO" runat="server" OverrideReturnKey="True" HideAbout="true"
                HideViewHtml="true" Width="100%" Height="100%" HideBackgroundColor="true" HideBold="true"
                HideBulletedList="true" HideFontSelection="true" HideFontSizeSelection="true"
                HideHeaderSelection="true" HideInsertDate="true" HideInsertImage="true" HideInsertLink="true"
                HideInsertTable="true" HideItalic="true" HideOrderedList="true" HideRemoveFormatting="true"
                HideStyleSheetSelection="true" HideToolBar2="true" HideToolBar3="true" RTEResourcesUrl="../RTE_Resources/" />
        </td>
    </tr>
</table>
