<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucIngresosGenerales.ascx.vb" Inherits="Controles_ucIngresosGenerales" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<table>
    <tr>
        <td align="right" style="width: 223px">
        </td>
        <td align="left" style="width: 609px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Blue"
                Text="CONFIGURE SU ELECCION" /></td>
    </tr>
    <tr>
        <td align="right" style="width: 223px">
            <asp:Label ID="LblAlmacen" runat="server" Text="Almacen:" /></td>
        <td align="left" style="width: 609px">
            <cc1:ddlALMACENES ID="DdlALMACENES1" runat="server" Width="328px">
            </cc1:ddlALMACENES></td>
    </tr>
    <tr>
        <td align="right" style="width: 223px">
            <asp:Label ID="LblCodigo" runat="server" Text="Tipo Suministro:" /></td>
        <td align="left" style="width: 609px">
            <cc1:ddlTIPOSUMINISTROS ID="DdlTIPOSUMINISTROS1" runat="server" Width="328px">
            </cc1:ddlTIPOSUMINISTROS></td>
    </tr>
    <tr>
        <td align="right" style="width: 223px; height: 18px">
            <asp:Label ID="LblFec1" runat="server" Text="Fecha Desde:" /></td>
        <td align="left" style="width: 609px; height: 18px">
            <ew:CalendarPopup ID="CalendarPopup1" runat="server">
            </ew:CalendarPopup>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 223px; height: 18px">
            <asp:Label ID="LblFec2" runat="server" Text="Fecha Hasta:" /></td>
        <td align="left" style="width: 609px; height: 18px">
            <ew:CalendarPopup ID="CalendarPopup2" runat="server">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 223px">
            <asp:Label ID="LblFuenteFinanciamiento" runat="server" Text="Fuente de Finanaciamiento:" /></td>
        <td align="left" style="width: 609px">
            <cc1:ddlFUENTEFINANCIAMIENTOS ID="DdlFUENTEFINANCIAMIENTOS1" runat="server" Width="328px">
            </cc1:ddlFUENTEFINANCIAMIENTOS></td>
    </tr>
    <tr>
        <td align="right" style="width: 223px">
            <asp:Label ID="LblResponsabledistribucion" runat="server" Text="Responsable de Distribucion:" /></td>
        <td align="left" style="width: 609px">
            <cc1:ddlRESPONSABLEDISTRIBUCION ID="DdlRESPONSABLEDISTRIBUCION1" runat="server" Width="328px">
            </cc1:ddlRESPONSABLEDISTRIBUCION></td>
    </tr>
    <tr>
        <td align="right" style="width: 223px; height: 26px">
        </td>
        <td align="left" style="width: 609px; height: 26px">
            <asp:Button ID="Button1" runat="server" Text="Imprimir" />
        </td>
    </tr>
</table>
