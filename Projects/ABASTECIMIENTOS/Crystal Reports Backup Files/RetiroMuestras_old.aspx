<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
     CodeFile="RetiroMuestras_old.aspx.vb" MaintainScrollPositionOnPostback="True" Inherits="RetiroMuestras_old" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
     TagPrefix="nds" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
     <table class="CenteredTable" style="width: 100%;">
          <tr>
               <td class="LinkMenuRuta">
                    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
                    <asp:Label ID="lblRuta" runat="server" Text="URMIM -> Retiro de muestras para análisis" /></td>
          </tr>
          <tr>
               <td>
               </td>
          </tr>
          <tr>
                <td>
                <asp:Panel ID="pnPC" runat="server" Width="100%" CssClass="ScrollPanel" GroupingText="Procesos de compra" ScrollBars="Vertical" Height="200px"><table class="CenteredTable" style="width: 100%;">
                     <tr>
                          <td align="left">
                          </td>
                     </tr>
                     <tr>
           <td>
                <asp:GridView ID="gvPC" runat="server" AutoGenerateColumns="False" CellPadding="4"
                     CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra" ForeColor="#333333"
                     GridLines="None">
                     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <RowStyle BackColor="#EFF3FB" />
                     <Columns>
                          <asp:TemplateField HeaderText="No.Proceso de compra">
                               <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text='<%# BIND("CODIGOLICITACION") %>'></asp:LinkButton>
                               </ItemTemplate>
                               <ItemStyle HorizontalAlign="Left" />
                          </asp:TemplateField>
                          <asp:BoundField DataField="DESCRIPCIONLICITACION" HeaderText="Nombre del Proceso de Compra">
                               <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="NUMERORESOLUCION" HeaderText="No. Resoluci&#243;n">
                               <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                          <asp:BoundField DataField="NOMBRE" HeaderText="Establecimiento">
                               <ItemStyle HorizontalAlign="Left" />
                          </asp:BoundField>
                     </Columns>
                     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <EditRowStyle BackColor="#2461BF" />
                     <AlternatingRowStyle BackColor="White" />
                     <EmptyDataTemplate>No hay procesos de compra adjudicados.</EmptyDataTemplate>
                </asp:GridView>
           </td>
                     </tr>
                </table>
                </asp:Panel>
           </td>
          </tr>
          <tr>
               <td>
               </td>
          </tr>
          <tr>
               <td><asp:Panel ID="pnProveedores" runat="server" Width="100%" CssClass="ScrollPanel" GroupingText="Proveedores" ScrollBars="Vertical" Visible="False" Height="150px">
                <table class="CenteredTable" style="width: 100%;" height="120px"> 
                     <tr>
                          <td align="left">
                          </td>
                     </tr>
                     <tr>
                          <td>
                               <asp:GridView ID="gvP" runat="server" AutoGenerateColumns="False" CellPadding="4"
                     CssClass="Grid" DataKeyNames="IDPROVEEDOR,IDCONTRATO" ForeColor="#333333"
                     GridLines="None">
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <Columns>
                                         <asp:TemplateField HeaderText="Nombre">
                                              <ItemTemplate>
                                                   <asp:LinkButton ID="LinkButton1" runat="server" Text='<%# BIND("NOMBRE") %>' CommandName="Select"></asp:LinkButton>
                                              </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Left" />
                                         </asp:TemplateField>
                                         <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No.Contrato/Orden de compra">
                                              <ItemStyle HorizontalAlign="Left" />
                                         </asp:BoundField>
                                    </Columns>
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <AlternatingRowStyle BackColor="White" />
                               </asp:GridView>
                          </td>
                     </tr>
                </table>
           </asp:Panel>
           </td>
          </tr>
          <tr>
               <td>
               </td>
          </tr>
          <tr>
               <td colspan="2">
               </td>
          </tr>
          <tr>
               <td>
                    <asp:Panel ID="pnMan" runat="server" Width="100%" Visible="False">
                         <table class="CenteredTable" style="width: 100%;">
                              <tr>
                                   <td>
                                        <asp:Label ID="lblInspector" runat="server" Text="Inspector:" Visible="False" />
                                        <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="226px" AutoPostBack="True" Visible="False" />
                                   </td>
                              </tr>
                              <tr>
                                   <td>
                                        <asp:GridView ID="gvRenglones" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                             GridLines="None" DataKeyNames="IDINFORME,NUMERONOTIFICACION" Width="100%">
                                             <HeaderStyle CssClass="GridListHeader" />
                                             <FooterStyle CssClass="GridListFooter" />
                                             <PagerStyle CssClass="GridListPager" />
                                             <RowStyle CssClass="GridListItem" />
                                             <SelectedRowStyle CssClass="GridListSelectedItem" />
                                             <EditRowStyle CssClass="GridListEditItem" />
                                             <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                                             <Columns>
                                                  <asp:BoundField HeaderText="Rengl&#243;n" DataField="RENGLON" />
                                                  <asp:BoundField HeaderText="C&#243;digo" DataField="CORRPRODUCTO" />
                                                  <asp:BoundField HeaderText="Descripci&#243;n del Producto" DataField="DESCLARGO" >
                                                       <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle Font-Size="X-Small" HorizontalAlign="Left" />
                                                  </asp:BoundField>
                                                  <asp:BoundField HeaderText="Lote" DataField="LOTE" >
                                                       <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Left" />
                                                  </asp:BoundField>
                                                  <asp:TemplateField HeaderText="Asignar" Visible="False">
                                                       <ItemTemplate>
                                                            <asp:CheckBox ID="cbAsignar" runat="server" Checked='<%# Iif (Eval("IDINSPECTOR1") = 0, False, True) %>' />
                                                       </ItemTemplate>
                                                  </asp:TemplateField>
                                             </Columns>
                                             <EmptyDataTemplate>
                                                  No hay lotes notificados actualmente</EmptyDataTemplate>
                                        </asp:GridView>
                                   </td>
                              </tr>
                              <tr>
                                   <td>
                                        <asp:Button ID="Button3" runat="server" Text="Seleccionar todos" Width="122px" Visible="False" />
                                        <asp:Button ID="Button4" runat="server" Text="Deseleccionar todos" Width="134px" Visible="False" /></td>
                              </tr>
                              <tr>
                                   <td>
                                        <asp:Button ID="Button1" runat="server" Text="Guardar" Visible="False" />
                                        <asp:Button ID="Button2" runat="server" Text="Ver formato de retiro de muestras" Width="211px" /></td>
                              </tr>
                         </table>
                    </asp:Panel>
               </td>
          </tr>
     </table>
     <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
