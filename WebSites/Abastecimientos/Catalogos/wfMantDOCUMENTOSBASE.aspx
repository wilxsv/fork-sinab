<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfMantDOCUMENTOSBASE.aspx.vb"
  Inherits="wfMantDOCUMENTOSBASE" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucMantdOCUMENTOSBASE" Src="~/catalogos/controles/ucMantdOCUMENTOSBASE.ascx" %>

<asp:Content runat="server" ID="ContentMenu" ContentPlaceHolderID="MenuContent">
    ;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos � Documentos base
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
 
        <uc1:ucMantdOCUMENTOSBASE ID="ucMantdOCUMENTOSBASE1" runat="server" />
 
</asp:Content>
