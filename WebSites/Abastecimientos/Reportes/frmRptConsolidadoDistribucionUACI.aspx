<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRptConsolidadoDistribucionUACI.aspx.vb" Inherits="Reportes_frmRptConsolidadoDistribucionUACI" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Ministerio De Salud .::SISTEMA DE ABASTECIMIENTO::.</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="True"  />
    </div>
    </form>
</body>
</html>
