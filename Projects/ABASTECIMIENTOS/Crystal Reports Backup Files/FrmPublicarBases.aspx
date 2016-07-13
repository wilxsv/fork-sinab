<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmPublicarBases.aspx.vb" Inherits="FrmPublicarBases" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx"
  TagName="ucVistaDetalleSolicProcesCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        UACI -> Publicar Bases</td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Código de bases o proceso compra:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="Label18" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label3" runat="server" Text="Fecha de iniciado el proceso de compra:"
          Font-Bold="True" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="FechaInicioProcCompra" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Fecha de elaboración de bases:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="FechaElaboracionBases" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label4" runat="server" Text="Fecha de Aprobación de bases:" Font-Bold="True" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblFechaAprobacionBase" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="left" style="background-color: gainsboro;" colspan="2">
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Información de recepción de ofertas:" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label17" runat="server" Text="Lugar de recepción de ofertas:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblLugarRecepcion" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label19" runat="server" Text="Fecha y Hora de Inicio:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblFechaHoraInicioRecepcion" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label22" runat="server" Text="Fecha y Hora Fin:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblFechaHoraFinRecepcion" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="left" style="background-color: gainsboro;" colspan="2">
        <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Información de aperturas de ofertas" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label25" runat="server" Text="Lugar de apertura de las ofertas:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblLugarAperturaBase" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label27" runat="server" Text="Fecha y Hora de Inicio:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblFechaHoraInicioApertura" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label28" runat="server" Text="Fecha Fin:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblFechaHoraFinApertura" runat="server" ForeColor="Navy" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="lblFechaenvionota" runat="server" Text="Fecha de envío al departamento de comunicaciones la nota para publicar anuncio en el periódico:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CPFechaEnvioNota" runat="server" DisableTextBoxEntry="False"
          Culture="Spanish (El Salvador)" />
        &nbsp;(dd/mm/yyyy)</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label6" runat="server" Text="Fecha en la que se hará la publicación:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CPFechaPublicacion" runat="server" DisableTextBoxEntry="False"
          Culture="Spanish (El Salvador)" />
        &nbsp;(dd/mm/yyyy)
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="CPFechaEnvioNota"
          ControlToValidate="CPFechaPublicacion" ErrorMessage="Fecha de publicación debe ser mayor o igual a la fecha de envio a comunicación."
          Operator="GreaterThanEqual" Type="Date" Display="Dynamic" />
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="CPFechaPublicacion"
          ErrorMessage="Fecha de publicación debe ser menor a la fecha de inicio de recepción de ofertas."
          Operator="LessThan" Type="Date" Display="Dynamic" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label7" runat="server" Text="Costo de las bases:" /></td>
      <td class="DataCell">
        <ew:NumericBox ID="NBCostoBases" runat="server" AutoFormatCurrency="True" DecimalPlaces="2"
          Width="92px" MaxLength="12" TextAlign="Right" />($US)</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="left" colspan="2">
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Información de retiro de bases:" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label9" runat="server" Text="Lugar de retiro de las bases y mandamientos de pago:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="txtLugarRetirobases" runat="server" Width="314px" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label12" runat="server" Text="INICIO DE RETIRO DE BASES" Font-Bold="True"
          Font-Size="X-Small" /></td>
      <td class="DataCell">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label10" runat="server" Text="Fecha:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CPFechaInicioBase" runat="server" DisableTextBoxEntry="False"
          Culture="Spanish (El Salvador)" />
        &nbsp; &nbsp;(dd/mm/yyyy)
        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="CPFechaPublicacion"
          ControlToValidate="CPFechaInicioBase" ErrorMessage="Fecha de inicio de retiro de bases debe ser mayor o igual a la fecha de publicación"
          Operator="GreaterThanEqual" Type="Date" Display="Dynamic" />
        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="CPFechaInicioBase"
          ErrorMessage="Fecha de inicio de retiro de bases debe ser menor al inicio de recepción de ofertas."
          Operator="LessThan" Type="Date" Display="Dynamic" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label11" runat="server" Text="Hora Inicio" /></td>
      <td class="DataCell">
        <ew:TimePicker ID="tpHoraInicioBase" runat="server" DisableTextBoxEntry="False" Width="40px"
          SelectedTime="2006-09-13" MinuteInterval="FiveMinutes" />
        &nbsp;(00:00)</td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="X-Small" Text="FIN DE RETIRO DE BASES" /></td>
      <td class="DataCell">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label14" runat="server" Text="Fecha:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="cpFechaFinRetiroBase" runat="server" DisableTextBoxEntry="False"
          Culture="Spanish (El Salvador)" />
        (dd/mm/yyyy)</td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label15" runat="server" Text="Hora Fin:" /></td>
      <td class="DataCell">
        <ew:TimePicker ID="tpHoraFinBase" runat="server" DisableTextBoxEntry="False" Width="40px"
          SelectedTime="2006-09-13" MinuteInterval="FiveMinutes" />
        (00:00)</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label32" runat="server" Text="Comentarios u Observaciones:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="txtObservaciones" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="81px" />
        <asp:Button ID="Button1" runat="server" Text="Publicar bases" Width="104px" Enabled="False" />
        <asp:Button ID="Button2" runat="server" Text="Imprimir Aviso" Visible="False" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
  <nds:MsgBox ID="MsgBox2" runat="server" />
</asp:Content>
