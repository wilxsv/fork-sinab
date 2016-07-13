<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleConsumo.ascx.vb"
    Inherits="Controles_ucVistaDetalleConsumo" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table id="VistaDetalle" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td style="height: 24px" width="10">
        </td>
        <td align="right" style="height: 24px" width="40%">
        </td>
        <td align="left" style="width: 60%; height: 24px">
        </td>
        <td style="height: 24px" width="10">
        </td>
    </tr>
    <tr>
        <td width="10" style="height: 24px">
        </td>
        <td align="right" width="40%" style="height: 24px">
            &nbsp;<asp:Label ID="lblIDCONSUMO" runat="server">Consumo N°:</asp:Label></td>
        <td align="left" style="height: 24px; width: 60%;">
            <asp:TextBox ID="txtIDCONSUMO" runat="server" BackColor="Linen" ReadOnly="True" Width="70px"></asp:TextBox>
            <asp:ImageButton ID="BttGenerarNuevo" runat="server" ImageUrl="~/Imagenes/botones/GenerarNuevoConsumo2.gif" />
            <asp:Label ID="lblid" runat="server" Visible="False" /></td>
        <td width="10" style="height: 24px">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="right" width="40%">
            <asp:Label ID="lblIDESTABLECIMIENTO" runat="server">Establecimiento:</asp:Label></td>
        <td align="left" style="width: 60%">
            <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Width="320px" Enabled="False">
            </cc1:ddlESTABLECIMIENTOS></td>
        <td width="10">
        </td>
    </tr>
    <tr>
        <td width="10" style="height: 25px">
        </td>
        <td align="right" style="height: 25px" width="40%">
            <asp:Label ID="lblFECHAINGRESO" runat="server">Fecha Ingreso:</asp:Label></td>
        <td style="height: 25px; width: 60%;" align="left">
            <ew:CalendarPopup ID="CalendarFechaIngreso" runat="server" MonthYearSelectionDisabled="True"
                Width="101px" Enabled="False">
            </ew:CalendarPopup>
        </td>
        <td width="10" style="height: 25px">
        </td>
    </tr>
    <tr>
        <td width="10" style="height: 22px">
        </td>
        <td align="right" width="40%" style="height: 22px">
            <asp:Label ID="lblTIEMPOCONSUMO" runat="server">Tiempo Consumo:</asp:Label></td>
        <td align="left" style="height: 22px; width: 60%;">
            <asp:DropDownList ID="DdlTiempoConsumo" runat="server" Width="130px" AutoPostBack="True"
                Enabled="False">
                <asp:ListItem Value="D">Diario</asp:ListItem>
                <asp:ListItem Value="M">Mensual</asp:ListItem>
            </asp:DropDownList></td>
        <td width="10" style="height: 22px">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="right" width="40%">
            <asp:Label ID="lblMESCONSUMO" runat="server">Periodo Consumo:</asp:Label></td>
        <td align="left" style="width: 60%">
            <asp:Label ID="lblDia" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="46px" />
            <%--<asp:DropDownList ID="DdlAño" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Set_CalendarYear"
                Width="78px" Enabled="False">--%>
            <%--</asp:DropDownList><asp:DropDownList ID="DdlMes" runat="server" Width="129px" AutoPostBack="True"
                OnSelectedIndexChanged="Set_Calendar" Enabled="False">
            </asp:DropDownList>--%></td>
        <td width="10">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="right">
        </td>
        <td align="left" valign="top">
            <asp:Calendar ID="CalendarDias" runat="server" BackColor="White" BorderColor="#3366CC"
                BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                Font-Size="8pt" ForeColor="#003399" Height="140px" Width="207px">
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <WeekendDayStyle BackColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                    Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>
        </td>
        <td width="10">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="right" width="40%">
            <asp:Label ID="lblIDEMPLEADO" runat="server">Empleado:</asp:Label></td>
        <td align="left" style="width: 60%">
            <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="334px" Enabled="False">
            </cc1:ddlEMPLEADOS>
        </td>
        <td width="10">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="right" width="40%">
            <asp:Label ID="lblIDESTADO" runat="server">Estado:</asp:Label></td>
        <td align="left" style="width: 60%">
            <cc1:ddlESTADOSCONSUMOS ID="DdlESTADOSCONSUMOS1" runat="server" Width="170px">
            </cc1:ddlESTADOSCONSUMOS>
        </td>
        <td width="10">
        </td>
    </tr>
    <tr>
        <td width="10">
        </td>
        <td align="center" bgcolor="#b5c7de" colspan="2">
            <asp:Label ID="Label1" runat="server" Text="Desglose de productos" /></td>
        <td width="10">
        </td>
    </tr>
</table>
