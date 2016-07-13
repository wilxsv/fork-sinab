<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptObservacionesNecesidades.aspx.vb"
    Inherits="Reportes_FrmRptObservacionesNecesidades" Title="Ministerio De Salud Publica y Asistencia Social .::SISTEMA DE ABASTECIMIENTO::." %>

<%@ Register Assembly="CrystalDecisions.Web"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ministerio De Salud Publica y Asistencia Social .::SISTEMA DE ABASTECIMIENTO::.</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="true" ReportSourceID="crsObservacionesNecesidades" />
    </form>
</body>
</html>
