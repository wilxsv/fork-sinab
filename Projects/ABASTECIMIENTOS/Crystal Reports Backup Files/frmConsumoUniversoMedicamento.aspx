<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmConsumoUniversoMedicamento.aspx.vb" Inherits="URMIM_frmConsumoUniversoMedicamento" title="" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        <asp:HyperLink runat="server" id="lnkSalir">URMIM</asp:HyperLink>  -> Hospitales por Medicamento (Consumos y Existencias)</td>
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
                Código:
            </td>
            <td>
              <asp:TextBox runat="server" ID="txtCodigo" Text = "" MaxLength="8" Columns ="8" />
              &nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Consultar" Width="72px" />  
              &nbsp;<asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" Width="72px" />
            </td>
          </tr>
        </table> 
      </td>
    </tr>
    <tr>
      <td>
        <table width="100%" align="left" runat="server" id="tblaDatos" style="border-bottom: solid 1px #CCCCCC;">
          <tr>
            <td width="120px" align="left">
              Código:
            </td>
            <td align="left">
              <asp:Label runat="server" ID="lblCodigo" />
            </td>
          </tr>
          <tr>
            <td align="left">
              Descripción:
            </td>
            <td align="left">
              <asp:Label runat="server" ID="lblDescripcion" />
            </td>
          </tr>
          <tr>
            <td align="left">
              U/M:
            </td>
            <td align="left">
              <asp:Label runat="server" ID="lblUM" />
            </td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" GridLines="Both" Width="100%" PageSize="15" DataKeyNames="capturado">
          <HeaderStyle CssClass="GridListHeaderSmaller" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItemSmaller" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItemSmaller" />
          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
          <Columns>
            <asp:BoundField DataField="NOMBRE" HeaderText="Hospital">
              <HeaderStyle HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" Width="90%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Capturado">
              <ItemTemplate>
                <asp:Image  ID="imgOK" runat="server" 
                  ImageUrl="~/Imagenes/ok.jpg" />
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" Width="10%" />
              <HeaderStyle HorizontalAlign="Center" />
            </asp:TemplateField>
          </Columns>
          <EmptyDataTemplate>
            Ningún Hospital ha definido el medicamento o el código no existe</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
</table> 

</asp:Content>

