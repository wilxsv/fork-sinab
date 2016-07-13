<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="frmGeneraSolicitudContratacionDirecta.aspx.vb" Inherits="frmGeneraSolicitudContratacionDirecta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucGenerarBasesContratacionDirecta.ascx" TagName="ucGenerarBasesContratacionDirecta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Adjudicación -> Generar Bases" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label57" runat="server" Text="Generación de Bases" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPlantilla" runat="server" Text="Seleccione la plantilla con la que desea trabajar" /></td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnPlantillas" runat="server" CausesValidation="False" Text="Ver Plantillas" /></td>
        </tr>
        <tr>
            <td style="text-align: left">
                <asp:Label ID="lblModalidadCompra" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <uc1:ucGenerarBasesContratacionDirecta ID="UcGenerarBasesContratacionDirecta1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>
