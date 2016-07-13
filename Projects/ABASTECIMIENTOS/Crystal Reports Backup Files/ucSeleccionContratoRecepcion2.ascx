<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucSeleccionContratoRecepcion2.ascx.vb" Inherits="Controles_ucSeleccionContratoRecepcion2" %>
<table style="background-color: #F5F5F5; " width="100%" border="0" cellpadding="0" cellspacing="0"  >
  <tr>
    <td>
    <asp:Panel ID="panel1" runat="server">
      <table width="100%" style="text-align: center; " border="0">
        <tr>
          <td style="text-align: left; background-color: #F5F5F5;">
            <asp:Label ID="Label1" runat="server" Text="SubAlmacén:" />
          </td>
        </tr>    
        <tr>
          <td style="background-color: #F5F5F5; " >
            <asp:DropDownList ID="dpAlmancenes" runat="server" AutoPostBack="True">
              <asp:ListItem Value="0">[Seleccione un almac&#233;n]</asp:ListItem>
              <asp:ListItem Value="42">Almac&#233;n el Paraiso: Medicamentos</asp:ListItem>
              <asp:ListItem Value="43">Almac&#233;n el Paraiso: FOSALUD</asp:ListItem>
            </asp:DropDownList>
          </td>
        </tr>
      </table>
     </asp:Panel>
     </td>
   </tr>   
   <tr>
     <td width="100%" colspan="2">   
     <asp:Panel ID="panel2" runat="server" Visible="False" Width="100%"> 
      <table border="0" cellpadding="0" cellspacing="0" style="background-color: #F5F5F5; text-align:center;  " width="100%" >
        <tr>
          <td align="left">
            <asp:Label ID="Label4" runat="server" Text="Proveedores habilitados para recepción de anticipos:" />
          </td>
        </tr>
        <tr>
          <td align="center" width="50%">
            <asp:Panel ID="panel3" runat="server" ScrollBars="Vertical" Visible="true">
              <asp:GridView ID="gvListaProveedores" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IDPROVEEDOR">
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <Columns>
                  <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# Eval("NOMBRE") %>'></asp:LinkButton>
                    </ItemTemplate>
                  </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                  No se encontraron proveedores habilitados para recepción de anticipos.
                </EmptyDataTemplate>
                <RowStyle BackColor="#EFF3FB" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              </asp:GridView>
            </asp:Panel>   
          </td>
        </tr>
        <tr>
          <td align="left" colspan="2">
          </td>
        </tr>
        <tr>
          <td align="left" colspan="2">
            <asp:Label ID="Label3" runat="server" Text="Modalidades de Compra" Visible="False" />
          </td>
        </tr>
      </table> 
    </asp:Panel> 
    </td>
  </tr>   
  <tr>  
    <td>       
    <asp:Panel ID="pnDoc" runat="server"  ScrollBars="Vertical" Visible="False" Width="50%">
      <asp:GridView ID="gvDoc" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" Width="100%" DataKeyNames="IdProcesoCompra,IDPROVEEDOR,IDESTABLECIMIENTO">
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <Columns>
            <asp:BoundField DataField="descripcion" HeaderText="Modalidad de Compra">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="No.Modalidad de Compra">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" Text='<%# eval("codigolicitacion") %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:BoundField DataField="nombre" HeaderText="Establecimiento Contratante">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
        </Columns>
        <RowStyle BackColor="#EFF3FB" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
      </asp:GridView>
    </asp:Panel>
    </td>  
  </tr>        
</table>