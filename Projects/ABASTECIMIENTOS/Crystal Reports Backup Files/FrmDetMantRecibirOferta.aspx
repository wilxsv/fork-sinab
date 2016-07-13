<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="FrmDetMantRecibirOferta.aspx.vb" Inherits="FrmDetMantRecibirOferta" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucVistaDetRecibirOferta.ascx" TagName="ucVistaDetRecibirOferta"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI -> Adjudicación -> Recibir ofertas" /></td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetRecibirOferta ID="UcVistaDetRecibirOferta1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
