<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmUFIConsultarPEP.aspx.vb" Inherits="FrmUFIConsultarPEP" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucFiltroReporteEstablecimientos.ascx" TagName="ucFiltroReporteEstablecimientos"
  TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table style="width: 100%; height: 100%">
    <tr>
      <td align="left" bgcolor="#b5c7de">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        &nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UFI -> Consultar PEP" /></td>
    </tr>
    <tr>
      <td align="center">
        &nbsp;<br />
        <asp:Label ID="Label2" runat="server" CssClass="Titulo" Text="CONSULTA PROGRAMA DE EJECUCI&OacuteN PRESUPUESTARIA" />
        <br />
      </td>
    </tr>
    <tr>
      <td align="center">
        <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Width="41px" Enabled="False"
          Visible="False" />
        <asp:Label ID="LblReporte" runat="server" Visible="False" />
      </td>
    </tr>
    <tr>
      <td align="center">
        <table width="100%">
          <tr>
            <td align="center" bgcolor="#b5c7de">
              <asp:Label ID="Label4" runat="server" Text="Elementos a considerar al  generar la consulta:" /></td>
          </tr>
          <tr>
            <td align="left">
              <uc1:ucFiltroReporteEstablecimientos ID="UcFiltroReporteEstablecimientos1" runat="server" />
            </td>
          </tr>
        </table>
        <asp:Button ID="BttGenerar" runat="server" Text="Generar Consulta" />
        <nds:MsgBox ID="MsgBox1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
