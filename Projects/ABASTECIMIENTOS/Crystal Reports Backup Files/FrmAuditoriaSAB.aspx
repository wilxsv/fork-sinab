<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmAuditoriaSAB.aspx.vb" Inherits="FrmAuditoriaSAB" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Seguridad -> Reportes de auditoría</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel1" runat="server" GroupingText="Usuarios" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label1" runat="server" Text="Empleado:" /></td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList1" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Fecha:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarPopup1" runat="server" />
                <asp:Label ID="Label3" runat="server" Text="hasta" />
                <ew:CalendarPopup ID="CalendarPopup2" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="CalendarPopup1"
                  ControlToValidate="CalendarPopup2" ErrorMessage="La fecha final no puede ser menor a la fecha de inicio de la búsqueda"
                  Operator="GreaterThanEqual" Type="Date" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Ver reporte" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Panel ID="Panel2" runat="server" GroupingText="Movimientos" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label4" runat="server" Text="Movimiento:" />
              </td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList4" runat="server">
                  <asp:ListItem Value="0">(Todos)</asp:ListItem>
                  <asp:ListItem Value="1">Actualizaci&#243;n</asp:ListItem>
                  <asp:ListItem Value="2">Inserci&#243;n</asp:ListItem>
                  <asp:ListItem Value="3">Eliminaci&#243;n</asp:ListItem>
                </asp:DropDownList></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label5" runat="server" Text="Tabla:" />
              </td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList8" runat="server" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Fecha:" />
              </td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarPopup3" runat="server" />
                <asp:Label ID="Label7" runat="server" Text="hasta" />
                <ew:CalendarPopup ID="CalendarPopup4" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="CalendarPopup3"
                  ControlToValidate="CalendarPopup4" ErrorMessage="La fecha final no puede ser menor a la fecha de inicio de la búsqueda"
                  Operator="GreaterThanEqual" Type="Date" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label8" runat="server" Text="Empleado:" />
              </td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList5" runat="server" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Button ID="Button2" runat="server" Text="Ver reporte" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>
