<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSUBGRUPOS.ascx.vb"
    Inherits="ucVistaDetalleSUBGRUPOS" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
    <tr>
        <td class="LabelCell">
      Grupo:</td>
        <td class="DataCell">
      <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
      Correlativo:</td>
        <td class="DataCell">
      <ew:NumericBox ID="txtCORRELATIVO" runat="server" MaxLength="2" Width="49px" />
      <asp:RequiredFieldValidator ID="rfvCORRELATIVO" runat="server" Display="Dynamic"
        ControlToValidate="txtCORRELATIVO" ErrorMessage="Requerido" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
      Descripción:</td>
        <td class="DataCell">
            <asp:TextBox ID="txtDESCRIPCION" runat="server" Width="422px" />
            <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" Display="Dynamic"
        ControlToValidate="txtDESCRIPCION" ErrorMessage="Requerido" /></td>
    </tr>
</table>
