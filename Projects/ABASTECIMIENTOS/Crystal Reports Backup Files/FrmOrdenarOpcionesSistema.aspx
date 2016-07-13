<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="True" CodeFile="FrmOrdenarOpcionesSistema.aspx.vb"
  Inherits="FrmOrdenarOpcionesSistema" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Orden de Opciones del Menú</td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" BorderColor="#E0E0E0" CssClass="ScrollPanel"
          Height="400px" HorizontalAlign="Left" Width="95%">
          <asp:TreeView ID="TreeView1" runat="server" EnableTheming="True">
            <SelectedNodeStyle CssClass="SelectedNodeStyle" />
          </asp:TreeView>
        </asp:Panel>
      </td>
      <td style="width: 10%;">
        <asp:Button ID="btnSubir" runat="server" Text="Subir" />
        <asp:Button ID="btnBajar" runat="server" Text="Bajar" /></td>
    </tr>
  </table>
</asp:Content>
