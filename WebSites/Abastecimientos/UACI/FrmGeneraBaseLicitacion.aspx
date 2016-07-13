<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FrmGeneraBaseLicitacion.aspx.vb" Inherits="FrmGeneraBaseLicitacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/ucGenerarBases.ascx" TagName="ucGenerarBases" TagPrefix="uc1" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cpmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />&nbsp;<asp:Label
                    ID="lblRuta" runat="server" Text="UACI » Adjudicación » Generar Bases" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    
        <h3>
                <asp:Label ID="Label57" runat="server" Text="Generación de Bases" /></h3>
        
                <asp:Label ID="lblPlantilla" runat="server" Text="Seleccione la plantilla con la que desea trabajar" />
        
                <asp:Button ID="btnPlantillas" runat="server" CausesValidation="False" Text="Ver Plantillas" />
    <br />
              <asp:Label ID="lblModalidadCompra" runat="server" />
        
                <uc1:ucGenerarBases ID="UcGenerarBases1" runat="server" />
        
</asp:Content>
