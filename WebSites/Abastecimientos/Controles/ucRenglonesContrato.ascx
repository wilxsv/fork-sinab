<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucRenglonesContrato.ascx.vb"
  Inherits="Controles_ucRenglonesContrato" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td>
      <asp:Label ID="lblSeleccioneUnRenglon" runat="server" Font-Names="Verdana" Font-Size="X-Small"
        Text="Seleccione un renglón:" />
    </td>
  </tr>
  <tr>
    <td>
    </td>
  </tr>
  <tr>
    <td>
      <table class="CenteredTable" style="font-family: Arial; font-size: smaller; text-align: left;
        width: 100%;">
        <tr>
          <td style="width: 4%">
            <asp:Label ID="lblC" runat="server" Text="C.:" /></td>
          <td style="width: 28%">
            <asp:Label ID="lblC1" runat="server" Text="Cantidad contratada" /></td>
          <td style="width: 4%">
            <asp:Label ID="lblCE" runat="server" Text="C.E.:" /></td>
          <td style="width: 28%">
            <asp:Label ID="lblCE1" runat="server" Text="Cantidad entregada" /></td>
          <td style="width: 4%">
            <asp:Label ID="lblCNE" runat="server" Text="C.N.E.:" /></td>
          <td>
            <asp:Label ID="lblCNE1" runat="server" Text="Cantidad no entregada" /></td>
        </tr>
        <tr>
          <td style="width: 4%">
            <asp:Label ID="lblM" runat="server" Text="M.:" /></td>
          <td style="width: 28%">
            <asp:Label ID="lblM1" runat="server" Text="Monto contratado" /></td>
          <td style="width: 4%">
            <asp:Label ID="lblME" runat="server" Text="M.E.:" /></td>
          <td style="width: 28%">
            <asp:Label ID="lblME1" runat="server" Text="Monto entregado" /></td>
          <td style="width: 4%">
            <asp:Label ID="lblMNE" runat="server" Text="M.N.E.:" /></td>
          <td>
            <asp:Label ID="lblMNE1" runat="server" Text="Monto no entregado" /></td>
        </tr>
      </table>
    </td>
  </tr>
  <tr>
    <td>
      <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" Width="100%" AllowPaging="True"
        PageSize="10" CellPadding="4" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,IDPRODUCTO,ESTAHABILITADO,IDCANCELACION"
        Font-Size="Smaller">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <SelectedRowStyle CssClass="GridSelectedItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:TemplateField ItemStyle-Width="5%">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;" />
            </ItemTemplate>
          </asp:TemplateField>
          <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" ItemStyle-Width="5%" />
          <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo" ItemStyle-Width="5%" />
          <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left"
            ItemStyle-Width="40%" />
          <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U. M." ItemStyle-Width="5%" />
          <asp:BoundField DataField="PRECIOUNITARIO" HeaderText="Precio Unitario" ItemStyle-HorizontalAlign="Right"
            ItemStyle-Width="5%" DataFormatString="{0:c}" HtmlEncode="false" />
          <asp:BoundField DataField="CANTIDAD" HeaderText="C." ItemStyle-HorizontalAlign="Right"
            ItemStyle-Width="5%" />
          <asp:BoundField DataField="CANTIDADENTREGADA" HeaderText="C.E." ItemStyle-HorizontalAlign="Right"
            ItemStyle-Width="5%" />
          <asp:TemplateField HeaderText="C.N.E." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%">
            <ItemTemplate>
              <%# Decimal.Round(Eval("CANTIDAD") - Eval("CANTIDADENTREGADA"), 2) %>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="M." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%">
            <ItemTemplate>
              <%#String.Format("{0:c}", Decimal.Round(Eval("CANTIDAD") * Eval("PRECIOUNITARIO"), 2))%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="M.E." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%">
            <ItemTemplate>
              <%#String.Format("{0:c}", Decimal.Round(Eval("CANTIDADENTREGADA") * Eval("PRECIOUNITARIO"), 2))%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="M.N.E." ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%">
            <ItemTemplate>
              <%#String.Format("{0:c}", Decimal.Round((Eval("CANTIDAD") - Eval("CANTIDADENTREGADA")) * Eval("PRECIOUNITARIO"), 2))%>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Habilitado" ItemStyle-Width="5%">
            <ItemTemplate>
              <%#IIf(Eval("ESTAHABILITADO") = 1, "Si", "No")%>
            </ItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
    </td>
  </tr>
</table>
