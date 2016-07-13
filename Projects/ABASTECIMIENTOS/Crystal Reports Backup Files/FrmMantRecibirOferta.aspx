<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmMantRecibirOferta.aspx.vb" Inherits="FrmMantRecibirOferta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetalleRecibirOferta.ascx" TagName="ucVistaDetalleRecibirOferta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td colspan="2" style="background-color: #b5c7de; text-align: left">
                <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
                <asp:Label ID="LblRuta" runat="server" Text="UACI -> Adjudicación -> Recibir ofertas" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <uc1:ucVistaDetalleRecibirOferta ID="UcVistaDetalleRecibirOferta1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
