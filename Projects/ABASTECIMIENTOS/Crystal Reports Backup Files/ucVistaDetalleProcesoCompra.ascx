<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleProcesoCompra.ascx.vb"
  Inherits="ucVistaDetalleProcesoCompra" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
        <table>
            <tr>
                <td style="width: 100px; height: 26px;">
                    Buscar</td>
                <td style="width: 100px; height: 26px;">
                    <asp:DropDownList ID="ddlFiltro" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 100px; height: 26px;">
                    <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox></td>
                <td style="width: 100px; height: 26px;">
                    <asp:Button ID="btnFind" runat="server" Text="Buscar" /></td>
            </tr>
        </table>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="server" Height="24px" ImageUrl="~/Imagenes/loading100.gif"
                    Width="32px" /><span style="color: #ff0033">Actualizando vista...</span>
            </ProgressTemplate>
        </asp:UpdateProgress>
      <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione el proceso de compra del siguiente listado:" />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
            <ContentTemplate>
      <asp:GridView ID="gvProcesosCompra" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        CellPadding="4" GridLines="None" Width="100%" AllowPaging="True" DataKeyNames="IDTIPOCOMPRAEJECUTAR">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:CommandField InsertVisible="False" SelectImageUrl="~/Imagenes/botones/flecha.jpg"
            ShowHeader="True" ShowSelectButton="True" />
          <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra" >
            <ItemStyle HorizontalAlign="Right" />
          </asp:BoundField>
          <asp:BoundField DataField="CODIGOLICITACION" HeaderText="C&#243;digo de Licitaci&#243;n" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="LUGARRETIROBASE" HeaderText="Lugar de Retiro" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="FECHAPUBLICACION" HeaderText="Fecha de publicaci&#243;n"
            DataFormatString="{0:d}" HtmlEncode="False" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Descripci&#243;n" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="OBSERVACION" HeaderText="Observaci&#243;n" >
            <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
          <asp:BoundField DataField="ESTADOPROCESOCOMPRA" HeaderText="Estado" />
            <asp:BoundField DataField="NOMBRECOMPLETO" HeaderText="Encargado" />
            <asp:BoundField DataField="MONTOSOLICITADO" HeaderText="Monto" DataFormatString="{0:c}" />
        </Columns>
        <EmptyDataTemplate>
          No hay procesos de compra en el estado seleccionado.
        </EmptyDataTemplate>
      </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFind" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="gvProcesosCompra" EventName="PageIndexChanging" />
                <asp:AsyncPostBackTrigger ControlID="gvProcesosCompra" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </td>
  </tr>
  <tr>
    <td>
        &nbsp;</td>
  </tr>
</table>
