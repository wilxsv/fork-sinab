<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmCalificaProveedor.aspx.vb" Inherits="FrmCalificaProveedor" %>

<%@ Register Src="~/Controles/ucCalificaProveedor.ascx" TagName="ucCalificaProveedor"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: center;">
                <uc1:ucCalificaProveedor ID="UcCalificaProveedor1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>

