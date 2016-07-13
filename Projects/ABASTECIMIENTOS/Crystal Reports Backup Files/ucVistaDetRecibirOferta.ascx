<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetRecibirOferta.ascx.vb"
  Inherits="Controles_ucVistaDetRecibirOferta" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Src="ucVistaDetalleSolicProcesCompra.ascx" TagName="ucVistaDetalleSolicProcesCompra"
  TagPrefix="uc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td colspan="2">
      <asp:Label ID="Label41" runat="server" Font-Bold="True" Text="Recepción de Ofertas" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblWarning" runat="server" Font-Bold="True" ForeColor="Red" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: right">
      <asp:Button ID="btnImprimirPresntaronOfertas" runat="server" Text="Proveedores que Presentaron Ofertas"
        Width="224px" />
      <asp:Button ID="Button2" runat="server" Text="Finalizar recepción de ofertas" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <uc1:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Fecha de publicación:" /></td>
    <td class="DataCell">
      <asp:Label ID="lblFechaPublicacion" runat="server" Text="Label" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label2" runat="server" Text="Fecha de iniciado el proceso de compra:" /></td>
    <td class="DataCell">
      <asp:Label ID="lblFechaIniciadoProceso" runat="server" Text="Label" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label3" runat="server" Text="Fecha de inicio para recepción de ofertas" /></td>
    <td class="DataCell">
      <asp:Label ID="lblFechaRecepcionOfertas" runat="server" Text="Label" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label10" runat="server" Text="Fecha final para recepción de ofertas" /></td>
    <td class="DataCell">
      <asp:Label ID="lblFechaFinRecepOferta" runat="server" Text="Label" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="Label4" runat="server" Text="Listado de proveedores que retiraron las bases"
        Font-Bold="True" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center;">
      <asp:DataGrid ID="dgProveedorRetiraBase" runat="server" AutoGenerateColumns="False"
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="True"
        PageSize="5">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditItemStyle BackColor="#2461BF" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
          PageButtonCount="8" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
          <asp:BoundColumn DataField="ORDEN" ItemStyle-HorizontalAlign="Left" HeaderText="Orden" />
          <asp:BoundColumn DataField="NOMBRE" ItemStyle-HorizontalAlign="Left" HeaderText="Proveedor" />
          <asp:BoundColumn DataField="NUMERORECIBO" ItemStyle-HorizontalAlign="Left" HeaderText="No. Recibo" />
          <asp:BoundColumn DataField="PERSONARECIBE" ItemStyle-HorizontalAlign="Left" HeaderText="Recibido por" />
          <asp:BoundColumn DataField="FECHAHORAENTREGA" ItemStyle-HorizontalAlign="Left" HeaderText="Fecha de entrega" />
        </Columns>
      </asp:DataGrid></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="Panel3" runat="server" Width="100%" BackColor="#EBF1FA">
        <table class="CenteredTable" style="width: 100%">
          <tr>
            <td>
              <uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="Label5" runat="server" Text="Listado de ofertas por orden de llegada"
                Font-Bold="True" /></td>
          </tr>
          <tr>
            <td>
            </td>
          </tr>
          <tr>
            <td>
              <asp:DataGrid ID="dgOfertaPresentada" runat="server" CellPadding="4" ForeColor="#333333"
                GridLines="None" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#2461BF" />
                <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                <AlternatingItemStyle BackColor="White" />
                <ItemStyle BackColor="#EFF3FB" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                  <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" />
                  <asp:BoundColumn DataField="ORDENLLEGADA" HeaderText="Orden" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundColumn DataField="PERSONAENTREGA" HeaderText="Persona entrega oferta" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundColumn DataField="FECHAENTREGA" HeaderText="Hora de entrega" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False" />
                </Columns>
              </asp:DataGrid>
            </td>
          </tr>
          <tr>
            <td>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
                <table class="CenteredTable" style="width: 100%">
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label6" runat="server" Text="Orden en que llegó la oferta:" /></td>
                    <td style="text-align: left;">
                      <asp:Label ID="lblOrden" runat="server" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label7" runat="server" Text="Proveedor:" /></td>
                    <td style="text-align: left;">
                      <asp:DropDownList ID="ddlProveedorEntregaBase" runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label8" runat="server" Text="Nombre de la persona que entrega la oferta:" /></td>
                    <td style="text-align: left">
                      <asp:TextBox ID="txtPersonaEntrega" runat="server" Width="353px" MaxLength="150" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtPersonaEntrega"
                        ErrorMessage="Requerido" /></td>
                  </tr>
                  <tr>
                    <td class="LabelCell">
                      <asp:Label ID="Label9" runat="server" Text="Hora de entrega:" /></td>
                    <td style="text-align: left">
                      <ew:TimePicker ID="tpHoraEntrega" runat="server" MinuteInterval="OneMinute" DisableTextBoxEntry="False"
                        LowerBoundTime="07/09/2008 07:00:00" PostedTime="09/07/2008 04:00 p.m." SelectedTime="07/09/2008 23:00:00"
                        UpperBoundTime="01/01/0001 16:00:00" Width="104px" />
                    </td>
                  </tr>
                </table>
              </asp:Panel>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblMsg" runat="server" />
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
<nds:MsgBox ID="MsgBox2" runat="server" />
