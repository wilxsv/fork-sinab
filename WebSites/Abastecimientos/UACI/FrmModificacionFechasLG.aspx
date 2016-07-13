<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmModificacionFechasLG.aspx.vb" Inherits="UACI_FrmModificacionFechasLG" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI Libre Gestión-> Modificación de fechas</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha de publicación:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup4" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha límite de retiro de solicitudes de cotización:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha límite para recepción de solicitudes de cotización:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup2" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha límite para apertura de ofertas:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup3" runat="server" />
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Actualizar" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
