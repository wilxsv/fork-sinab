<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmConsumoUniversoHospital.aspx.vb" Inherits="URMIM_frmConsumoUniversoHospital" title="" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        <asp:HyperLink runat="server" id="lnkSalir">URMIM</asp:HyperLink>  -> Universo de Medicamento de Hospitales</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td style="width:100%; border-bottom: solid 1px #CCCCCC;" align="left"   >
        <table style="width:100%" cellpadding="3" cellspacing="3"  >
          <tr>
            <td width="90px">
                Hospital:
            </td>
            <td>
              <asp:DropDownList ID="cboEstablecimientos" runat="server" AppendDataBoundItems="True" Font-Size="12px" Width="450px"   />
              &nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Consultar" Width="72px" />  
              &nbsp;<asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" Width="72px" />
            </td>
          </tr>
        </table> 
      </td>
    </tr>
    <tr>
      <td>
        <br />
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" 
          AllowPaging="True" PageSize="15" DataKeyNames="capturado">
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
              <ItemStyle HorizontalAlign="Left" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="IDPRODUCTO" HeaderText="C&#243;digo" Visible="False"></asp:BoundField>
            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="80%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="5%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Capturado">
              <ItemTemplate>
                <asp:Image  ID="imgOK" runat="server" 
                  ImageUrl="~/Imagenes/ok.jpg" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="5%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            No se han definido productos para el establecimiento.</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
</table> 

</asp:Content>

