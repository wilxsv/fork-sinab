<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmMantProgramacionAjuste.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantProgramacionAjuste" %>


<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>

  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
      <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        ESTABLECIMIENTOS » Programación de Compras
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
  
  
   
  
          <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False" AllowPaging="True"
            Width="100%" GridLines="None" CellPadding="4" DataKeyNames="IDPROGRAMACION,IDPRODUCTO,IDESTABLECIMIENTO,CANTIDADCOMPRARAJUSTADA,NOOBSERVACION2" >
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left"  />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Left" Width="100%" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                <HeaderStyle HorizontalAlign="Left"  />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="PRECIO" HeaderText="Precio" DataFormatString="{0:c4}">
                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADCOMPRAR" HeaderText="Cantidad a Comprar">
                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Cantidad a Comprar Ajustada">
                <ItemTemplate>
                    <asp:TextBox ID="txtCANTIDACOMPRAR" runat="server" Width="69px"></asp:TextBox>
                    &nbsp;
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtCANTIDACOMPRAR"
                        ErrorMessage="Favor ingresar Valor Numerico" MaximumValue="9999999999" MinimumValue="0"
                        Type="Double" Display="Dynamic"></asp:RangeValidator>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="80px" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" />
              </asp:TemplateField>
              <asp:BoundField DataField="MONTOTOTALAJUSTADO" HeaderText="Monto Total Ajustado"
                DataFormatString="{0:c4}">
                <HeaderStyle HorizontalAlign="Right" Width="90px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton runat="server" ID="btnCom" ImageUrl="../imagenes/information.png" Visible="false" AlternateText="Consultar" CommandName="Delete"
                  CausesValidation="False" />  
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se han definido productos para la distribucion.</EmptyDataTemplate>
          </asp:GridView>
        <%--</asp:Panel>--%>
    
      <table class="CenteredTable" style="width: 100%;">
        <tr>
          <td style="width: 387px">
            <asp:Button runat="server" ID="btnRpt1" Text="Reporte de Ajustes" Width="180px" />
            &nbsp;
            <asp:Button runat="server" ID="btnRpt2" Text="Reporte Final" Width="180px" Enabled="False" />
          </td>
          <td align="right">
            Techo presupuestario: $<asp:Label runat="server" ID="lblTP"></asp:Label>
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
            <%--<asp:Button id="btnRpt5" runat="server" Width="180px" Text="Reporte de Observaciones" Font-Size="12px"></asp:Button>--%>
          </td>
          <td align="right">
            Monto total calculado: $<asp:Label runat="server" ID="lblMT"></asp:Label>
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          <asp:Button id="btnRpt5" runat="server" Width="180px" Text="Reporte de Observaciones" Font-Size="12px"></asp:Button>
          </td>
          <td align="right">
            Monto total ajustado: $<asp:Label runat="server" ID="lblMTA"></asp:Label>
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          </td>
          <td align="right">
            Diferencia (calculado/ajustado): $<asp:Label runat="server" ID="lblDif"></asp:Label>
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          </td>
          <td align="right">
            <b>Disponible: $<asp:Label runat="server" ID="lblDispo" ForeColor="Blue"></asp:Label></b>
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          </td>
          <td align="right">
              <asp:Label ID="Label1" runat="server" Font-Size="Smaller" ForeColor="Red" Text="(Recuerde Guardar antes de Cerrar)  "></asp:Label>
            <asp:Button runat="server" ID="btnFinalizar" Text="Cerrar Programa" Font-Size="Small" Width="180px" OnClientClick="return confirm('Desea cerrar el programa de compras?');" />
          </td>
        </tr>
      </table>
  
</asp:Content>
 
