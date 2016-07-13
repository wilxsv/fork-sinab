<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmCatAspectos.aspx.vb" Inherits="frmCatAspectos" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="cmenu">
    <asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI - Certificación de Productos » Catálogo de Aspectos
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <h3>CATALOGO DE ASPECTOS</h3>
    <div style="margin: 10px 0">
         <asp:Button ID="Button1" runat="server" Text="Agregar" OnClick="BtnViewDetails_Click"/>
    </div>
  
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id,idlista"
         GridLines="None"  CssClass="Grid">
          <Columns>
               <asp:BoundField DataField="idlista" HeaderText="" />
            <asp:BoundField DataField="Lista" HeaderText="Lista">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
           
              <asp:BoundField DataField="Orden" HeaderText="Orden" />
            <asp:BoundField DataField="nombre" HeaderText="Aspecto" >
              <ItemStyle HorizontalAlign="Left" Font-Size="Small" />
            </asp:BoundField>
              <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="lnkEdit" runat="server" CssClass="GridEditar"  OnClick="lnkEdit_Click" />
              </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
              <ItemTemplate>
                <asp:LinkButton ID="lnkDelete" runat="server" CssClass="GridBorrar" OnClick="lnkDelete_Click" 
                    OnClientClick="return confirm('¿Está seguro de eliminar este registro?');" />
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
          <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" />
        <RowStyle CssClass="GridListItem" />
        <SelectedRowStyle CssClass="GridListSelectedItem" />
        <EditRowStyle CssClass="GridListEditItem" />
        <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        </asp:GridView>
      

        <asp:HiddenField ID="hfShowPopup" runat="server" />
        
        <ajaxtoolkit:modalpopupextender
          id="mdlPopup" runat="server" backgroundcssclass="ui-widget-overlay ui-front" cancelcontrolid="btnClose"
          popupcontrolid="pnlPopup" targetcontrolid="hfShowPopup">
          </ajaxtoolkit:modalpopupextender>
          
        <asp:Panel ID="pnlPopup" runat="server" Style="display: none"  CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front">
            <div class="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix">
            <
                <asp:Label ID="lblCustomerDetail" runat="server"  class="ui-dialog-title" Text="Nuevo Aspecto:"/>
        </div>
          <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
              <div align="center">
               
               <table>
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
                        <td>
                            Orden:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbOrden" CssClass="numeric"/>
                        </td>
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
        
        
        
        
      
        
        
        
        
    
</asp:Content>

