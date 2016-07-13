<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleNecesidadesEstablecimientos.ascx.vb"
  Inherits="Controles_ucVistaDetalleNecesidadesEstablecimientos" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<table id="VistaDetalle" cellspacing="0" cellpadding="0" width="100%" border="0">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDNECESIDAD" runat="server" Visible="False">IDNECESIDAD:</asp:Label></td>
    <td class="DataCell">
      <asp:TextBox ID="txtIDNECESIDAD" runat="server" BackColor="Linen" ReadOnly="True"
        Width="70px" Visible="False" />
      <asp:TextBox ID="txtCORRELATIVO" runat="server" Width="93px" Visible="False" />
      <asp:Label ID="lblaño" runat="server" Visible="False" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDESTABLECIMIENTO" runat="server">Establecimiento:</asp:Label>
    </td>
    <td class="DataCell">
      <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Enabled="False"
        Width="307px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="LblNivel" runat="server" Text="Nivel" /></td>
    <td class="DataCell">
      <asp:TextBox ID="TxtNivel" runat="server" Width="58px" Enabled="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDALMACENENTREGA" runat="server">Almac&eacuten Entrega:</asp:Label></td>
    <td class="DataCell">
      <cc1:ddlALMACENES ID="DdlALMACENES1" runat="server" Width="310px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDSUMINISTRO" runat="server">Suministro:</asp:Label></td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="DdlSUMINISTROS1" runat="server" Width="309px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPROPUESTA" runat="server">Propuesta</asp:Label></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlPropuesta" runat="server" AppendDataBoundItems="True" Width="42px"
        Enabled="False">
        <asp:ListItem Value="1">A</asp:ListItem>
        <asp:ListItem Value="2">B</asp:ListItem>
        <asp:ListItem Value="3">C</asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDESTADO" runat="server">Estado:</asp:Label></td>
    <td class="DataCell">
      <cc1:ddlESTADOSNECESIDADES ID="DdlESTADOSNECESIDADES1" runat="server" Width="195px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblFECHAELABORACION" runat="server">Fecha Elaboraci&oacuten:</asp:Label></td>
    <td class="DataCell">
      <ew:CalendarPopup ID="CalendarFecha" runat="server" Enabled="False" Width="96px" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPERIODOUTILIZACION" runat="server">Periodo Utilizaci&oacuten:</asp:Label></td>
    <td class="DataCell">
      <asp:DropDownList ID="DdlPeriodoUtilizacion" runat="server" Width="52px" AutoPostBack="True">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
        <asp:ListItem Value="6">6</asp:ListItem>
        <asp:ListItem Value="7">7</asp:ListItem>
        <asp:ListItem Value="8">8</asp:ListItem>
        <asp:ListItem Value="9">9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
      </asp:DropDownList>
      <asp:Label ID="Label1" runat="server" Text="mes(es)" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="LblPeriodoComprado" runat="server" Text="Periodo comprado" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblANIOINICIOPERIODO" runat="server">Inicial:</asp:Label></td>
    <td class="DataCell">
      <asp:DropDownList ID="DdlMesInicio" runat="server" Width="129px" AutoPostBack="True" />
      <asp:DropDownList ID="ddlAñoInicio" runat="server" Width="57px" AutoPostBack="True" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblANIOFINPERIODO" runat="server">Final:</asp:Label></td>
    <td class="DataCell">
      <asp:DropDownList ID="ddlMesFinal" runat="server" Width="129px" Enabled="False" />
      <asp:DropDownList ID="DdlAñoFinal" runat="server" Width="57px" Enabled="False" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblIDEMPLEADO" runat="server">Empleado:</asp:Label></td>
    <td class="DataCell">
      <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="258px" AutoPostBack="True"
        Enabled="False" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblPRESUPUESTOASIGNADO" runat="server">Presupuesto Asignado:</asp:Label></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtPRESUPUESTOASIGNADO" runat="server" AutoFormatCurrency="True"
        PositiveNumber="True" Width="120px" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTONECESIDADREAL" runat="server">Monto Total Necesidad Real:</asp:Label></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTONECESIDADREAL" runat="server" AutoFormatCurrency="True"
        PositiveNumber="True" Width="121px" Enabled="False" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblMONTONECESIDADAJUSTADA" runat="server">Monto Total Necesidad Ajustada:</asp:Label></td>
    <td class="DataCell">
      <ew:NumericBox ID="txtMONTONECESIDADAJUSTADA" runat="server" AutoFormatCurrency="True"
        PositiveNumber="True" Width="121px" Enabled="False" TextAlign="Right" MaxLength="12" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblOBSERVACION" runat="server">Observaciones:</asp:Label></td>
    <td class="DataCell">
      <asp:TextBox ID="txtOBSERVACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
