<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmCatProveedores.aspx.vb" Inherits="frmCatProveedores" title="Untitled Page" enableEventValidation="false" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Control de Garantías&gt; Catálogo de Proveedores</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>CATÁLOGO DE PROVEEDORES</strong></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:Button ID="Button1" runat="server" Text="Agregar nuevo Proveedor" OnClick="BtnViewDetails_Click" Width="172px"/>
        <asp:Button ID="Button2" runat="server" Text="Impresión" /></td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
          BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="idproveedor,idestablecimiento"
          ForeColor="Black" GridLines="Vertical">
          <Columns>
            <asp:BoundField DataField="NIT" HeaderText="NIT" >
              <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" >
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="nombreabr" HeaderText="Nombre Abreviado">
              <ItemStyle HorizontalAlign="Left" />
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
          BorderWidth="1px" Height="250px" Style="display: none" Width="500px">
          <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div align="center">
                <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                  ForeColor="White" Text="Nuevo Proveedor:" Width="100%"></asp:Label>
                &nbsp;&nbsp;<table width="100%">
                  <tr>
                    <td align="right" style="width: 100px">
                      Correlativo:</td>
                    <td align="left" style="width: 100px">
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Width="100px"></asp:Label></td>
                  </tr>
                  <tr>
                    <td align="right" style="width: 100px">
                      NIT:</td>
                    <td align="left" style="width: 100px">
                      <asp:TextBox ID="TextBox1" runat="server" MaxLength="14" Width="130px"></asp:TextBox>(sin guiones)</td>
                  </tr>
                  <tr>
                    <td style="width: 100px" align="right">
                      Nombre:</td>
                    <td style="width: 100px" align="left">
                      <asp:TextBox ID="TextBox2" runat="server" MaxLength="200" Width="350px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td align="right" style="width: 100px">
                      Nombre Abreviado:</td>
                    <td align="left" style="width: 100px">
                      <asp:TextBox ID="TextBox3" runat="server" MaxLength="200" Width="350px"></asp:TextBox></td>
                  </tr>
                </table>
              </div>
              <div>
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
        <asp:Button ID="Button3" runat="server" Style="display: none" />&nbsp;<ajaxtoolkit:modalpopupextender
          id="Modalpopupextender2" runat="server" backgroundcssclass="modalBackground" cancelcontrolid="btnCerrar"
          popupcontrolid="Panel2" targetcontrolid="Button3">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel2" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
          BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div align="center">
                <asp:Label ID="lblCustomerDetail3" runat="server" BackColor="Black" Font-Bold="True"
                  ForeColor="White" Text="Seleccione el formato del Reporte" Width="95%"></asp:Label>
                &nbsp;&nbsp;<br />
                <asp:DropDownList ID="DropDownList99" runat="server">
                  <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
                  <asp:ListItem Value="1">Formato Word</asp:ListItem>
                  <asp:ListItem Value="2">Formato Excel</asp:ListItem>
                </asp:DropDownList>&nbsp;<br />
                <br />
              </div>
              <div align="center" style="width: 95%">
                <br />
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Ok" Width="150px" />
                <asp:Button ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" Text="Cerrar"
                  Width="150px" />
                <br />
                <asp:Label ID="lblError3" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
              </div>
            </ContentTemplate>
            <Triggers>
              <asp:PostBackTrigger ControlID="btnOK" />
            </Triggers>
          </asp:UpdatePanel>
        </asp:Panel>
      </td>
    </tr>
  </table>
</asp:Content>

