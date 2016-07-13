<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmGarantiaMO.aspx.vb" Inherits="UACI_GARANTIAS_frmGarantiaMO" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Control de Garantías&gt; Registro de garantías de
        <asp:Label ID="Label1" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
  <tr>
    <td colspan="2">
      <strong>REGISTRO DE GARANTÍAS DE 
        <asp:Label ID="Label2" runat="server"></asp:Label></strong></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="Button1" runat="server" Text="Registrar Nueva Garantía" Width="184px" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
          BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idgarantia"
          ForeColor="Black" GridLines="Vertical">
          <Columns>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="Ver Garantía" OnClick="LinkButton1_Click"></asp:LinkButton>
              </ItemTemplate>
              <ItemStyle Font-Size="Smaller" />
            </asp:TemplateField>
            <asp:BoundField DataField="NIT" HeaderText="NIT" >
              <ItemStyle Font-Size="10pt" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Proveedor">
              <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
            </asp:BoundField>
            <asp:BoundField DataField="numcontrato" HeaderText="No.Contrato">
              <ItemStyle Font-Size="10pt" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="modalidadcompra" HeaderText="Modalidad de Compra">
              <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
            </asp:BoundField>
            <asp:BoundField DataField="numproceso" HeaderText="No.Proceso">
              <ItemStyle HorizontalAlign="Left" Font-Size="10pt" />
            </asp:BoundField>
            <asp:BoundField DataField="fechaemision" DataFormatString="{0:d}" HeaderText="Fecha Emisi&#243;n" >
              <ItemStyle Font-Size="10pt" />
            </asp:BoundField>
            <asp:BoundField DataField="fechavto" DataFormatString="{0:d}" HeaderText="Fecha Vencimiento" >
              <ItemStyle Font-Size="10pt" />
            </asp:BoundField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/cerrar.gif"
                  OnClick="BtnViewDetails2_Click" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#CCCCCC" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="Modalpopupextender1" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose2" PopupControlID="Panel2" TargetControlID="btnShowPopup2">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="Panel2" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid"
        BorderWidth="1px" Height="125px" Width="300px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              &nbsp;</div>
            <div align="center">
              <br />
              Esta seguro de eliminar este registro?<br />
              <br />
              <asp:Button ID="btnSave2" runat="server" OnClick="btnSave2_Click" Text="Si" Width="62px" />
              <asp:Button ID="btnClose2" runat="server" OnClick="btnClose2_Click" Text="No" Width="58px" />
              <br />
              <asp:Label ID="lblError2" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave2" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
    </td>
  </tr>
    </table>
</asp:Content>

