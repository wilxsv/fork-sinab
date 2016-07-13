<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmAsesoriasNecesidadesEstablecimientos.aspx.vb" Inherits="FrmAsesoriasNecesidadesEstablecimientos"
  MaintainScrollPositionOnPostback="True" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucAsesoriasNecesidadesEstablecimientos" Src="~/Controles/ucAsesoriasNecesidadesEstablecimientos.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;&nbsp;<asp:Label
          ID="LblRuta" runat="server" Text="UTMIM -> Asesoría de Necesidades a Establecimientos" /></td>
      &nbsp;<asp:Label ID="Label1" runat="server" Text="V.1.7" />
    </tr>
    <tr>
      <td>
        <uc1:ucAsesoriasNecesidadesEstablecimientos ID="UcAsesoriasNecesidadesEstablecimientos1"
          runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
