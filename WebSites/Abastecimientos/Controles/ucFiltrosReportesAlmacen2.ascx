<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFiltrosReportesAlmacen2.ascx.vb"
  Inherits="ucFiltrosReportesAlmacen2" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblBuscarPor" runat="server" Text="Buscar por:" Visible="False" />
    </td>
    <td class="DataCell">
      <asp:RadioButtonList ID="rblBuscarPor" runat="server" AutoPostBack="true" Visible="False">
        <asp:ListItem Text="Criterio" Value="1" Selected="True" />
      </asp:RadioButtonList>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plCriterio" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblEstablecimiento2" runat="server" Text="Establecimiento:" Visible="False" />
            </td>
            <td class="DataCell">
                <asp:DropDownList runat="server" ID="ddlESTABLECIMIENTOS2" AppendDataBoundItems="true" AutoPostBack="true" Visible="False"/>
                <asp:Literal runat="server" ID="ltEstablecimiento" Visible="False"/>
              <%--<cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS2" runat="server" AppendDataBoundItems="True"
                AutoPostBack="True" Visible="False" />--%>
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblAlmacen" runat="server" Text="Almacén:" Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Visible="False" Width="320px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblProveedor" runat="server" Text="Proveedor:" Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlPROVEEDORES ID="ddlPROVEEDORES1" runat="server" Visible="False" Width="320px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha desde:" Visible="False" />
            </td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFechaDesde" runat="server" DisableTextBoxEntry="False" Visible="False"
                Width="81px" />
              <asp:CheckBox ID="cbFechas" runat="server" Checked="True" Text="No filtrar fechas"
                Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha hasta:" Visible="False" />
            </td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFechaHasta" runat="server" DisableTextBoxEntry="False" Visible="False"
                Width="81px" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFechaHasta1" runat="server" ControlToCompare="cpFechaDesde"
                ControlToValidate="cpFechaHasta" Display="Dynamic" ErrorMessage="La fecha desde no debe ser anterior a la fecha desde."
                Operator="GreaterThanEqual" Type="Date" ValidationGroup="Consultar" Visible="False" />
              <asp:CompareValidator ID="cvFechaHasta2" runat="server" ControlToValidate="cpFechaHasta"
                Display="Dynamic" ErrorMessage="La fecha hasta no puede ser posterior a hoy." Operator="LessThanEqual"
                Type="Date" ValidationGroup="Consultar" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblPeriodo" runat="server" Text="Periodo:" Visible="False" />
            </td>
            <td class="DataCell">
              <asp:DropDownList ID="ddlMesPeriodo" runat="server" Visible="False" />
              <ew:NumericBox ID="nbAnioPeriodo" runat="server" MaxLength="4" Visible="False" PositiveNumber="True"
                RealNumber="False" TruncateLeadingZeros="True" />
              <asp:RequiredFieldValidator ID="rfvAnioPeriodo" runat="server" ControlToValidate="nbAnioPeriodo"
                ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Consultar" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblAnio" runat="server" Text="Año:" Visible="False" />
            </td>
            <td class="DataCell">
              <ew:NumericBox ID="nbAnio" runat="server" MaxLength="4" Visible="False" PositiveNumber="True"
                RealNumber="False" TruncateLeadingZeros="True" />
              <asp:RequiredFieldValidator ID="rfvAnio" runat="server" ControlToValidate="nbAnio"
                ErrorMessage="Requerido" Display="Dynamic" ValidationGroup="Consultar" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblGrupoFuenteFinanciamiento" runat="server" Text="Grupo fuente de financiamiento:"
                Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlGRUPOSFUENTEFINANCIAMIENTO ID="ddlGRUPOSFUENTEFINANCIAMIENTO1" runat="server"
                Visible="False" Width="320px" AutoPostBack="True" AppendDataBoundItems="True" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFuenteFinanciamiento" runat="server" Text="Fuente de financiamiento:"
                Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" Width="320px"
                Visible="False" AppendDataBoundItems="True" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFOSALUD" runat="server" Text="Tomar en cuenta FOSALUD:" Visible="False" />
            </td>
            <td class="DataCell">
              <asp:CheckBox ID="cbFOSALUD" runat="server" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblResponsableDistribucion" runat="server" Text="Responsable de distribución:"
                Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlRESPONSABLEDISTRIBUCION ID="ddlRESPONSABLEDISTRIBUCION1" runat="server" Width="320px"
                Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblEstadoDocumento" runat="server" Text="Estado:" Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlESTADOSMOVIMIENTOS ID="ddlESTADOSMOVIMIENTOS1" runat="server" Width="320px"
                Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblEstablecimiento" runat="server" Text="Establecimiento o dependencia destino:"
                Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="320px" Visible="False" />
              <asp:CheckBox ID="cbVerTodos" runat="server" AutoPostBack="true" Text="Ver todos"
                Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblTipoProducto" runat="server" Text="Tipo de producto:" Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" Width="320px" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblGrupo" runat="server" Text="Grupo:" Visible="False" />
            </td>
            <td class="DataCell">
              <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" Width="320px" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
                <asp:Label ID="Label2" runat="server" Text="Programa:" Visible="False"></asp:Label>
            </td>
            <td class="DataCell">
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td class="LabelCell" rowspan="2">
                <asp:Label ID="lblProducto" runat="server" Text="Código de producto:" 
                    Visible="False" />
            </td>
              <td class="DataCell">
                  <asp:LinkButton ID="lbSeleccionar" runat="server" 
                      Text="Seleccionar de una lista..." Visible="False" />
              </td>
          </tr>
          <tr>
            <td class="DataCell">
                <asp:TextBox ID="txtProducto" runat="server" MaxLength="8" Visible="False" />
                <asp:RequiredFieldValidator ID="rfvProducto" runat="server" 
                    ControlToValidate="txtProducto" Display="Dynamic" ErrorMessage="Requerido" 
                    ValidationGroup="Consultar" Visible="False" />
                <cc1:ddlLOTES ID="ddlLOTES1" runat="server" Visible="False" Width="320px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblAlmacenOrigen" runat="server" Text="Almacén origen:" 
                    Visible="False" />
            </td>
            <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES2" runat="server" Visible="False" 
                    Width="320px" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblEstado" runat="server" Text="Estado:" Visible="False" /></td>
            <td class="DataCell">
                <asp:DropDownList ID="ddlEstado" runat="server" Visible="False">
                    <asp:ListItem Selected="True" Text="Próximo a vencer" Value="2" />
                    <asp:ListItem Text="Vencido a la fecha" Value="3" />
                    <asp:ListItem Text="Agotado a la fecha" Value="4" />
                    <asp:ListItem Text="No disponible" Value="5" />
                </asp:DropDownList>
              </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Text="Por Transferencias:" 
                    Visible="False" />
            </td>
            <td class="DataCell">
                <asp:CheckBox ID="CheckBox1" runat="server" Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
                <asp:Label ID="lblEspecificoGasto" runat="server" Text="Específico de gasto:" 
                    Visible="False" />
            </td>
              <td class="DataCell">
                  <cc1:ddlESPECIFICOSGASTO ID="ddlESPECIFICOSGASTO1" runat="server" 
                      Visible="False" Width="320px" />
              </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
            <tr>
                <td class="LabelCell">
                    <asp:Label ID="lblAgruparPor" runat="server" Text="Agrupar por:" 
                        Visible="False" />
                </td>
                <td class="DataCell">
                    <asp:DropDownList ID="ddlAgruparPor" runat="server" Visible="False" />
                </td>
            </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plDocumento" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDocumento" runat="server" Visible="False" />
            </td>
            <td class="DataCell">
              <ew:NumericBox ID="nbDocumento" runat="server" MaxLength="14" Visible="False" PositiveNumber="True"
                RealNumber="False" />
              <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ControlToValidate="nbDocumento"
                Display="Dynamic" ErrorMessage="Requerido" ValidationGroup="Consultar" Visible="False" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnConsultar" runat="server" Text="Consultar" ValidationGroup="Consultar" />
    </td>
  </tr>
</table>
