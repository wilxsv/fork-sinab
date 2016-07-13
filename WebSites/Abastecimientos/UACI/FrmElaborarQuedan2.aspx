<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmElaborarQuedan2.aspx.vb" Inherits="FrmElaborarQuedan2" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table align="center" width="100%">
    <tr>
      <td align="left" bgcolor="#b5c7de" width="2%">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>
        &nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Elaborar Quedan" /></td>
    </tr>
    <tr>
      <td width="5%">
        <asp:Label ID="lblcont" runat="server" Visible="False" />&nbsp;
        <asp:Label ID="lblid" runat="server" Visible="False" />
        <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Visible="False" Width="38px" />
      </td>
    </tr>
    <tr>
      <td width="2%">
        &nbsp;<br />
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="Elaborar Quedan" /></td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <asp:Label ID="lblLicitacion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="690px" /><br />
      </td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <table>
          <tr>
            <td align="right">
              <asp:Label ID="Label2" runat="server" Text="N&uacutemero de contrato" /></td>
            <td align="left">
              <asp:Label ID="LblContrato" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label3" runat="server" Text="N&uacutemero de oferta" /></td>
            <td align="left">
              <asp:Label ID="lblOferta" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label4" runat="server" Text="Nombre del proveedor" /></td>
            <td align="left">
              <asp:Label ID="lblProveedor" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="34px" Width="426px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label5" runat="server" Text="Persona" /></td>
            <td align="left">
              <asp:Label ID="lblPersoneria" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label7" runat="server" Text="Fecha finalizaci&oacuten elaboraci&oacuten de contratos" /></td>
            <td align="left">
              <asp:Label ID="lblFechaContrato" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label12" runat="server" Text="Numero de resolucion de adjudicaci&oacuten" /></td>
            <td align="left">
              <asp:Label ID="lblResolucion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label6" runat="server" Text="Fecha resolucion adjudicaci&oacuten" /></td>
            <td align="left">
              <asp:Label ID="lblFechaResolucion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="158px" /></td>
          </tr>
          <tr>
            <td align="right">
              <asp:Label ID="Label11" runat="server" Text="Renglones adjudicados" /></td>
            <td align="left">
              <asp:Label ID="lblRenglones" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="34px" Width="426px" /></td>
          </tr>
        </table>
      </td>
    </tr>
    <tr>
      <td align="center" width="90%" bgcolor="#b5c7de">
        <asp:Label ID="lblmensaje2" runat="server" EnableViewState="False" Text="Solicitudes asociadas a proceso de compra:" /></td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <asp:DataGrid ID="dgLista2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="5">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
            NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:HyperLinkColumn DataNavigateUrlField="IDSOLICITUD" DataNavigateUrlFormatString="~/ESTABLECIMIENTOS/FrmDetaMantSolicitudCompra.aspx?id={0}&amp;flag=consultaProceso"
              HeaderText="Consultar" Text="Consultar" Visible="False" />
            <asp:BoundColumn DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" SortExpression="CORRELATIVO">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="SUMINISTRO" HeaderText="Suministro">
              <HeaderStyle Width="20%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DEPENDENCIA" HeaderText="Dependencia">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" VerticalAlign="Top" />
              <HeaderStyle Width="70%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FUENTE" HeaderText="Fuente">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FECHASOLICITUD" DataFormatString="{0:d}" HeaderText="Fecha Creacion"
              SortExpression="FECHASOLICITUD">
              <HeaderStyle Width="60%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
          </Columns>
        </asp:DataGrid></td>
    </tr>
    <tr>
      <td align="center" width="90%" bgcolor="#b5c7de">
        <asp:Label ID="Label8" runat="server" EnableViewState="False" Text="Fuentes asociadas a Contrato" /></td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <asp:DataGrid ID="dglista3" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Width="35%" PageSize="5">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages"
            NextPageText="Siguiente &gt;&gt;" PrevPageText="&lt;&lt; Anterior" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:BoundColumn DataField="NOMBRE" HeaderText="Fuente">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="70%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="MONTOCONTRATADO" HeaderText="Monto" DataFormatString="{0:c}">
              <HeaderStyle Width="30%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Right" />
            </asp:BoundColumn>
          </Columns>
        </asp:DataGrid></td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <asp:Label ID="Label10" runat="server" Text="Monto total del contrato: " />
        &nbsp;
        <ew:NumericBox ID="lblmonto" runat="server" AutoFormatCurrency="True" ReadOnly="True"
          Width="95px" Enabled="False" MaxLength="12" TextAlign="Right"></ew:NumericBox>
        <br />
      </td>
    </tr>
    <tr>
      <td align="center" bgcolor="#b5c7de" width="90%">
        <asp:Label ID="Label9" runat="server" EnableViewState="False" Text="Garantias asociadas a Contrato" /></td>
    </tr>
    <tr>
      <td align="center" width="90%">
        <asp:DataGrid ID="dgLista" runat="server" AllowPaging="True" AutoGenerateColumns="False"
          CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="5">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:BoundColumn DataField="NUMEROGARANTIA" HeaderText="N&#176; Garantia">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Tipo Garantia" SortExpression="PROVEEDOR" DataField="TIPOGARANTIA">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="30%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="MONTO" DataFormatString="{0:c}" HeaderText="Monto">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FECHARECEPCION" DataFormatString="{0:d}" HeaderText="Fecha de Ingreso">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataFormatString="{0:d}" HeaderText="Fecha de Vencimiento" DataField="FECHAVENCIMIENTO">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="VIGENCIA" HeaderText="Vigencia">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn HeaderText="Estado" DataField="ESTADOGARANTIA">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Width="30%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Elaborar Quedan">
              <ItemTemplate>
                &nbsp;<asp:ImageButton ID="LinkButton1" runat="server" CommandName="Edit" ImageUrl="~/Imagenes/generar.gif" />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idproveedor" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidproveedor" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDPROVEEDOR") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idestablec" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidestablecimiento" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTABLECIMIENTO") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idContrato" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidcontrato" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDCONTRATO") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idtipogarantia" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidtipogarantia" runat="server" Height="15px" Text='<%# DataBinder.Eval(Container, "DataItem.IDTIPOGARANTIA") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="idGarantiaContrato" Visible="False">
              <ItemTemplate>
                <asp:Label ID="lblidgarantiacontrato" runat="server" Height="15px" Text='<%# DataBinder.Eval(Container, "DataItem.IDGARANTIACONTRATO") %>' />
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid>
        <nds:MsgBox ID="MsgBox1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
