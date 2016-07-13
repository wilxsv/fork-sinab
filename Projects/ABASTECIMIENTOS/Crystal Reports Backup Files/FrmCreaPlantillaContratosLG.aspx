<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmCreaPlantillaContratosLG.aspx.vb" Inherits="FrmCreaPlantillaContratosLG" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucCreaPlantillaContrato" Src="~/Controles/ucCreaPlantillaContratoLG.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="Catálogos -> Plantillas para contratos" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td>
                <uc1:ucCreaPlantillaContrato ID="UcCreaPlantillaContrato1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
