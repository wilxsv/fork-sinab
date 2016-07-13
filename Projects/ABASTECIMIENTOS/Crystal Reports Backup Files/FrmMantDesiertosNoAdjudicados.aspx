<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmMantDesiertosNoAdjudicados.aspx.vb" Inherits="FrmMantDesiertosNoAdjudicados" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucDesiertosNoAdjudicados.ascx" TagName="ucDesiertosNoAdjudicados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Adjudicación -> Renglones Desiertos y No Adjudicados</td>
    </tr>
    <tr>
      <td>
        <uc2:ucDesiertosNoAdjudicados ID="UcDesiertosNoAdjudicados1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
