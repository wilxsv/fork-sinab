<%@ Page Language="VB" ValidateRequest="false" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
  MaintainScrollPositionOnPostback="true" CodeFile="frmDetAclaraciones.aspx.vb" Inherits="frmDetAclaraciones" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI » Adjudicación » Generar Aclaraciones
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <asp:Panel runat="server" ID="pNavegacion" >
          <div class="NavBar" style="text-align: left">
              <asp:LinkButton runat="server" ID="btGuardar" Text="Guardar" CssClass="opGuardar" Width="50px"/>
                  <asp:LinkButton runat="server" ID="btCancelar" Text="Cancelar" CssClass="opCancelar" Width="50px"/>
          </div>
          </asp:Panel>
  <table class="CenteredTable" style="width: 100%;">
    
     
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label1" runat="server" Text="Proceso No:" /></td>
      <td class="DataCell">
        <asp:Label ID="Label3" runat="server" Font-Bold="True" />
        <asp:TextBox ID="TxtACLARACION" runat="server" Enabled="False" Visible="False" /></td>
    </tr>
    <tr>
      <td class="LabelCell">
        <asp:Label ID="Label2" runat="server" Text="Número de Aclaración:" /></td>
      <td class="DataCell">
        <asp:TextBox ID="TxtNumeroAclaracion" runat="server" /></td>
    </tr>
    <tr>
      <td class="LabelCell" valign="top">
        <asp:Label ID="Label4" runat="server" Text="Detalle de Aclaración:" /></td>
      <td class="DataCell"><asp:TextBox ID="Texdetalle" runat="server" Width="200px" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
      </td>
    </tr>
    
  </table>
</asp:Content>
