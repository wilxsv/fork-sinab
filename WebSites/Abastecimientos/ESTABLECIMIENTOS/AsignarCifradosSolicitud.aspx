<%@ Page Title="Asignar Cifrados Presupuestarios" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AsignarCifradosSolicitud.aspx.vb" Inherits="ESTABLECIMIENTOS_AsignarCifradosSolicitud" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/Ctrl_Paso6_CrearSolicitudCompra.ascx" TagPrefix="uc1" TagName="Ctrl_Paso6_CrearSolicitudCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContent" Runat="Server">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="LblRuta" runat="server" Text="Establecimientos » Asignar Cifrados Presupuestarios" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
   <h3>Solicitud: <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label> </h3>
  
            <uc1:Ctrl_Paso6_CrearSolicitudCompra runat="server" Titulo=" Asignar Cifrados Presupuestarios a Distribución de Solicitud" ID="ProductosDistribucion" VerificarCifrado="True" />
            <div style="margin: 10px 0;">
                <hr />
                <asp:HyperLink NavigateUrl="~/ESTABLECIMIENTOS/FrmConsultarSolicitudes.aspx" runat="server" Text="« Volver a listado de solicitudes" ID="linkBack"/>
                <asp:LinkButton runat="server" ID="lbReporteCifrados" Text="Ver reporte de cifrados por producto"/>
                </div>
       
      
</asp:Content>

