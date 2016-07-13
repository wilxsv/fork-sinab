<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmReporte2.aspx.vb" Inherits="UACI_CERTIFICACION_frmReporte2" title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
<table class="CenteredTable" style="width: 100%" cellpadding="0">
    <tr>
      <td class="LinkMenuRuta" colspan="2">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú"></asp:LinkButton>
        UACI -Certificación de Productos &gt; Reportes &gt; Constancia de Productos Certificados</td>
    </tr>
    <tr>
      <td colspan="2">
      </td>
    </tr>
    <tr>
      <td colspan="2">
        <strong>Constancia de Productos Certificados</strong></td>
    </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2" style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
         <ContentTemplate>
        <table class="CenteredTable" style="width: 100%" cellpadding="0">
          <tr>
            <td align="right">
              Proceso:</td>
            <td align="left">
              <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
              </asp:DropDownList>
              <asp:DropDownList ID="DropDownList2" runat="server">
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td colspan="2">
              <hr />
            </td>
          </tr>
      <tr>
      <td align="right">
        Proveedor:</td>
      <td align="left">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
          RepeatDirection="Horizontal">
          <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
          <asp:ListItem Value="1">Proveedor Espec&#237;fico</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label ID="Label1" runat="server" Text="NIT:" Visible="False"></asp:Label><asp:TextBox
          ID="TextBox1" runat="server" MaxLength="14" Visible="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
          Enabled="False" ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
      </tr>
          <tr>
            <td colspan="2">
              <hr />
            </td>
          </tr>
          <tr>
            <td align="right">
              Producto:</td>
            <td align="left">
              <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged"
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                <asp:ListItem Value="1">Producto Espec&#237;fico</asp:ListItem>
              </asp:RadioButtonList>
              <asp:Label ID="Label2" runat="server" Text="Código:" Visible="False"></asp:Label><asp:TextBox
                ID="TextBox2" runat="server" MaxLength="8" Visible="False"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                Enabled="False" ErrorMessage="* Dato Requerido" ValidationGroup="1"></asp:RequiredFieldValidator></td>
          </tr>
          <tr>
            <td colspan="2">
              <hr />
            </td>
          </tr>
          <tr>
            <td align="right">
              </td>
            <td align="left">
              <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal" Visible="False">
                <asp:ListItem Value="0">Todos</asp:ListItem>
                <asp:ListItem Value="1" Selected="True">Certificado</asp:ListItem>
                <asp:ListItem Value="2">No Certificado</asp:ListItem>
              </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td align="right">
            </td>
            <td align="left">
            </td>
          </tr>
            </table>
             </ContentTemplate>
       
     
      </asp:UpdatePanel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="Button1" runat="server" Text="Buscar" ValidationGroup="1" /></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="No existen registros que concuerden con los filtros de búsqueda"
        Visible="False"></asp:Label></td>
  </tr>
  <tr>
    <td colspan="2">
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="btnShowPopup" runat="server" Style="display: none" /><br />
      <ajaxToolkit:ModalPopupExtender ID="mdlPopup" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="btnClose" PopupControlID="pnlPopup" TargetControlID="btnShowPopup">
      </ajaxToolkit:ModalPopupExtender>
      <asp:Panel ID="pnlPopup" runat="server" BackColor="white" BorderColor="Black" BorderStyle="Dashed"
        BorderWidth="3px" Height="150px" Style="display: none" Width="250px">
        <asp:UpdatePanel ID="updPnlCustomerDetail" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <div align="center">
              <asp:Label ID="lblCustomerDetail" runat="server" BackColor="Black" Font-Bold="True"
                ForeColor="White" Text="Seleccione el formato del Reporte" Width="95%"></asp:Label>
              &nbsp;&nbsp;<br />
              <asp:DropDownList ID="DropDownListAjax" runat="server">
                <asp:ListItem Selected="True" Value="0">Formato PDF</asp:ListItem>
                <asp:ListItem Value="1">Formato Word</asp:ListItem>
                <asp:ListItem Value="2">Formato Excel</asp:ListItem>
              </asp:DropDownList>&nbsp;<br />
              <br />
            </div>
            <div align="center" style="width: 95%">
              <br />
              <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Ok" Width="150px" />
              <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Cerrar" Width="150px" />
              <br />
              <asp:Label ID="lblError" runat="server" Font-Size="Small" ForeColor="red" Text=""></asp:Label>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
          </Triggers>
        </asp:UpdatePanel>
      </asp:Panel>
      <br />
    </td>
  </tr>
  </table>
</asp:Content>

