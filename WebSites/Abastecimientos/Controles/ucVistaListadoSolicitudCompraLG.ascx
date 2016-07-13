<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaListadoSolicitudCompraLG.ascx.vb"
  Inherits="Controles_ucVistaListadoSolicitudCompraLG" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucListaTipoCompra" Src="~/Controles/ucListaTipoCompra.ascx" %>
<%@ Register TagPrefix="uc3" TagName="ucListaEmpleado" Src="~/Controles/ucListaEmpleado.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td>
      <asp:Label ID="Label1" runat="server" Text="Seleccione las solicitudes del siguiente listado" /></td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="pnlSeleccion" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td>
              <asp:Label ID="Label8" runat="server" Text="Estado de la solicitud:" Visible="False" />
              <cc1:ddlESTADOS ID="DdlESTADOS1" runat="server" Visible="False">
                <asp:ListItem Value="2" Selected="True">Enviada UACI</asp:ListItem>
                <asp:ListItem Value="5">Enviada UFI</asp:ListItem>
                <asp:ListItem Value="6">Aprobada UFI</asp:ListItem>
                <asp:ListItem Value="0">Todas</asp:ListItem>
                  <asp:ListItem Value="7">Libre Gestión</asp:ListItem>
              </cc1:ddlESTADOS>
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Button ID="btnIniciaProceso" runat="server" Text="Iniciar proceso de compra" />
              <asp:Button ID="lbRechazaSolicitud" runat="server" Text="Rechazar solicitud" Visible="False" /></td>
          </tr>
          <tr>
            <td>
              <asp:GridView ID="gvSolicitudCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" AllowPaging="True" DataKeyNames="IDESTABLECIMIENTO,IDSOLICITUD">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:CheckBox ID="chkSeleccionada" runat="server" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="CORRELATIVO" HeaderText="No. de Solicitud">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="DEPENDENCIA_SOLICITANTE" HeaderText="Dependencia Solicitante">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="CLASE_SUMINISTRO" HeaderText="Clase de suministro">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:TemplateField HeaderText="Fuente de Financiamiento">
                    <ItemTemplate>
                      <asp:GridView ID="gvFuentesFinanciamiento" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                        GridLines="None" ShowHeader="false">
                        <Columns>
                          <asp:BoundField DataField="NOMBRE" />
                        </Columns>
                      </asp:GridView>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="FECHASOLICITUD" HeaderText="Fecha de env&#237;o" DataFormatString="{0:MM-dd-yyyy}"
                    ReadOnly="True">
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:BoundField>
                  <asp:BoundField DataField="MONTOSOLICITADO" HeaderText="Monto Solicitado" DataFormatString="{0:$#,##0.00;($#,##0.00);0)}"
                    HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" />
                  </asp:BoundField>
                  <asp:BoundField DataField="COMPRACONJUNTA" HeaderText="Compra Conjunta" />
                  <asp:BoundField DataField="DESCRIPCION" HeaderText="Estado" />
                  <asp:BoundField DataField="IDSOLICITUD" HeaderText="IDSOLICITUD" />
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Label ID="lblMsgerror" runat="server" /></td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="pnlIngreso" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label5" runat="server" Text="Proceso de compra sugerido:" /></td>
            <td class="DataCell">
              <uc2:ucListaTipoCompra ID="UcListaTipoCompra2" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label2" runat="server" Text="Proceso de compra que va a ejecutar:" /></td>
            <td class="DataCell">
              <asp:DropDownList ID="ddlProcesoCompraEjecutar" runat="server" />
              <uc2:ucListaTipoCompra ID="UcListaTipoCompra1" runat="server" Visible="false" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Text="Número asignado al proceso:" Visible="False" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtNoAsignado" runat="server" Width="327px" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label6" runat="server" Text="Fecha de inicio del proceso:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFechaInicio" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="Comentarios / observaciones:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtComentarios" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label7" runat="server" Text="Seleccione el analista que desea asignar:"
                Visible="False" /></td>
            <td class="DataCell">
              <uc3:ucListaEmpleado ID="UcListaEmpleado1" runat="server" Visible="false" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
            </td>
            <td class="DataCell">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label9" runat="server" Text="Número de Proceso de compra:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtCODIGOLICITACION" runat="server" AutoPostBack="True" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCODIGOLICITACION"
                ErrorMessage="Requerido" Display="Dynamic" />
              <asp:Label ID="lblPrefijoBase" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label10" runat="server" Text="Nombre del Proceso de Compra:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtTITULOLICITACION" runat="server" Width="419px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTITULOLICITACION"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label11" runat="server" Text="Entidad que realiza la libre gestión:"
                Visible="False" /></td>
            <td class="DataCell">
              <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Enabled="False"
                Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label12" runat="server" Text="Descripción del proceso de compra:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDESCRIPCIONLICITACION" runat="server" Rows="5" TextMode="MultiLine"
                Width="403px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDESCRIPCIONLICITACION"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label16" runat="server" Text="Fecha de publicación:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="CalendarPopup1" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CalendarPopup1"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label22" runat="server" Text="Fecha de inicio para retiro de solicitudes:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="txtFechaInicioRetiroBases" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell" style="border-bottom: gray thin solid;">
              <asp:Label ID="Label23" runat="server" Text="Fecha fin de retiro de solicitudes:" /></td>
            <td class="DataCell" style="border-bottom: gray thin solid;">
              <ew:CalendarPopup ID="txtFechaFinRetiroBases" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFechaFinRetiroBases"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label13" runat="server" Text="Fecha inicio para recepción de ofertas:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="txtFECHAINICIORECEPCION" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell" style="border-bottom: gray thin solid;">
              <asp:Label ID="Label14" runat="server" Text="Fecha fin para recepción de ofertas:" /></td>
            <td class="DataCell" style="border-bottom: gray thin solid;">
              <ew:CalendarPopup ID="txtFECHAFINRECEPCION" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechaInicioRetiroBases"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label15" runat="server" Text="Fecha inicio para apertura de ofertas:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="txtFECHAINICIOAPERTURA" runat="server" Width="84px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFECHAINICIOAPERTURA"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label25" runat="server" Text="Fecha fin para apertura de ofertas:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="txtFECHAFINAPERTURA" runat="server" Width="84px">
              </ew:CalendarPopup>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFECHAFINAPERTURA"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td style="border-top: gray thin solid;">
            </td>
            <td style="border-top: gray thin solid;">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label20" runat="server" Text="Vigencia de la cotización (días):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACUMPLIMIENTOVIGENCIA" runat="server" Width="88px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGARANTIACUMPLIMIENTOVIGENCIA"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label21" runat="server" Text="Garantía de cumplimiento de orden de compra (%):" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtGarantiaCumplimientoOrdenCompra" runat="server" Width="87px" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtGarantiaCumplimientoOrdenCompra"
                Display="Dynamic" ErrorMessage="Requerido" />
              <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtGarantiaCumplimientoOrdenCompra"
                Display="Dynamic" ErrorMessage="El valor debe estar en el rango adecuado" MaximumValue="99.99"
                MinimumValue="0" Type="Double" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label24" runat="server" Text="Garantía de buena calidad (%):" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="txtGARANTIACALIDADVALOR" runat="server" Width="88px" />
              <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtGARANTIACALIDADVALOR"
                Display="Dynamic" ErrorMessage="El valor debe estar en el rango adecuado" MaximumValue="99.99"
                MinimumValue="0" Type="Double" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
<nds:MsgBox ID="MsgBox3" runat="server" />
