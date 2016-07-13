<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="CargarSolicitudes.aspx.vb" Inherits="CargarSolicitudes" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UACI -> Cargar Solicitudes de URMIM</td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
    <tr>
      <td align="left">
        </td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="pnNuevo" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Panel ID="Panel8" runat="server">
                  <table class="CenteredTable">
                    <tr>
                      <td colspan="2" style="font-weight: bold; color: #ffffff; background-color: #000099">
                        Datos Generales</td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                      </td>
                      <td class="DataCell">
                        &nbsp;</td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Dependencia:</td>
                      <td class="DataCell">
                          </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Clase de Suministro:</td>
                      <td class="DataCell">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:Label ID="Label3" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Asignar No.Solicitud" Width="137px" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="height: 17px">
                        No.Solicitud:</td>
                      <td class="DataCell" style="height: 17px">
                        <asp:Label ID="Label16" runat="server" Font-Bold="True"></asp:Label></td>
                    </tr>
                    <tr>
                      <td class="LabelCell" style="height: 49px">
                        Fecha de la Solicitud:</td>
                      <td class="DataCell" style="height: 49px">
                        <ew:CalendarPopup ID="CalendarPopup2" runat="server">
                        </ew:CalendarPopup>
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Compra conjunta:</td>
                      <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                  <asp:ListItem Value="0">NO</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Monto Solicitado:</td>
                      <td class="DataCell">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label17" runat="server" Text="Período de utilización(meses):"></asp:Label></td>
                      <td class="DataCell">
                        <ew:NumericBox ID="NumericBox1" runat="server" MaxLength="2" PositiveNumber="True"
                          RealNumber="False" Width="53px"></ew:NumericBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Nombre del empleado Solicitante:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Cargo del Solicitante:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Nombre del empleado del área técnica:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label18" runat="server" Text="Observación:"></asp:Label></td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBoxMultiLine" Height="31px"
                          TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        plazo</td>
                      <td class="DataCell">
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBoxMultiLine" Height="31px"
                          TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button3" runat="server" Text="Crear Solicitud" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;<asp:Button ID="Button4" runat="server" Text="Ver Solicitud" />
                <asp:Button ID="Button2" runat="server" Text="Ver Distribución" Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
                &nbsp;</td>
            </tr>
          </table>
        </asp:Panel>
                </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
