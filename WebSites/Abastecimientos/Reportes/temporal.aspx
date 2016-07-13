<%@ Page Language="VB" AutoEventWireup="false" CodeFile="temporal.aspx.vb" Inherits="Reportes_temporal" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <CR:CrystalReportViewer ID="crvPrincipal" runat="server" />
    </div>
    </form>
</body>
</html>
