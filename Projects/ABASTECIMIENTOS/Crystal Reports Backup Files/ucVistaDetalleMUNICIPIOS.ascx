<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleMUNICIPIOS.ascx.vb"
    Inherits="ucVistaDetalleMUNICIPIOS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblCODIGOMUNICIPIO" runat="server" Text="Código de Municipio:" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtCODIGOMUNICIPIO" runat="server" MaxLength="2" Width="63px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDDEPARTAMENTO" runat="server" Text="Código de Departamento:" /></td>
        <td class="DataCell">
            <cc1:ddlDEPARTAMENTOS ID="ddlDEPARTAMENTOS1" runat="server" Width="280px" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre del Municipio:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtNOMBRE" runat="server" Width="351px" />
            <asp:RequiredFieldValidator ID="rfvNOMBREMUNICIPIO" runat="server" ControlToValidate="txtNOMBRE"
                Display="Dynamic" ErrorMessage="Nombre de Municipio Requerido" /></td>
    </tr>
</table>
