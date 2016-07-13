<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmModificacionFechasLG.aspx.vb" Inherits="UACI_FrmModificacionFechasLG" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Men�" CausesValidation="False" />
        UACI Libre Gesti�n-> Modificaci�n de fechas</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha de publicaci�n:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup4" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha l�mite de retiro de solicitudes de cotizaci�n:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup1" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha l�mite para recepci�n de solicitudes de cotizaci�n:</td>
      <td class="DataCell">
        <ew:CalendarPopup ID="CalendarPopup2" runat="server" />
      </td>
    </tr>
    <tr>
      <td class="LabelCell">
        Fecha l�mite para apertura de ofertas:</td>
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
