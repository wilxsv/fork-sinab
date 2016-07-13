<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptAbastecimientoProductosExistencias.aspx.vb" Inherits="Reportes_FrmRptAbastecimientoProductosExistencias" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Ministerio De Salud .::SISTEMA DE ABASTECIMIENTO::.</title>
   
</head>
<body>
    <form id="form1" runat="server">
    <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="true" />
    </form>
   
</body>
</html>

