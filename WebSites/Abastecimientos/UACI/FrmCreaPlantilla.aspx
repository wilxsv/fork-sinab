<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmCreaPlantilla.aspx.vb" Inherits="FrmCreaPlantilla" EnableEventValidation="false"
  ValidateRequest="false" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc2" TagName="ucPlantilla" Src="~/Controles/ucPlantilla.ascx" %>
<%@ Register Src="~/Controles/ucCreaPlantilla.ascx" TagName="ucCreaPlantilla" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Catálogo -> Plantillas</td>
        </tr>
        <tr>
            <td>
                <uc1:ucCreaPlantilla ID="UcCreaPlantilla1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
