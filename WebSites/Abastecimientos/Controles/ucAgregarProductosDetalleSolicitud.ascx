<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAgregarProductosDetalleSolicitud.ascx.vb" Inherits="Controles_ucAgregarProductosDetalleSolicitud" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%">
    <tr>
        <td colspan="2">
            <asp:RadioButtonList ID="rdblCriterio" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" Width="100%">
                <asp:ListItem Selected="True" Value="0">B&#250;squeda por c&#243;digo</asp:ListItem>
                <asp:ListItem Value="1">Por selecci&#243;n</asp:ListItem>
                <asp:ListItem Value="2">Por Grupo</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="lblproducto" runat="server" Visible="False" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblIDPRODUCTO" runat="server" Text="Código Producto:" />
            <cc1:ddlCATALOGOPRODUCTOS ID="DdlCATALOGOPRODUCTOS1" runat="server" Width="416px" Visible="False" />
            <ew:NumericBox ID="TxtProducto" runat="server" Width="77px"/>
            <cc1:ddlGRUPOS ID="DdlGRUPOS1" runat="server" Visible="False" Width="188px" />
            <asp:Button ID="BtnBuscar" runat="server" CausesValidation="False" Text="Buscar" Width="50px" />
            <asp:Button ID="bttgenerar" runat="server" Text="Filtrar" Visible="False" /></td>
    </tr>
    <tr>
        <td colspan="2">
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label2" runat="server" Text="Producto" /></td>
        <td class="DataCell">
            <asp:Label ID="LblDescripcionCompleta" runat="server" Visible="False"/></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblIDUNIDADMEDIDA" runat="server" Text="Unidad de medida:" /></td>
        <td class="DataCell">
            <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS1" runat="server" Width="68px" Enabled="False" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblPRESUPUESTOUNITARIO" runat="server" Text="Precio Unitario:" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtPRESUPUESTOUNITARIO" runat="server" Width="99px" ReadOnly="True" PositiveNumber="True" AutoFormatCurrency="True" Enabled="False" MaxLength="12" TextAlign="Right" /></td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="lblCANTIDAD" runat="server" Text="Cantidad:" /></td>
        <td class="DataCell">
            <ew:NumericBox ID="txtCANTIDAD" runat="server" Width="68px" PositiveNumber="True" MaxLength="12" TextAlign="Right" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="N&uacutemero Entregas" /></td>
        <td class="DataCell">
            <asp:DropDownList ID="DDLnumeroEntregas" runat="server" Width="41px" /></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:ImageButton ID="ImgbGuardar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg" />
            <asp:ImageButton ID="ImgbCancelar" runat="server" ImageUrl="~/Imagenes/botones/cancel.jpg" />&nbsp;
            <asp:Label ID="lblSuministro" runat="server" Visible="False" Text="1" />
            <asp:Label ID="lblTipoSuministro" runat="server" Visible="False" Text="1" />
            <asp:Label ID="Labelid" runat="server" Visible="False" /></td>
    </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
