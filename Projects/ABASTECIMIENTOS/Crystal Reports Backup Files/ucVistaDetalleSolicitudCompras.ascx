<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleSolicitudCompras.ascx.vb"
  Inherits="Controles_ucVistaDetalleSolicitudCompras" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucDetalleFuenteFinanciamientoSolicitud.ascx"
  TagName="ucDetalleFuenteFinanciamientoSolicitud" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDSOLICITUD" runat="server" Visible="False" Text="IDSOLICITUD:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtIDSOLICITUD" runat="server" BackColor="Linen" ReadOnly="True"
        Visible="False" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="LabelEstablecimientoSolicita" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCORRELATIVO" runat="server" Text="N° Solicitud:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCORRELATIVO" runat="server" Width="74px" />
      <asp:Label ID="Label5" runat="server" Text="(##/año)" />
      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCORRELATIVO"
        ErrorMessage="* Caracteres no permitidos" ValidationExpression="[0-9]+\/[0-9]+" />
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCORRELATIVO"
        ErrorMessage="*Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFECHASOLICITUD" runat="server" Text="Fecha de Solicitud:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="CalendarFechaSolicitud1" runat="server" Width="114px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDESTADO" runat="server" Text="Estado:" /></td>
    <td class="DataCell">
      <cc1:ddlESTADOS ID="ddlESTADOS1" runat="server" Width="420px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDDEPENDENCIASOLICITANTE" runat="server" Text="Dependencia solicitante:" /></td>
    <td class="DataCell">
      <cc1:ddlDEPENDENCIAESTABLECIMIENTOS ID="ddlDEPENDENCIAESTABLECIMIENTOS1" runat="server"
        Width="420px" Enabled="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPLAZOENTREGA" runat="server" Text="Plazo de Entrega:" /></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlPlazoentrega" runat="server" Width="147px">
        <asp:ListItem Value="0">0 Dias</asp:ListItem>
        <asp:ListItem Value="15">15 Dias</asp:ListItem>
        <asp:ListItem Value="30">30 Dias</asp:ListItem>
        <asp:ListItem Value="45">45 Dias</asp:ListItem>
        <asp:ListItem Value="60">60 dias</asp:ListItem>
        <asp:ListItem Value="75">75 Dias</asp:ListItem>
        <asp:ListItem Value="90">90 Dias</asp:ListItem>
        <asp:ListItem Value="105">105 Dias</asp:ListItem>
        <asp:ListItem Value="120">120 Dias</asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="LblIDALMACEN" runat="server" Text="Lugar de Entrega:" /></td>
    <td class="DataCell">
      <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="420px" AutoPostBack="True" />
      <asp:TextBox ID="TxtDireccion" runat="server" Width="8px" Enabled="False" Visible="False" />
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlALMACENES1"
        ErrorMessage="*Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblDireccion" runat="server" Text="Direcci&oacuten de Almac&eacuten:" /></td>
    <td class="DataCell">
      <asp:Label ID="lblDireccionA" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPERIODOUTILIZACION" runat="server" Text="Periodo Utilizaci&oacuten:" /></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlPeriodoUtilizacion" runat="server" Width="51px">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="6">6</asp:ListItem>
        <asp:ListItem Value="7">7</asp:ListItem>
        <asp:ListItem Value="8">8</asp:ListItem>
        <asp:ListItem Value="9">9</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
      </asp:DropDownList>
      <asp:Label ID="Label2" runat="server" Text="mes(es)" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDCLASESUMINISTRO" runat="server" Text="Clase de Suministro:" /></td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="419px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTODISPONIBLE" runat="server" Text="Monto Disponible:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTODISPONIBLE" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
        Enabled="False" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTOSOLICITADO" runat="server" Text="Monto Solicitado:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTOSOLICITADO" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
        Enabled="False" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPOCOMPRASOLICITADO" runat="server" Text="Tipo de compra Solicitado:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPOCOMPRAS ID="ddlTIPOCOMPRAS1" runat="server" Width="420px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPOCOMPRASUGERIDO" runat="server" Text="Tipo de Compra Sugerido:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPOCOMPRAS ID="ddlTIPOCOMPRAS2" runat="server" Width="421px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDTIPOCOMPRAEJECUTAR" runat="server" Text="Tipo de Compra ejecutar:" /></td>
    <td class="DataCell">
      <cc1:ddlTIPOCOMPRAS ID="ddlTIPOCOMPRAS3" runat="server" Width="421px" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblOBSERVACION" runat="server" Text="Observaciones:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtOBSERVACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDSOLICITANTE" runat="server" Text="Solicita:" /></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="424px" AutoPostBack="True" /></td>
  </tr>
  <tr>
    <td>
    </td>
    <td class="DataCell">
      <asp:Label ID="TxtCargoEmpleadoSolicita" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDAREATECNICA" runat="server" Text="Area T&eacutecnica:" /></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS2" runat="server" Width="425px" AutoPostBack="True" /></td>
  </tr>
  <tr>
    <td>
    </td>
    <td class="DataCell">
      <asp:Label ID="TxtCargoEmpleadoAreaTec" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDAUTORIZA" runat="server" Text="Autoriza:" /></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS3" runat="server" Width="425px" AutoPostBack="True" /></td>
  </tr>
  <tr>
    <td>
    </td>
    <td class="DataCell">
      <asp:Label ID="TxtCargoEmpleadoAutoriza" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="Label4" runat="server" Text="Forma de entregas" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="LblFormasEntrega" runat="server" Text="Formas de Entrega:" /></td>
    <td class="DataCell">
      <asp:Button ID="BttFormasEntrega" runat="server" Text="Detallar entregas >>" Width="300px" />
      <br />
      <asp:TreeView ID="TvEntregas" runat="server" ExpandDepth="0" SkipLinkText="" ImageSet="Inbox"
        Width="100%">
        <ParentNodeStyle Font-Bold="False" ForeColor="Navy" />
        <HoverNodeStyle Font-Underline="True" />
        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
          NodeSpacing="0px" VerticalPadding="0px" />
        <RootNodeStyle ForeColor="Navy" />
      </asp:TreeView>
      <asp:Button ID="BttImprimirPrograma" runat="server" Text="Imprimir programa de distribucion"
        Width="300px" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblCertificacion" runat="server" Text="Certificaci&oacuten de fondos" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCIFRADOPRESUPUESTARIO" runat="server" Text="Certificaci&oacuten de fondos:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCIFRADOPRESUPUESTARIO" runat="server" CssClass="TextBoxMultiLine"
        TextMode="MultiLine" MaxLength="50" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCODRESERVAFONDO" runat="server" Visible="False" Text="C&oacutedigo Reserva Fondos:" /></td>
    <td class="DataCell">
      <asp:TextBox ID="txtCODRESERVAFONDO" runat="server" Width="171px" Visible="False"
        MaxLength="10" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblRESERVAFONDO" runat="server" Visible="False" Text="Reserva de Fondos:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtRESERVAFONDO" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
        Width="170px" Visible="False" MaxLength="10" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDCERTIFICA" runat="server" Text="Certifica:" /></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS4" runat="server" Width="448px" AutoPostBack="True" /></td>
  </tr>
  <tr>
    <td>
    </td>
    <td class="DataCell">
      <asp:Label ID="TxtCargoEmpleadoCertifica" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTOAUTORIZADO" runat="server" Visible="False" Text="Monto Autorizado:" /></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTOAUTORIZADO" runat="server" AutoFormatCurrency="True" PositiveNumber="True"
        Width="168px" Visible="False" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFECHAAUTORIZACION" runat="server" Text="Fecha de Autorizaci&oacuten:" /></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="CalendarFechaAut1" runat="server" Width="86px" />
      <asp:TextBox ID="TxtCompraConjunta" runat="server" Visible="False" Width="36px" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="Label3" runat="server" Text="Fuente de financiamiento" /></td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
