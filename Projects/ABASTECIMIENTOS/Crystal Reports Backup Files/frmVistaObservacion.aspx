<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmVistaObservacion.aspx.vb" Inherits="URMIM_frmVistaObservacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Observación a Productos</title>
    <link href="../Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="700px" cellpadding="3" cellspacing="3"  >
      <tr>
        <td width="90px" align="left" valign="top">
          <asp:Label runat="server" id="Label1" Text="Establecimiento:" Font-Bold="true"   />
        </td>
        <td align="left" width="610px" >
          <asp:Label runat="server" id="lblNomEst" />
        </td>
      </tr>
      <tr>
        <td align="left">
          <asp:Label runat="server" id="Label2" Text="Código - U/M:"  Font-Bold="true"  />
        </td>
        <td align="left">
          <asp:Label runat="server" id="lblCodProd" />&nbsp;-&nbsp;<asp:Label runat="server" id="lblUM" />
        </td>
      </tr>
      <tr>
        <td valign="top" align="left">
          <asp:Label runat="server" id="Label3" Text="Producto:"  Font-Bold="true"  />
        </td>
        <td align="left">
          <asp:Label runat="server" id="lblNomProd" />
        </td>
      </tr>
      <tr>
        <td valign="top" align="left">
          <asp:Label runat="server" id="Label4" Text="Tipo:"  Font-Bold="true"  />
        </td>
        <td align="left">
          <asp:Label runat="server" id="lblTipo" />
        </td>
      </tr>
      <tr>
        <td colspan="2" >
              <asp:GridView ID="gvLista" runat="server" CssClass="Grid" 
                GridLines="Both" CellPadding="4" Width="700px" AutoGenerateColumns="False" AllowPaging="True">
                <RowStyle CssClass="GridListItemSmaller"></RowStyle>
                <Columns>
                  <asp:BoundField DataField="FECHA" HeaderText="Fecha">
                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" Width="180px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="USUARIO" HeaderText="Usuario">
                    <HeaderStyle HorizontalAlign="Left" Width="180px" VerticalAlign="Top"  ></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                  <asp:BoundField DataField="OBSERVACION" HeaderText="Observacion">
                    <HeaderStyle HorizontalAlign="Left" Width="340px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                  </asp:BoundField>
                </Columns>
                <FooterStyle CssClass="GridListFooter"></FooterStyle>
                <PagerStyle CssClass="GridListPager"></PagerStyle>
                <EmptyDataTemplate>
                  No se han definido productos para la programación.
                </EmptyDataTemplate>
                <SelectedRowStyle CssClass="GridListSelectedItem"></SelectedRowStyle>
                <HeaderStyle CssClass="GridListHeaderSmaller"></HeaderStyle>
                <EditRowStyle CssClass="GridListEditItemSmaller"></EditRowStyle>
                <AlternatingRowStyle CssClass="GridListAlternatingItemSmaller"></AlternatingRowStyle>
              </asp:GridView>
      </td>
      </tr>
    </table>
    </div>
    </form>
</body>
</html>
