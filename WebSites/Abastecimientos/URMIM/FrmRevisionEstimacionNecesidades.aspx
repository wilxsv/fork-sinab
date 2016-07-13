<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmRevisionEstimacionNecesidades.aspx.vb" Inherits="FrmRevisionEstimacionNecesidades" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucConsultarEstimacionNecesidades.ascx" TagName="ucConsultarEstimacionNecesidades"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td style="text-align: left; width: 5%; background-color: #b5c7de">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="UTMIM -> Revisión de estimación de necesidades" />&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="V. 0.04" /></td>
    </tr>
    <tr>
      <td style="width: 100%; text-align: center">
        <uc1:ucConsultarEstimacionNecesidades ID="UcConsultarEstimacionNecesidades1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
