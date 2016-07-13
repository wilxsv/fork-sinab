<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmAdicionarEspecificacion.aspx.vb" Inherits="ESTABLECIMIENTOS_frmAdicionarEspecificacion" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table align="center" class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="ESTABLECIMIENTOS -> Adicionar Especificación Técnica" />
        </td>
    </tr> </table>
 
      <table width="100%">
    <tr>
      <td style="width: 100px"> 
        <div align="center">
          <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Navy" ForeColor="White"
            Text="Especificación Técnica"></asp:Label>
          <table cellpadding="3" cellspacing="3" width="100%">
            <tr>
              <td align="left">
                <asp:Label ID="Label21" runat="server" Font-Size="10px" Text="Código - U/M:"></asp:Label>
              </td>
              <td align="left">
                <asp:Label ID="lblCodProd" runat="server" Font-Bold="True" Font-Size="10px"></asp:Label>
                -
                <asp:Label ID="lblUM" runat="server" Font-Bold="True" Font-Size="10px"></asp:Label>
                <asp:Label ID="Label7" runat="server" Font-Size="10px" Visible="False"></asp:Label>
                <asp:Label ID="Label1" runat="server" Font-Size="10px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td align="left" valign="top">
                <asp:Label ID="Label31" runat="server" Font-Size="10px" Text="Producto:"></asp:Label>
              </td>
              <td align="left">
                <asp:Label ID="lblNomProd" runat="server" Font-Bold="True" Font-Size="10px"></asp:Label>
              </td>
            </tr>
            <tr>
              <td align="left" valign="top">
                Especificaciones Técnicas
              </td>
              <td align="left">
                &nbsp;<asp:Label ID="Label10" runat="server" Font-Size="10px" Visible="False"></asp:Label></td>
            </tr>
            <tr>
              <td align="left" colspan="2" valign="top">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="idestablecimiento,idproducto,idespecificacion,nombreespecificacion"
                  ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView5_SelectedIndexChanged"
                  Width="650px">
                  <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                  <Columns>
                    <asp:CommandField HeaderText="Seleccionar" SelectText="&gt;&gt;" ShowSelectButton="True" />
                    <asp:BoundField DataField="idespecificacion" HeaderText="No.Especificaci&#243;n">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Nombre Corto">
                      <ItemTemplate>
                        <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click"></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="precio" DataFormatString="{0:c}" HeaderText="Precio">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaactualizacion" DataFormatString="{0:d}" HeaderText="&#218;ltima fecha de Actualizaci&#243;n">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                  </Columns>
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <EditRowStyle BackColor="#999999" />
                  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                  <EmptyDataTemplate>
                    [No existen especificaciones técnicas registradas para este producto]</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
            <tr>
              <td align="left" valign="top" colspan="2">
                <asp:Panel ID="Panel1" runat="server" Visible="False" Width="100%">
                  <table cellpadding="3" cellspacing="3" width="100%">
                    <tr>
                      <td align="left" colspan="2">
                        <strong>
                Detalle de la Especificación Técnica:</strong></td>
                    </tr>
                    <tr>
              <td align="left" valign="top" style="text-align: right">
                <strong>
                Nombre corto:</strong></td>
              <td align="left">
                &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False"></asp:Label></td>
                    </tr>
                    <tr>
              <td align="left" colspan="2" valign="top">
                <strong>
                Especificación:</strong></td>
                    </tr>
                    <tr>
              <td align="left" colspan="2" valign="top">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Width="100%"></asp:Label></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </div>
        <div style="text-align: center">
          &nbsp;<asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cancelar" Width="150px" />
          <br />
          <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
        </div>
        <br />
      
      

 
      </td>
    </tr>
    <tr>
      <td style="width: 100px">
      </td>
    </tr>
    <tr>
      <td style="width: 100px">
      </td>
    </tr>
  </table>
</asp:Content>

