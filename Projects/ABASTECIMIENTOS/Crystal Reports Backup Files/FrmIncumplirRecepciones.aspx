<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmIncumplirRecepciones.aspx.vb" Inherits="FrmIncumplirRecepciones" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr class="LinkMenuRuta">
      <td align="left" colspan="2">
        <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton><asp:Label
          ID="LblRuta" runat="server" Text="UACI -> Incumplimiento de Recepciones" />
        <asp:Label ID="Label1" runat="server" Text="V1.0" /></td>
    </tr>
    <tr>
      <td style="height: 18px;" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Label ID="Label2" runat="server" Text="Tipo de Incumplimiento que desea consultar:" /><asp:DropDownList
          ID="DropDownList1" runat="server" Width="201px">
          <asp:ListItem Value="0">Entregas con atrasos</asp:ListItem>
          <asp:ListItem Value="1">Entregas no realizadas</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2" rowspan="2">
        <br />
        <asp:Label ID="Label3" runat="server" Text="Consultar por:" /><br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
          Width="100%" AutoPostBack="True" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
          <asp:ListItem Value="0">Producto</asp:ListItem>
          <asp:ListItem Value="1">Contrato</asp:ListItem>
          <asp:ListItem Value="2">Lugar de asignaci&#243;n</asp:ListItem>
          <asp:ListItem Value="3">Proveedor</asp:ListItem>
        </asp:RadioButtonList><br />
        <asp:Panel ID="pnProducto" runat="server" Width="100%" Visible="False">
          <asp:Label ID="Label4" runat="server" Text="Producto:" />
          <asp:DropDownList ID="ddProducto" runat="server" Width="497px" />
        </asp:Panel>
        <asp:Panel ID="pnContrato" runat="server" Width="100%" Visible="False">
          &nbsp;
          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" DataKeyNames="IDPROVEEDOR,IDCONTRATO">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
              <asp:CommandField SelectText="&gt;&gt;" ShowSelectButton="True">
                <ItemStyle Font-Bold="True" />
              </asp:CommandField>
              <asp:TemplateField HeaderText="Contrato">
                <ItemStyle HorizontalAlign="Left" />
                <ItemTemplate>
                  <asp:Label ID="lblNContrato" runat="server" Text='<%# bind("NUMEROCONTRATO") %>' />
                  <asp:Label ID="lblIDCONTRATO" runat="server" Text='<%# bind("IDCONTRATO") %>' Visible="False" />
                  <asp:Label ID="lblIDPROVEEDOR" runat="server" Text='<%# bind("IDPROVEEDOR") %>' Visible="False" />
                </ItemTemplate>
              </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnAlmacen" runat="server" Width="100%" Visible="False">
          <asp:Label ID="Label6" runat="server" Text="Lugar de Asignación:" />
          <asp:DropDownList ID="ddAlmacen" runat="server" Width="323px">
          </asp:DropDownList></asp:Panel>
        <asp:Panel ID="pnProveedor" runat="server" Width="100%" Visible="False">
          <asp:Label ID="Label7" runat="server" Text="Proveedor:" />
          <asp:DropDownList ID="ddProveedor" runat="server" Width="387px">
          </asp:DropDownList></asp:Panel>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Consultar" Visible="False" />
        <nds:MsgBox ID="MsgBox1" runat="server" />
      </td>
    </tr>
    <tr>
    </tr>
    <tr>
      <td align="center" colspan="2">
      </td>
    </tr>
    <tr>
      <td align="center" colspan="2">
        <asp:Panel ID="pniProducto" runat="server" Width="100%">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            ForeColor="#333333" GridLines="None" Width="760px">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
              <asp:BoundField DataField="RENGLON" HeaderText="Rengl&#243;n" />
              <asp:BoundField DataField="CORRPRODUCTO" HeaderText="C&#243;digo Producto" />
              <asp:BoundField DataField="DESCLARGO" HeaderText="Descripci&#243;n Producto">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="CANTIDADENTREGAS" HeaderText="Cantidad Entregas" />
              <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Contrato" />
              <asp:BoundField DataField="NOMBRECONTRATO" HeaderText="Proveedor">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="NOMBREALMACEN" HeaderText="Almac&#233;n">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="CODIGOPROVEEDOR" HeaderText="C&#243;digo Proveedor" />
              <asp:BoundField DataField="NOMBREPROVEEDOR" HeaderText="Proveedor">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
          <br />
          <br />
          <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="establecimiento,idproveedor,contrato,fechadistribucion,cantidadtotal,preciounitario,numeroentrega,plazoentrega,porcentajeentrega,idproducto,fechalimite,idalmacen,cantidadalmacen,producto,Almacen,proveedor,unidadmedida,renglon,numerocontrato,codigoproducto,cantidadentregadaalmacen,cantidadatrasoalmacen,tiempoatraso,id"
            ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Smaller">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
              <asp:TemplateField HeaderText="Rengl&#243;n">
                <ItemTemplate>
                  <%#Eval("renglon")%>
                </ItemTemplate>
              </asp:TemplateField>
              <asp:BoundField DataField="codigoproducto" HeaderText="C&#243;digo" />
              <asp:BoundField DataField="producto" HeaderText="Producto">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField HeaderText="Entregas" DataField="totalentregas" />
              <asp:BoundField DataField="numerocontrato" HeaderText="Contrato" />
              <asp:BoundField DataField="proveedor" HeaderText="Proveedor">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="numeroentrega" HeaderText="N&#250;mero de Entregas" />
              <asp:BoundField DataField="lote" HeaderText="Lote" />
              <asp:BoundField DataField="almacen" HeaderText="Almac&#233;n">
                <ItemStyle HorizontalAlign="Left" />
              </asp:BoundField>
              <asp:BoundField DataField="cantidadtotal" HeaderText="Cantidad Contratada">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="cantidad" HeaderText="Cantidad Recibida">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:BoundField DataField="cantidadatrasoalmacen" HeaderText="Cantidad Entregada">
                <ItemStyle HorizontalAlign="Right" />
              </asp:BoundField>
              <asp:TemplateField HeaderText="Cantidad No Entregada">
                <ItemTemplate>
                  <%#Eval("cantidadtotal") - Eval("cantidadentregadarecepcion")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad Pendiente">
                <ItemTemplate>
                  <%#Eval("cantidadalmacen") - Eval("cantidadentregadaalmacen")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Cantidad Pendiente">
                <ItemTemplate>
                  <%#Eval("cantidadtotal") - Eval("cantidadentregadarecepcion")%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
              </asp:TemplateField>
              <asp:BoundField DataField="unidadmedida" HeaderText="U/M" />
              <asp:TemplateField HeaderText="Precio Unitario">
                <ItemTemplate>
                  <%#String.Format("{0:c}", Eval("preciounitario"))%>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Valores Totales:&lt;br /&gt; -Contratado&lt;br /&gt; -Entregado&lt;br /&gt; -Pendiente">
                <ItemTemplate>
                  <%#String.Format("{0:c}", (Eval("cantidadtotal") * Eval("preciounitario")))%>
                  <%#String.Format("{0:c}", CDec(Eval("cantidadentregadaalmacen")) * CDec(Eval("preciounitario")))%>
                  <%#String.Format("{0:c}", (Eval("cantidadtotal") - Eval("cantidadentregadaalmacen")) * Eval("preciounitario"))%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Right" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Fechas:&lt;br /&gt; -Entrega&lt;br /&gt; -Recepci&#243;n&lt;br /&gt; -Solicitud CC&lt;br /&gt; -Notificaci&#243;n CC">
                <ItemTemplate>
                  <%#CDate(Eval("fechalimite")).ToShortDateString%>
                  <%#CDate(Eval("fecharecepcion")).ToShortDateString%>
                  <%#CDate(Eval("fechasolicitudinspeccion")).ToShortDateString%>
                  <%#CDate(Eval("fechacertificacion")).ToShortDateString%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="D&#237;as:&lt;br /&gt; -Atraso&lt;br /&gt; -Tiempo Muerto&lt;br /&gt; -Reales">
                <ItemTemplate>
                  <%#CInt(Eval("tiempoatraso"))%>
                  <%#CInt(Eval("tiempomuerto"))%>
                  <%#cint(Eval("tiempoatraso")) - cint(Eval("tiempomuerto"))%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <p style="font-size: small;">
                Para esta consulta aún no hay entregas definidas</p>
            </EmptyDataTemplate>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
          </asp:GridView>
          <br />
          <asp:Button ID="Button2" runat="server" Text="Imprimir" Visible="False" /></asp:Panel>
  </table>
</asp:Content>
