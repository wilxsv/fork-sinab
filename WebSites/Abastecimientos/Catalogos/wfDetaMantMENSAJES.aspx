<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="wfDetaMantMENSAJES.aspx.vb" Inherits="wfDetaMantMENSAJES" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ucVistaDetalleMENSAJES" Src="~/Catalogos/Controles/ucVistaDetalleMENSAJES.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        Cat�logos -> Mensajes</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucVistaDetalleMENSAJES ID="ucVistaDetalleMENSAJES1" runat="server" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
