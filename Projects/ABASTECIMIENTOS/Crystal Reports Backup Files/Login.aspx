<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>
<%@ Register TagPrefix="uc1" TagName="ucLogin" Src="~/Controles/ucLogin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Ministerio De Salud Pública y Asistencia Social .::SISTEMA DE ABASTECIMIENTO::.
    </title>
    <link id="Link1" href="Style/Style.css" rel="stylesheet" type="text/css" />
    <link href="Style/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <link href="Style/Style.css" rel="stylesheet" type="text/css" />
    
 <script type="text/javascript" src="Script/jquery-1.9.1.js"  ></script>
            <script type="text/javascript" src="Script/jquery-ui-1.10.3.custom.min.js" ></script>
           <script type="text/javascript" src="Script/jquery.ui.datepicker-es.min.js" ></script>
            <script type="text/javascript" src="Script/jquery.ui.message.js"></script>
    <script type="text/javascript">
        //Script para que no funcione el boton atras del navegador
        if (history.forward(1)) {
            location.replace(history.forward(1));
        }

        $(function () {

          /*  $("input[type=submit],input[type=button], button").button().click(function (event) {
                event.preventDefault();
            });*/

            $("div.aviso").message();
            $("div.error").message({ type: "error" });

        });
    </script>
</head>
<body>
     <form id="form1" runat="server">
    <div id="Page" class="frame">
        <div id="Header">
            <div class="logo">
                <asp:Image runat="server" ID="logo" ImageUrl="~/Imagenes/MSPAS-LOGO.png" />
            </div>
            <div class="textos" style="margin: 0px !important">
                <asp:HyperLink runat="server" ID="mainlink" CssClass="siglas" Text="SINAB" NavigateUrl="~/FrmPrincipal.aspx" />
                <div class="nombre">
                    Sistema Nacional de Abastecimiento</div>
            </div>
        </div>
        <uc1:ucLogin ID="ucLogin1" runat="server" />
    </div>
    </form>
  
</body>
</html>
