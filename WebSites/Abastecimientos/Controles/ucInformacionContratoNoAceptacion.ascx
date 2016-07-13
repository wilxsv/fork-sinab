<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucInformacionContratoNoAceptacion.ascx.vb" Inherits="Controles_ucInformacionContratoNoAceptacion" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<table width="100%" cellspacing="2" cellpadding="2" style="background-color: #f5f5f5; " >
  <tr>
    <td colspan="2" style="text-align:left; font-weight:bold; background-color:#dcdcdc ">
      Información de la Modalidad de Compra
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Modalidad de Compra:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblModCompra" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      No. de Modalidad de Compra:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblNoModCompra" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Fuentes de Financiamiento:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblFuenteFinanc" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Responsable de Distribución:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblRespDist" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Resolución de Adjudicación:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblResAdjud" runat="server" /> 
    </td>
  </tr>
  <tr>
    <td colspan="2"style="text-align:left; font-weight:bold; background-color:#dcdcdc   ">
      Información del Contrato
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      No. de Contrato/Orden de Compra:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblNoContrato" runat="server" Font-Bold="True" Font-Size="Small" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Proveedor:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="Small" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Fecha de Distribución:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:Label ID="lblFchDist" runat="server" Font-Bold="True" Font-Size="Small" /> 
    </td>
  </tr>
  <tr>  
    <td colspan="2">
      &nbsp;
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      No. de Informe:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:TextBox ID="txtNoRecepcion" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Fecha de Informe:
    </td>
    <td style="text-align:left; " width="50%">
        <ew:CalendarPopup ID="dtRecepcion" runat="server" Culture="Spanish (El Salvador)">
        </ew:CalendarPopup>
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Guardalmacén:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:TextBox ID="txtGuardalmacen" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; " width="50%">
      Transportista o Enviado por el Proveedor:
    </td>
    <td style="text-align:left; " width="50%">
      <asp:TextBox ID="txtTransportista" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td colspan="2"style="text-align:left; font-weight:bold; background-color:#dcdcdc ">
  Renglones Contratados</td>
  </tr>
  <tr>
    <td colspan="2" align="center" >
    <br />     
        <asp:GridView ID="gvRenglones" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    GridLines="None" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,RENGLON,IDALMACENENTREGA">
                    
             <HeaderStyle CssClass="GridListHeader" />
             <FooterStyle CssClass="GridListFooter" />
             <PagerStyle CssClass="GridListPager" />
             <RowStyle CssClass="GridListItem" />
             <SelectedRowStyle CssClass="GridListSelectedItem" />
             <EditRowStyle CssClass="GridListEditItem" />
             <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                    
             <Columns>
                <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:CommandField>
             
                <asp:BoundField DataField="IDESTABLECIMIENTO" HeaderText="Tipo" Visible="False" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="IDPROVEEDOR" HeaderText="Tipo" Visible="False" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>
                
                <asp:BoundField DataField="IDCONTRATO" HeaderText="Tipo" Visible="False" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>
                        
                <asp:BoundField DataField="IDALMACENENTREGA" HeaderText="Tipo" Visible="False" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>        
                        
                <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>        
                        
                <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>        
                        
                <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Descripci&#243;n Proveedor" Visible="False" >
                    <ItemStyle Font-Size="10px" />
                    <HeaderStyle Font-Size="9px" />
                </asp:BoundField>          
                        
             </Columns>                     
             <EmptyDataTemplate>
               No existen renglones contratados pendientes de entregar
             </EmptyDataTemplate>        
        </asp:GridView>
    
    </td>
  </tr>
  <tr>  
    <td colspan="2">
      &nbsp;
    </td>
  </tr>
</table>