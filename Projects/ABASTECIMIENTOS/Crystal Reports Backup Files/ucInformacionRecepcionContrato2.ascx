<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucInformacionRecepcionContrato2.ascx.vb" Inherits="Controles_ucInformacionRecepcionContrato2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<table width="100%" cellspacing="2" cellpadding="2" style="background-color: #f5f5f5; " >
  <tr>
    <td colspan="2" style="text-align:left; font-weight:bold;   ">
      Informaci�n de la Modalidad de Compra
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Modalidad de Compra:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblModCompra" runat="server" Font-Bold="True" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      No. de Modalidad de Compra:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblNoModCompra" runat="server" Font-Bold="True" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Fuentes de Financiamiento:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblFuenteFinanc" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Responsable de Distribuci�n:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblRespDist" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Resoluci�n de Adjudicaci�n:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblResAdjud" runat="server" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
        &nbsp;</td>
    <td style="text-align:left; ">
        &nbsp;</td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Proveedor:
    </td>
    <td style="text-align:left; ">
      <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="Small" /> 
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
        &nbsp;</td>
    <td style="text-align:left; ">
        &nbsp;</td>
  </tr>
  <tr>  
    <td colspan="2">
      &nbsp;
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      No. de Recibo de Recepci�n:
    </td>
    <td style="text-align:left; ">
      <asp:TextBox ID="txtNoRecepcion" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Fecha de Recepci�n:
    </td>
    <td style="text-align:left; ">
        <ew:CalendarPopup ID="dtRecepcion" runat="server" Culture="Spanish (El Salvador)">
        </ew:CalendarPopup>
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Guardalmac�n:
    </td>
    <td style="text-align:left; ">
      <asp:TextBox ID="txtGuardalmacen" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td style="text-align:right; ">
      Transportista o Enviado por el Proveedor:
    </td>
    <td style="text-align:left; ">
      <asp:TextBox ID="txtTransportista" runat="server" />   
    </td>
  </tr>
  <tr>  
    <td colspan="2"style="text-align:left; font-weight:bold;  height: 23px;">
  Renglones Contratados</td>
  </tr>
  <tr>
    <td colspan="2">
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
                    
        </asp:GridView>
    
    </td>
  </tr>
</table>