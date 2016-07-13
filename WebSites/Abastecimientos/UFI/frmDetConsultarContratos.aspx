<%@ Page Language="VB" MaintainScrollPositionOnPostback="true" MasterPageFile="~/MasterPage.master"
  AutoEventWireup="false" CodeFile="frmDetConsultarContratos.aspx.vb" Inherits="frmDetConsultarContratos" %>

<%@ Register Src="~/Controles/ucDetConsultaContrato.ascx" TagName="ucDetConsultaContrato"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td style="width: 100px">
        <uc1:ucDetConsultaContrato ID="UcDetConsultaContrato1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
