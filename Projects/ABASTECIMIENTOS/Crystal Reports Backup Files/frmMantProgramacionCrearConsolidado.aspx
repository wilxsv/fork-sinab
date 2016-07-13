<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacionCrearConsolidado.aspx.vb" Inherits="URMIM_frmMantProgramacionCrearConsolidado" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" TagPrefix="nds" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Consolidación Programas de Compras</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" DataKeyNames="FPROGRAMACION, FULTIMO, FCORTE, MESESCPM, MESESPLANEACION, INDICEINFLACION, IDPROGRAMACION" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:BoundField DataField="FPROGRAMACION" HeaderText="Periodo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="FULTIMO" HeaderText="Fin Ultimo Programa" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="FCORTE" HeaderText="Fecha Corte CPM" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="40%" />
            </asp:BoundField>
            <asp:BoundField DataField="MESESCPM" HeaderText="Meses CPM" >
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="MESESPLANEACION" HeaderText="Horizonte Planeación" >
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="INDICEINFLACION" HeaderText="Indice Inflación" >
                <HeaderStyle HorizontalAlign="right" />
                <ItemStyle HorizontalAlign="right" Width="10%" />
            </asp:BoundField> 
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones disponibles</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td style="border-top: solid 1px #CCCCCC; border-bottom: solid 1px #CCCCCC;" >Advertencias</td>
    </tr>
    <tr>
      <td><div align="left" runat="server" id="dvAdvertencia"></div>  </td>
    </tr>
    <tr>
      <td style="border-top: solid 1px #CCCCCC; border-bottom: solid 1px #CCCCCC;" >Errores</td>
    </tr>
    <tr>
      <td>
        <div align="left" runat="server" id="dvErrores"></div>
        <div align="left" runat="server" id="dvTabla"></div>
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td align="right" style="border-top: solid 1px #CCCCCC; " >
        <asp:Button runat="server" ID="btnIniciar" Text="Consolidar" Width="150px" />
      </td>
    </tr>
    
  </table>


  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>

