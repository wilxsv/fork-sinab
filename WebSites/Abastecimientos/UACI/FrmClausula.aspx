<%@ Page Language="VB" ValidateRequest="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmClausula.aspx.vb" Inherits="FrmClausula" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucMenu.ascx" TagName="ucMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucClausulas.ascx" TagName="ucClausulas" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Catálogos - > Contratos - > Clausulas" /></td>
        </tr>
        <tr>
            <td>
                <uc2:ucClausulas ID="UcClausulas1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
