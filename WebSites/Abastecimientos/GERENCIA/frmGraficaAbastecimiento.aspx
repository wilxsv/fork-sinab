<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmGraficaAbastecimiento.aspx.vb" Inherits="GERENCIA_frmGraficaAbastecimiento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="SharpPieces.Web.Controls" Namespace="SharpPieces.Web.Controls" TagPrefix="piece" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Abastecimiento -> Abastecimiento por período</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
          
        Tipo de gráfica: <asp:RadioButton ID="rd1" runat="server" Checked="True" GroupName="rdo"/>Abastecimiento&nbsp;
        <asp:RadioButton ID="rd2" runat="server" GroupName="rdo" />Desabastecimiento

           <fieldset>
			    <label for="valueA">Seleccione un período y luego presione:</label>
			    <piece:ExtendedDropDownList ID="valueA" runat="server" />
			    <label for="valueB"></label><asp:Button ID="Button1" runat="server" Text="Consultar" />
                <piece:ExtendedDropDownList ID="valueB" runat="server" />
                
		    </fieldset>
            
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <div width="100%" style="text-align:center" runat="server" id="contenedor">
            <div id="chartdiv" style="height:400px;width:600px"></div>
            </div>
      </td>
    </tr>
  </table>    





</asp:Content>

