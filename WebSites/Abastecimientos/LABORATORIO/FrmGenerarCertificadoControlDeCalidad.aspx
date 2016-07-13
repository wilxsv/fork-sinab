<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmGenerarCertificadoControlDeCalidad.aspx.vb" Inherits="FrmGenerarCertificadoControlDeCalidad" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="LblRuta" runat="server" Text="Laboratorio -> Generar Certificado de Control de Calidad" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
</asp:Content>
