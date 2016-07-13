<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmDetaMantGenerarCertificadoControlCalidad.aspx.vb" Inherits="FrmDetaMantGenerarCertificadoControlCalidad" MaintainScrollPositionOnPostBack="True" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleRegistrarInspeccionMuestras" Src="~/Controles/ucVistaDetalleRegistrarInspeccionMuestras.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table class="CenteredTable" style="width:100%;">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="lblRuta" runat="server" Text="Laboratorio CC -> Generar certificado de control de calidad" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td>
                <uc1:ucVistaDetalleRegistrarInspeccionMuestras ID="ucVistaDetalleRegistrarInspeccionMuestras1" runat="server" />
            </td>
        </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
