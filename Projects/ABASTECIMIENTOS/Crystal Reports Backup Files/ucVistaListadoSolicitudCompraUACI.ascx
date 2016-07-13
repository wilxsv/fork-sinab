<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaListadoSolicitudCompraUACI.ascx.vb"
  Inherits="Controles_ucVistaListadoSolicitudCompraUACI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>

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
              </cc1:ddlESTADOS>
            </td>
          </tr>
          <tr>
            <td style="text-align: right">
              <asp:Button ID="btnIniciaProceso" runat="server" Text="Asignar Tipo Proceso de Compra" />
              <%--<asp:Button ID="lbRechazaSolicitud" runat="server" Text="Rechazar solicitud" Visible="False" />--%></td>
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
              <asp:Label ID="Label5" runat="server" Text="Tipo de Compra:" /></td>
            <td class="DataCell">
            <asp:DropDownList runat="server" ID="ddListEstados" >
            <asp:ListItem Text="Libre Gestión" Value="7" />
            <asp:ListItem Text="Otro" Value="6" />
            </asp:DropDownList>&nbsp;
            </td>
          </tr>
          
          
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
<nds:MsgBox ID="MsgBox3" runat="server" />
