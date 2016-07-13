<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="RevisionInforme.aspx.vb" MaintainScrollPositionOnPostback="True" Inherits="RevisionInforme" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="nds" Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        Laboratorio CC -> Revisión de Informes</td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P1" runat="server" HorizontalAlign="Center" Visible="False" Width="100%">
          <asp:Panel ID="Panel2" runat="server" CssClass="ScrollPanel" Height="250px" Width="100%">
            <asp:GridView ID="gvEncabezado" runat="server" AutoGenerateColumns="False" CellPadding="4"
              CssClass="Grid" DataKeyNames="IDESTABLECIMIENTO,IdProcesoCompra,IDPROVEEDOR,IDCONTRATO,ESTABLECIMIENTO,NUMPC,NUMERONOTIFICACION,IDINFORME,OBSERVACIONASIGNACION,IDINSPECTOR,IDTIPOINFORME"
              GridLines="None" OnRowCommand="eventoGvEncabezado">
              <RowStyle BackColor="#EFF3FB" />
              <Columns>
                <asp:BoundField DataField="NUMERONOTIFICACION" HeaderText="No.Notificaci&#243;n" />
                <asp:BoundField DataField="FECHANOTIFICACION" DataFormatString="{0:d}" HeaderText="Fecha de notificaci&#243;n">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="inspector" HeaderText="Inspector">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NOMBRE" HeaderText="Proveedor">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PC" HeaderText="Proceso de compra">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="No.Contrato" />
                <asp:BoundField DataField="renglon" HeaderText="Rengl&#243;n">
                  <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="lote" HeaderText="Lote">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="NUMEROINFORME1" HeaderText="No. Informe" />
                <asp:ButtonField CommandName="a" Text="Ver detalle">
                  <ItemStyle HorizontalAlign="Left" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="d" Text="Ver" ButtonType="Image" ImageUrl="~/Imagenes/botones/btnimprimir.jpg" />
                <asp:ButtonField CommandName="c" Text="Rechazar" ButtonType="Image" ImageUrl="~/Imagenes/botones/rechazar.jpg" />
                <asp:ButtonField CommandName="b" Text="Cerrar" ButtonType="Image" ImageUrl="~/Imagenes/botones/cerrar.gif" />
              </Columns>
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <EmptyDataTemplate>
                No hay notificaciones registradas.
              </EmptyDataTemplate>
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <EditRowStyle BackColor="#2461BF" />
              <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
          </asp:Panel>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="P2" runat="server" GroupingText="Detalle de la notificación" Width="100%"
          Visible="False">
          <table class="CenteredTable" style="width: 100%;">
            <tr>
              <td colspan="2" style="font-size: x-small">
              </td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proceso de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblPC" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Establecimiento:</td>
              <td class="DataCell">
                <asp:Label ID="lblEstablecimiento" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                Proveedor:</td>
              <td class="DataCell">
                <asp:Label ID="lblProveedor" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell" style="font-size: x-small">
                No.Contrato/Orden de Compra:</td>
              <td class="DataCell">
                <asp:Label ID="lblNoDoc" runat="server" Font-Bold="True" Font-Size="X-Small" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                No.Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblNumNotificacion" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Notificación:</td>
              <td class="DataCell">
                <asp:Label ID="lblFechaNotificacion" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Asignación:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="CalendarPopup2" runat="server" DisableTextBoxEntry="False"
                  Enabled="False" Visible="False">
                </ew:CalendarPopup>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                  Enabled="False" Visible="False" />
                <asp:Label ID="Label2" runat="server" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Inspector:</td>
              <td class="DataCell">
                <cc1:ddlEMPLEADOS ID="ddlEMPLEADOS1" runat="server" Width="226px" />
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Varios inspectores" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                  DataKeyNames="IDINFORME,NUMERONOTIFICACION,IDPRODUCTO,UNIDAD_MEDIDA,CODIGOPRODUCTO,DESCRIPCIONPRODUCTO1"
                  GridLines="None" OnRowCommand="eventoGv4" Visible="False">
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <RowStyle BackColor="#EFF3FB" />
                  <Columns>
                    <asp:BoundField DataField="RENGLON" HeaderText="Renglon">
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LOTE" HeaderText="No.Lote" />
                    <asp:BoundField DataField="NOMBRECOMERCIAL" HeaderText="Nombre Comercial">
                      <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LABORATORIOFABRICANTE" HeaderText="Laboratorio Fabricante">
                      <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NUMEROUNIDADES" HeaderText="Tama&#241;o Lote">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FECHAFABRICACION2" HeaderText="Fecha Fabricaci&#243;n" />
                    <asp:BoundField DataField="FECHAVENCIMIENTO2" HeaderText="Fecha Vencimiento" />
                    <asp:BoundField DataField="CANTIDADAENTREGAR" HeaderText="Cantidad total a entregar ">
                      <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:ButtonField CommandName="a" Text="Registrar/Actualizar" HeaderText="Informes">
                      <HeaderStyle HorizontalAlign="Right" />
                    </asp:ButtonField>
                    <asp:ButtonField HeaderText="de" Text="Ver " CommandName="b">
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Image" CommandName="c" Text="Cerrar " HeaderText="Inspecci&#243;n"
                      ImageUrl="~/Imagenes/botones/cerrar.gif">
                      <HeaderStyle HorizontalAlign="Left" />
                    </asp:ButtonField>
                  </Columns>
                  <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <EditRowStyle BackColor="#2461BF" />
                  <AlternatingRowStyle BackColor="White" />
                  <EmptyDataTemplate>
                    No hay lotes registrados actualmente</EmptyDataTemplate>
                </asp:GridView>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
    <tr>
      <td>
        <strong><span style="font-size: 12pt">
          <asp:Label ID="lblTitulo" runat="server" Text="Registro de informe de Inspección"
            Visible="False" /></span></strong></td>
    </tr>
    <tr>
      <td>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Detalle del informe" Visible="False"
          Width="100%">
          <table class="CenteredTable" style="width: 100%">
            <tr>
              <td class="LabelCell">
                Fecha de registro del informe:</td>
              <td class="DataCell">
                <ew:CalendarPopup ID="cpFECHAregistroInspeccion" runat="server" Culture="Spanish (El Salvador)"
                  DisableTextBoxEntry="False" GoToTodayText="">
                </ew:CalendarPopup>
                <asp:Label ID="lbl1" runat="server" Font-Bold="True" />
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Origen del medicamento, insumo médico o producto biológico:</td>
              <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
                  <asp:ListItem Value="1">Extranjero</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lbl2" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Tipo de medicamento, insumo médico o producto biológico:</td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList5" runat="server">
                  <asp:ListItem Value="0">Medicamento</asp:ListItem>
                  <asp:ListItem Value="1">Vacuna</asp:ListItem>
                  <asp:ListItem Value="2">Insumos m&#233;dicos</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lbl3" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nombre del medicamento, insumo médico o Producto biológico:</td>
              <td class="DataCell">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Nombre Comercial:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl4" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Laboratorio Fabricante:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox3" runat="server" Width="431px" />
                <asp:Label ID="lbl5" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Suministrante:</td>
              <td class="DataCell">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Small" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                  Lote:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox4" runat="server" Width="99px" /><asp:Label ID="lbl6" runat="server"
                  Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Fabricación:</td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList1" runat="server">
                  <asp:ListItem Value="31/1">Enero</asp:ListItem>
                  <asp:ListItem Value="28/2">Febrero</asp:ListItem>
                  <asp:ListItem Value="31/3">Marzo</asp:ListItem>
                  <asp:ListItem Value="30/4">Abril</asp:ListItem>
                  <asp:ListItem Value="31/5">Mayo</asp:ListItem>
                  <asp:ListItem Value="30/6">Junio</asp:ListItem>
                  <asp:ListItem Value="31/7">Julio</asp:ListItem>
                  <asp:ListItem Value="31/8">Agosto</asp:ListItem>
                  <asp:ListItem Value="30/9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="31/10">Octubre</asp:ListItem>
                  <asp:ListItem Value="30/11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="31/12">Diciembre</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownList2" runat="server">
                  <asp:ListItem Value="1990">1990</asp:ListItem>
                  <asp:ListItem Value="1991">1991</asp:ListItem>
                  <asp:ListItem Value="1992">1992</asp:ListItem>
                  <asp:ListItem Value="1993">1993</asp:ListItem>
                  <asp:ListItem Value="1994">1994</asp:ListItem>
                  <asp:ListItem Value="1995">1995</asp:ListItem>
                  <asp:ListItem Value="1996">1996</asp:ListItem>
                  <asp:ListItem Value="1997">1997</asp:ListItem>
                  <asp:ListItem Value="1998">1998</asp:ListItem>
                  <asp:ListItem Value="1999">1999</asp:ListItem>
                  <asp:ListItem Value="2000">2000</asp:ListItem>
                  <asp:ListItem Value="2001">2001</asp:ListItem>
                  <asp:ListItem Value="2002">2002</asp:ListItem>
                  <asp:ListItem Value="2003">2003</asp:ListItem>
                  <asp:ListItem Value="2004">2004</asp:ListItem>
                  <asp:ListItem Value="2005">2005</asp:ListItem>
                  <asp:ListItem Value="2006">2006</asp:ListItem>
                  <asp:ListItem Value="2007">2007</asp:ListItem>
                  <asp:ListItem Value="2008">2008</asp:ListItem>
                  <asp:ListItem Value="2009">2009</asp:ListItem>
                  <asp:ListItem Value="2010">2010</asp:ListItem>
                  <asp:ListItem Value="2011">2011</asp:ListItem>
                  <asp:ListItem Value="2012">2012</asp:ListItem>
                  <asp:ListItem Value="2013">2013</asp:ListItem>
                  <asp:ListItem Value="2014">2014</asp:ListItem>
                  <asp:ListItem Value="2015">2015</asp:ListItem>
                  <asp:ListItem Value="2016">2016</asp:ListItem>
                  <asp:ListItem Value="2017">2017</asp:ListItem>
                  <asp:ListItem Value="2018">2018</asp:ListItem>
                  <asp:ListItem Value="2019">2019</asp:ListItem>
                  <asp:ListItem Value="2020">2020</asp:ListItem>
                  <asp:ListItem Value="2021">2021</asp:ListItem>
                  <asp:ListItem Value="2022">2022</asp:ListItem>
                  <asp:ListItem Value="2023">2023</asp:ListItem>
                  <asp:ListItem Value="2024">2024</asp:ListItem>
                  <asp:ListItem Value="2025">2025</asp:ListItem>
                  <asp:ListItem Value="2026">2026</asp:ListItem>
                  <asp:ListItem Value="2027">2027</asp:ListItem>
                  <asp:ListItem Value="2028">2028</asp:ListItem>
                  <asp:ListItem Value="2029">2029</asp:ListItem>
                  <asp:ListItem Value="2030">2030</asp:ListItem>
                  <asp:ListItem Value="2031">2031</asp:ListItem>
                  <asp:ListItem Value="2032">2032</asp:ListItem>
                  <asp:ListItem Value="2033">2033</asp:ListItem>
                  <asp:ListItem Value="2034">2034</asp:ListItem>
                  <asp:ListItem Value="2035">2035</asp:ListItem>
                  <asp:ListItem Value="2036">2036</asp:ListItem>
                  <asp:ListItem Value="2037">2037</asp:ListItem>
                  <asp:ListItem Value="2038">2038</asp:ListItem>
                  <asp:ListItem Value="2039">2039</asp:ListItem>
                  <asp:ListItem Value="2040">2040</asp:ListItem>
                  <asp:ListItem Value="2041">2041</asp:ListItem>
                  <asp:ListItem Value="2042">2042</asp:ListItem>
                  <asp:ListItem Value="2043">2043</asp:ListItem>
                  <asp:ListItem Value="2044">2044</asp:ListItem>
                  <asp:ListItem Value="2045">2045</asp:ListItem>
                  <asp:ListItem Value="2046">2046</asp:ListItem>
                  <asp:ListItem Value="2047">2047</asp:ListItem>
                  <asp:ListItem Value="2048">2048</asp:ListItem>
                  <asp:ListItem Value="2049">2049</asp:ListItem>
                  <asp:ListItem Value="2050">2050</asp:ListItem>
                </asp:DropDownList><asp:Label ID="lbl7" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Fecha de Vencimiento:</td>
              <td class="DataCell">
                <asp:DropDownList ID="DropDownList3" runat="server">
                  <asp:ListItem Value="31/1">Enero</asp:ListItem>
                  <asp:ListItem Value="28/2">Febrero</asp:ListItem>
                  <asp:ListItem Value="31/3">Marzo</asp:ListItem>
                  <asp:ListItem Value="30/4">Abril</asp:ListItem>
                  <asp:ListItem Value="31/5">Mayo</asp:ListItem>
                  <asp:ListItem Value="30/6">Junio</asp:ListItem>
                  <asp:ListItem Value="31/7">Julio</asp:ListItem>
                  <asp:ListItem Value="31/8">Agosto</asp:ListItem>
                  <asp:ListItem Value="30/9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="31/10">Octubre</asp:ListItem>
                  <asp:ListItem Value="30/11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="31/12">Diciembre</asp:ListItem>
                </asp:DropDownList><asp:DropDownList ID="DropDownList4" runat="server">
                  <asp:ListItem Value="2008">2008</asp:ListItem>
                  <asp:ListItem Value="2009">2009</asp:ListItem>
                  <asp:ListItem Value="2010">2010</asp:ListItem>
                  <asp:ListItem Value="2011">2011</asp:ListItem>
                  <asp:ListItem Value="2012">2012</asp:ListItem>
                  <asp:ListItem Value="2013">2013</asp:ListItem>
                  <asp:ListItem Value="2014">2014</asp:ListItem>
                  <asp:ListItem Value="2015">2015</asp:ListItem>
                  <asp:ListItem Value="2016">2016</asp:ListItem>
                  <asp:ListItem Value="2017">2017</asp:ListItem>
                  <asp:ListItem Value="2018">2018</asp:ListItem>
                  <asp:ListItem Value="2019">2019</asp:ListItem>
                  <asp:ListItem Value="2020">2020</asp:ListItem>
                  <asp:ListItem Value="2021">2021</asp:ListItem>
                  <asp:ListItem Value="2022">2022</asp:ListItem>
                  <asp:ListItem Value="2023">2023</asp:ListItem>
                  <asp:ListItem Value="2024">2024</asp:ListItem>
                  <asp:ListItem Value="2025">2025</asp:ListItem>
                  <asp:ListItem Value="2026">2026</asp:ListItem>
                  <asp:ListItem Value="2027">2027</asp:ListItem>
                  <asp:ListItem Value="2028">2028</asp:ListItem>
                  <asp:ListItem Value="2029">2029</asp:ListItem>
                  <asp:ListItem Value="2030">2030</asp:ListItem>
                  <asp:ListItem Value="2031">2031</asp:ListItem>
                  <asp:ListItem Value="2032">2032</asp:ListItem>
                  <asp:ListItem Value="2033">2033</asp:ListItem>
                  <asp:ListItem Value="2034">2034</asp:ListItem>
                  <asp:ListItem Value="2035">2035</asp:ListItem>
                  <asp:ListItem Value="2036">2036</asp:ListItem>
                  <asp:ListItem Value="2037">2037</asp:ListItem>
                  <asp:ListItem Value="2038">2038</asp:ListItem>
                  <asp:ListItem Value="2039">2039</asp:ListItem>
                  <asp:ListItem Value="2040">2040</asp:ListItem>
                  <asp:ListItem Value="2041">2041</asp:ListItem>
                  <asp:ListItem Value="2042">2042</asp:ListItem>
                  <asp:ListItem Value="2043">2043</asp:ListItem>
                  <asp:ListItem Value="2044">2044</asp:ListItem>
                  <asp:ListItem Value="2045">2045</asp:ListItem>
                  <asp:ListItem Value="2046">2046</asp:ListItem>
                  <asp:ListItem Value="2047">2047</asp:ListItem>
                  <asp:ListItem Value="2048">2048</asp:ListItem>
                  <asp:ListItem Value="2049">2049</asp:ListItem>
                  <asp:ListItem Value="2050">2050</asp:ListItem>
                </asp:DropDownList><asp:Label ID="lbl8" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                No. de unidades:</td>
              <td class="DataCell">
                <ew:NumericBox ID="NumericBox2" runat="server" DecimalPlaces="2" MaxLength="15" PositiveNumber="True"
                  Text="0" TextAlign="Right" Width="77px" />
                <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" Visible="False" />
                <asp:Label ID="lbl9" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad remitida:</td>
              <td class="DataCell">
                <ew:NumericBox ID="NumericBox1" runat="server" DecimalPlaces="2" MaxLength="15" PositiveNumber="True"
                  Text="0" TextAlign="Right" Width="77px" />
                <cc1:ddlUNIDADMEDIDAS ID="DdlUNIDADMEDIDAS2" runat="server" Visible="False" />
                <asp:Label ID="lbl10" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
              </td>
              <td class="DataCell">
                <asp:Label ID="Label5" runat="server" ForeColor="Red" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Inspección realizada en:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl11" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Guía aérea:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox6" runat="server" Width="99px" />
                <asp:Label ID="lbl12" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Comprobante de Crédito Fiscal No:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox7" runat="server" Width="99px" />
                <asp:Label ID="lbl13" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Pago de análisis:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox8" runat="server" Width="99px" />
                <asp:Label ID="lbl14" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                No. y texto del renglón:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox9" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                  Visible="False" />
                <asp:Label ID="Label9" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Cantidad contratada:</td>
              <td class="DataCell">
                <asp:Label ID="Label8" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Descripción del empaque primario:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl15" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel3" runat="server" GroupingText="Leyenda requerida" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb1" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob1" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl16" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel4" runat="server" GroupingText="Número de registro" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb2" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob2" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl17" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel5" runat="server" GroupingText="Vía de administración" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb3" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob3" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl18" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel6" runat="server" GroupingText="Forma de dilución" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb4" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob4" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl19" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel7" runat="server" GroupingText="Condiciones de almacenamiento"
                  HorizontalAlign="Center" Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb5" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob5" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl20" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel8" runat="server" GroupingText="Número de lote" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb6" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob6" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl21" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel9" runat="server" GroupingText="Fecha de expiración" HorizontalAlign="Center"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td>
                        <asp:RadioButtonList ID="rb7" runat="server" RepeatDirection="Horizontal">
                          <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                          <asp:ListItem Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <asp:TextBox ID="txtob7" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                          TextMode="MultiLine" />
                        <asp:Label ID="lbl22" runat="server" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
            <tr>
              <td class="LabelCell">
                Condiciones de Almacenamiento recomendadas por el fabricante:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox11" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl23" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Condiciones de almacenamiento encontradas en el lugar de inspección:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox12" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl24" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Descripción del producto:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox13" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl25" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Observaciones:</td>
              <td class="DataCell">
                <asp:TextBox ID="TextBox14" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine" />
                <asp:Label ID="lbl26" runat="server" Font-Bold="True" /></td>
            </tr>
            <tr>
              <td class="LabelCell">
                Criterio:</td>
              <td class="DataCell">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal"
                  Enabled="False">
                  <asp:ListItem Value="1">Aceptado</asp:ListItem>
                  <asp:ListItem Value="2">Rechazado</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="lbltipoinforme" runat="server" Visible="False" /></td>
            </tr>
            <tr>
              <td colspan="2">
              </td>
            </tr>
            <tr>
              <td colspan="2">
                <asp:Panel ID="Panel10" runat="server" GroupingText="Información complementaria del informe de inspección"
                  Width="100%">
                  <table class="CenteredTable" style="width: 100%">
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Informe No.:</td>
                      <td class="DataCell">
                        <asp:TextBox ID="txtNUMEROINFORME" runat="server" CssClass="TextBox" MaxLength="10" />
                        <asp:RequiredFieldValidator ID="rfvNUMEROINFORME" runat="server" ControlToValidate="txtNUMEROINFORME"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" Visible="False" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                      </td>
                      <td class="DataCell">
                        <asp:RegularExpressionValidator ID="revNUMEROINFORME" runat="server" ControlToValidate="txtNUMEROINFORME"
                          Display="Dynamic" Text="Formato incorrecto.  Debe ser 9999CC9999: 4 dígitos para el año, las letras CC indicando Control de Calidad y por último 4 dígitos correspondientes al número de informe."
                          ValidationExpression="[0-9][0-9][0-9][0-9][c,C][c,C][0-9][0-9][0-9][0-9]" ValidationGroup="Guardar"></asp:RegularExpressionValidator></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Distribución interna de la muestra" /></td>
                      <td class="DataCell">
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Físico químico:</td>
                      <td class="DataCell">
                        <ew:NumericBox ID="nbCANTIDADFISICOQUIMICO" runat="server" DecimalPlaces="2" MaxLength="9"
                          PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                        <asp:Label ID="txtUM4" runat="server" CssClass="TextBox" />
                        <asp:RequiredFieldValidator ID="rfvCANTIDADFISICOQUIMICO" runat="server" ControlToValidate="nbCANTIDADFISICOQUIMICO"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Microbiología:</td>
                      <td class="DataCell">
                        <ew:NumericBox ID="nbCANTIDADMICROBIOLOGIA" runat="server" DecimalPlaces="2" MaxLength="9"
                          PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                        <asp:Label ID="txtUM5" runat="server" CssClass="TextBox" />
                        <asp:RequiredFieldValidator ID="rfvCANTIDADMICROBIOLOGIA" runat="server" ControlToValidate="nbCANTIDADMICROBIOLOGIA"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        Retención:</td>
                      <td class="DataCell">
                        <ew:NumericBox ID="nbCANTIDADRETENCION" runat="server" DecimalPlaces="2" MaxLength="9"
                          PlacesBeforeDecimal="6" PositiveNumber="True" TextAlign="Right" Width="78px" />
                        <asp:Label ID="txtUM6" runat="server" CssClass="TextBox" />
                        <asp:RequiredFieldValidator ID="rfvCANTIDADRETENCION" runat="server" ControlToValidate="nbCANTIDADRETENCION"
                          Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="2">
                      </td>
                    </tr>
                    <tr>
                      <td class="LabelCell">
                        <asp:Button ID="Button1" runat="server" Text="Guardar información" ValidationGroup="Guardar" /></td>
                      <td class="DataCell">
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" /></td>
                    </tr>
                  </table>
                </asp:Panel>
              </td>
            </tr>
          </table>
        </asp:Panel>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
