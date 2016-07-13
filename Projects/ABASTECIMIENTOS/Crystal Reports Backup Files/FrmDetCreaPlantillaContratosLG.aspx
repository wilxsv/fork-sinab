<%@ Page Language="VB" ValidateRequest="false"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmDetCreaPlantillaContratosLG.aspx.vb" Inherits="FrmDetCreaPlantillaContratosLG" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register Src="~/Controles/ucDetCreaPlantillaContratoLG.ascx" TagName="ucDetCreaPlantillaContrato"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="background-color: #b5c7de; text-align: left;">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Catálogos -> Contratos - > Plantillas contratos" /></td>
        </tr>
        <tr>
            <td style="text-align: center">
                <uc1:ucDetCreaPlantillaContrato ID="UcDetCreaPlantillaContrato1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

