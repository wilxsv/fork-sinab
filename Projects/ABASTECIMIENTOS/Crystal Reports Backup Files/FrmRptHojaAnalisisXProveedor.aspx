<%@ Page Language="VB" MaintainScrollPositionOnPostBack="True" AutoEventWireup="false" CodeFile="FrmRptHojaAnalisisXProveedor.aspx.vb" Inherits="Reportes_FrmRptHojaAnalisisXProveedor" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ministerio De Salud Publica y Asistencia Social .::SISTEMA DE ABASTECIMIENTO::.</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True" />
        <CR:CrystalReportViewer ID="crvSecundario" runat="server" AutoDataBind="True" Visible="False" />
    </form>
</body>
</html>
