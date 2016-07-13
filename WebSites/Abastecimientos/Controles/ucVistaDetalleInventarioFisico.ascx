<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleInventarioFisico.ascx.vb"
    Inherits="ucVistaDetalleInventarioFisico" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td class="DataCell">
            &nbsp;
            <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Visible="False" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblAlmacen" runat="server" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblFECHAINICIO" runat="server">Fecha Inicio:</asp:Label></td>
        <td class="DataCell">
            <ew:CalendarPopup ID="CalendarInicio" runat="server" Width="106px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="LabelCierreExistencias" runat="server">Fecha Cierre de existencias:</asp:Label></td>
        <td class="DataCell">
            <ew:CalendarPopup ID="CalendarCierreExistencias" runat="server" Width="106px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDSUMINISTRO" runat="server">Suministro:</asp:Label></td>
        <td class="DataCell">
            <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="230px" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="Label2" runat="server" Text="Elementos a considerar al generar el Inventario Fisico (opcional):" /></td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <asp:CheckBoxList ID="cblOpciones" runat="server" AutoPostBack="True">
                <asp:ListItem Value="1">Fuente de financiamiento</asp:ListItem>
                <asp:ListItem Value="2">Responsable de distribuci&#243;n</asp:ListItem>
                <asp:ListItem Value="3">Productos Vencidos</asp:ListItem>
                <asp:ListItem Value="4">Productos no disponibles</asp:ListItem>
            </asp:CheckBoxList></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDFUENTEFINANCIAMIENTO" runat="server">Fuente Financiamiento:</asp:Label></td>
        <td class="DataCell">
            <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="181px" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDRESPONSABLEDISTRIBUCION" runat="server">Responsable Distribuci&oacuten:</asp:Label></td>
        <td class="DataCell">
            <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" Width="182px"
                Visible="False" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblFECHACIERRE" runat="server" Visible="False">Fecha Cierre de inventario:</asp:Label></td>
        <td class="DataCell">
            <ew:CalendarPopup ID="CalendarFinal" runat="server" Visible="False" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            &nbsp;<asp:Label ID="lblESTACERRADO" runat="server">Cerrado:</asp:Label></td>
        <td class="DataCell">
            <asp:CheckBox ID="ChbCerrado" runat="server" />
            <asp:Label ID="cfuente" runat="server" Visible="False" />
            <asp:Label ID="cResponsable" runat="server" Visible="False" />
            <asp:Label ID="cVencidos" runat="server" Visible="False" />
            <asp:Label ID="cNoDisponible" runat="server" Visible="False" /></td>
    </tr>
</table>
