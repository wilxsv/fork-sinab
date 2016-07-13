<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantDespacharProductos.aspx.vb" Inherits="FrmMantDespacharProductos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucSeleccionDocumentoSalida" Src="~/Controles/ucSeleccionDocumentoSalida.ascx" %>
<asp:Content ID="menucontent" runat="server" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén » Despachar productos
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
    <uc1:ucSeleccionDocumentoSalida ID="ucSeleccionDocumentoSalida1" runat="server" />
</asp:Content>
