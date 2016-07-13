<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucAsignarCantidades.ascx.vb"
  Inherits="Controles_ucAsignarCantidades" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<div class="form" style="width: auto">
<h3><asp:Label ID="Label8" runat="server" Text="Oferta del proveedor" /></h3>
<table cellpadding="4" cellspacing="0"  style="width: 100%">
  
  <tr>
    <td class="LabelCell" style="height: 21px">
      <asp:Label ID="lblOfertaProveedorCantidad" runat="server" Text="Cantidad:" /></td>
    <td  style="height: 21px">
      <asp:Label ID="txtOfertaProveedorCantidad" runat="server" Text="0.00" />
      <asp:Label ID="lblUnidadMedidaOferta" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblOfertaProveedorPlazo" runat="server" Text="Plazo de Entrega:" /></td>
    <td >
      <asp:Label ID="txtOfertaProveedorPlazo" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCantidadSolicitada" runat="server" Text="Cantidad Total Solicitada:" /></td>
    <td >
      <asp:Label ID="txtCantidadSolicitada" runat="server" Text="0.00" />
      <asp:Label ID="lblUnidadMedidaCantidadSolicitada" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCantidadRecomendada" runat="server" Text="Cantidad Recomendada:" /></td>
    <td >
      <asp:Label ID="txtCantidadRecomendada" runat="server" Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCantidadAdjudicada" runat="server" Text="Cantidad Adjudicada:" /></td>
    <td >
      <asp:Label ID="txtCantidadAdjudicada" runat="server" Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCantidadOtrosProveedores" runat="server" /></td>
    <td >
      <asp:Label ID="txtCantidadOtrosProveedores" runat="server" Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Monto Total Solicitado:$" /></td>
    <td >
      <asp:Label ID="txtTotalSolicitado" runat="server" Font-Bold="True" ForeColor="#004000"
        Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label2" runat="server" Text="Monto Total Adjudicado:$" /></td>
    <td >
      <asp:Label ID="txtTotalAdjudicado" runat="server" Font-Bold="True" ForeColor="#004000"
        Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell" style="height: 21px">
      <asp:Label ID="Label3" runat="server" Text="Diferencia Total:$" /></td>
    <td  style="height: 21px">
      <asp:Label ID="txtTotalDiferencia" runat="server" Font-Bold="True" Text="0.00" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblCantidadAsignada" runat="server" /></td>
    <td >
      <ew:NumericBox ID="nbCantidadRecomendada" runat="server" PositiveNumber="True"
        Width="78px" TextAlign="Right"  DecimalPlaces="2"/>
      <ew:NumericBox ID="nbCantidadAdjudicada" runat="server" PositiveNumber="True" RealNumber="False"
        Width="72px" TextAlign="Right"  />
      <ew:NumericBox ID="nbCantidadAdjudicadaEnFirme" runat="server" PositiveNumber="True"
        RealNumber="False" Width="77px" TextAlign="Right"  /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:RequiredFieldValidator ID="rfvCantidadAsignada" runat="server" ValidationGroup="Guardar"
        Display="Dynamic" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:CompareValidator ID="cvCantidadOferta" runat="server" Operator="LessThanEqual"
        Type="Double" ValidationGroup="Guardar" Display="Dynamic" Enabled="False" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:CompareValidator ID="cvCantidadAsignada" runat="server" Operator="GreaterThanEqual"
        Type="Double" ValidationGroup="Guardar" ValueToCompare="0" Display="Dynamic" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:CompareValidator ID="cvCantidadSolicitada" runat="server" ValidationGroup="Guardar"
        Operator="LessThanEqual" Type="Double" Display="Dynamic" Enabled="False"></asp:CompareValidator></td>
  </tr>
  <tr>
    <td style="width: 50%;">
      <asp:Label ID="lblEntregasSolicitadas" runat="server" Text="Entregas solicitadas:" /></td>
    <td style="width: 50%;">
      <asp:Label ID="lblPlazosEntrega" runat="server" /></td>
  </tr>
  <tr>
    <td style="vertical-align: top; width: 50%;">
      <asp:GridView ID="gvEntregasSolicitadas" CssClass="Grid" AutoGenerateColumns="False"
        runat="server" CellPadding="4" GridLines="None" Visible="False">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridEditRow" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:BoundField DataField="IDDETALLE" HeaderText="Entrega" />
          <asp:BoundField DataField="PORCENTAJE" HeaderText="Porcentaje" >
              <ItemStyle HorizontalAlign="Right" />
          </asp:BoundField>
          <asp:BoundField DataField="DIAS" HeaderText="D&#237;as" >
              <ItemStyle HorizontalAlign="Right" />
          </asp:BoundField>
          <asp:BoundField DataField="FECHACONTEO" HeaderText="A partir de" >
              <ItemStyle HorizontalAlign="Left" />
          </asp:BoundField>
        </Columns>
      </asp:GridView>
    </td>
    <td style="vertical-align: top; width: 50%;">
      <asp:GridView ID="gvEntregasOferta" CssClass="Grid" AutoGenerateColumns="False" runat="server"
        CellPadding="4" GridLines="None" ShowFooter="True" Visible="False">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridEditRow" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:TemplateField HeaderText="Porcentaje">
            <ItemTemplate>
              <asp:Label ID="lblPORCENTAJE" runat="server" Text='<%# Eval("PORCENTAJE") %>' />
            </ItemTemplate>
            <FooterTemplate>
              <ew:NumericBox ID="nbPORCENTAJE" runat="server" MaxLength="3" PositiveNumber="True"
                RealNumber="False" Width="60px" TextAlign="Right" />
              <asp:RequiredFieldValidator ID="rfvPORCENTAJE" runat="server" ControlToValidate="nbPORCENTAJE"
                ErrorMessage="*" ValidationGroup="Agregar" />
              <asp:RangeValidator ID="rvPROCENTAJE" runat="server" ControlToValidate="nbPORCENTAJE"
                ErrorMessage="*" MinimumValue="1" MaximumValue="100" Type="Integer" />
            </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="D&#237;as">
            <ItemTemplate>
              <asp:Label ID="lblDIAS" runat="server" Text='<%# Eval("DIAS") %>' />
            </ItemTemplate>
            <FooterTemplate>
              <ew:NumericBox ID="nbDIAS" runat="server" MaxLength="3" PositiveNumber="True" RealNumber="False"
                Width="60px" TextAlign="Right" />
              <asp:RequiredFieldValidator ID="rfvDIAS" runat="server" ControlToValidate="nbDIAS"
                ErrorMessage="*" ValidationGroup="Agregar" />
              <asp:RangeValidator ID="rvDIAS" runat="server" ControlToValidate="nbDIAS" ErrorMessage="*"
                MinimumValue="1" MaximumValue="360" Type="Integer" Width="3px" />
            </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="A partir de">
            <ItemTemplate>
              <asp:Label ID="lblFECHACONTEO" runat="server" Text="Liberación contrato" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField Visible="False">
            <ItemTemplate>
              <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                Text="Eliminar" />
            </ItemTemplate>
            <FooterTemplate>
              <asp:LinkButton ID="lbAgregar" runat="server" CausesValidation="true" CommandName="Update"
                Text="Agregar" ValidationGroup="Agregar" />
            </FooterTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:" Visible="False" /></td>
    <td >
      <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Visible="False"
        CssClass="TextBoxMultiLine" /></td>
  </tr>
  <tr>
    <td colspan="2" class="NavBar" style="border: none">
        <hr />
        <div style="margin: 10px 0">
      <asp:LinkButton ID="btnGuardar" runat="server" Text="Guardar" CssClass="opGuardar" ValidationGroup="Guardar" />
      <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CausesValidation="False" CssClass="opBorrar"
        Enabled="False" Visible="False" />
      <asp:LinkButton ID="btnCancelar" runat="server" CausesValidation="False" Text="Cancelar" CssClass="opCancelar"/>
      </div>
    </td>
  </tr>
</table>
</div>