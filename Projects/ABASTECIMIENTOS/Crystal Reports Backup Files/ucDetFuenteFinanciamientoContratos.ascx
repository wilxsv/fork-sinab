<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucDetFuenteFinanciamientoContratos.ascx.vb"
  Inherits="ucDetFuenteFinanciamientoContratos" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<%@ Register TagPrefix="ew" Assembly="eWorld.UI" Namespace="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
        GridLines="None" Width="100%" DataKeyNames="IDFUENTEFINANCIAMIENTO">
        <HeaderStyle CssClass="GridListHeaderSmaller" />
        <FooterStyle CssClass="GridListFooterSmaller" />
        <PagerStyle CssClass="GridListPagerSmaller" />
        <RowStyle CssClass="GridListItemSmaller" />
        <EditRowStyle CssClass="GridListEditItemSmaller" />
        <SelectedRowStyle CssClass="GridSelectedItemSmaller" />
        <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
        <Columns>
          <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left"
            ItemStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="MONTOCONTRATADO" Visible="False" HeaderText="Monto" />
          <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="5%">
            <ItemTemplate>
              <asp:ImageButton ID="LinkButton1" runat="server" CssClass="GridImagenEliminarItem"
                AlternateText="Elimina el registro" CommandName="Delete" CausesValidation="False"
                ImageUrl="~/Imagenes/cancel.jpg" OnClientClick="if(!window.confirm('¿Confirma que desea eliminar el registro?')){return false;}" />
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Button ID="btnAgregarFuente" runat="server" Text="Agregar fuente" Width="150px" Visible="False" />
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <asp:Panel ID="plAgregarFuente" runat="server" Visible="false" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              Grupo fuente financiamiento:</td>
            <td class="DataCell">
              <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">GOES</asp:ListItem>
                <asp:ListItem Value="2">Otras Fuentes</asp:ListItem>
              </asp:RadioButtonList>
              <cc1:ddlFUENTEFINANCIAMIENTOS ID="ddlFUENTEFINANCIAMIENTOS1" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="LblMonto" runat="server" Visible="False">Monto Participaci&oacuten ($):</asp:Label></td>
            <td class="DataCell">
              <ew:NumericBox ID="TxtMontoContratado" runat="server" AutoPostBack="True" PositiveNumber="True"
                Width="156px" Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="80px" ToolTip="Agrega la fuente de financiamiento al documento." />
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="80px" ToolTip="Cierra la definición de la fuente de financiamiento." /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
