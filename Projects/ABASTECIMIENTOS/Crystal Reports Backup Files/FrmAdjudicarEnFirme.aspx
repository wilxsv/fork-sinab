<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmAdjudicarEnFirme.aspx.vb" Inherits="FrmAdjudicarEnFirme" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucRenglonesProcesoCompra" Src="~/Controles/ucRenglonesProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucOfertasPorRenglonProcesoCompra" Src="~/Controles/ucOfertasPorRenglonProcesoCompra.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucAsignarCantidades" Src="~/Controles/ucAsignarCantidades.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Adjudicación en firme y resolución modificativa v1.2</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td style="font-weight: bold;">
        <asp:Label ID="lblRecursosRevisionNotasAceptacion" runat="server" Text="Se debe modificar la resolución de adjudicación debido a que: " /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnModificarRecomendacion" runat="server" Text="1. Modificar Resolución de Adjudicación"
          Width="260px" />
        <asp:Button ID="btnIngresarFechaAdjudicar" runat="server" Text="2. Generar Resolución de Adjudicación"
          Width="260px" /></td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnInformeEvaluacionPorRenglon" runat="server" Text="Ver Informe de evaluación por Renglones"
          CausesValidation="False" UseSubmitBehavior="False" Visible="False" Width="260px" />
        <asp:Button ID="btnInformeEvaluacionPorOferta" runat="server" Text="Ver Informe de evaluación por Ofertas"
          CausesValidation="False" UseSubmitBehavior="False" Visible="False" Width="260px" /></td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="btnAviso" runat="server" Text="Imprimir Aviso" UseSubmitBehavior="False" /></td>
    </tr>
  </table>
  <asp:Panel ID="pnGenerarResolucionAdjudicacion" runat="server" Visible="false">
    <table class="CenteredTable" style="width: 100%;">
      <tr>
        <td>
          <uc1:ucRenglonesProcesoCompra ID="UcRenglonesProcesoCompra1" runat="server" Visible="false" />
        </td>
      </tr>
      <tr>
        <td>
          <uc1:ucOfertasPorRenglonProcesoCompra ID="UcOfertasPorRenglonProcesoCompra1" runat="server"
            Visible="false" />
        </td>
      </tr>
      <tr>
        <td>
          <uc1:ucAsignarCantidades ID="UcAsignarCantidades1" runat="server" Visible="false" />
        </td>
      </tr>
    </table>
  </asp:Panel>
  <asp:Panel ID="pnRegistrarFecha" runat="server" Visible="false" Width="100%">
    <table class="CenteredTable" style="width: 100%;">
      <tr>
      </tr>
      <tr>
        <td class="LabelCell">
          <asp:Label ID="lblFechaFirmaResolucion" runat="server" Text="Fecha de adjudicación en firme:" /></td>
        <td class="DataCell">
          <ew:CalendarPopup ID="cpFechaFirmaResolucion" runat="server" DisableTextBoxEntry="False"
            GoToTodayText="" Culture="Spanish (El Salvador)" />
          <asp:RequiredFieldValidator ID="rfvFechaFirmaResolucion" runat="server" ControlToValidate="cpFechaFirmaResolucion"
            ErrorMessage="Debe ingresar la fecha de adjudicación en firme" ValidationGroup="Adjudicar" /></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:CompareValidator ID="cvFechaFirmaResolucion" runat="server" ControlToValidate="cpFechaFirmaResolucion"
            ErrorMessage="La fecha de firma de la resolución no puede ser anterior a la de notificación."
            Operator="GreaterThanEqual" Type="Date" ValidationGroup="Adjudicar" Visible="False" /></td>
      </tr>
      <tr>
        <td colspan="2">
          <asp:CompareValidator ID="cvFechaFirmaResolucion1" runat="server" ControlToValidate="cpFechaFirmaResolucion"
            ErrorMessage="La fecha de firma de la resolución no puede ser posterior a hoy."
            Operator="LessThanEqual" Type="Date" ValidationGroup="Adjudicar" Display="Dynamic" /></td>
      </tr>
      <tr>
      </tr>
      <tr>
        <td colspan="2">
          <asp:ImageButton ID="btnAdjudicar" runat="server" ImageUrl="~/Imagenes/botones/save.jpg"
            ValidationGroup="Adjudicar" />
          <asp:ImageButton ID="btnCancelar" runat="server" CausesValidation="False" ImageUrl="~/Imagenes/botones/cancel.jpg" />
        </td>
      </tr>
    </table>
    <nds:MsgBox ID="MsgBox1" runat="server" />
  </asp:Panel>
</asp:Content>
