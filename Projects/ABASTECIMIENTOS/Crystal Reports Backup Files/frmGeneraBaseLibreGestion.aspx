<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmGeneraBaseLibreGestion.aspx.vb" Inherits="frmGeneraBaseLibreGestion" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register Src="~/Controles/ucGenerarBasesLibreGestion.ascx" TagName="ucGenerarBasesLibreGestion"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="background-color: #b5c7de; text-align: left">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Adjudicación -> Generar Bases" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="Label57" runat="server" Text="Generación de Bases" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <asp:Label ID="lblPlantilla" runat="server" Text="Seleccione la plantilla con la que desea trabajar" /></td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnPlantillas" runat="server" CausesValidation="False" Text="Ver Plantillas" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
            </td>
        </tr>
        <tr>
            <td style="text-align: left;">
                <asp:Label ID="lblModalidadCompra" runat="server" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                <uc1:ucGenerarBasesLibreGestion ID="UcGenerarBasesLibreGestion1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

