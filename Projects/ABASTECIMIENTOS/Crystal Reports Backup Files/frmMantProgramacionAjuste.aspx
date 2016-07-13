<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmMantProgramacionAjuste.aspx.vb" Inherits="URMIM_frmMantProgramacionAjuste" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="~/Controles/ucFiltrarDatos2.ascx" TagName="ucFiltrarDatos" TagPrefix="uc1" %>
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
        URMIM -> Programación de Compras</td>
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
              Hosp./Región:
            </td>
            <td>
              <asp:DropDownList ID="cboEstablecimientos" runat="server" AppendDataBoundItems="True" Font-Size="12px" Width="450px"   />
              &nbsp;<asp:Button ID="btnAceptar" runat="server" Text="Consultar" Width="72px" />  
              &nbsp;<asp:Button ID="btnCancelar" runat="server" Enabled="False" Text="Cancelar" Width="72px" />
            </td>
          </tr>
        </table> 
      </td>
    </tr>
    <tr>
      <td>
      <asp:Label runat="server" ID="lblEstadoPC" Visible="false"></asp:Label>
      <asp:Label runat="server" ID="lblTextoPC" Visible="true" ForeColor="darkred"></asp:Label>  
      <br /><br />
      <uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" Visible="false"/>
      <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:Panel ID="pnlGrid" runat="server" CssClass="ScrollPanel" ScrollBars="Auto">
          <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
            Width="800px" CellPadding="4" GridLines="Both" DataKeyNames="IDPROGRAMACION, IDPRODUCTO, IDESTABLECIMIENTO, NOOBSERVACION2" AllowPaging="True">
            <HeaderStyle CssClass="GridListHeaderSmaller" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItemSmaller" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItemSmaller" />
            <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller" />
            <Columns>
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo">
                <HeaderStyle HorizontalAlign="Left" Width="65px" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n">
                <HeaderStyle HorizontalAlign="Left" Width="400px" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="DESCRIPCION" HeaderText="U/M">
                <HeaderStyle HorizontalAlign="Left" Width="30px" />
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="PRECIO" HeaderText="Precio" DataFormatString="{0:c4}">
                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADCOMPRAR" HeaderText="Cantidad a Comprar">
                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADCOMPRARAJUSTADA" HeaderText="Cantidad a Comprar Ajustada">
                <HeaderStyle HorizontalAlign="Right" Width="60px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="MONTOTOTALAJUSTADO" HeaderText="Monto Total Ajustado"
                DataFormatString="{0:c4}">
                <HeaderStyle HorizontalAlign="Right" Width="90px" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton runat="server" ID="btnCom" ImageUrl="../imagenes/information.png" Visible="false" AlternateText="Consultar" CommandName="Delete"
                  CausesValidation="False" />  
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:ImageButton ID="BtnViewDetails" runat="server" AlternateText="Observaciones"
                        ImageUrl="../imagenes/note_add.png" OnClick="BtnViewDetails_Click "/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="35px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center" BorderColor="#E0E0E0"></ItemStyle>
                  </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              No se han definido productos para la programación.</EmptyDataTemplate>
          </asp:GridView>
 </asp:Panel>
          </ContentTemplate>
        </asp:UpdatePanel>
      </td>
    </tr>
    <tr>
    </tr>
  </table>
      <table width="100%">
        <tr>
          <td style="width: 387px" valign ="top" >
          <asp:Panel runat="server" id="pnlRpts" Visible ="false" Width="100%" >
            <asp:Button runat="server" ID="btnRpt1" Text="Reporte de Ajustes" Width="180px" />
            &nbsp;
            <asp:Button runat="server" ID="btnRpt2" Text="Reporte Final" Width="180px" /><br /><br />
            <asp:Button id="btnRpt5" runat="server" Width="180px" Text="Reporte de Observaciones" Font-Size="12px"></asp:Button>
            </asp:Panel> 
          </td>
          <td align="right" rowspan ="3" valign="top" >
          <asp:Panel runat="server" id="pnlMT" Visible ="false" Width="100%" >
            Monto total calculado: $<asp:Label runat="server" ID="lblMT"></asp:Label><br />
            Monto total ajustado: $<asp:Label runat="server" ID="lblMTA"></asp:Label><br />
            Diferencia: $<asp:Label runat="server" ID="lblDif"></asp:Label><br />
            </asp:Panel> 
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          </td>
        </tr>
        <tr>
          <td style="width: 387px">
          </td>
        </tr>
        
      </table>
<asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
  <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup"
    PopupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="modalBackground" />
  <asp:Panel ID="pnlPopup" runat="server" Width="600px" Style="display: none"
    BackColor="white">
    <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <div align="center">
          <asp:Label ID="lblCustomerDetail" runat="server" Text="Observación a producto"
            BackColor="Navy" ForeColor="white" Width="100%" />
          <asp:Label ID="lblIdPrograma" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdProducto" runat="server" Text="" Visible="false" />
          <asp:Label ID="lblIdEst" runat="server" Text="" Visible="false" />
          <table width="100%" cellpadding="3" cellspacing="3"  >
              <tr>
                <td width="90px" align="left" valign="top">
                  <asp:Label runat="server" id="Label1" Font-Size="10px" Text="Establecimiento:"   />
                </td>
                <td align="left">
                  <asp:Label runat="server" id="lblNomEst" Font-Size="10px"  />
                </td>
              </tr>
              <tr>
                <td align="left">
                  <asp:Label runat="server" id="Label2" Font-Size="10px" Text="Código - U/M:"   />
                </td>
                <td align="left">
                  <asp:Label runat="server" id="lblCodProd" Font-Size="10px" />&nbsp;-&nbsp;<asp:Label runat="server" id="lblUM" Font-Size="10px" />
                </td>
              </tr>
              <tr>
                <td valign="top" align="left">
                  <asp:Label runat="server" id="Label3" Font-Size="10px" Text="Producto:"   />
                </td>
                <td align="left">
                  <asp:Label runat="server" id="lblNomProd" Font-Size="10px" />
                </td>
              </tr>
              <tr>
                <td valign="top" align="left">
                  <asp:Label runat="server" id="Label4" Font-Size="10px" Text="Observación:"   />
                </td>
                <td align="left">
                  <asp:TextBox ID="txtObservacion" runat="server" MaxLength="500" Width="446px" Rows="4" TextMode="MultiLine" />
                </td>
              </tr>
          </table>
        </div>
        <div align="right" style="width: 95%">
          <br />
          <asp:Button ID="btnSave" runat="server" Text="Guardar" OnClick="btnSave_Click" Width="150px" />
          <asp:Button ID="btnClose" runat="server" Text="Cerrar" Width="150px" OnClick="btnClose_Click" />
          <br />
          <asp:Label ID="lblError" runat="server" Text="" Font-Size="Small" ForeColor="red" />
        </div>
        <br />
      </ContentTemplate>
    </asp:UpdatePanel>
  </asp:Panel>
</asp:Content>
 
