<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="FrmSeleccionarProveedores.aspx.vb" Inherits="FrmSeleccionarProveedores" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="pmenu">
    <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú"/>
        UACI » Seleccionar proveedores participantes
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
    <div>
         <asp:Label ID="Label5" runat="server" Text="Seleccione los proveedores que desea invitar a participar en este proceso de compra, si el proveedor no se encuentra en esta lista, proceda a adicionarlo al" />
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="True">Catálogo de Proveedores</asp:LinkButton>
    </div>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <table class="CenteredTable" style="width: 100%">
              <tr>
                <td colspan="2">
                  <uc1:wucFiltroGrid ID="WucFiltroGrid1" runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <asp:Panel ID="Panel1" runat="server" CssClass="ScrollPanel" HorizontalAlign="Center" Width="520px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                      DataKeyNames="IDPROVEEDOR" ForeColor="#333333" GridLines="None" Width="500px">
                      <HeaderStyle CssClass="GridListHeader" />
                      <FooterStyle CssClass="GridListFooter" />
                      <PagerStyle CssClass="GridListPager" />
                      <RowStyle CssClass="GridListItem" />
                      <SelectedRowStyle CssClass="GridListSelectedItem" />
                      <EditRowStyle CssClass="GridListEditItem" />
                      <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                      <Columns>
                        <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="NIT" DataField="NIT" />
                        <asp:BoundField HeaderText="RAZON SOCIAL" DataField="NOMBRE">
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                      </Columns>
                    </asp:GridView>
                  </asp:Panel>
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <asp:Label ID="Label2" runat="server" ForeColor="Red" /></td>
              </tr>
              <tr>
                <td align="left">
                  <asp:Label ID="Label1" runat="server" Text="Proveedores a invitar en el proceso de compra" />
                  <asp:Label ID="Label3" runat="server" Font-Bold="True" /></td>
                <td>
                </td>
              </tr>
              <tr>
                <td colspan="2" >
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="IDPROVEEDOR" ForeColor="#333333" GridLines="None" Width="500px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                      <asp:BoundField HeaderText="NIT" DataField="NIT">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="RAZON SOCIAL" DataField="NOMBRE">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:CommandField ButtonType="Image" DeleteText="" DeleteImageUrl="~/Imagenes/botones/delete.jpg"
                        ShowDeleteButton="True" />
                    </Columns>
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                    <EmptyDataTemplate>
                      < No hay proveedores seleccionados >
                    </EmptyDataTemplate>
                  </asp:GridView>
                </td>
              </tr>
              <tr>
                <td colspan="2">
                  <asp:Label ID="Label4" runat="server" ForeColor="Red" /></td>
              </tr>
            </table>
          </ContentTemplate>
        </asp:UpdatePanel>
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td>
        <asp:Button ID="Button2" runat="server" Text="Guardar" />&nbsp;
        <asp:Button ID="Button3" runat="server" Enabled="False" Text="Generar Notas de Invitación" />&nbsp;
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
