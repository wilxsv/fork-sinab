<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmIndiceProductosEstablecimientosDetalle.aspx.vb" Inherits="Reportes_VisorReporte" title="Mostrar reporte" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
  Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
  <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="true" />
</asp:Content>

