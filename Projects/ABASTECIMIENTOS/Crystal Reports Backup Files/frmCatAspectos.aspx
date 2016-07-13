<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmCatAspectos.aspx.vb" Inherits="frmCatAspectos" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Men�"></asp:LinkButton>
        UACI -Certificaci�n de Productos &gt; Cat�logo de Aspectos</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>CATALOGO DE ASPECTOS</strong></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="BtnViewDetails_Click"/></td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
          BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idaspecto,idlista"
          ForeColor="Black" GridLines="Vertical">
          <Columns>
            <asp:BoundField DataField="lista" HeaderText="Lista">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="idlista" HeaderText="Correlativo" />
            <asp:BoundField DataField="nombre" HeaderText="Aspecto" >
              <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
            </asp:BoundField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/page_edit.png" OnClick="BtnViewDetails_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/cerrar.gif" OnClick="BtnViewDetails2_Click" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <FooterStyle BackColor="#CCCCCC" />
          <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
          <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
          <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td colspan="2">
        
        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
        
        <ajaxtoolkit:modalpopupextender
          id="mdlPopup" runat="server" backgroundcssclass="modalBackground" cancelcontrolid="btnClose"
          popupcontrolid="pnlPopup" targetcontrolid="btnShowPopup">
          </ajaxtoolkit:modalpopupextender>
          
        <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Solid"
          BorderWidth="1px" Height="300px" Style="display: none" Width="600px">
          <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div align="center">
                <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                  ForeColor="White" Text="Nuevo Aspecto:" Width="100%"></asp:Label>
                &nbsp;&nbsp;<table>
                  <tr>
                    <td align="right" style="width: 100px">
                      </td>
                    <td align="left" style="width: 100px">
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Width="100px" Visible="False"></asp:Label></td>
                  </tr>
                  <tr>
                    <td align="right" style="width: 100px">
                      Lista:</td>
                    <td align="left" style="width: 100px">
                      <asp:DropDownList ID="DropDownList1" runat="server">
                      </asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td align="right" style="width: 100px; height: 79px;">
                      Nombre del Aspecto:</td>
                    <td align="left" style="width: 100px; height: 79px;">
                      <asp:TextBox ID="TextBox1" runat="server" Width="450px" Height="162px" TextMode="MultiLine"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                  </tr>
                </table>
              </div>
              <div align="center" style="width: 95%">
                <br />
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Guardar" Width="104px" />
                <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar"
                  Width="104px" />
                <br />
                <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
              </div>
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="btnSave" />
            </Triggers>
          </asp:UpdatePanel>
        </asp:Panel>
        
        
        
        
        <asp:Button ID="btnShowPopup2" runat="server" Style="display: none" />
        <br />
        <ajaxtoolkit:modalpopupextender
          id="Modalpopupextender1" runat="server" backgroundcssclass="modalBackground" cancelcontrolid="btnClose"
          popupcontrolid="Panel1" targetcontrolid="btnShowPopup2">
        </ajaxToolkit:ModalPopupExtender>
        
        <asp:Panel ID="Panel1" runat="server" BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Height="125px" Width="300px">
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
        
        <br />
        &nbsp;
      </td>
    </tr>
  </table>
</asp:Content>

