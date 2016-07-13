<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmConsultarContratos.aspx.vb" Inherits="FrmConsultarContratos" %>

<%@ Register Src="~/Controles/ucConsultarContratos.ascx" TagName="ucConsultarContratos"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                <uc1:ucConsultarContratos ID="UcConsultarContratos1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

