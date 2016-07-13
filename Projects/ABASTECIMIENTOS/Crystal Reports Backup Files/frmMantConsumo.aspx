<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantConsumo.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantConsumo" MaintainScrollPositionOnPostback="true" %>

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
              ESTABLECIMIENTOS -> Registro de Consumos y Existencias
            </td>
        </tr>
        <tr>
            <td>
              <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="left">
              <br />
                Almacén/Farmacia: <asp:DropDownList runat="server" ID="cboAlmacen" Width="376px" AppendDataBoundItems="True" />
                <asp:Button runat="server" ID="btnConsA" Text="Seleccionar" Enabled="False" Width="80px" />
                <asp:Button runat="server" ID="btnCancA" Text="Cancelar" Enabled="false" Width="80px" /></td>
        </tr>
        <tr>
            <td align="left" style="height: 91px">
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
                <asp:Button runat="server" ID="b1" Text="Consultar" Enabled="False" />
                &nbsp;
                <asp:Button runat="server" ID="b2" Text="Cancelar" Enabled="false" />
                <br /><br />
                <asp:Label ID="Label1" runat="server" ForeColor="DarkRed" Text="* El mes/año seleccionados no son válidos" Visible="False"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
    &nbsp;<asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<asp:Panel id="pnlGrid" runat="server" CssClass="ScrollPanel" ScrollBars="Auto" ><asp:GridView id="gvLista" runat="server" CssClass="Grid" DataKeyNames="IDALMACEN, IDPRODUCTO, DESCRIPCION, CONSUMOREAL, EXISTENCIA, CONSUMOAJUSTADO, DESCLARGO" GridLines="Both" CellPadding="4" width="950px" AutoGenerateColumns="False">
                          <RowStyle CssClass="GridListItemSmaller"></RowStyle>
                          <Columns>
                            <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                              <HeaderStyle HorizontalAlign="Left" Width="60px"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                              <HeaderStyle HorizontalAlign="Left" Width="465px"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                              <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:ImageButton ID="BtnViewDetails" runat="server" AlternateText="Dias Desabastecidos" ImageUrl="../imagenes/date.png"  OnClick="BtnViewDetails_Click" />
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField>
                              <ItemTemplate>
                                <asp:ImageButton ID="BtnViewDetails2" runat="server" AlternateText="Demanda insatisfecha" ImageUrl="../imagenes/table.png"  OnClick="BtnViewDetails2_Click" />
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Consumo Real">
                              <ItemTemplate>
                                <ew:NumericBox ID="txtConsumo" runat="server" Columns="9" TextAlign="Right" Font-Size="Small" DecimalPlaces="2" MaxLength="7" PositiveNumber="true"></ew:NumericBox>
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CONSUMOREAL" HeaderText="Consumo Real" visible="False">
                              <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CONSUMOAJUSTADO" HeaderText="Consumo Ajustado">
                              <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Existencia">
                              <ItemTemplate>
                                <ew:NumericBox ID="txtExistencia" runat="server" Columns="9" TextAlign="Right" Font-Size="Small" DecimalPlaces="2" MaxLength="7" PositiveNumber="true" Enabled="False"></ew:NumericBox>
                              </ItemTemplate>
                              <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EXISTENCIA" HeaderText="Existencia" visible="False">
                              <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                              <ItemStyle HorizontalAlign="Right"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Eliminar">
                              <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CssClass="GridImagenEliminarItem"
                                  ImageUrl="~/Imagenes/Eliminar.gif" AlternateText="Eliminar el registro" CommandName="Delete"
                                  CausesValidation="False" OnClientClick="return confirm('Realmente desea eliminar el registro?');"  />
                              </ItemTemplate>
                              <ItemStyle HorizontalAlign="Center" Width="5%" />  
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                          </Columns>
                          <FooterStyle CssClass="GridListFooter"></FooterStyle>
                          <PagerStyle CssClass="GridListPager"></PagerStyle>
                          <EmptyDataTemplate>
                            No se han definido productos para el establecimiento.
                          </EmptyDataTemplate>
                          <SelectedRowStyle CssClass="GridListSelectedItem"></SelectedRowStyle>
                          <HeaderStyle CssClass="GridListHeaderSmaller"></HeaderStyle>
                          <EditRowStyle CssClass="GridListEditItemSmaller"></EditRowStyle>
                          <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller"></AlternatingRowStyle>
                        </asp:GridView> &nbsp;</asp:Panel> 
</contenttemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
        </tr>
    </table>
          <TABLE style="WIDTH: 100%"><TBODY><TR><TD align=left width="50%"><IMG alt="" src="../imagenes/date.png" />:: Ajuste por dias desabastecidos <BR /><IMG alt="" src="../imagenes/table.png" />:: Ajuste por demanda insatisfecha </TD><TD align="right"><asp:Button id="btnCobertura" runat="server" text="Reporte de Cobertura" OnClick="btnCobertura_Click" Visible="false" Width="144px" />&nbsp;<asp:Button id="btnReporte" runat="server" text="Reporte Consolidado" OnClick="btnReporte_Click" Visible="false" Width="144px" /></TD></TR></TBODY></TABLE>
    
    <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
    
   <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
    
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" PopupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
    
    <asp:Panel ID="pnlPopup" runat="server" Width="500px" Height="200px" Style="display: none" BackColor="white">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <div align="center">
                  <asp:Label ID="lblCustomerDetail" runat="server" Text="Ajuste por dias desabastecidos" BackColor="Navy" ForeColor="white" Width="95%" />
                  <asp:Label ID="lblIdEstablecimiento" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblIdProducto" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblConsumo" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblUM" runat="server" Text="" visible="false" />
                  
                  <br /><br />
                  <asp:Label ID="lblProd" runat="server" Text="" Font-Size="Small" />
                  <br /><br />
                  Dias desabastecidos: <ew:NumericBox ID="txtDiasDesab" runat="server" Columns="7" TextAlign="Right" Font-Size="Small" MaxLength="2" RealNumber="false"></ew:NumericBox>
                </div>
                <div align="center" style="width:95%">
                  <br />
                    <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" Width="150px" />
                    <asp:Button ID="btnClose" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose_Click" />
                  <br />
                  <asp:Label ID="lblError" runat="server" Text="" Font-Size="Small" ForeColor="red"  />
                </div>   
            </contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    
    <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" />
    
    <ajaxToolkit:ModalPopupExtender ID="mdlPopup2" runat="server" TargetControlID="btnShowPopup2" PopupControlID="pnlPopup2" CancelControlID="btnClose2" BackgroundCssClass="modalBackground" />
    <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="200px" Style="display: none" BackColor="white">
        <asp:UpdatePanel ID="updPnlCustomerDetail2" runat="server" UpdateMode="Conditional">
            <contenttemplate>
                <div align="center">
                  <asp:Label ID="lblCustomerDetail2" runat="server" Text="Ajuste por demanda insatisfecha" BackColor="Navy" ForeColor="white" Width="95%" />
                  <asp:Label ID="lblIdEstablecimiento2" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblIdProducto2" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblConsumo2" runat="server" Text="" visible="false" />
                  <asp:Label ID="lblUM2" runat="server" Text="" visible="false" />
                  
                  <br /><br />
                  <asp:Label ID="lblProd2" runat="server" Text="" Font-Size="Small" />
                  <br /><br />
                  Demanda insatisfecha: <ew:NumericBox ID="txtDemandaIns" runat="server" Columns="7" TextAlign="Right" Font-Size="Small" MaxLength="7" DecimalPlaces="2"></ew:NumericBox>
                </div>
                <div align="center" style="width:95%">
                  <br />
                    <asp:Button ID="btnSave2" runat="server" Text="Guardar" OnClick="btnSave2_Click" Width="150px" />
                    <asp:Button ID="btnClose2" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose2_Click" />
                  <br />
                  <asp:Label ID="lblError2" runat="server" Text="" Font-Size="Small" ForeColor="red"  />
                </div>   
            </contenttemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
