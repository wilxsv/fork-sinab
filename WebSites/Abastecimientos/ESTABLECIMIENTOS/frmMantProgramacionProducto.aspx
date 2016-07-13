<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmMantProgramacionProducto.aspx.vb" Inherits="ESTABLECIMIENTOS_frmMantProgramacionProducto"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
      <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        ESTABLECIMIENTOS » Programación de Compras
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
     <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
 
    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:Panel ID="pnlGrid" runat="server" CssClass="ScrollPanel" ScrollBars="Auto" >
              <asp:GridView ID="gvLista" runat="server" CssClass="Grid"  DataKeyNames="IDPROGRAMACION, IDPRODUCTO, IDESTABLECIMIENTO, CONSUMOPROMEDIOAJUSTADO, CANTIDADREGION, CANTIDADALMACEN, COMPRATRANSITO, PRECIO, DESCLARGO, CONSUMOTOTAL, NOOBSERVACION1"
                GridLines="None" CellPadding="4" Width="100%" AutoGenerateColumns="False" 
                    >
                <RowStyle CssClass="GridListItemSmaller"></RowStyle>
                <Columns>
                  <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                    <HeaderStyle HorizontalAlign="Left" ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                    <HeaderStyle HorizontalAlign="Left" Width="100%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                    <HeaderStyle HorizontalAlign="Left" ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="PRECIO" DataFormatString="{0:c}" HeaderText="Precio">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="CONSUMOPROMEDIO" HeaderText="CPM">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                  </asp:BoundField>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="BtnViewDetails" runat="server" AlternateText="Dias Desabastecidos"
                        ImageUrl="../imagenes/date.png" OnClick="BtnViewDetails_Click" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="BtnViewDetails2" runat="server" AlternateText="Demanda insatisfecha"
                        ImageUrl="../imagenes/table.png" OnClick="BtnViewDetails2_Click" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CPM Ajustado">
                    <ItemTemplate>
                      <ew:NumericBox ID="txtCPM" runat="server" Columns="6" TextAlign="Right" Font-Size="Small"></ew:NumericBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Existencia en Estab.">
                    <ItemTemplate>
                      <ew:NumericBox ID="txtCANTIDADREGION" runat="server" Columns="7" TextAlign="Right"
                        Font-Size="Small"></ew:NumericBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Invent Alm. Regional">
                    <ItemTemplate>
                      <ew:NumericBox ID="txtCANTIDADALMACEN" runat="server" Columns="7" TextAlign="Right"
                        Font-Size="Small"></ew:NumericBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Compras en Tr&#225;nsito">
                    <ItemTemplate>
                      <ew:NumericBox ID="txtCOMPRATRANSITO" runat="server" Columns="7" TextAlign="Right"
                        Font-Size="Small"></ew:NumericBox>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                  </asp:TemplateField>
                  <asp:BoundField DataField="COBERTURA" HeaderText="Cobert.">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="CANTIDADCOMPRAR" HeaderText="Cantidad a Comprar">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="MONTOTOTAL" DataFormatString="{0:c}" HeaderText="Monto Total">
                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                  </asp:BoundField>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton runat="server" ID="btnCom" ImageUrl="../imagenes/information.png" Visible="false" AlternateText="Consultar" CommandName="Delete"
                  CausesValidation="False" />  
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="GridListFooter"></FooterStyle>
                <PagerStyle CssClass="GridListPager"></PagerStyle>
                <EmptyDataTemplate>
                  No se han definido productos para la distribucion.
                </EmptyDataTemplate>
                <SelectedRowStyle CssClass="GridListSelectedItem"></SelectedRowStyle>
                <HeaderStyle CssClass="GridListHeaderSmaller"></HeaderStyle>
                <EditRowStyle CssClass="GridListEditItemSmaller"></EditRowStyle>
                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller"></AlternatingRowStyle>
              </asp:GridView>
            </asp:Panel>
            <br />
            <table style="width: 100%">
              <tbody>
                <tr>
                  <td align="left" style="width: 50%">
                    <img alt="" src="../imagenes/date.png" />:: Ajuste por dias desabastecidos<br />
                    <img alt="" src="../imagenes/table.png" />:: Ajuste por demanda insatisfecha
                  </td>
                  <td valign="top" align="right" width="50%">
                    Monto total: $<asp:Label ID="lblMT" runat="server"></asp:Label>
                  </td>
                </tr>
              </tbody>
            </table>
          </ContentTemplate>
        </asp:UpdatePanel>
    
 <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td style="text-align: left; width: 85%">
        <asp:Button runat="server" ID="btnRpt1" Text="Reporte de Programacion" Width="155px"
          Font-Size="12px" />
        &nbsp;
        <asp:Button runat="server" ID="btnRpt2" Text="Reporte VEN" Width="155px" Font-Size="12px" />
        &nbsp;
        <asp:Button runat="server" ID="btnRpt3" Text="Reporte ABC" Width="155px" Font-Size="12px" />
        
        <br /><br />
        <asp:Button runat="server" ID="btnRpt4" Text="Desabastecimiento. Proy." Width="155px"
          Font-Size="12px" />&nbsp;
          <asp:Button runat="server" ID="btnRpt6" Text="Reporte de Observaciones" Width="155px"
          Font-Size="12px" />
      </td>
      <td style="text-align: right; width: 15%" valign="top">
        <asp:Button runat="server" ID="btnFinalizar" Text="Iniciar ajustes" Font-Size="Small"
          Width="155px" OnClientClick="return confirm('Desea iniciar los ajustes?');" />
      </td>
    </tr>
  </table>
  
  <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
  <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
    PopupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
  <asp:Panel ID="pnlPopup" runat="server" Width="500px" Height="200px" Style="display: none"
    BackColor="white">
    <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <div align="center">
          <asp:Label ID="lblCustomerDetail" runat="server" Text="Ajuste por dias desabastecidos"
            BackColor="Navy" ForeColor="white" Width="95%" />
          <asp:Label ID="lblIdPrograma" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdProducto" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblcpm" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdEst" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblca" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblce" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblct" runat="server" Text="" Visible="false" />
          <br />
          <br />
          <asp:Label ID="lblProd" runat="server" Text="" Font-Size="Small" />
          <br />
          <br />
          Dias desabastecidos:
          <asp:TextBox runat="server" ID="txtDiasDesab"></asp:TextBox>
        </div>
        <div align="center" style="width: 95%">
          <br />
          <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" Width="150px" />
          <asp:Button ID="btnClose" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose_Click" />
          <br />
          <asp:Label ID="lblError" runat="server" Text="" Font-Size="Small" ForeColor="red" />
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>
  </asp:Panel>
  <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" />
  <ajaxToolkit:ModalPopupExtender ID="mdlPopup2" runat="server" TargetControlID="btnShowPopup2"
    PopupControlID="pnlPopup2" CancelControlID="btnClose2" BackgroundCssClass="modalBackground" />
  <asp:Panel ID="pnlPopup2" runat="server" Width="500px" Height="200px" Style="display: none"
    BackColor="white">
    <asp:UpdatePanel ID="updPnlCustomerDetail2" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <div align="center">
          <asp:Label ID="lblCustomerDetail2" runat="server" Text="Ajuste por demanda insatisfecha"
            BackColor="Navy" ForeColor="white" Width="95%" />
          <asp:Label ID="lblIdPrograma2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdProducto2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblcpm2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdEst2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblca2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblce2" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblct2" runat="server" Text="" Visible="false" />
          <br />
          <br />
          <asp:Label ID="lblProd2" runat="server" Text="" Font-Size="Small" />
          <br />
          <br />
          Demanda insatisfecha:
          <asp:TextBox runat="server" ID="txtDemandaInsatisfecha"></asp:TextBox>
        </div>
        <div align="center" style="width: 95%">
          <br />
          <asp:Button ID="btnSave2" runat="server" Text="Guardar" OnClick="btnSave2_Click"
            Width="150px" />
          <asp:Button ID="btnClose2" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose2_Click" />
          <br />
          <asp:Label ID="lblError2" runat="server" Text="" Font-Size="Small" ForeColor="red" />
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>
  </asp:Panel>
</asp:Content>
