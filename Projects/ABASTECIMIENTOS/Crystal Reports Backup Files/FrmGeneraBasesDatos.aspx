<%@ Page Language="VB" MaintainScrollPositionOnPostBack="true" ValidateRequest="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmGeneraBasesDatos.aspx.vb" Inherits="frmGeneraBasesDatos" %>

<%@ Register Src="~/Controles/ucGenerarBasesDatos.ascx" TagName="ucGenerarBasesDatos"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <uc1:ucGenerarBasesDatos ID="UcGenerarBasesDatos1" runat="server" />
</asp:Content>

