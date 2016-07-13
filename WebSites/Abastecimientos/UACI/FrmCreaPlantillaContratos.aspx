<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmCreaPlantillaContratos.aspx.vb" Inherits="FrmCreaPlantillaContratos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucCreaPlantillaContrato" Src="~/Controles/ucCreaPlantillaContrato.ascx" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    <asp:Label ID="Label1" runat="server" Text="Catálogos » Plantillas para contratos" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
      <uc1:ucCreaPlantillaContrato ID="UcCreaPlantillaContrato1" runat="server" />
</asp:Content>
