<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFiltroReporteEstablecimientos.ascx.vb" Inherits="Controles_ucFiltroReporteEstablecimientos" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
    TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<table>
    <tr>
        <td>
        </td>
        <td>
            <cc1:ddlestablecimientos id="DdlestablecimientosInicial" runat="server" width="93px" Visible="False"></cc1:ddlestablecimientos></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LblZona" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="16px" Width="599px" /></td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="LblEstablecimiento" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="37px" Width="601px" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:RadioButtonList ID="RblRegiones" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                TabIndex="5" Visible="False" Width="686px">
                <asp:ListItem Selected="True" Value="0">Todas las Regiones</asp:ListItem>
                <asp:ListItem Value="1">Una Regi&amp;oacuten</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lblRegion" runat="server" Text="Regi&oacuten" /></td>
        <td>
            <cc1:ddlZONAS ID="DdlZONAS1" runat="server" Width="217px" AutoPostBack="True">
            </cc1:ddlZONAS></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:RadioButtonList ID="RblEstablecimientos" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                TabIndex="5" Visible="False" Width="686px">
                <asp:ListItem Selected="True" Value="0">Todos los establecimientos</asp:ListItem>
                <asp:ListItem Value="1">Un establecimiento</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lblestab" runat="server" Text="Establecimiento" /></td>
        <td>
            <cc1:ddlestablecimientos id="DdlESTABLECIMIENTOS1" runat="server" width="483px" AutoPostBack="True"></cc1:ddlestablecimientos></td>
    </tr>
    <tr>
        <td align="right" bgcolor="#b5c7de" colspan="2">
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lblEjercicio" runat="server" Text="Ejercicio fiscal" /></td>
        <td>
            <asp:DropDownList ID="ddlAñoInicio" runat="server" AutoPostBack="True" Width="69px">
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lblfecha" runat="server" Text="Fecha de referencia" /></td>
        <td>
            <ew:calendarpopup id="FechaReferencia" runat="server" width="97px" AutoPostBack="True"></ew:calendarpopup>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LblOperador" runat="server" Text="Operador" /></td>
        <td>
            <asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True" Width="217px">
                <asp:ListItem Value="=">Igual (=)</asp:ListItem>
                <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
                <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
                <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
                <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
                <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
            </asp:DropDownList>&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lblServicioH" runat="server" Text="Servicio Hospitalario" /></td>
        <td>
            <cc1:ddlSERVICIOSHOSPITALARIOS ID="DdlSERVICIOSHOSPITALARIOS1" runat="server" AutoPostBack="True"
                Width="481px">
            </cc1:ddlSERVICIOSHOSPITALARIOS></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="lblFechaInicialRango" runat="server" Text="Fecha Inicial" />&nbsp;<ew:CalendarPopup ID="FechaInicialRango" runat="server" Width="100px" AutoPostBack="True">
            </ew:CalendarPopup>
            &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Label ID="lblFechaFinalRango" runat="server" Text="Fecha Final" />
            <ew:CalendarPopup ID="FechaFinalRango" runat="server" Width="100px" AutoPostBack="True">
            </ew:CalendarPopup>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:RadioButtonList ID="RdbProveedor" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                TabIndex="5" Visible="False" Width="686px">
                <asp:ListItem Selected="True" Value="0">Todos los Proveedores</asp:ListItem>
                <asp:ListItem Value="1">Un Proveedor</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LblProveedor" runat="server" Text="Proveedor" />
            <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Width="494px">
            </cc1:ddlPROVEEDORES>
            <asp:Button ID="Bttaceptarproveedor" runat="server" CausesValidation="False" Text="Aceptar"
                Width="50px" />
            <asp:Label ID="LblDescripcionProveedor" runat="server" BorderColor="LightBlue" BorderStyle="Solid"
                BorderWidth="1px" Height="41px" Visible="False" Width="89%" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:RadioButtonList ID="rdbProducto" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                TabIndex="5" Visible="False" Width="686px">
                <asp:ListItem Selected="True" Value="0">Todos los Productos</asp:ListItem>
                <asp:ListItem Value="1">Un Producto</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                Width="580px">
                <asp:ListItem Selected="True" Value="0">B&#250;squeda por c&amp;oacutedigo</asp:ListItem>
                <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                <asp:ListItem Value="2">Por Grupo</asp:ListItem>
                <asp:ListItem Value="3">Por Suministro</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="lblproducto" runat="server" Visible="False" /></td>
    </tr>
    <tr>
        <td colspan="2" align="center">
            <asp:Label ID="lblIDPRODUCTO" runat="server">Producto:</asp:Label><ew:NumericBox
                ID="TxtProducto" runat="server" Width="101px" /><cc1:ddlGRUPOS ID="DdlGRUPOS1"
                    runat="server" Visible="False" Width="242px">
                </cc1:ddlGRUPOS><cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" Width="244px">
            </cc1:ddlSUMINISTROS>
            <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server"
                    AutoPostBack="True" Visible="False" Width="416px">
                </cc1:ddlCATALOGOPRODUCTOS>
            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar"
                Width="50px" />
            <asp:Button ID="bttFiltrarGrupo" runat="server" Text="Filtrar Productos por Grupo" Visible="False" />
            <asp:Button ID="bttFiltrarSuministro" runat="server" Text="Filtrar Productos por Suministro" Visible="False" /></td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Label ID="LblDescripcionCompleta" runat="server" BorderColor="LightBlue" BorderStyle="Solid"
                BorderWidth="1px" Height="41px" Visible="False" Width="89%" />&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <nds:MsgBox ID="MsgBox1" runat="server" />
            <asp:Label ID="lblidestablecimiento" runat="server" Visible="False" />
            <asp:Label ID="lblidpadre" runat="server" Visible="False" />
            <asp:Label ID="lblidtipoestablecimiento" runat="server" Visible="False" />
            <asp:Label ID="lblidestabseleccionado" runat="server" Visible="False" />
            <asp:Label ID="FechaRefSeleccionada" runat="server" Visible="False" />
            <asp:Label ID="FechaIniSelecionada" runat="server" Visible="False" />
            <asp:Label ID="fechaFinSelecionada" runat="server" Visible="False" />
            <asp:Label ID="servcioseleccionado" runat="server" Visible="False" />
            <asp:Label ID="RegionSeleccionada" runat="server" Visible="False" />
            <asp:Label ID="año" runat="server" Visible="False" />
            <asp:Label ID="ProductoSeleccionado" runat="server" Visible="False" />
            <asp:Label ID="OperSeleccionado" runat="server" Visible="False" />
            <asp:Label ID="ProveedorSeleccionado" runat="server" Visible="False" />
            <asp:Label ID="TodosLosProveedores" runat="server" Visible="False" />
            <asp:Label ID="TodosLosProductos" runat="server" Visible="False" />
            <asp:Label ID="TodasLasRegiones" runat="server" Visible="False" />
            <asp:Label ID="TodosLosEstablecimientos" runat="server" Visible="False" />
            <asp:Label ID="lblSuministro" runat="server" Visible="False" />
            <asp:Label ID="lblTipoSuministro" runat="server" Visible="False" /></td>
    </tr>
</table>
