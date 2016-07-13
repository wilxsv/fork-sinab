<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleCATALOGOPRODUCTOS.ascx.vb"
  Inherits="ucVistaDetalleCATALOGOPRODUCTOS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td class="LabelCell">
      Suministro:</td>
    <td class="DataCell">
      <cc1:ddlSUMINISTROS ID="ddlSUMINISTROS1" runat="server" AutoPostBack="True" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      Grupo:</td>
    <td class="DataCell">
      <cc1:ddlGRUPOS ID="ddlGRUPOS1" runat="server" AutoPostBack="True" />
      <asp:LinkButton ID="lbGrupo" runat="server" CausesValidation="False" Text="Agregar Grupo"
        PostBackUrl="~/Catalogos/wfMantGRUPOS.aspx" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      Subgrupo:</td>
    <td class="DataCell">
      <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" />
      <asp:LinkButton ID="lbSubGrupo" runat="server" CausesValidation="False" Text="Agregar SubGrupo"
        PostBackUrl="~/Catalogos/wfMantSUBGRUPOS.aspx" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
        AllowPaging="True" CellPadding="4" GridLines="None" Width="100%" DataKeyNames="IDPRODUCTO">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
          <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" />
          <asp:BoundField DataField="DESCPRODUCTO" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" />
          <asp:BoundField DataField="DESCRIPCION" HeaderText="U.M." />
          <asp:BoundField DataField="PRECIOACTUAL" HeaderText="Precio Actual" DataFormatString="{0:c4}"
            HtmlEncode="false" ItemStyle-HorizontalAlign="Right" />
        </Columns>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnAgregar" runat="server" CausesValidation="False" Text="Agregar Nuevo Producto" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plDatos" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              Código del producto:</td>
            <td class="DataCell">
              <asp:Label ID="txtCODIGO" runat="server" Font-Bold="True" />
              <asp:TextBox ID="txtCORRELATIVO" runat="server" MaxLength="3" Width="40px" />
              <asp:RequiredFieldValidator ID="rfvCORRELATIVO" runat="server" ControlToValidate="txtCORRELATIVO"
                Display="Dynamic" ErrorMessage="Requerido" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Unidad de medida:</td>
            <td class="DataCell">
              <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Nombre:</td>
            <td class="DataCell">
              <asp:TextBox ID="txtNOMBRE" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" />
              <asp:RequiredFieldValidator ID="rfvNOMBRE" runat="server" ControlToValidate="txtNOMBRE"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Nivel de uso:</td>
            <td class="DataCell">
              <cc1:ddlNIVELESUSO ID="ddlNIVELESUSO1" runat="server" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              Precio actual:</td>
            <td class="DataCell">
              <ew:NumericBox ID="nbPRECIOACTUAL" runat="server" DecimalPlaces="4" TextAlign="Right" />
              <asp:RequiredFieldValidator ID="rfvPRECIOACTUAL" runat="server" ControlToValidate="nbPRECIOACTUAL"
                ErrorMessage="Requerido" Display="Dynamic" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Aplica lote:</td>
            <td class="DataCell">
              <asp:CheckBox ID="cbAPLICALOTE" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Producto habilitado:</td>
            <td class="DataCell">
              <asp:CheckBox ID="cbESTADOPRODUCTO" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              Observación:</td>
            <td class="DataCell">
              <asp:TextBox ID="txtOBSERVACION" runat="server" TextMode="MultiLine" CssClass="TextBoxMultiLine" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
</table>
