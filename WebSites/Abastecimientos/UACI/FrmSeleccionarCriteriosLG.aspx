<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"
  AutoEventWireup="false" CodeFile="FrmSeleccionarCriteriosLG.aspx.vb" Inherits="FrmSeleccionarCriteriosLG" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Src="~/Controles/wucFiltroGrid.ascx" TagName="wucFiltroGrid" TagPrefix="uc1" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Seleccionar criterios de evaluación" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td align="left" colspan="2" style="font-size: smaller">
        <asp:Label ID="Label4" runat="server" Font-Size="Small" Text="Seleccione los criterios de evaluación para este proceso de compra, si el criterio de evaluación no se encuentra en esta lista o desea modificar los porcentajes, proceda a realizar el cambio  en el" /><asp:LinkButton
          ID="LinkButton1" runat="server" Font-Underline="True" Font-Size="Small">Catálogo de criterios de evaluación</asp:LinkButton></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
            <table style="width: 100%">
              <tr>
                <td colspan="2">
                </td>
              </tr>
              <tr>
                <td colspan="2" align="center">
                  <asp:Panel ID="Panel1" runat="server" Height="200px" CssClass="ScrollPanel" HorizontalAlign="Center"
                    Width="520px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
                      DataKeyNames="IDCRITERIO" ForeColor="#333333" GridLines="None" Width="500px">
                      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <RowStyle BackColor="#EFF3FB" />
                      <Columns>
                        <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" />
                        <asp:BoundField HeaderText="CRITERIO DE EVALUACION" DataField="CRITERIO">
                          <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="PORCENTAJE" DataField="PORCENTAJE">
                          <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                      </Columns>
                      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                      <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                      <EditRowStyle BackColor="#2461BF" />
                      <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                  </asp:Panel>
                  <table style="width: 100%">
                    <tr>
                      <td colspan="2">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" /></td>
                    </tr>
                  </table>
                </td>
              </tr>
              <tr>
                <td align="left">
                  <asp:Label ID="Label1" runat="server" Text="Criterios de evaluación en el proceso de compra" />
                  <asp:Label ID="Label3" runat="server" Font-Bold="True" /></td>
                <td style="width: 100px">
                </td>
              </tr>
              <tr>
                <td colspan="2" align="center">
                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    DataKeyNames="IDCRITERIO" ForeColor="#333333" GridLines="None" Width="500px">
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                      <asp:BoundField HeaderText="CRITERIO DE EVALUACION" DataField="CRITERIO">
                        <ItemStyle HorizontalAlign="Left" />
                      </asp:BoundField>
                      <asp:BoundField HeaderText="PORCENTAJE" DataField="PORCENTAJE">
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
                      < No hay criterios de evaluación seleccionados >
                    </EmptyDataTemplate>
                  </asp:GridView>
                </td>
              </tr>
              <tr>
                <td colspan="2">
                </td>
              </tr>
            </table>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button2" runat="server" Text="Guardar" />
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
