<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucGenerarBases.ascx.vb"
  Inherits="Controles_ucGenerarBases" %>
<%@ Register TagPrefix="cc2" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE" %>
<%@ Register TagPrefix="uc1" Src="ucVistaDetalleProcesoCompra.ascx" TagName="ucVistaDetalleProcesoCompra" %>
<%@ Register TagPrefix="uc2" Src="~/Controles/ucsubirbase.ascx" TagName="ucsubirbase" %>
<%@ Register src="BaseLicitacion_9.ascx" tagname="BaseLicitacion_9" tagprefix="uc3" %>
<%@ Register src="BaseLicitacion_11.ascx" tagname="BaseLicitacion_11" tagprefix="uc4" %>
<%@ Register Src="~/Controles/BaseLicitacion_5.ascx" TagPrefix="uc1" TagName="BaseLicitacion_5" %>
<%@ Register Src="~/Controles/BaseLicitacion_6.ascx" TagPrefix="uc1" TagName="BaseLicitacion_6" %>


<div class="NavBar" style="text-align: right; margin-top: 8px">
      <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
      <asp:Label ID="Label44" runat="server"  Text="Pasos:" />
      <asp:LinkButton ID="paso1" ToolTip="Datos Generales" runat="server" Text="1" />
      <asp:LinkButton ID="paso2" ToolTip="Recepción Ofertas" runat="server" Text="2" />
      <asp:LinkButton ID="paso3" ToolTip="Apertura Ofertas" runat="server" Text="3" />
      <asp:LinkButton ID="paso4" ToolTip="Consultas y Aclaraciones" runat="server" Text="4" />
      <asp:LinkButton ID="paso5" ToolTip="Documentación Legal y Financiera" runat="server" Text="5" />
      <asp:LinkButton ID="paso6" ToolTip="Oferta Técnica" runat="server" Text="6" />
      <asp:LinkButton ID="paso7" ToolTip="Porcentaje de Evaluación" runat="server" Text="7" />
      <asp:LinkButton ID="paso8" ToolTip="Garantias" runat="server" Text="8" />
      <asp:LinkButton ID="paso9" ToolTip="Detalle de Productos" runat="server" Text="9" />
      <asp:LinkButton ID="paso10" ToolTip="Plazos de Entrega" runat="server" Text="10" />
      <asp:LinkButton ID="paso11" ToolTip="Generar Documentos" runat="server" Text="11" />
       
             <asp:LinkButton runat="server" ID="lnkGuardar" CssClass="opGuardar" Text="Guardar"/>
    
            </div>

      <asp:Panel ID="pnlPaso1" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="lblPaso1l" runat="server" Text="Datos generales" /></td>
            <td class="PasoRight">
              <asp:Label ID="lblPaso1r" runat="server" Text="paso 1" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Text="Código de la Licitación:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtCODIGOLICITACION" runat="server" MaxLength="20" AutoPostBack="True" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCODIGOLICITACION"
                ErrorMessage="Requerido" />
              <asp:Label ID="lblPrefijoBase" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Text="Nombre de la licitación:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtTITULOLICITACION" runat="server" Width="325px" MaxLength="200" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTITULOLICITACION"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="Nombre de la entidad que solicita la licitación:" /></td>
            <td class="DataCell">
              <cc2:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" AutoPostBack="True"
                Enabled="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label5" runat="server" Text="Descripción de la licitación:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDESCRIPCIONLICITACION" runat="server" MaxLength="500" Rows="7"
                TextMode="MultiLine" CssClass="TextBoxMultiLine" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label6" runat="server" Text="Nombre del titular:" /></td>
            <td class="DataCell">
              <cc2:ddlEMPLEADOS ID="ddlIDTITULAR" runat="server" AutoPostBack="True" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label7" runat="server" Text="Cargo del titular:" /></td>
            <td class="DataCell">
              <asp:Label ID="lblCargoTitular" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell" style="height: 21px">
              <asp:Label ID="Label10" runat="server" Text="Dirección:" /></td>
            <td class="DataCell" style="height: 21px">
              <asp:Label ID="lblDireccionUACI" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label11" runat="server" Text="Municipio:" /></td>
            <td class="DataCell">
              <asp:Label ID="lblMunicipio" runat="server" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right;">
              <asp:LinkButton ID="lbSiguiente1" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>
  
      <asp:Panel ID="pnlPaso2" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="lblPaso2l" runat="server" Text="Recepción de ofertas" /></td>
            <td class="PasoRight">
              <asp:Label ID="lblPaso2r" runat="server" Text="paso 2" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label12" runat="server" Text="Lugar:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLUGARRECEPCIONOFERTA" runat="server" Width="278px" MaxLength="100" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLUGARRECEPCIONOFERTA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label13" runat="server" Text="Dirección:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDIRECCIONRECEPCIONOFERTA" runat="server" Width="320px" MaxLength="200" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDIRECCIONRECEPCIONOFERTA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label14" runat="server" Text="Municipio:" /></td>
            <td class="DataCell">
              <cc2:ddlMUNICIPIOS ID="DdlMUNICIPIOS1" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label15" runat="server" Text="Fecha de inicio recepcion:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtFECHAINICIORECEPCION" CssClass="datefield"/>
              <%--<ew:CalendarPopup ID="txtFECHAINICIORECEPCION" runat="server" Culture="Spanish (El Salvador)" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFECHAINICIORECEPCION"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label18" runat="server" Text="Hora inicio recepción:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtHORAINICIORECEPCION" CssClass="timefield"/>
             <%-- <ew:TimePicker ID="txtHORAINICIORECEPCION" runat="server" MinuteInterval="FiveMinutes"
                NumberOfColumns="3" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtHORAINICIORECEPCION"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label19" runat="server" Text="Fecha fin recepción:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtFECHAFINRECEPCION" CssClass="datefield"/>
              <%--<ew:CalendarPopup ID="txtFECHAFINRECEPCION" runat="server" Culture="Spanish (El Salvador)" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFECHAFINRECEPCION"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label26" runat="server" Text="Hora fin recepción:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtHORAFINRECEPCION" CssClass="timefield"/>
              <%--<ew:TimePicker ID="txtHORAFINRECEPCION" runat="server" MinuteInterval="FiveMinutes"
                NumberOfColumns="3" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtHORAFINRECEPCION"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton1" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>
  
      <asp:Panel ID="pnlPaso3" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="Label68" runat="server" Text="Apertura de ofertas" /></td>
            <td class="PasoRight">
              <asp:Label ID="Label69" runat="server" Text="paso 3" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label20" runat="server" Text="Lugar:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLUGARAPERTURABASE" runat="server" Width="285px" MaxLength="100" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtLUGARAPERTURABASE"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label21" runat="server" Text="Dirección:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDIRECCIONAPERTURABASE" runat="server" Width="285px" MaxLength="200" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDIRECCIONAPERTURABASE"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label22" runat="server" Text="Municipio:" /></td>
            <td class="DataCell">
              <cc2:ddlMUNICIPIOS ID="DdlMUNICIPIOS2" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label23" runat="server" Text="Fecha de inicio de apertura:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtFECHAINICIOAPERTURA" runat="server" CssClass="datefield" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFECHAINICIOAPERTURA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label24" runat="server" Text="Hora de inicio de apertura:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtHORAINICIOAPERTURA" runat="server" CssClass="timefield"/>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtHORAINICIOAPERTURA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>||
            <td class="LabelCell">
              <asp:Label ID="Label17" runat="server" Text="Fecha de fin de apertura:" /></td>
            <td class="DataCell">
              <%--<ew:CalendarPopup ID="txtFECHAFINAPERTURA" runat="server" Culture="Spanish (El Salvador)" />--%>
                <asp:TextBox runat="server" ID="txtFECHAFINAPERTURA" CssClass="datefield"/>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtFECHAFINAPERTURA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label43" runat="server" Text="Hora de fin de apertura:" Visible="False" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtHORAFINAPERTURA" CssClass="timefield"/>
              <%--<ew:TimePicker ID="txtHORAFINAPERTURA" runat="server" MinuteInterval="FiveMinutes"
                NumberOfColumns="3" Visible="False" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtHORAFINAPERTURA"
                ErrorMessage="Requerido" Visible="False" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton9" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton2" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>
 
      <asp:Panel ID="pnlPaso4" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="Label70" runat="server" Text="Consultas y aclaraciones" /></td>
            <td class="PasoRight">
              <asp:Label ID="Label71" runat="server" Text="paso 4" /></td>
          </tr>
          <tr>
            <td class="DataCell">
              <asp:Label ID="Label25" runat="server" Text="Fecha de inicio:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtFechaInicioConsultasAclaraciones" CssClass="datefield" />
              <%--<ew:CalendarPopup ID="txtFechaInicioConsultasAclaraciones" runat="server" Culture="Spanish (El Salvador)" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFechaInicioConsultasAclaraciones"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td class="DataCell">
              <asp:Label ID="Label27" runat="server" Text="Fecha fin:" /></td>
            <td class="DataCell">
                <asp:TextBox runat="server" ID="txtFechaFinConsultasAclaraciones" CssClass="datefield"/>
              <%--<ew:CalendarPopup ID="txtFechaFinConsultasAclaraciones" runat="server" Culture="Spanish (El Salvador)" />--%>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFechaFinConsultasAclaraciones"
                ErrorMessage="Requerido" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton10" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton3" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>
  
      <asp:Panel ID="pnlPaso5" runat="server" Visible="False" Width="100%">
          <uc1:BaseLicitacion_5 runat="server" id="cbl5" />
        <div style="text-align: right; margin:20px  0">
              <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton4" runat="server" Text="Siguiente" /></div>
      </asp:Panel>
 
      <asp:Panel ID="pnlPaso6" runat="server" Visible="False" Width="100%">
          <uc1:BaseLicitacion_6 runat="server" ID="cbl6" Title="paso 6 - Oferta técnica" />
          <div style="text-align: right; margin:20px  0" >
         <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton5" runat="server" Text="Siguiente" /></div>
      </asp:Panel>
 
      <asp:Panel ID="pnlPaso7" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="Label76" runat="server" Text="Porcentajes de evaluación" /></td>
            <td class="PasoRight">
              <asp:Label ID="Label77" runat="server" Text="paso 7" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label33" runat="server" Font-Bold="True" Text="Aspecto  técnico: " /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label35" runat="server" Text="Incluya los criterios a evaluar para la oferta técnica" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:DataGrid ID="dgEvaluacionTecnica" runat="server" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="100%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <ItemStyle CssClass="GridListItem" />
                <SelectedItemStyle CssClass="GridListSelectedItem" />
                <EditItemStyle CssClass="GridListEditItem" />
                <AlternatingItemStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:CheckBox ID="chkCriterio" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.CHK") %>' />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:BoundColumn DataField="IDCRITERIOEVALUACION" HeaderText="IDCRITERIOEVALUACION"
                    Visible="False" />
                  <asp:BoundColumn DataField="DESCRIPCION" HeaderText="Criterio de evaluaci&#243;n">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje" Visible="False" />
                  <asp:TemplateColumn HeaderText="Porcentaje">
                    <ItemTemplate>
                      <ew:NumericBox ID="txtPorcentaje" runat="server" MaxLength="5" PositiveNumber="True"
                        Text='<%# DataBinder.Eval(Container, "DataItem.PORCENTAJE") %>' TextAlign="Right"
                        Width="115px" DecimalPlaces="2" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtPorcentaje"
                        Display="Dynamic" ErrorMessage="*" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn>
                    <ItemTemplate>
                      <asp:Button ID="btnCalcularTotal1" runat="server" Text="Calcular Total" OnClick="btnCalcularTotal_Click"
                        Visible="False" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                </Columns>
              </asp:DataGrid>
              <asp:Label ID="lblErrorSuma30" runat="server" ForeColor="Red" />
              </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:TextBox ID="txtOcultototal" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: left;">
              <asp:Label ID="Label36" runat="server" Font-Bold="True" Text="Aspecto  Financiero:" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label38" runat="server" Text="Porcentaje para el índice de solvencia:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtIndiceSolvencia" runat="server" PositiveNumber="True" TextAlign="Right"
                Width="115px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtIndiceSolvencia"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label39" runat="server" Text="Porcentaje para el capital de trabajo:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtPocentajeCapital" runat="server" PositiveNumber="True" TextAlign="Right"
                Width="115px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtPocentajeCapital"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label40" runat="server" Text="Porcentaje para el índice de endeudamiento:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtIndiceEndeudamiento" runat="server" PositiveNumber="True" TextAlign="Right"
                Width="115px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtIndiceEndeudamiento"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label41" runat="server" Text="Porcentaje para las referencias bancarias:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtReferenciaBancaria" runat="server" PositiveNumber="True" TextAlign="Right"
                Width="115px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtReferenciaBancaria"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label37" runat="server" Text="Porcentaje global de calificación" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGlobalFinanciero" runat="server" Enabled="False" PositiveNumber="True"
                TextAlign="Right" Width="115px" />
              <asp:Button ID="Button1" runat="server" Text="Calcular Total" />
              <asp:Label ID="lblErrorSuma70" runat="server" ForeColor="Red" /></td>
          </tr>
          <tr>
            <td colspan="2" align="right">
              <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtGlobalFinanciero"
                ErrorMessage="Requerido" />
              <asp:Label ID="lblsetenta" runat="server" Text="Los criterios  deben sumar 100%" /></td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right;">
              <asp:LinkButton ID="LinkButton13" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton6" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>

      <asp:Panel ID="pnlPaso8" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="Label80" runat="server" Text="Garantías" /></td>
            <td class="PasoRight">
              <asp:Label ID="Label81" runat="server" Text="paso 8" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label42" runat="server" Text="Garantía de mantenimiento de la oferta" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label45" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIAMNTTOVIGENCIA" runat="server" TextAlign="Right" PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGARANTIAMNTTOVIGENCIA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label46" runat="server" Text="Lugar de entrega:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLUGARMNTTO" runat="server" Width="386px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtLUGARMNTTO"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label47" runat="server" Text="Garantía de cumplimiento de contrato" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label48" runat="server" Text="Valor (Porcentaje):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVALOR" runat="server" TextAlign="Right"
                PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVALOR"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label49" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOENTREGA" runat="server" TextAlign="Right"
                PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOENTREGA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label50" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVIGENCIA" runat="server" TextAlign="Right"
                PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVIGENCIA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label51" runat="server" Text="Lugar de entrega:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLUGARCUMPLIMIENTO" runat="server" Width="386px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtLUGARCUMPLIMIENTO"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Label ID="Label53" runat="server" Text="Garantía de buena calidad" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label52" runat="server" Text="Valor (Porcentaje):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACALIDADVALOR" runat="server" TextAlign="Right" PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtGARANTIACALIDADVALOR"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label34" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACALIDADENTREGA" runat="server" TextAlign="Right" PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtGARANTIACALIDADENTREGA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label54" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACALIDADVIGENCIA" runat="server" TextAlign="Right" PositiveNumber="True">0</ew:NumericBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtGARANTIACALIDADVIGENCIA"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label55" runat="server" Text="Lugar de entrega:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLUGARCALIDAD" runat="server" Width="385px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtLUGARCALIDAD"
                ErrorMessage="Requerido" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Panel ID="Panel5" runat="server" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td colspan="2">
                      <asp:Label ID="Label60" runat="server" Text="Garantía de Anticipo" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label61" runat="server" Text="Valor (Porcentaje):" /></td>
                    <td class="DataCell">
                      <ew:NumericBox ID="txtGARANTIAANTICIPOVALOR" runat="server" PositiveNumber="True"
                        TextAlign="Right">0</ew:NumericBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtGARANTIAANTICIPOVALOR"
                        ErrorMessage="Requerido" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label62" runat="server" Text="Plazo de entrega (en días calendario):" /></td>
                    <td class="DataCell">
                      <ew:NumericBox ID="txtGARANTIAANTICIPOENTREGAS" runat="server" PositiveNumber="True"
                        TextAlign="Right">0</ew:NumericBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtGARANTIAANTICIPOENTREGAS"
                        ErrorMessage="Requerido" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label63" runat="server" Text="Plazo de vigencia (en días calendario):" /></td>
                    <td class="DataCell">
                      <ew:NumericBox ID="txtGARANTIAANTICIPOVIGENCIA" runat="server" PositiveNumber="True"
                        TextAlign="Right">0</ew:NumericBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtGARANTIAANTICIPOVIGENCIA"
                        ErrorMessage="Requerido" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label64" runat="server" Text="Lugar de entrega:" /></td>
                    <td class="DataCell">
                      <asp:TextBox ID="txtLUGARANTICIPO" runat="server" Width="363px" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtLUGARANTICIPO"
                        ErrorMessage="Requerido" /></td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right;">
              <asp:LinkButton ID="LinkButton14" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton7" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>

      <asp:Panel ID="pnlPaso9" runat="server" Visible="False" Width="100%">
           <uc3:BaseLicitacion_9 ID="cbl9" runat="server" />
         <div style="text-align: right">
              <asp:LinkButton ID="LinkButton15" runat="server" CausesValidation="False" Text="« Anterior" />
              <asp:LinkButton ID="LinkButton16" runat="server" Text="Siguiente »" />
             
          </div>
      </asp:Panel>

      <asp:Panel ID="pnlPaso10" runat="server" Visible="False" Width="100%">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="PasoLeft">
              <asp:Label ID="Label82" runat="server" Text="Plazos de entrega" /></td>
            <td class="PasoRight">
              <asp:Label ID="Label83" runat="server" Text="paso 10" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Panel ID="pnlE1" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td style="width: 1147px">
                      <asp:Label ID="Label8" runat="server" Text="Para una entrega" /></td>
                  </tr>
                  <tr>
                    <td style="width: 1147px">
                      <asp:DataGrid ID="dg1" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:BoundColumn DataField="DIAS" HeaderText="Plazo (d&#237;as)" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlE2" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:Label ID="Label9" runat="server" Text="Para dos entregas" /></td>
                  </tr>
                  <tr>
                    <td>
                      <asp:DataGrid ID="dg2" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:BoundColumn DataField="DIAS" HeaderText="Plazo (d&#237;as)" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlE3" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:Label ID="Label56" runat="server" Text="Para tres entregas" /></td>
                  </tr>
                  <tr>
                    <td>
                      <asp:DataGrid ID="dg3" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:BoundColumn DataField="Dias" HeaderText="Plazo (d&#237;as)" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundColumn DataField="Porcentaje" HeaderText="Porcentaje de entrega" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlE4" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:Label ID="Label58" runat="server" Text="Para cuatro entregas" /></td>
                  </tr>
                  <tr>
                    <td>
                      <asp:DataGrid ID="dg4" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:BoundColumn DataField="Dias" HeaderText="Plazo (d&#237;as)" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de Entrega" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlE5" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td>
                      <asp:Label ID="Label59" runat="server" Text="Para cinco entregas" /></td>
                  </tr>
                  <tr>
                    <td>
                      <asp:DataGrid ID="dg5" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#2461BF" />
                        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#EFF3FB" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <Columns>
                          <asp:BoundColumn DataField="DIAS" HeaderText="Plazo (d&#237;as)" ItemStyle-HorizontalAlign="Left" />
                          <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega" ItemStyle-HorizontalAlign="Right" />
                        </Columns>
                      </asp:DataGrid></td>
                  </tr>
                </table>
              </asp:Panel><table class="CenteredTable" style="width: 100%">
                  <tr>
                      <td>
                          <asp:Label ID="Label88" runat="server" Text="Para seis entregas" Visible="False" /></td>
                  </tr>
                  <tr>
                      <td>
                          <asp:DataGrid ID="dg6" runat="server" CellPadding="4" GridLines="None" AutoGenerateColumns="False"
                        Width="100%" Visible="False">
                              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                              <EditItemStyle BackColor="#2461BF" />
                              <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                              <AlternatingItemStyle BackColor="White" />
                              <ItemStyle BackColor="#EFF3FB" />
                              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                              <Columns>
                                  <asp:BoundColumn DataField="DIAS" HeaderText="Plazo (d&#237;as)" >
                                      <ItemStyle HorizontalAlign="Left" />
                                  </asp:BoundColumn>
                                  <asp:BoundColumn DataField="PORCENTAJE" HeaderText="Porcentaje de entrega" >
                                      <ItemStyle HorizontalAlign="Right" />
                                  </asp:BoundColumn>
                              </Columns>
                          </asp:DataGrid></td>
                  </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="2" style="text-align: right">
              <asp:LinkButton ID="LinkButton17" runat="server" CausesValidation="False" Text="Anterior" />
              <asp:LinkButton ID="LinkButton18" runat="server" Text="Siguiente" /></td>
          </tr>
        </table>
      </asp:Panel>

      <asp:Panel ID="pnlPlantilla" runat="server" Visible="False" Width="100%">
           <uc4:BaseLicitacion_11 ID="cbl11" runat="server" />
          <div style="margin: 10px 0; text-align: right">
             
         <asp:LinkButton ID="LinkButton19" runat="server" CausesValidation="False" Text="« Anterior" />
              </div>
      </asp:Panel>

<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
