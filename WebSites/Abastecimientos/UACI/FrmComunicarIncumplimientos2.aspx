<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmComunicarIncumplimientos2.aspx.vb" Inherits="FrmComunicarIncumplimientos2" %>

<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table align="center" width="100%">
    <tr>
      <td align="left" bgcolor="#b5c7de" width="5%">
        &nbsp; &nbsp;&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="UACI -> Comunicar Incumplimientos" /></td>
    </tr>
    <tr>
      <td width="5%">
        <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td width="5%" style="height: 24px">
        &nbsp;&nbsp;
        <cc1:ddlPROVEEDORES ID="DdlPROVEEDORES1" runat="server" Visible="False" Width="100px" />
        <asp:Label ID="lblidcontrato" runat="server" Visible="False" />
        <asp:Label ID="idprov" runat="server" Visible="False" />
        <asp:Label ID="idcontrat" runat="server" Visible="False" />
        <asp:Label ID="idproces" runat="server" Visible="False" />
        <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Visible="False" Width="34px" />
        <cc1:ddlCARGOS ID="DdlCARGOS1" runat="server" Visible="False" Width="32px" />
        <cc1:ddlTIPOCOMPRAS ID="DdlTIPOCOMPRAS1" runat="server" Visible="False" Width="30px" />
        <asp:Label ID="descproc" runat="server" Visible="False" /></td>
    </tr>
    <tr>
      <td width="2%">
        <table width="100%">
          <tr>
            <td align="center" colspan="2">
              &nbsp;<asp:Label ID="Label12" runat="server" CssClass="Titulo" Text="GENERAR NOTA INCUMPLIMIENTO DE CONTRATO" />
            </td>
          </tr>
          <tr>
            <td align="center" bgcolor="#b5c7de" colspan="2">
              <asp:Label ID="Label8" runat="server" Text="Informaci&oacuten necesaria para la generaci&oacuten de la notificaci&oacuten del incumplimiento" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label20" runat="server" Text="N&uacutemero de documento:" Visible="False" /></td>
            <td align="left">
              <asp:Label ID="Lblidnota" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="136px" Visible="False" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label4" runat="server" Text="N&uacutemero de informe:" /></td>
            <td align="left">
              <asp:TextBox ID="TxtNUMEROINFORME" runat="server" Width="125px" MaxLength="19" />
              <asp:Label ID="lblerror" runat="server" ForeColor="#C00000" Text="*Requerido" Visible="False" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px; height: 53px">
              <asp:Label ID="Label1" runat="server" Text="Titulo de documento:" /></td>
            <td align="left" style="height: 53px">
              <asp:TextBox ID="TxtTitulo" runat="server" Height="48px" TextMode="MultiLine" Width="479px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label5" runat="server" Text="Fecha de Elaboraci&oacuten" /></td>
            <td align="left">
              <asp:Label ID="LblFecha" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="176px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label6" runat="server" Text="Nombre a quien va dirigido la nota:" /></td>
            <td align="left">
              <asp:TextBox ID="txtNombreDirigido" runat="server" Width="437px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label14" runat="server" Text="Cargo a quien va dirigido la nota:" /></td>
            <td align="left">
              <asp:TextBox ID="TxtCargoDirigido" runat="server" Width="437px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label15" runat="server" Text="Nombre de quien envia la nota:" /></td>
            <td align="left">
              <asp:Label ID="LblNombreEntrega" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="398px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label16" runat="server" Text="Cargo de quien envia la nota:" /></td>
            <td align="left">
              <asp:Label ID="LblCargoEntrega" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="18px" Width="398px" /></td>
          </tr>
          <tr>
            <td align="left" colspan="2">
            </td>
          </tr>
          <tr>
            <td align="center" bgcolor="#b5c7de" colspan="2">
              <asp:Label ID="Label9" runat="server" Text="Datos del registro" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              &nbsp;<asp:Label ID="Label7" runat="server" Text="N&uacutemero de Proceso de compra" /></td>
            <td align="left">
              <asp:Label ID="LblProcesoCompra" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
            </td>
            <td align="left">
              <asp:Label ID="lblLicitacion" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="40px" Width="454px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              &nbsp;<asp:Label ID="Label2" runat="server" Text="N&uacutemero de contrato" /></td>
            <td align="left">
              <asp:Label ID="LblContrato" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Width="138px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label3" runat="server" Text="Proveedor" /></td>
            <td align="left">
              <asp:Label ID="LblProveedor" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                BorderStyle="Solid" BorderWidth="1px" Height="49px" Width="390px" /></td>
          </tr>
          <tr>
            <td align="right" style="width: 825px">
              <asp:Label ID="Label10" runat="server" Text="Monto" /></td>
            <td align="left">
              <ew:NumericBox ID="Txtmonto" runat="server" AutoFormatCurrency="True" Enabled="False"
                ReadOnly="True" Width="95px" MaxLength="12" TextAlign="Right" /></td>
          </tr>
          <tr>
            <td align="center" bgcolor="#b5c7de" colspan="2">
              <asp:Label ID="Label13" runat="server" Text="Detalle de incumplimientos" /></td>
          </tr>
          <tr>
            <td align="center" colspan="2">
              <asp:DataGrid ID="dgLista1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
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
                  <asp:TemplateColumn HeaderText="Consultar">
                    <ItemTemplate>
                      <asp:ImageButton ID="LinkButton1" runat="server" CommandName="Edit" ImageUrl="~/Imagenes/consulta.gif" />&nbsp;
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Rengl&#243;n">
                    <ItemTemplate>
                      <asp:Label ID="lblidrenglon" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RENGLON") %>' />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Producto">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" />
                    <ItemTemplate>
                      <asp:Label ID="Label3" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.CORRPRODUCTO") %>'
                        Width="114px" />
                      &nbsp;&nbsp;<br />
                      <asp:TextBox ID="TxtProducto" runat="server" Height="41px" ReadOnly="True" Text='<%# DataBinder.Eval(Container, "DataItem.DESCLARGO") %>'
                        TextMode="MultiLine" Width="233px" />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:BoundColumn HeaderText="U/M" DataField="UNIDADMEDIDA">
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" />
                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" />
                  </asp:BoundColumn>
                  <asp:TemplateColumn HeaderText="Precio">
                    <ItemTemplate>
                      <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PRECIOUNITARIO", "{0:c}") %>' />
                    </ItemTemplate>
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Right" />
                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Cantidad Contratado / Entregado / No Entregado">
                    <ItemTemplate>
                      <asp:Label ID="lblCC" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.CANTIDAD") %>'
                        Width="80px" /><br />
                      <asp:Label ID="lblCE" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.ENTREGADO") %>'
                        Width="80px" /><br />
                      <asp:Label ID="lblCNE" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.NOENTREGADO") %>'
                        Width="80px" />
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" Font-Size="Small" Width="15%" />
                    <EditItemTemplate>
                      &nbsp;
                    </EditItemTemplate>
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Right" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="Valor Total Contratado / Entregado / No Entregado">
                    <ItemTemplate>
                      <asp:Label ID="lblVC" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.COSTOTOTAL","{0:c}") %>'
                        Width="88px" /><br />
                      <asp:Label ID="lblVE" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.COSTOENTREGADO","{0:c}") %>'
                        Width="88px" /><br />
                      <asp:Label ID="lblVNE" runat="server" BackColor="Transparent" BorderColor="LightBlue"
                        BorderStyle="Solid" BorderWidth="1px" Text='<%# DataBinder.Eval(Container, "DataItem.COSTONOENTREGADO","{0:c}") %>'
                        Width="88px" />
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Left" Font-Size="Small" Width="15%" />
                    <EditItemTemplate>
                      &nbsp;
                    </EditItemTemplate>
                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                      Font-Underline="False" HorizontalAlign="Right" />
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="idproveedor" Visible="False">
                    <ItemTemplate>
                      <asp:Label ID="lblidproveedor" runat="server" Height="15px" Text='<%# DataBinder.Eval(Container, "DataItem.IDPROVEEDOR") %>' />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="idestablecimiento" Visible="False">
                    <ItemTemplate>
                      <asp:Label ID="lblidestablecimiento" runat="server" Height="15px" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTABLECIMIENTO") %>' />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                  <asp:TemplateColumn HeaderText="idcontrato" Visible="False">
                    <ItemTemplate>
                      <asp:Label ID="lblidcontrato" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDCONTRATO") %>' />
                    </ItemTemplate>
                  </asp:TemplateColumn>
                </Columns>
              </asp:DataGrid></td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
