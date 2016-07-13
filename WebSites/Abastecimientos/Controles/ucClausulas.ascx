<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucClausulas.ascx.vb"
  Inherits="Controles_ucClausulas" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="ucMenu.ascx" TagName="ucMenu" TagPrefix="uc1" %>
<%@ Register Src="ucBarraNavegacion.ascx" TagName="ucBarraNavegacion" TagPrefix="uc2" %>
<%@ Register Assembly="ExportTechnologies.WebControls.RTE" Namespace="ExportTechnologies.WebControls.RTE"
  TagPrefix="cc1" %>
<table class="CenteredTable" style="width: 100%">
  <tr>
    <td colspan="2">
      <uc2:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
    </td>
  </tr>
  <tr>
    <td style="width: 100px; text-align: right">
    </td>
    <td style="text-align: right;">
      <asp:Button ID="Button1" runat="server" Text="Eliminar Clausula" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Label ID="Label4" runat="server" Text="Ingrese la información que se solicita:" /></td>
  </tr>
  <tr>
    <td style="text-align: center" colspan="2">
      <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" /></td>
  </tr>
  <tr>
    <td style="text-align: right">
      <asp:Label ID="Label1" runat="server" Text="Nombre:" /></td>
    <td style="width: 100px">
      <asp:TextBox ID="txtNombreClausula" runat="server" Width="487px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreClausula"
        ErrorMessage="Requerido"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td style="text-align: right">
      <asp:Label ID="Label5" runat="server" Text="Tipo de Clausula:" Visible="False" /></td>
    <td style="width: 100px">
      <asp:DropDownList ID="ddlTipoClausula" runat="server" Visible="False">
        <asp:ListItem Selected="True" Value="1">Considerando</asp:ListItem>
        <asp:ListItem Value="2">Recomendaci&#243;n</asp:ListItem>
        <asp:ListItem Value="3">Clausula</asp:ListItem>
      </asp:DropDownList></td>
  </tr>
  <tr>
    <td style="text-align: right">
      <asp:Label ID="Label3" runat="server" Text="Es requerida:" /></td>
    <td style="text-align: left;">
      <asp:CheckBox ID="chkRequerida" runat="server" /></td>
  </tr>
  <tr>
    <td colspan="2" style="text-align: center">
      <asp:Label ID="Label2" runat="server" Text="Ingrese el contenido de la clausula" /></td>
  </tr>
  <tr>
    <td style="width: 100px; text-align: left" rowspan="11" valign="top">
      <asp:DataGrid ID="dgEtiqueta" runat="server" AutoGenerateColumns="False" CellPadding="4"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditItemStyle BackColor="#2461BF" />
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <Columns>
          <asp:BoundColumn DataField="Nombre" HeaderText="Nombre" Visible="False"></asp:BoundColumn>
          <asp:ButtonColumn CommandName="Select" DataTextField="Nombre" HeaderText="Nombre" />
          <asp:BoundColumn DataField="Etiqueta" HeaderText="Etiqueta"></asp:BoundColumn>
        </Columns>
      </asp:DataGrid></td>
    <td style="text-align: left;" rowspan="11" valign="top">
      <cc1:RichTextEditor ID="rteContenido" runat="server" Height="588px" OverrideReturnKey="True"
        RTEResourcesUrl="../RTE_Resources/" />
    </td>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
  </tr>
  <tr>
    <td style="height: 22px; text-align: right">
    </td>
    <td style="width: 100px; height: 22px">
      <nds:MsgBox ID="MsgBox1" runat="server" />
    </td>
  </tr>
</table>
