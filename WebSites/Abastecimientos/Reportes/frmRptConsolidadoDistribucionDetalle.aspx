<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRptConsolidadoDistribucionDetalle.aspx.vb" Inherits="Reportes_frmRptConsolidadoDistribucionDetalle" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ministerio de Salud .::SISTEMA DE ABASTECIMIENTO::.</title>
</head>
<body>
    <form id="form1" runat="server">
     <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True" />
    </form>
</body>
</html>
