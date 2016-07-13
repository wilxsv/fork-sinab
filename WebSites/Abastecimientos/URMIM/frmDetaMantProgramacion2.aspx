<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantProgramacion2.aspx.vb" Inherits="URMIM_frmDetaMantProgramacion2" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register assembly="ABASTECIMIENTOS_WUC" namespace="ABASTECIMIENTOS.WUC" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        URMIM -> Programación de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDescripcion" runat="server" Text="Descripción:" />
            </td>
            <td class="DataCell">
              <asp:TextBox ID="txtDescripcion" runat="server" MaxLength="300" Width="216px" />
              <asp:RequiredFieldValidator ID="rfvDESCRIPCION" runat="server" ControlToValidate="txtDescripcion"
                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Text="Mes/Año de preparación:" />
            </td>
            <td class="DataCell">
              <asp:TextBox ID="txtFechaPrep" Enabled="false" runat="server" Width="216px"></asp:TextBox></td>
          </tr>
            <tr>
                                        <td class="LabelCell" __designer:mapid="21">
                                            Selección de productos:</td>
                                        <td class="DataCell" __designer:mapid="22">
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Enabled="False">
                                                <asp:ListItem Value="1">Por Tipo de Suministro</asp:ListItem>
                                                <asp:ListItem Value="2" Selected="True">Por Programa</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
          <tr>
            <td class="LabelCell">
                                            <asp:Label runat="server"  ID="Label5" Text="Programa:" />
            </td>
            <td class="DataCell">
                                            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="Tipo de Suministro:" Visible="False" />
            </td>
            <td class="DataCell">
              <asp:DropDownList ID="cboTipoSuministro" runat="server" AppendDataBoundItems="True" OnSelectedIndexChanged="cboTipoSuministro_SelectedIndexChanged" Width="224px" AutoPostBack="True" Visible="False">
              </asp:DropDownList> 
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
                                            <asp:Label runat="server" ID="Label41" Text="Grupos de Medicamentos:" AssociatedControlID="ddlGRUPOS1" Visible="False" />
            </td>
            <td class="DataCell">
                                            <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblPERIODO" runat="server" Text="Mes/Año de corte (consumos y existencias):" />
            </td>
            <td class="DataCell">
              <asp:DropDownList ID="cboMES" runat="server">
                <asp:ListItem>[Seleccione un mes]</asp:ListItem>
                <asp:ListItem>Enero</asp:ListItem>
                <asp:ListItem>Febrero</asp:ListItem>
                <asp:ListItem>Marzo</asp:ListItem>
                <asp:ListItem>Abril</asp:ListItem>
                <asp:ListItem>Mayo</asp:ListItem>
                <asp:ListItem>Junio</asp:ListItem>
                <asp:ListItem>Julio</asp:ListItem>
                <asp:ListItem>Agosto</asp:ListItem>
                <asp:ListItem>Septiembre</asp:ListItem>
                <asp:ListItem>Octubre</asp:ListItem>
                <asp:ListItem>Noviembre</asp:ListItem>
                <asp:ListItem>Diciembre</asp:ListItem>
              </asp:DropDownList>
              /
              <asp:DropDownList ID="cboAnio" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label2" runat="server" Text="Mes/Año de finalización del último programa:" />
            </td>
            <td class="DataCell">
              <asp:DropDownList ID="cboMesProy" runat="server">
                <asp:ListItem>[Seleccione un mes]</asp:ListItem>
                <asp:ListItem>Enero</asp:ListItem>
                <asp:ListItem>Febrero</asp:ListItem>
                <asp:ListItem>Marzo</asp:ListItem>
                <asp:ListItem>Abril</asp:ListItem>
                <asp:ListItem>Mayo</asp:ListItem>
                <asp:ListItem>Junio</asp:ListItem>
                <asp:ListItem>Julio</asp:ListItem>
                <asp:ListItem>Agosto</asp:ListItem>
                <asp:ListItem>Septiembre</asp:ListItem>
                <asp:ListItem>Octubre</asp:ListItem>
                <asp:ListItem>Noviembre</asp:ListItem>
                <asp:ListItem>Diciembre</asp:ListItem>
              </asp:DropDownList>
              /
              <asp:DropDownList ID="cboAnioProy" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCPM" runat="server" Text="Meses para el cálculo del CPM:" />
            </td>
            <td class="DataCell">
              <ew:NumericBox ID="txtCPM" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2"
                PositiveNumber="True"></ew:NumericBox>
              <asp:RequiredFieldValidator ID="rfvCPM" runat="server" ControlToValidate="txtCPM"
                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Text="Horizonte de planeación (meses):" />
            </td>
            <td class="DataCell">
              <ew:NumericBox ID="txtCOBER" runat="server" Columns="5" DecimalPlaces="0" MaxLength="2"
                PositiveNumber="True"></ew:NumericBox>
              <asp:RequiredFieldValidator ID="rfvCOBER" runat="server" ControlToValidate="txtCOBER"
                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblInflacion" runat="server" Text="Indice inflacionario (%):" />
            </td>
            <td class="DataCell">
              <ew:NumericBox ID="txtIndice" runat="server" Columns="5" DecimalPlaces="2" MaxLength="5"></ew:NumericBox>
              <asp:RequiredFieldValidator ID="rfvIndice" runat="server" ControlToValidate="txtIndice"
                ErrorMessage="* Campo requerido"></asp:RequiredFieldValidator></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
