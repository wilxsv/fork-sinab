<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantDetalleProgramacionEntrega.aspx.vb" Inherits="URMIM_frmDetaMantDetalleProgramacionEntrega"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucFiltrarDatos2.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        UNABAST -> Programación de Compras: Entrega por Renglón</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" Visible="true"/>
        <%--<asp:Panel ScrollBars="Vertical" Height="200px" CssClass="ScrollPanel" runat="server" ID="pnlGrid">--%>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" Width="100%" DataKeyNames="IDPROGRAMACION,IDPRODUCTO,ENTREGA,OBSERVACION"
          AllowPaging="True" PageSize="15">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="RENGLON" HeaderText="Ren.">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Right" Width="4%" />
            </asp:BoundField>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:BoundField>
            <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad Total" DataFormatString="{0:#,##0.00}">
              <HeaderStyle HorizontalAlign="Right" />
              <ItemStyle HorizontalAlign="Right" Width="8%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Entregas">
              <ItemTemplate>
                <asp:DropDownList runat="server" ID="cboEntr"></asp:DropDownList>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="10%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Observaciones">
              <ItemTemplate>
                <asp:TextBox ID="txtObsr" runat="server" Font-Size="12px" MaxLength="200"  Width="170px"  /> 
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="25%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido productos para la programación o no se han definido productos
            para el programa</EmptyDataTemplate>
        </asp:GridView>
        <%--</asp:Panel>    --%>
      </td>
    </tr>
    <tr>
      <td width="100%">
        <table width="100%">
          <tr>
            <td align="left">
                <asp:Button ID="btnEntregas" runat="server" Text="Definición de Entregas" Font-Size="11px" Width="192px" />
                <asp:Button ID="btnInc" runat="server" Text="Inconsistencias" Font-Size="11px" Width="192px" /></td>
            <td align="right">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Font-Size="11px" Width="192px" /></td>
          </tr>
          <tr>
            <td colspan="2">
              &nbsp;
            </td>
          </tr>
          <tr>
            <td align="left">
                <asp:Button ID="Button4" runat="server" Font-Size="11px" Text="Reporte Entregas Medicamentos"
                    Width="192px" />
                <asp:Button ID="Button1" runat="server" Font-Size="11px" Text="Reporte Medicamentos sin Incluir"
                    Width="192px" />
                <asp:Button ID="Button5" runat="server" Font-Size="11px" Text="Reporte consolidado"
                    Width="192px" />
                </td>
            <td align="right">
                <asp:Button ID="btnConsolidad" runat="server" Text="Finalizar Programación" Font-Size="11px" Width="192px" /></td>
          </tr>
        </table>
          </td>
    </tr>
  </table>
  <br />
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
