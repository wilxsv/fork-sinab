<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BaseLicitacion_9.ascx.vb" Inherits="Controles_BaseLicitacion_9" %>
<h3>
              <asp:Literal ID="Label79" runat="server" Text="paso 9 - Detalle de productos" />
</h3>
    <div style="margin:10px 0">
        <asp:Label ID="Label16" runat="server" Text="Porcentaje de la garantía de mantenimiento de oferta para cada renglon:" />
        <asp:Textbox ID="txtPorcentaje" runat="server" Width="67px" CssClass="double" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPorcentaje"
                                          ErrorMessage="Requerido" /><br />
          
              <asp:Button ID="btnReplicar" runat="server" Text="Aplica a cada renglon" CausesValidation="False" />
        </div>
          <div style="margin:10px 0">
              <asp:Panel ID="Panel4" runat="server" CssClass="ScrollPanel" >
                  <div>
                <asp:DataGrid ID="dgDetalleProductos" runat="server" AutoGenerateColumns="False"
                  CellPadding="4" GridLines="None" Width="100%" DataKeyField="IDPRODUCTO">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditItemStyle BackColor="#2461BF" />
                  <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <AlternatingItemStyle BackColor="White" />
                  <ItemStyle BackColor="#EFF3FB" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <Columns>
                    <asp:BoundColumn DataField="Renglon" HeaderText="Renglon" />
                    <asp:BoundColumn DataField="Codigo" HeaderText="Código" />
                    <asp:BoundColumn DataField="DESCRIPCION" HeaderText="Producto" />
                   
                    <asp:BoundColumn DataField="CANTIDAD" DataFormatString="{0:#,##0.00;(#,##0.00);0}"
                      HeaderText="Cantidad">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="MONTO" DataFormatString="{0:$#,##0.00;($#,##0.00);0}"
                      HeaderText="Monto (USD$)">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="UnidadMedida" HeaderText="Unidad de medida" />
                    <asp:BoundColumn DataField="ENTREGAS" HeaderText="Número de entregas" />
                    
                    <asp:TemplateColumn HeaderText="Valor garantía (USD$)">
                      <ItemTemplate>
                        <asp:TextBox ID="txtValorGarantia" runat="server" TextAlign="Right" Width="93px"
                          CssClass="double" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtValorGarantia"
                          ErrorMessage="*" Display="Dynamic" />
                      </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="IDPRODUCTO" Visible="False" />
                  </Columns>
                </asp:DataGrid>
               </div>
              </asp:Panel>
          </div>
<div style="text-align: right; margin: 10px 0">
    
              <asp:Label ID="Label65" runat="server" Font-Italic="True" Text="Monto Solicitado (US$): " />
                <asp:Textbox ID="lblMontoSolicitado" runat="server" Font-Bold="True"  ReadOnly="True" TextAlign="Right" Width="112px" CssClass="double"/>

              <asp:Label ID="Label67" runat="server" Font-Italic="True" Text="Total Garantia 5.00% (US$):    " />
                <asp:Textbox ID="lblTotalG" runat="server" Font-Bold="True" ReadOnly="True" TextAlign="Right" Width="112px" CssClass="double"/>
              
                <asp:Label ID="Label66" runat="server" Font-Italic="True" Text="Total Calculado de garantia (US$): " />
                <asp:TextBox ID="lblTotalGarantia" runat="server" Font-Bold="True" ReadOnly="True" TextAlign="Right" Width="112px" CssClass="double"/>
     </div>   