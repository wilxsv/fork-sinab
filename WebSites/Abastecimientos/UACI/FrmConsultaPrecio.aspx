<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmConsultaPrecio.aspx.vb" Inherits="UACI_FrmConsultaPrecio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consulta de precios</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="100%">
        <tr>
          <td align="center" colspan="2">
            <span style="font-family: Arial">CONSULTA DE PRECIOS</span></td>
        </tr>
        <tr>
          <td style="width: 100px">
          </td>
          <td style="width: 100px">
          </td>
        </tr>
        <tr>
          <td align="right" >
            <span style="font-size: 10pt; font-family: Arial">Código del producto:</span></td>
          <td >
            <asp:TextBox ID="TextBox1" runat="server" MaxLength="8" Width="107px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Buscar" /></td>
        </tr>
        <tr>
          <td >
          </td>
          <td style="width: 100px">
            <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="10pt" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
          <td align="right" >
            <span style="font-size: 10pt; font-family: Arial">
              <asp:Label ID="Label7" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="False">Código:</asp:Label></span></td>
          <td style="width: 100px">
            <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
          <td align="right" > 
            <span style="font-size: 10pt; font-family: Arial">
              <asp:Label ID="Label8" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="False">Nombre:</asp:Label></span></td>
          <td>
            <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
          <td align="right" >
            <span style="font-size: 10pt; font-family: Arial">
              <asp:Label ID="Label9" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="False">Unidad de Medida:</asp:Label></span></td>
          <td style="width: 100px">
            <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
        </tr>
        <tr>
          <td align="right" >
          </td>
          <td >
          </td>
        </tr>
        <tr>
          <td align="center" colspan="2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DESCRIPCION_PROVEEDOR"
              Font-Names="Arial" Font-Size="10pt" CellPadding="4" ForeColor="#333333" GridLines="None">
              <Columns>
                <asp:CommandField SelectText="Ver Descripci&#243;n " ShowCancelButton="False" ShowSelectButton="True" />
                <asp:BoundField DataField="PROVEEDOR" HeaderText="Proveedor" >
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="CONTRATO" HeaderText="Contrato" >
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PC" HeaderText="Proceso de Compra" >
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PRECIO" HeaderText="Precio de compra" DataFormatString="{0:c}" >
                  <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
              </Columns>
              <RowStyle BackColor="#EFF3FB" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" />
              <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
          </td>
        </tr>
        <tr>
          <td align="right" >
            <span style="font-size: 10pt; font-family: Arial">
              <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="False" Font-Bold="True">Descripción del proveedor:</asp:Label></span></td>
          <td >
            <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="10pt" Visible="False" Font-Bold="True" ForeColor="Navy"></asp:Label></td>
        </tr>
      </table>
    
    </div>
    </form>
</body>
</html>
