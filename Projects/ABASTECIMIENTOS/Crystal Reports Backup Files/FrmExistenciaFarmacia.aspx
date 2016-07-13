<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmExistenciaFarmacia.aspx.vb" Inherits="FrmExistenciaFarmacia" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%">
    <tr>
      <td style="text-align: left; width: 100%; background-color: #b5c7de">
        &nbsp;
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Reportes del m&oacutedulo -> Existencia farmacia" /></td>
    </tr>
    <tr>
      <td style="width: 100%; background-color: transparent; text-align: left; height: 36px;">
        <asp:ImageButton ID="ImgbSalir" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG"
          ToolTip="Salir de la pantalla actual" /></td>
    </tr>
  </table>
  &nbsp;
  <asp:Panel ID="PnlGeneral" runat="server" Width="100%" Font-Bold="True" GroupingText="Defina el criterio de selección">
    <table width="100%">
      <tr>
        <td align="right" style="width: 50%; height: 24px;">
          <asp:Label ID="Label6" runat="server" Font-Bold="False" Text="Farmacia:" /></td>
        <td align="left" style="width: 49%; height: 24px;">
          <cc1:ddlALMACENES ID="DdlALMACENES1" runat="server" Width="327px">
          </cc1:ddlALMACENES></td>
        <td align="right" style="width: 50%; height: 24px;">
        </td>
      </tr>
      <tr>
        <td align="right" style="width: 50%">
        </td>
        <td align="left" style="width: 49%">
        </td>
        <td align="right" style="width: 50%">
        </td>
      </tr>
    </table>
  </asp:Panel>
  <table width="100%">
    <tr>
      <td align="center" style="width: 100%">
        <asp:Button ID="BtnFiltrar" runat="server" Text="Generar reporte" Width="174px" ValidationGroup="V1"
          BackColor="LightSteelBlue" Font-Bold="True" ToolTip="Ejecuta la consulta de las existencias por producto según la definición del criterio de selección" />
      </td>
    </tr>
  </table>
</asp:Content>
