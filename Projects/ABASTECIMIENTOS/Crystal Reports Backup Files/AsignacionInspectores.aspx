<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="AsignacionInspectores.aspx.vb" MaintainScrollPositionOnPostback="True"
  Inherits="AsignacionInspectores" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
        <asp:Label ID="lblRuta" runat="server" Text="URMIM -> Asignación de proveedores a inspectores" /></td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P1" runat="server" HorizontalAlign="Center" Visible="False" Width="100%">
          <asp:Panel ID="Panel2" runat="server" CssClass="ScrollPanel" Height="250px" Width="100%">
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra,IDPROVEEDOR,IDCONTRATO,ESTABLECIMIENTO,NUMPC,NUMERONOTIFICACION"
              GridLines="None" OnRowCommand="eventoGvEncabezado">
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                <asp:BoundField DataField="NUMERONOTIFICACION" HeaderText="No.Notificaci&#243;n" />
                <asp:BoundField DataField="FECHANOTIFICACION" DataFormatString="{0:d}" HeaderText="Fecha de notificaci&#243;n">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No.Contrato" />
                <asp:BoundField DataField="PC" HeaderText="Proceso de compra">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:ButtonField CommandName="1" Text="Ver detalle" />
                <asp:ButtonField ButtonType="Image" CommandName="2" Text="Rechazar" ImageUrl="~/Imagenes/botones/rechazar.jpg" />
                <asp:ButtonField ButtonType="Image" CommandName="3" Text="Cerrar" ImageUrl="~/Imagenes/botones/cerrar.gif" />
              </Columns>
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <EmptyDataTemplate>
                No hay notificaciones registradas.
              </EmptyDataTemplate>
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" />
              <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
          </asp:Panel>
          &nbsp;
        </asp:Panel>
        <asp:Button ID="Button2" runat="server" Text="Ver cuadro de asignaciones" Width="183px"
          Visible="False" />
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P2" runat="server" GroupingText="Asignaciones" Width="100%" Visible="False">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell" style="font-size: x-small">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblPC" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Establecimiento:</td>
              <td class="DataCell">
                <asp:Label ID="lblEstablecimiento" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proveedor:</td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                No.Contrato/Orden de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNoDoc" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                No.Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblNumNotificacion" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblFechaNotificacion" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Asignación:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarPopup2" runat="server" DisableTextBoxEntry="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Inspector:</td>
              <td class="DataCell">
                <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="226px" />
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Varios inspectores" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UNIDAD_MEDIDA,CODIGOPRODUCTO,DESCRIPCIONPRODUCTO1"
                  GridLines="None">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <RowStyle BackColor="#EFF3FB" />
                  <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                      <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                      <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tama&#241;o Lote">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION2" HeaderText="Fecha Fabricaci&#243;n" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO2" HeaderText="Fecha Vencimiento" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Inspectores" Visible="False">
                      <ItemTemplate>
                        <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="226px" AutoPostBack="True" />
                      </ItemTemplate>
                    </asp:TemplateField>
                  </Columns>
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <AlternatingRowStyle BackColor="White" />
                  <EmptyDataTemplate>
                    No hay lotes registrados actualmente</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
              </td>
            </tr>
            <tr>
              <td align="center" colspan="2">
                <asp:Button ID="Button7" runat="server" Text="Guardar asignación" />
                <asp:Button ID="Button8" runat="server" Text="Cancelar" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;</td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
