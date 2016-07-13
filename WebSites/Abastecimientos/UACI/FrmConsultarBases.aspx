<%@ Page Language="VB" ValidateRequest="false" EnableEventValidation="true" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmConsultarBases.aspx.vb" Inherits="frmConsultarBases" %>

<%@ Register Src="~/Controles/ucGenerarBases.ascx" TagName="ucGenerarBases" TagPrefix="uc1" %>
<%@ Register Src="~/Controles/ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc2:ucVistaDetalleProcesoCompra ID="UcVistaDetalleProcesoCompra1" runat="server" />
</asp:Content>

