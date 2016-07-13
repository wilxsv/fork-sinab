<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmDetaMantProgramacionEntrega.aspx.vb" Inherits="URMIM_frmDetaMantProgramacionEntrega"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>  
    
  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Programación de Compras: Definición de Entregas</td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td style="text-align:left;  " >
        Definir No. de Entregas:&nbsp;
        <asp:DropDownList runat="server" ID="cboEntregasDef"></asp:DropDownList>&nbsp;
        <asp:Button runat="server" ID="btnEntregasDef" Text="Aceptar" />
        <br /><br />
      </td>
    </tr>
    <tr>
      <td align="left">
        <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" Height="130px" Width="380px" ActiveTabIndex="1"  >
          <ajaxToolkit:TabPanel ID="pnl1" runat="server" HeaderText="Una Entrega">
            <ContentTemplate>
              <table width="360px" border="1" cellpadding="1" cellspacing="0" >
                <tr>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">No. de Entrega</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Porcentaje</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Dias</td>
                </tr>
                <tr>
                  <td>1</td>
                  <td>100%</td>
                  <td><ew:NumericBox runat="server" ID="pnl1txtD1" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
              </table>
            </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="pnl2" runat="server" HeaderText="Dos Entregas">
            <ContentTemplate>
              <table width="360" border="1" cellpadding="1" cellspacing="0" >
                <tr>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">No. de Entrega</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Porcentaje</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Dias</td>
                </tr>
                <tr>
                  <td>1</td>
                  <td><ew:NumericBox runat="server" ID="pnl2txtP1" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl2txtD1" PositiveNumber="True" RealNumber="False" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>2</td>
                  <td><ew:NumericBox runat="server" ID="pnl2txtP2" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl2txtD2" PositiveNumber="True" RealNumber="False" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
              </table>
            </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="pnl3" runat="server" HeaderText="Tres Entregas">
            <ContentTemplate>
              <table width="360px" border="1" cellpadding="1" cellspacing="0" >
                <tr>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">No. de Entrega</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Porcentaje</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Dias</td>
                </tr>
                <tr>
                  <td>1</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtP1" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtD1" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>2</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtP2" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtD2" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>3</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtP3" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl3txtD3" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
              </table>
            </ContentTemplate>
          </ajaxToolkit:TabPanel>
          <ajaxToolkit:TabPanel ID="pnl4" runat="server" HeaderText="Cuatro Entregas">
            <ContentTemplate>
              <table width="360px" border="1" cellpadding="1" cellspacing="0" >
                <tr>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">No. de Entrega</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Porcentaje</td>
                  <td style="width:120px; font-weight:bold; background-color:#708090; color:White;">Dias</td>
                </tr>
                <tr>
                  <td>1</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtP1" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtD1" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>2</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtP2" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtD2" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>3</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtP3" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtD3" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
                <tr>
                  <td>4</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtP4" decimalplaces="2" MaxLength="5" Columns="5"></ew:NumericBox>%</td>
                  <td><ew:NumericBox runat="server" ID="pnl4txtD4" PositiveNumber="true" DecimalPlaces="0" RealNumber="false" MaxLength="3" Columns="3"></ew:NumericBox></td>
                </tr>
              </table>
            </ContentTemplate>
          </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>  
      </td>
    </tr>
    <tr>
      <td align="left">
        <table width="380px" >
          <tr>
            <td align="right">
               <asp:Button runat="server" ID="btnInc" Text="Inconsistencias" Width="170px" />&nbsp;
              <asp:Button runat="server" ID="btnGuardar" Text="Guardar" Width="170px" />
            </td>
          </tr>
        </table>
        
      </td> 
     </tr>  
  </table>
  <br />
  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>
