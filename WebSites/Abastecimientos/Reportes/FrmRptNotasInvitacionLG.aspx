<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmRptNotasInvitacionLG.aspx.vb"
    Inherits="Reportes_FrmRptNotasInvitacionLG" %>

<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ministerio De Salud Publica y Asistencia Social .::SISTEMA DE ABASTECIMIENTO::.</title>
   
</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="true" />
    </form>
</body>
</html>