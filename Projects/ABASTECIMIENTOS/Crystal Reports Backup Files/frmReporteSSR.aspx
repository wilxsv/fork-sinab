<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporteSSR.aspx.vb" Inherits="ESTABLECIMIENTOS_frmReporteSSR" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" TagPrefix="nds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <table class="CenteredTable" style="width: 100%;">
        <tr>
            <td class="LinkMenuRuta">&nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
              ESTABLECIMIENTOS -> Reporte Salud Sexual y Reproductiva</td>
        </tr>
        <tr>
            <td>
  &nbsp;</td>
        </tr>
        <tr>
            <td align="left">
              <br />
                Almacén/Farmacia: <asp:DropDownList runat="server" ID="cboAlmacen" Width="376px" AppendDataBoundItems="True" />
                <asp:Button runat="server" ID="btnConsA" Text="Seleccionar" Enabled="False" Width="80px" />
                <asp:Button runat="server" ID="btnCancA" Text="Cancelar" Enabled="false" Width="80px" /></td>
        </tr>
        <tr>
            <td align="left">
                <br />
                Fecha:
                <asp:DropDownList runat="server" ID="cboMes" Enabled="False">
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
                </asp:DropDownList>
                /
                <asp:DropDownList runat="server" ID="cboAnio" Enabled="False" />
    &nbsp; &nbsp;
    <br />
                <asp:Label ID="Label1" runat="server" ForeColor="DarkRed" Text="* El mes/año seleccionados no son válidos" Visible="False"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
  &nbsp;</td>
        </tr>
        <tr>
        </tr>
    </table>
          <TABLE style="WIDTH: 100%"><TBODY><TR><TD align=left colspan="2">
          
    <asp:Button ID="Button2" runat="server" Text="Ver Reporte de Cobertura" OnClick="BtnViewDetails_Click"/>
         &nbsp;&nbsp;&nbsp;</TD></TR></TBODY></TABLE>
          
    <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
    
   <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
    
    <asp:Panel ID="pnlPopup" runat="server" Width="250px" Height="150px" Style="display: none" BackColor="white" BorderColor="Black" BorderStyle="Dashed" BorderWidth="3px">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional" >
            <contenttemplate>
                <div align="center">
                  <asp:Label ID="lblCustomerDetail" runat="server" Text="Seleccione el formato del Reporte" BackColor="Black" ForeColor="White" Width="95%" Font-Bold="True" />
    &nbsp;&nbsp;<br />
    <asp:DropDownList ID="DropDownList1" runat="server">
      <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
      <asp:ListItem Value="1">Formato Word</asp:ListItem>
      <asp:ListItem Value="2">Formato Excel</asp:ListItem>
    </asp:DropDownList>&nbsp;<br /><br />
                </div>
                <div align="center" style="width:95%">
                  <br />
                    <asp:Button ID="btnSave" runat="server" Text="Ok" OnClick="btnSave_Click" Width="150px" />
                    <asp:Button ID="btnClose" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose_Click" />
                  <br />
                  <asp:Label ID="lblError" runat="server" Text="" Font-Size="Small" ForeColor="red"  />
                </div>   
            </contenttemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
  &nbsp;&nbsp;
</asp:Content>
