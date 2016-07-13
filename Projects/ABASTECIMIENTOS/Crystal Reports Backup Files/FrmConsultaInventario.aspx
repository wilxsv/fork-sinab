<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmConsultaInventario.aspx.vb" Inherits="FrmConsultaInventario" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />
        URMIM -> Consultas a Inventario</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel2" runat="server" Visible="False" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2">
                <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="PARAMETROS" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label20" runat="server" Text="Consulta:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblconsulta" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label6" runat="server" Text="Período:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblperiodo" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label13" runat="server" Text="Producto:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblProducto" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblNom" runat="server" Text="Filtro geográfico:" /></td>
              <td class="DataCell">
                <asp:Label ID="lblsuministro" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel5" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2" style="text-align: left;">
                <asp:Label ID="Label17" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Text="Reporte" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal"
                  AutoPostBack="True">
                  <asp:ListItem Value="0" Selected="True" Text="Demanda Insatisfecha" />
                  <asp:ListItem Value="1" Text="Compras en tr&#225;nsito" />
                  <asp:ListItem Value="2" Text="Existencias" />
                  <asp:ListItem Value="3" Text="Consumos" />
                  <asp:ListItem Value="4" Text="Cr&#237;ticos" />
                  <asp:ListItem Value="5" Text="Sobre existencias" />
                  <asp:ListItem Value="6" Text="Pr&#243;ximos a vencerse" />
                </asp:RadioButtonList></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2" style="text-align: left; height: 9px;">
                <asp:Label ID="Label5" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Text="Período a consultar" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblDesde" runat="server" Text="Del:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpDesde" runat="server" DisableTextBoxEntry="False" Width="81px" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="lblHasta" runat="server" Text="Al:" /></td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpHasta" DisableTextBoxEntry="False" runat="server" Width="81px" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvHasta1" runat="server" ControlToCompare="cpDesde" ControlToValidate="cpHasta"
                  Display="Dynamic" ErrorMessage="La fecha desde no debe ser anterior a la fecha desde."
                  Operator="GreaterThanEqual" Type="Date" ValidationGroup="Consultar" />
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:CompareValidator ID="cvHasta2" runat="server" ErrorMessage="La fecha hasta no puede ser posterior a hoy."
                  ControlToValidate="cpHasta" Type="Date" Display="Dynamic" Operator="LessThanEqual"
                  ValidationGroup="Consultar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel3" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2" style="text-align: left;">
                <asp:Label ID="Label7" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Text="Tipo de producto o Insumo que desea consultar" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="RadioButtonListLeftAligned"
                  AutoPostBack="True">
                  <asp:ListItem Selected="True" Value="0" Text="Por suministro" />
                  <asp:ListItem Value="1" Text="Por Grupo" />
                  <asp:ListItem Value="2" Text="Por Subgrupo" />
                  <asp:ListItem Value="3" Text="Por Producto" />
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label9" runat="server" Text="Suministro:" /></td>
              <td class="DataCell">
                <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" Width="298px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label10" runat="server" Text="Grupo:" /></td>
              <td class="DataCell">
                <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" Width="472px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label11" runat="server" Text="Subgrupo:" /></td>
              <td class="DataCell">
                <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="True" Width="474px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label12" runat="server" Text="Producto:" /></td>
              <td class="DataCell">
                <cc1:ddlCATALOGOPRODUCTOS ID="ddlCATALOGOPRODUCTOS1" runat="server" Width="474px" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel4" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2" style="text-align: left;">
                <asp:Label ID="Label14" runat="server" BackColor="Black" Font-Bold="True" ForeColor="White"
                  Text="Filtro Geográfico" /></td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="RadioButtonListLeftAligned"
                  AutoPostBack="True">
                  <asp:ListItem Selected="True" Value="0" Text="Consolidado" />
                  <asp:ListItem Value="1" Text="Por Region" />
                  <asp:ListItem Value="2" Text="Por Establecimiento" />
                </asp:RadioButtonList></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label15" runat="server" Text="Región:" /></td>
              <td class="DataCell">
                <cc1:ddlZONAS ID="ddlZONAS1" runat="server" AutoPostBack="True" TabIndex="1" Width="174px" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                <asp:Label ID="Label16" runat="server" Text="Establecimiento:" /></td>
              <td class="DataCell">
                <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" TabIndex="2" Width="436px" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Button ID="Button1" runat="server" Text="Ver reporte" /></td>
    </tr>
  </table>
</asp:Content>
