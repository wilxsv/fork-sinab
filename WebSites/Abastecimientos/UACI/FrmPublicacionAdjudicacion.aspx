<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmPublicacionAdjudicacion.aspx.vb" Inherits="FrmPublicacionAdjudicacion"
  MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;&nbsp;<asp:Label
          ID="LblRuta" runat="server" Text="UACI ->Publicación de resultados" />
        &nbsp;<asp:Label ID="lblVersion" runat="server" Text="v1.0" />
      </td>
    </tr>
  </table>
  <table class="Table">
    <tr>
      <td colspan="2">
        <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server"
          PermiteSeleccionar="false" />
      </td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label12" runat="server" Text="Proceso de compra:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="lblNoProcesoCompra" runat="server" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label3" runat="server" Text="Fecha de iniciado el proceso de compra:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="FechaInicioProcCompra" runat="server" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label4" runat="server" Text="Fecha de finalización examen preliminar:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="FechaExamen" runat="server" /></td>
    </tr>
    <tr>
      <td class="CoolLabelCell">
        <asp:Label ID="Label13" runat="server" Text="Fecha en que se finalizó la recomendación:" /></td>
      <td class="CoolDataCell">
        <asp:Label ID="FechaRecomendacion" runat="server" /></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red" /></td>
    </tr>
    <tr>
      <td colspan="2">
        &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="TituloLeftCell">
        <asp:Label ID="Label16" runat="server" Text="Notificación a empresas" /></td>
      <td class="DataCell">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label19" runat="server" Text="Fecha de notificación:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CPFechaNotificacion" runat="server" DisableTextBoxEntry="False"
          Width="88px" Enabled="False" />
        (dd/mm/aaaa)<asp:RangeValidator ID="rvNotificacion" runat="server" ControlToValidate="CPFechaNotificacion"
          ErrorMessage="La fecha de notificación debe ser menor o igual a la fecha actual"
          Font-Size="Large" Type="Date">*</asp:RangeValidator></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label14" runat="server" Text="Fecha límite para recibir notas de aceptación y recursos de revisión:" /></td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CPFechaLimite" runat="server" DisableTextBoxEntry="False" Width="88px"
          Enabled="False" />
        (dd/mm/aaaa)<asp:RangeValidator ID="rvLimite" runat="server" ControlToValidate="CPFechaLimite"
          ErrorMessage="La fecha de límite debe ser mayor a la fecha actual" Font-Size="Large"
          Type="Date">*</asp:RangeValidator>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" Width="100%">
          <table class="Table">
            <tr>
              <td class="TituloLeftCell">
                <asp:Label ID="Label24" runat="server" Text="Publicación de resultados" /></td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label27" runat="server" Text="Fecha publicación:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CPFechaPublicacion" runat="server" DisableTextBoxEntry="False"
                  Width="88px" />
                (dd/mm/aaaa)<asp:RangeValidator ID="rvPublicacion" runat="server" ControlToValidate="CPFechaPublicacion"
                  ErrorMessage="La fecha de publicación debe ser mayor a la fecha de recomendacion y menor o igual a la fecha actual."
                  Font-Size="Large" Type="Date">*</asp:RangeValidator></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label25" runat="server" Text="Medios de divulgación:" /></td>
              <td class="DataCell">
                <asp:TextBox ID="txtMediosDivulgacion" runat="server" CssClass="TextBoxMultiLine"
                  TextMode="MultiLine" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe ingresar los medios de divulgación"
                  Font-Size="Large" ControlToValidate="txtMediosDivulgacion">*</asp:RequiredFieldValidator></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <nds:Button ID="Button2" runat="server" Message="¿Desea guardar la información ingresada?"
          ShowConfirmDialog="True" Text="Guardar" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
