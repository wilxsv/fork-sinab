<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmConsultarProcesoCompra.aspx.vb" Inherits="FrmConsultarProcesoCompra" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucConsultarProcesoCompra" Src="~/Controles/ucConsultarProcesoCompra.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="UACI -> Consulta de asignación de procesos de compra"/></td>
        </tr>
        <tr>
            <td>
                <uc1:ucConsultarProcesoCompra ID="UcConsultarProcesoCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
