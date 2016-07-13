<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmMantClausula.aspx.vb" Inherits="FrmMantClausula" %>

<%@MasterType VirtualPath="~/MasterPage.master"%> 

<%@ Register Src="~/Controles/ucStaClausula.ascx" TagName="ucStaClausula" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" PostBackUrl="~/FrmPrincipal.aspx"/>&nbsp;&nbsp;<asp:Label ID="LblRuta" runat="server" Text="Catálogo -> Clausulas" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.3" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <uc1:ucStaClausula ID="UcStaClausula1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

