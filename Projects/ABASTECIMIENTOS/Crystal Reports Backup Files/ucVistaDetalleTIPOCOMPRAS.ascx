<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleTIPOCOMPRAS.ascx.vb"
    Inherits="ucVistaDetalleTIPOCOMPRAS" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblMODALIDADESCOMPRA" runat="server" Text="Modalidad de Compra:" /></td>
        <td class="DataCell">
            <cc1:ddlMODALIDADESCOMPRA ID="ddlMODALIDADESCOMPRA1" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblDESCRIPCION" runat="server" Text="Descripción:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="287px" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ErrorMessage="Dato requerido"
                ControlToValidate="txtDESCRIPCION" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblMIN" runat="server" Text="Monto Minimo($):" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtMIN" runat="server" Width="141px" PositiveNumber="true" TextAlign="Right"
                DecimalPlaces="2" MaxLength="10" TruncateLeadingZeros="True" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblMAX" runat="server" Text="Monto Máximo($):" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtMAX" runat="server" Width="141px" PositiveNumber="true" TextAlign="Right"
                DecimalPlaces="2" MaxLength="10" TruncateLeadingZeros="True" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:CompareValidator ID="cvMAX" runat="server" ControlToValidate="txtMAX" ControlToCompare="txtMIN"
                Display="Dynamic" Operator="GreaterThan" Type="Currency">El valor máximo deber ser mayor al valor mínimo</asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblREQUIERECALIFICACION" runat="server" Text="Requiere calificación:" /></td>
        <td class="DataCell">
            <asp:CheckBox ID="cbREQUIERECALIFICACION" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblPREFIJOBASE" runat="server" Text="Prefijo:" /></td>
        <td class="DataCell">
            <asp:TextBox ID="txtPREFIJOBASE" runat="server" MaxLength="4" Width="60px" />
        </td>
    </tr>
</table>
