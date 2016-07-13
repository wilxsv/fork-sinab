<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmMantIniciaProcesoCompraUACI.aspx.vb" Inherits="FrmMantIniciaProcesoCompraUACI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaListadoSolicitudCompra" Src="~/Controles/ucVistaListadoSolicitudCompraUACI.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
                    ID="LblRuta" runat="server" Text="UACI -> Iniciar proceso de compra" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.1" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaListadoSolicitudCompra ID="UcVistaListadoSolicitudCompra1" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
