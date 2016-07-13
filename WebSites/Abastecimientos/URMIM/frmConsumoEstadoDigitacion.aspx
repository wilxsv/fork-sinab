<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmConsumoEstadoDigitacion.aspx.vb" Inherits="URMIM_frmConsumoEstadoDigitacion" title="" %>

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
      <td style="width:100%; border-bottom: solid 1px #CCCCCC; " align="left"   >
        <table style="width:100%" cellpadding="3" cellspacing="3"  >
          <tr>
            <td width="120px">
                Mes/año:
            </td>
            <td>
              <asp:DropDownList runat="server" ID="cboMes" >
                  <asp:ListItem Value="0">[Seleccione un mes]</asp:ListItem>
                  <asp:ListItem Value="1">Enero</asp:ListItem>
                  <asp:ListItem Value="2">Febrero</asp:ListItem>
                  <asp:ListItem Value="3">Marzo</asp:ListItem>
                  <asp:ListItem Value="4">Abril</asp:ListItem>
                  <asp:ListItem Value="5">Mayo</asp:ListItem>
                  <asp:ListItem Value="6">Junio</asp:ListItem>
                  <asp:ListItem Value="7">Julio</asp:ListItem>
                  <asp:ListItem Value="8">Agosto</asp:ListItem>
                  <asp:ListItem Value="9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="10">Octubre</asp:ListItem>
                  <asp:ListItem Value="11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="12">Diciembre</asp:ListItem>
              </asp:DropDownList> / <asp:DropDownList runat="server" ID="cboAnio" >
                <asp:ListItem Value="0">[Seleccione un a&#241;o]</asp:ListItem>
                </asp:DropDownList>
              &nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Consultar" Width="72px" />  
              &nbsp;<asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" Width="72px" />
            </td>
          </tr>
        </table> 
      </td>
    </tr>
    <tr>
      <td runat="server" id="tdDatos" width="100%">
        
      </td>
    </tr>
    
</table> 

</asp:Content>

