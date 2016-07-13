<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="frmDetAdendas.aspx.vb" Inherits="frmDetAdendas" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="uc1" Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Adjudicación -> Generar Adendas</td>
    </tr>
    <tr>
      <td colspan="2">
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Modificar la Base" Visible="False" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label1" runat="server" Text="Proceso No:" /></td>
      <td class="DataCell">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" />
        <asp:TextBox ID="TxtADENDA" runat="server" Enabled="False" Visible="False" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="Número de Adenda:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtNumeroAdenda" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label4" runat="server" Text="Detalle de Adenda:" /></td>
      <td>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:TextBox ID="Texdetalle" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
