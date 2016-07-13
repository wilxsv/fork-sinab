<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantReportesProgramacion.aspx.vb" Inherits="URMIM_frmDetaMantReportesProgramacion"
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
        URMIM -> Programación de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:label runat="server" ID="lblProgramas" Text = "Consultar:"></asp:label>
        <asp:DropDownList ID="cboProgramas" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
          DataTextField="nombre" DataValueField="idPrograma">
          <asp:ListItem Selected="True" Value="0">Todos los medicamentos</asp:ListItem>
          <asp:ListItem Value="-1">Medicamentos excluyendo los de programas</asp:ListItem>
        </asp:DropDownList>
      </td>
    </tr>
    <tr>
      <td>
        <uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" Visible="true"/>
        <%--<asp:Panel ScrollBars="Vertical" Height="200px" CssClass="ScrollPanel" runat="server" ID="pnlGrid">--%>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" DataKeyNames="IDPROGRAMACION, IDPRODUCTO"
          AllowPaging="True" PageSize="15">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="8%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="67%" />
            </asp:BoundField>
            <asp:BoundField DataField="UM" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" Width="5%" />
            </asp:BoundField>
            <asp:BoundField DataField="PRECIOAJUSTADO" HeaderText="Precio Ajustado" DataFormatString="{0:c}">
              <HeaderStyle HorizontalAlign="right" />
              <ItemStyle HorizontalAlign="right" Width="8%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Consultar">
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                  ImageUrl="~/Imagenes/table.png" AlternateText="Consultar" CommandName="Delete"
                  CausesValidation="False" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="9%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido productos para la programación o no se han definido productos
            para el programa o el filtro no ha devuelto datos</EmptyDataTemplate>
        </asp:GridView>
        <%--</asp:Panel>    --%>
      </td>
    </tr>
  </table>
  <br />
  <table width="100%" id="TABLE1" style="height: 112px">
    <tr>
      <td width="100%" align="left" style="height: 23px">
        <asp:Button runat="server" ID="btnRpt1" Text="Reporte VEN" Width="155px" Font-Size="11px" />
        &nbsp;
        <asp:Button runat="server" ID="btnRpt2" Text="Reporte ABC" Width="155px" Font-Size="11px" />
        &nbsp;
        <asp:Button runat="server" ID="btnRpt3" Text="Reporte de Programación" Width="155px"
          Font-Size="11px" /></td>
      <td style="height: 23px">
        <asp:Button runat="server" ID="btnAlternativas" Text="1-Adicionar Alternativas" Width="155px" Font-Size="11px" />
        <hr style="height: 1px"/>
        <asp:Button runat="server" ID="btnConsolidad" Text="2-Iniciar Consolidación" Width="155px" Font-Size="11px" />   
           
          </td></tr>
    <tr>
      <td width="100%" align="left" style="height: 23px">
        <asp:Button runat="server" ID="Button4" Text="Reporte por Producto" Width="155px"
          Font-Size="11px" />
         
        <asp:Button runat="server" ID="btnRpt4" Text="Necesidad por Desab." Width="155px"
          Font-Size="11px" />
        &nbsp;
        <asp:Button runat="server" ID="btnRpt5" Text="Detalle Establecimientos" Width="155px"
          Font-Size="11px" Visible="true" />
      </td>
    </tr>
    <tr>
      <td width="100%" align="left" style="height: 28px">
        <asp:Button runat="server" ID="Button1" Text="Reporte por Establecimiento" Width="155px"
          Font-Size="11px" />
      </td>
    </tr>
  </table>
  <br />
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
