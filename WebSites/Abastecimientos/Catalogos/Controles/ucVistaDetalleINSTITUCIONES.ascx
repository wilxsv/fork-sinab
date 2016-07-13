<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleINSTITUCIONES.ascx.vb"
    Inherits="ucVistaDetalleINSTITUCIONES" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblNOMBRE" runat="server" Text="Nombre:" />
        </td>
        <td class="DataCell">
            <asp:Label ID="txtNOMBRE" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblPORCENTAJERESERVA" runat="server" Text="Porcentaje de Reserva:" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtPORCENTAJERESERVA" runat="server" Width="100px" TextAlign="Right"
                MaxLength="5" />
            <asp:RequiredFieldValidator ID="rfvPORCENTAJERESERVA" runat="server" Display="Dynamic"
                ControlToValidate="txtPORCENTAJERESERVA" ErrorMessage="Porcentaje Requerido" /></td>
    </tr>
</table>
