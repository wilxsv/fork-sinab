<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReportesAbastecimiento.aspx.vb" Inherits="GERENCIA_frmReporteAbastecimiento" %>

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

    <fieldset>
             Tipo de reporte: <asp:RadioButton ID="rd1" runat="server"  Checked="True" GroupName="rdo"/>Abastecimiento&nbsp;
        <asp:RadioButton ID="rd2" runat="server" GroupName="rdo" />Desabastecimiento
        <br />
			    Seleccione un mes/año:
			    <asp:DropDownList ID="cboMes" runat="server">
			      <asp:ListItem Value ="1" Text ="Enero" />
			      <asp:ListItem Value ="2" Text ="Febrero" />
			      <asp:ListItem Value ="3" Text ="Marzo" />
			      <asp:ListItem Value ="4" Text ="Abril" />
			      <asp:ListItem Value ="5" Text ="Mayo" />
			      <asp:ListItem Value ="6" Text ="Junio" />
			      <asp:ListItem Value ="7" Text ="Julio" />
			      <asp:ListItem Value ="8" Text ="Agosto" />
			      <asp:ListItem Value ="9" Text ="Septiembre" />
			      <asp:ListItem Value ="10" Text ="Octubre" />
			      <asp:ListItem Value ="11" Text ="Noviembre" />
			      <asp:ListItem Value ="12" Text ="Diciembre" />
			    </asp:DropDownList> 
			    <asp:DropDownList runat="server" ID="cboAnio"></asp:DropDownList>
			    <asp:Button ID="Button1" runat="server" Text="Consultar" />
                
                
		    </fieldset>
            
            <p>
              <asp:Label runat="server" ID="lblTipo" /><br />
              <asp:Label runat="server" ID="lblFecha" />
            </p>

            <p>
            <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
              CellPadding="2" Width="100%" BackColor="#E0E0E0" ShowFooter="True">
              <HeaderStyle CssClass="GridListHeader" />
              <FooterStyle CssClass="GridListFooter" BackColor="Silver" ForeColor="Black" />
              <PagerStyle CssClass="GridListPager" />
              <RowStyle CssClass="GridListItem" />
              <SelectedRowStyle CssClass="GridListSelectedItem" />
              <EditRowStyle CssClass="GridListEditItem" />
              <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="#E0E0E0" />
              <Columns>
               
                <asp:BoundField DataField="nombre" HeaderText="Hospital" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                </asp:BoundField>
                <asp:BoundField DataField="porcentaje" HeaderText="Porcentaje" DataFormatString="{0:f2}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="abastecimiento" HeaderText="Porcentaje" DataFormatString="{0:f2}" >
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="20%" />
                </asp:BoundField>
             </Columns>
              <EmptyDataTemplate>
                No se encontraron registros de Hospitales para la fecha.</EmptyDataTemplate>
            </asp:GridView>
            </p>
            
            <p>
            <asp:GridView ID="gvLista2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
              CellPadding="2" Width="100%" BackColor="#E0E0E0" ShowFooter="True">
              <HeaderStyle CssClass="GridListHeader" />
              <FooterStyle CssClass="GridListFooter" BackColor="Silver" ForeColor="Black" />
              <PagerStyle CssClass="GridListPager" />
              <RowStyle CssClass="GridListItem" />
              <SelectedRowStyle CssClass="GridListSelectedItem" />
              <EditRowStyle CssClass="GridListEditItem" />
              <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="#E0E0E0" />
              <Columns>
               
                <asp:BoundField DataField="nombre" HeaderText="Regi&#243;n" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="80%" />
                </asp:BoundField>
                <asp:BoundField DataField="porcentaje" HeaderText="Porcentaje" DataFormatString="{0:f2}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="20%" />
                </asp:BoundField>
                <asp:BoundField DataField="abastecimiento" HeaderText="Porcentaje" DataFormatString="{0:f2}" >
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" Width="20%" />
                </asp:BoundField>
             </Columns>
              <EmptyDataTemplate>
                No se encontraron registros de Regiones para la fecha.</EmptyDataTemplate>
            </asp:GridView>
            </p>
      </td>
    </tr>
  </table>    

    

       

</asp:Content>

