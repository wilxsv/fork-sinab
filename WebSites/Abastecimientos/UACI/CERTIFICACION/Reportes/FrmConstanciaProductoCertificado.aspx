<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmConstanciaProductoCertificado.aspx.vb" Inherits="UACI_CERTIFICACION_Reportes_FrmConstanciaProductoCertificado"
    Title="Certificación - Constancia de Productos Certificados" %>
<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="cr" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=Title%></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <cr:CrystalReportViewer ID="crvPrincipal" runat="server" AutoDataBind="true" />
    </div>
    </form>
</body>
</html>
