<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacionInconsistencias.aspx.vb" Inherits="URMIM_frmMantProgramacionInconsistencias" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

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
      <td>
        <h3>
          <asp:Label runat="server" ID="lblTitulo" />
        </h3>
      </td>
    </tr>
    <tr>
      <td>
        <table width="100%" >
          <tr>
            <td width="15%" align="left">Programación:</td>
            <td width="85%" align="left"><asp:Label runat="server" ID="lblNProgramacion" /></td>
          </tr>
        </table> 
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="Both" Width="100%" AllowPaging="True" DataKeyNames="IDPROGRAMACION,ESTADO" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
              <ItemTemplate>
               <asp:CheckBox runat="server" id="chkSelect" OnCheckedChanged="chk1_CheckedChanged" AutoPostBack="true" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="7%" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="PERIODO" HeaderText="Periodo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="7%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="75%" />
            </asp:BoundField>
              <asp:BoundField DataField="DETALLEESTADO" HeaderText="Estado" >
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Width="11%" />
              </asp:BoundField>
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones de compra.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="right" style="height: 26px">
        <asp:Button runat="server" ID="btnComparar" Text = "Verificar" />
      </td>
    </tr>
    <tr>
      <td align="right">
        &nbsp;
      </td>
    </tr>
    <tr>
      <td align="left">
        <asp:label runat="server" ID="lblTit2" />
        <br /><br />
        <asp:GridView ID="gvLista2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="Both" Width="100%" AllowPaging="True" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="Código" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="7%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="75%" />
            </asp:BoundField>
              <asp:BoundField DataField="UM" HeaderText="U/M" >
                  <HeaderStyle HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" Width="11%" />
              </asp:BoundField>
         </Columns>
          <EmptyDataTemplate>
            No se detectaron inconsistencias</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
  </table>



</asp:Content>

