<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  MaintainScrollPositionOnPostback="true" CodeFile="FrmAnularTransaccionesDetalle.aspx.vb"
  Inherits="FrmAnularTransaccionesDetalle" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Almacén -> Anular transacciones</td>
    </tr>
    <tr>
      <td style="text-align: left;">
        <asp:ImageButton ID="ImgbCerrar" runat="server" ImageUrl="~/Imagenes/botones/Anular.gif" />
        <asp:ImageButton ID="ImgbImprimir" runat="server" ImageUrl="~/Imagenes/botones/btnImprimir.gif" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="plEncabezado" runat="server" Width="100%">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td class="LabelCell">
                Tipo movimiento:</td>
              <td class="DataCell">
                <cc1:ddlTIPOTRANSACCIONES ID="ddlTIPOTRANSACCIONES1" runat="server" Width="328px"
                  Enabled="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                No. documento:</td>
              <td class="DataCell">
                <asp:TextBox ID="txtDocumento" runat="server" Width="91px" ReadOnly="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Almacén:</td>
              <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES1" runat="server" Width="320px" Enabled="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha despacho:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarFechaDespacho" runat="server" Enabled="False" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Establecimiento destino:</td>
              <td class="DataCell">
                <cc1:ddlESTABLECIMIENTOS ID="ddlESTABLECIMIENTOS1" runat="server" Width="362px" Enabled="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Almacén destino:</td>
              <td class="DataCell">
                <cc1:ddlALMACENES ID="ddlALMACENES2" runat="server" Width="320px" Enabled="False" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:
              </td>
              <td class="DataCell">
                <asp:TextBox ID="txtObservacion" runat="server" CssClass="TextBoxMultiLine" MaxLength="1000"
                  TextMode="MultiLine" /></td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="100%" DataKeyNames="IDLOTE">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooterSmaller" />
          <PagerStyle CssClass="GridListPagerSmaller" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItemSmaller" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="IDDETALLEMOVIMIENTO" HeaderText="Secuencia" HeaderStyle-Width="5%"
              Visible="false" />
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" HeaderStyle-Width="10%" />
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripción" HeaderStyle-Width="40%"
              ItemStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U/M" HeaderStyle-Width="5%" />
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" HeaderStyle-Width="10%"
              ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="PRECIOLOTE" HeaderText="Precio Unitario" DataFormatString="{0:c4}"
              HtmlEncode="false" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Right" />
            <asp:BoundField DataField="CODIGO" HeaderText="Lote" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
          </Columns>
        </asp:GridView>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
