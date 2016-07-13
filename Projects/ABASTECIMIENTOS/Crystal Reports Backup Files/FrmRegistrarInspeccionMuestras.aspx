<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmRegistrarInspeccionMuestras.aspx.vb" Inherits="FrmRegistrarInspeccionMuestras" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td class="LinkMenuRuta">
                &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False"/>&nbsp;&nbsp;<asp:Label ID="LblRuta" runat="server" Text="Laboratorio -> Registrar Inspección de Muestras" />
                &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td class="LabelCell">
                <asp:Label ID="lblTipoInforme" runat="server" Text="Tipo de informe:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Número de informe:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Proveedor:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label3" runat="server" Text="Contrato:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Descripción:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="Descripción:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Laboratorio fabricante:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label7" runat="server" Text="Lote:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Text="Fecha de fabricación:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Fecha de vencimiento:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label10" runat="server" Text="Número de unidades:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Cantidad remitida:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Establecimiento que remite muestra:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Número de licitación pública:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label14" runat="server" Text="Número de modificativa del contrato:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label15" runat="server" Text="Resolución:" /></td>
            <td class="DataCell"></td>
        </tr>
        <tr>
            <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Proveedor:" /></td>
            <td class="DataCell"></td>
        </tr>
    </table>

</asp:Content>
