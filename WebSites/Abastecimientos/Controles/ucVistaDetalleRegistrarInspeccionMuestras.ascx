<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleRegistrarInspeccionMuestras.ascx.vb"
  Inherits="Controles_ucVistaDetalleRegistrarInspeccionMuestras" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="nds" Namespace="Cooperator.Framework.Web.Controls" Assembly="Cooperator.Framework.Web" %>
<%@ Register TagPrefix="uc1" TagName="ucFiltrarDatos" Src="~/Controles/ucFiltrarDatos.ascx" %>
<table class="CenteredTable" style="width: 100%;">
  <tr>
    <td colspan="2">
      <asp:Panel ID="plSeleccionarRenglon" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td colspan="2" style="text-align: right;">
              <asp:LinkButton ID="lbVerTodos" runat="server" Text="Ver todos" Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <uc1:ucFiltrarDatos ID="ucFiltrarDatos1" runat="server" />
              <asp:GridView ID="gvProveedores" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="80%" AllowPaging="True" PageSize="5" DataKeyNames="IDPROVEEDOR">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;"
                        CausesValidation="False" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="NOMBREPROVEEDOR" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
                </Columns>
                <EmptyDataTemplate>
                  No se encontraron proveedores.</EmptyDataTemplate>
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:GridView ID="gvContratos" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="80%" AllowPaging="True" PageSize="5" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,MODALIDADCOMPRA,NUMEROMODALIDADCOMPRA,FECHADISTRIBUCION,NUMERORESOLUCION"
                Visible="False">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;"
                        CausesValidation="False" />
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                      <%#Eval("MODALIDADCOMPRA").ToString + " " + Eval("NUMEROMODALIDADCOMPRA").ToString%>
                    </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="NUMEROCONTRATO" HeaderText="Contrato" ItemStyle-HorizontalAlign="Center" />
                  <asp:BoundField DataField="ESTABLECIMIENTO" HeaderText="Establecimiento" ItemStyle-HorizontalAlign="Left" />
                </Columns>
                <EmptyDataTemplate>
                  No se encontraron contratos para el proveedor seleccionado.</EmptyDataTemplate>
              </asp:GridView>
            </td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <uc1:ucFiltrarDatos ID="UcFiltrarDatos2" runat="server" Visible="false" />
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:GridView ID="gvRenglones" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="80%" AllowPaging="True" PageSize="5" DataKeyNames="IDESTABLECIMIENTO,IDPROVEEDOR,IDCONTRATO,RENGLON"
                Visible="False">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select" Text="&gt;&gt;"
                        CausesValidation="False" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:TemplateField>
                  <asp:BoundField DataField="RENGLON" HeaderText="Renglón" ItemStyle-HorizontalAlign="Center" />
                  <asp:BoundField DataField="DESCLARGO" HeaderText="Nombre genérico" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundField DataField="DESCRIPCIONPROVEEDOR" HeaderText="Nombre comercial" ItemStyle-HorizontalAlign="Left" />
                  <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Right" />
                  <asp:BoundField DataField="UNIDADMEDIDA" HeaderText="U. M." ItemStyle-HorizontalAlign="Center" />
                </Columns>
                <EmptyDataTemplate>
                  No se encontraron renglones para el contrato seleccionado.</EmptyDataTemplate>
              </asp:GridView>
            </td>
          </tr>
          <tr>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblTIPOINFORME" runat="server" Text="Tipo Informe:" Visible="False" /></td>
            <td class="DataCell">
              <cc1:ddlTIPOINFORMES ID="ddlTIPOINFORMES1" runat="server" Visible="False" />
              <asp:Label ID="txtTIPOINFORME" runat="server" Visible="False" ForeColor="Red" /></td>
          </tr>
          <tr>
          </tr>
          <tr>
            <td colspan="2">
              <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Visible="False" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="lblTIPOINFORME1" runat="server" Text="Tipo Informe:" Visible="False" /></td>
    <td class="DataCell">
      <asp:Label ID="txtTIPOINFORME1" runat="server" Visible="False" ForeColor="Red" /></td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plDatosContrato" runat="server" GroupingText="Datos del contrato:"
        Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label5" runat="server" Text="Proveedor:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtPROVEEDOR1" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCONTRATO" runat="server" Text="Contrato:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtCONTRATO" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblESTABLECIMIENTOCONTRATO" runat="server" Text="Establecimiento:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtESTABLECIMIENTO" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHADISTRIBUCIONCONTRATO" runat="server" Text="Fecha de distribución:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtFECHADISTRIBUCIONCONTRATO" runat="server" Text="" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblRENGLON" runat="server" Text="Renglón:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtRENGLON" runat="server" />
              <asp:Label ID="txtESPECIFICACIONES" runat="server" CssClass="TextBox" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblMODALIDADCOMPRA" runat="server" /></td>
            <td class="DataCell">
              <asp:Label ID="txtNUMEROMODALIDADCOMPRA" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNUMEROMODIFICATIVA" runat="server" Text="Modificativas:" Visible="False" /></td>
            <td class="DataCell">
              <asp:GridView ID="gvModificativas" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="100%" Visible="False">
                <Columns>
                  <asp:BoundField DataField="NUMEROMODIFICATIVA" HeaderText="N&#250;mero modificativa">
                    <HeaderStyle Width="50%" />
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="FECHAMODIFICATIVA" HeaderText="Fecha" DataFormatString="{0:d}"
                    HtmlEncode="False">
                    <HeaderStyle Width="50%" />
                    <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                </Columns>
              </asp:GridView>
              <asp:Label ID="lblModificativas" runat="server" Text="No se han registrado." Visible="False" />
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblRESOLUCION" runat="server" Text="Resolución modificativa de Adjudicación:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtRESOLUCION" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblIDSOLICITUDCOTIZACION" runat="server" Text="idsolicitudcotizacion:"
                Visible="False" /></td>
            <td class="DataCell">
              <asp:Label ID="txtIDSOLICITUDCOTIZACION" runat="server" CssClass="TextBox" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCANTIDADCONTRATADA" runat="server" Text="Cantidad contratada:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtCANTIDADCONTRATADA" runat="server" CssClass="TextBox" />
              <asp:Label ID="txtUM1" runat="server" CssClass="TextBox" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plDatosAdicionalesContrato" runat="server" GroupingText="Datos adicionales del contrato:"
        Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNUMERORECEPCION" runat="server" Text="Número de recepción:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtNUMERORECEPCION" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblGUIAAEREA" runat="server" Text="Guía aérea:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtGUIAAEREA" runat="server" CssClass="TextBox" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label3" runat="server" Text="Comprobante de Crédito Fiscal No:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtCCF" runat="server" CssClass="TextBox" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plSolicitudRecoleccion" runat="server" GroupingText="Inspección y recolección:"
        Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHASOLICITUDINSPECCION" runat="server" Text="Fecha de solicitud de inspección:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFECHASOLICITUDINSPECCION" runat="server" DisableTextBoxEntry="False"
                GoToTodayText="" Culture="Spanish (El Salvador)" />
              <asp:RequiredFieldValidator ID="rfvFECHASOLICITUDINSPECCION" runat="server" Display="dynamic"
                ControlToValidate="cpFECHASOLICITUDINSPECCION" ValidationGroup="Guardar" Text="Requerido" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHARECOLECCIONMUESTRA" runat="server" Text="Fecha de recolección de muestra:"
                Visible="False" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFECHARECOLECCIONMUESTRA" runat="server" DisableTextBoxEntry="False"
                GoToTodayText="" Visible="False" Culture="Spanish (El Salvador)" />
              <asp:RequiredFieldValidator ID="rfvFECHARECOLECCIONMUESTRA" runat="server" Display="dynamic"
                ControlToValidate="cpFECHARECOLECCIONMUESTRA" Text="Requerido" ValidationGroup="Guardar"
                Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFECHASOLICITUDINSPECCION" runat="server" Text="La fecha de solicitud no puede ser anterior a la de liberación del contrato."
                ControlToValidate="cpFECHASOLICITUDINSPECCION" Operator="GreaterThanEqual" Type="Date"
                ValidationGroup="Guardar" Display="Dynamic" Visible="False" />
              <asp:CompareValidator ID="cvFECHARECOLECCIONMUESTRA" runat="server" Text="La fecha de recolección debe ser posterior a la de solicitud de inspección."
                ControlToCompare="cpFECHASOLICITUDINSPECCION" ControlToValidate="cpFECHARECOLECCIONMUESTRA"
                Operator="GreaterThan" Type="Date" ValidationGroup="Guardar" Display="Dynamic"
                Visible="False" /><br />
              <asp:CompareValidator ID="cvFECHASOLICITUDINSPECCION1" runat="server" ControlToValidate="cpFECHASOLICITUDINSPECCION"
                Text="La fecha de solicitud de inspección no puede ser posterior a hoy." Display="Dynamic"
                Type="Date" Operator="LessThanEqual" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plTituloInforme" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="TituloLeftCell">
              <asp:Label ID="lblINFORME" runat="server" Text="Informe:" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plNumeroInforme" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNUMEROINFORME" runat="server" Text="Número de informe:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtNUMEROINFORME" runat="server" CssClass="TextBox" MaxLength="10" />
              <asp:RequiredFieldValidator ID="rfvNUMEROINFORME" runat="server" Display="dynamic"
                ControlToValidate="txtNUMEROINFORME" Text="Requerido" ValidationGroup="Guardar"
                Visible="False" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:RegularExpressionValidator ID="revNUMEROINFORME" runat="server" ControlToValidate="txtNUMEROINFORME"
                Text="Formato incorrecto.  Debe ser 9999CC9999: 4 dígitos para el año, las letras CC indicando Control de Calidad y por último 4 dígitos correspondientes al número de informe."
                Display="Dynamic" ValidationExpression="[0-9][0-9][0-9][0-9][c,C][c,C][0-9][0-9][0-9][0-9]"
                ValidationGroup="Guardar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plInforme" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label1" runat="server" Text="Origen del medicamento, insumo médico o producto biológico:" /></td>
            <td class="DataCell">
              &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Nacional</asp:ListItem>
                <asp:ListItem Value="1">Extranjero</asp:ListItem>
              </asp:RadioButtonList></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label2" runat="server" Text="Tipo de medicamento, insumo médico o producto biológico:" /></td>
            <td class="DataCell">
              <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem Value="0">Medicamento</asp:ListItem>
                <asp:ListItem Value="1">Vacuna</asp:ListItem>
                <asp:ListItem Value="2">Insumos m&#233;dicos</asp:ListItem>
              </asp:DropDownList></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNOMBREMEDICAMENTO" runat="server" Text="Nombre genérico del medicamento, insumo médico o producto biológico:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtNOMBREMEDICAMENTO" runat="server" CssClass="TextBox" Font-Bold="True" />
              <asp:RequiredFieldValidator ID="rfvNOMBREMEDICAMENTO" runat="server" Display="dynamic"
                ControlToValidate="txtNOMBREMEDICAMENTO" Text="Requerido" ValidationGroup="Guardar"
                Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNOMBRECOMERCIAL" runat="server" Text="Nombre comercial:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox1" runat="server" CssClass="TextBoxMultiLine" MaxLength="100"
                TextMode="MultiLine" />
              <asp:RequiredFieldValidator ID="rfvNOMBRECOMERCIAL" runat="server" Display="dynamic"
                ControlToValidate="TextBox1" Text="Requerido" ValidationGroup="Guardar" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblLABORATORIOFABRICANTE" runat="server" Text="Laboratorio fabricante:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLABORATORIOFABRICANTE" runat="server" CssClass="TextBoxMultiLine"
                MaxLength="100" TextMode="MultiLine" />
              <asp:RequiredFieldValidator ID="rfvLABORATORIOFABRICANTE" runat="server" Display="dynamic"
                ControlToValidate="txtlaboratoriofabricante" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblPROVEEDOR" runat="server" Text="Suministrante:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtPROVEEDOR" runat="server" CssClass="TextBox" />
              <asp:RequiredFieldValidator ID="rfvPROVEEDOR" runat="server" Display="dynamic" ControlToValidate="txtPROVEEDOR"
                Text="Requerido" ValidationGroup="Guardar" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblLOTE" runat="server" Text="Lote:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtLOTE" runat="server" CssClass="TextBox" MaxLength="15" />
              <asp:RequiredFieldValidator ID="rfvLOTE" runat="server" Display="dynamic" ControlToValidate="txtLOTE"
                Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHAFABRICACION" runat="server" Text="Fecha de fabricación:" /></td>
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
                <asp:ListItem Value="/1990">1990</asp:ListItem>
                <asp:ListItem Value="/1991">1991</asp:ListItem>
                <asp:ListItem Value="/1992">1992</asp:ListItem>
                <asp:ListItem Value="/1993">1993</asp:ListItem>
                <asp:ListItem Value="/1994">1994</asp:ListItem>
                <asp:ListItem Value="/1995">1995</asp:ListItem>
                <asp:ListItem Value="/1996">1996</asp:ListItem>
                <asp:ListItem Value="/1997">1997</asp:ListItem>
                <asp:ListItem Value="/1998">1998</asp:ListItem>
                <asp:ListItem Value="/1999">1999</asp:ListItem>
                <asp:ListItem Value="/2000">2000</asp:ListItem>
                <asp:ListItem Value="/2001">2001</asp:ListItem>
                <asp:ListItem Value="/2002">2002</asp:ListItem>
                <asp:ListItem Value="/2003">2003</asp:ListItem>
                <asp:ListItem Value="/2004">2004</asp:ListItem>
                <asp:ListItem Value="/2005">2005</asp:ListItem>
                <asp:ListItem Value="/2006">2006</asp:ListItem>
                <asp:ListItem Value="/2007">2007</asp:ListItem>
                <asp:ListItem Value="/2008">2008</asp:ListItem>
                <asp:ListItem Value="/2009">2009</asp:ListItem>
                <asp:ListItem Value="/2010">2010</asp:ListItem>
                <asp:ListItem Value="/2011">2011</asp:ListItem>
                <asp:ListItem Value="/2012">2012</asp:ListItem>
                <asp:ListItem Value="/2013">2013</asp:ListItem>
                <asp:ListItem Value="/2014">2014</asp:ListItem>
                <asp:ListItem Value="/2015">2015</asp:ListItem>
                <asp:ListItem Value="/2016">2016</asp:ListItem>
                <asp:ListItem Value="/2017">2017</asp:ListItem>
                <asp:ListItem Value="/2018">2018</asp:ListItem>
                <asp:ListItem Value="/2019">2019</asp:ListItem>
                <asp:ListItem Value="/2020">2020</asp:ListItem>
                <asp:ListItem Value="/2021">2021</asp:ListItem>
                <asp:ListItem Value="/2022">2022</asp:ListItem>
                <asp:ListItem Value="/2023">2023</asp:ListItem>
                <asp:ListItem Value="/2024">2024</asp:ListItem>
                <asp:ListItem Value="/2025">2025</asp:ListItem>
                <asp:ListItem Value="/2026">2026</asp:ListItem>
                <asp:ListItem Value="/2027">2027</asp:ListItem>
                <asp:ListItem Value="/2028">2028</asp:ListItem>
                <asp:ListItem Value="/2029">2029</asp:ListItem>
                <asp:ListItem Value="/2030">2030</asp:ListItem>
                <asp:ListItem Value="/2031">2031</asp:ListItem>
                <asp:ListItem Value="/2032">2032</asp:ListItem>
                <asp:ListItem Value="/2033">2033</asp:ListItem>
                <asp:ListItem Value="/2034">2034</asp:ListItem>
                <asp:ListItem Value="/2035">2035</asp:ListItem>
                <asp:ListItem Value="/2036">2036</asp:ListItem>
                <asp:ListItem Value="/2037">2037</asp:ListItem>
                <asp:ListItem Value="/2038">2038</asp:ListItem>
                <asp:ListItem Value="/2039">2039</asp:ListItem>
                <asp:ListItem Value="/2040">2040</asp:ListItem>
                <asp:ListItem Value="/2041">2041</asp:ListItem>
                <asp:ListItem Value="/2042">2042</asp:ListItem>
                <asp:ListItem Value="/2043">2043</asp:ListItem>
                <asp:ListItem Value="/2044">2044</asp:ListItem>
                <asp:ListItem Value="/2045">2045</asp:ListItem>
                <asp:ListItem Value="/2046">2046</asp:ListItem>
                <asp:ListItem Value="/2047">2047</asp:ListItem>
                <asp:ListItem Value="/2048">2048</asp:ListItem>
                <asp:ListItem Value="/2049">2049</asp:ListItem>
                <asp:ListItem Value="/2050">2050</asp:ListItem>
              </asp:DropDownList></td>
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
              <asp:Label ID="lblFECHAVENCIMIENTO" runat="server" Text="Fecha de vencimiento:" /></td>
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
                <asp:ListItem Value="/2008">2008</asp:ListItem>
                <asp:ListItem Value="/2009">2009</asp:ListItem>
                <asp:ListItem Value="/2010">2010</asp:ListItem>
                <asp:ListItem Value="/2011">2011</asp:ListItem>
                <asp:ListItem Value="/2012">2012</asp:ListItem>
                <asp:ListItem Value="/2013">2013</asp:ListItem>
                <asp:ListItem Value="/2014">2014</asp:ListItem>
                <asp:ListItem Value="/2015">2015</asp:ListItem>
                <asp:ListItem Value="/2016">2016</asp:ListItem>
                <asp:ListItem Value="/2017">2017</asp:ListItem>
                <asp:ListItem Value="/2018">2018</asp:ListItem>
                <asp:ListItem Value="/2019">2019</asp:ListItem>
                <asp:ListItem Value="/2020">2020</asp:ListItem>
                <asp:ListItem Value="/2021">2021</asp:ListItem>
                <asp:ListItem Value="/2022">2022</asp:ListItem>
                <asp:ListItem Value="/2023">2023</asp:ListItem>
                <asp:ListItem Value="/2024">2024</asp:ListItem>
                <asp:ListItem Value="/2025">2025</asp:ListItem>
                <asp:ListItem Value="/2026">2026</asp:ListItem>
                <asp:ListItem Value="/2027">2027</asp:ListItem>
                <asp:ListItem Value="/2028">2028</asp:ListItem>
                <asp:ListItem Value="/2029">2029</asp:ListItem>
                <asp:ListItem Value="/2030">2030</asp:ListItem>
                <asp:ListItem Value="/2031">2031</asp:ListItem>
                <asp:ListItem Value="/2032">2032</asp:ListItem>
                <asp:ListItem Value="/2033">2033</asp:ListItem>
                <asp:ListItem Value="/2034">2034</asp:ListItem>
                <asp:ListItem Value="/2035">2035</asp:ListItem>
                <asp:ListItem Value="/2036">2036</asp:ListItem>
                <asp:ListItem Value="/2037">2037</asp:ListItem>
                <asp:ListItem Value="/2038">2038</asp:ListItem>
                <asp:ListItem Value="/2039">2039</asp:ListItem>
                <asp:ListItem Value="/2040">2040</asp:ListItem>
                <asp:ListItem Value="/2041">2041</asp:ListItem>
                <asp:ListItem Value="/2042">2042</asp:ListItem>
                <asp:ListItem Value="/2043">2043</asp:ListItem>
                <asp:ListItem Value="/2044">2044</asp:ListItem>
                <asp:ListItem Value="/2045">2045</asp:ListItem>
                <asp:ListItem Value="/2046">2046</asp:ListItem>
                <asp:ListItem Value="/2047">2047</asp:ListItem>
                <asp:ListItem Value="/2048">2048</asp:ListItem>
                <asp:ListItem Value="/2049">2049</asp:ListItem>
                <asp:ListItem Value="/2050">2050</asp:ListItem>
              </asp:DropDownList>
            </td>
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
              <asp:Label ID="lblNUMEROUNIDADES" runat="server" Text="Número de unidades:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="nbNUMEROUNIDADES" runat="server" PositiveNumber="True" Width="88px"
                TextAlign="Right" MaxLength="9" DecimalPlaces="2" PlacesBeforeDecimal="6" />
              <asp:Label ID="txtUM2" runat="server" />
              <asp:RequiredFieldValidator ID="rfvNUMEROUNIDADES" runat="server" ControlToValidate="nbNUMEROUNIDADES"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCANTIDADREMITIDA" runat="server" Text="Cantidad remitida:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="nbCANTIDADREMITIDA" runat="server" PositiveNumber="True" Width="88px"
                TextAlign="Right" MaxLength="9" DecimalPlaces="2" PlacesBeforeDecimal="6" />
              <asp:Label ID="txtUM3" runat="server" />
              <asp:RequiredFieldValidator ID="rfvCANTIDADREMITIDA" runat="server" ControlToValidate="nbCANTIDADREMITIDA"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvNUMEROUNIDADES" runat="server" ControlToValidate="nbNUMEROUNIDADES"
                Display="Dynamic" Text="El número de unidades debe ser mayor a cero." Operator="GreaterThanEqual"
                Type="Double" ValueToCompare="0" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvCANTIDADREMITIDA" runat="server" ControlToValidate="nbCANTIDADREMITIDA"
                Display="Dynamic" Text="La cantidad remitida debe ser mayor a cero." Operator="GreaterThanEqual"
                Type="Double" ValueToCompare="0" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvCANTIDADREMITIDA1" runat="server" ControlToValidate="nbCANTIDADREMITIDA"
                ControlToCompare="nbNUMEROUNIDADES" Display="Dynamic" Text="La cantidad remitida debe ser menor al número de unidades del lote."
                Operator="LessThanEqual" Type="Double" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblESTABLECIMIENTOREMITE" runat="server" Text="Inspección realizada en:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtESTABLECIMIENTOREMITE" runat="server" CssClass="TextBoxMultiLine"
                MaxLength="60" TextMode="MultiLine" />
              <asp:RequiredFieldValidator ID="rfvESTABLECIMIENTOREMITE" runat="server" ControlToValidate="txtESTABLECIMIENTOREMITE"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plAceptacion" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label9" runat="server" Text="Descripción empaque colectivo:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox6" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                MaxLength="200" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox6"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label8" runat="server" Text="Número de empaque colectivos:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox5" runat="server" CssClass="TextBox" Width="39px" MaxLength="2" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox5"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label7" runat="server" Text="Descripción empaque secundario:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox4" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                MaxLength="200" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox4"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label6" runat="server" Text="Número de empaques secundarios:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox3" runat="server" CssClass="TextBox" Width="36px" MaxLength="2" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="Número de empaque primario (N):" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox2" runat="server" CssClass="TextBox" Width="35px" MaxLength="2" />
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDESCRIPCIONEMPAQUE" runat="server" Text="Descripción del empaque primario:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDESCRIPCIONEMPAQUE" runat="server" CssClass="TextBoxMultiLine"
                TextMode="MultiLine" MaxLength="200" />
              <asp:RequiredFieldValidator ID="rfvDESCRIPCIONEMPAQUE" runat="server" ControlToValidate="TextBox1"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblLEYENDAREQUERIDA" runat="server" Text="Leyenda requerida:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbLEYENDAREQUERIDA" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNUMEROREGISTRO" runat="server" Text="Número de registro:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbNUMEROREGISTRO" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblVIAADMINISTRACION" runat="server" Text="Vía de administración:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbVIAADMINISTRACION" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFORMADISOLUCION" runat="server" Text="Forma de dilución:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbFORMADISOLUCION" runat="server" AutoPostBack="True" OnCheckedChanged="cbFORMADISOLUCION_CheckedChanged" /><br />
              <asp:TextBox ID="txtDescripcionDilucion" runat="server" CssClass="TextBoxMultiLine"
                MaxLength="100" TextMode="MultiLine" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCONDICIONESALMACENAMIENTO" runat="server" Text="Condiciones de almacenamiento:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbCONDICIONESALMACENAMIENTO" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblNUMEROLOTE" runat="server" Text="Número de lote:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbNUMEROLOTE" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHAEXPIRACION" runat="server" Text="Fecha de expiración:" /></td>
            <td class="DataCell">
              <asp:CheckBox ID="cbFECHAEXPIRACION" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblOTROSEMPAQUES" runat="server" Text="Otros empaques:" /></td>
            <td class="DataCell" style="vertical-align: middle;" valign="middle">
              <asp:CheckBox ID="cbOTROSEMPAQUES" runat="server" />
              <asp:TextBox ID="txtDESCRIPCIONOTROSEMPAQUES" runat="server" CssClass="TextBoxMultiLine"
                MaxLength="100" TextMode="MultiLine" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDESCRIPCIONPRODUCTO" runat="server" Text="Descripción del producto:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDESCRIPCIONPRODUCTO" runat="server" CssClass="TextBoxMultiLine"
                TextMode="MultiLine" MaxLength="400" />
              <asp:RequiredFieldValidator ID="rfvDESCRIPCIONPRODUCTO" runat="server" ControlToValidate="txtDESCRIPCIONPRODUCTO"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="TituloLeftCell" colspan="2">
              <asp:Label ID="lblDistribucionInternaMuestra" runat="server" Text="Distribución interna de la muestra:" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCANTIDADFISICOQUIMICO" runat="server" Text="Fisicoquímico:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="nbCANTIDADFISICOQUIMICO" runat="server" PositiveNumber="True"
                Width="78px" TextAlign="Right" MaxLength="9" DecimalPlaces="2" PlacesBeforeDecimal="6" />
              <asp:Label ID="txtUM4" runat="server" CssClass="TextBox" />
              <asp:RequiredFieldValidator ID="rfvCANTIDADFISICOQUIMICO" runat="server" ControlToValidate="nbCANTIDADFISICOQUIMICO"
                Display="Dynamic" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCANTIDADMICROBIOLOGIA" runat="server" Text="Microbiología:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="nbCANTIDADMICROBIOLOGIA" runat="server" PositiveNumber="True"
                Width="78px" TextAlign="Right" MaxLength="9" DecimalPlaces="2" PlacesBeforeDecimal="6" />
              <asp:Label ID="txtUM5" runat="server" CssClass="TextBox" />
              <asp:RequiredFieldValidator ID="rfvCANTIDADMICROBIOLOGIA" runat="server" Display="dynamic"
                ControlToValidate="nbCANTIDADMICROBIOLOGIA" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCANTIDADRETENCION" runat="server" Text="Retención:" /></td>
            <td class="DataCell">
              <ew:NumericBox ID="nbCANTIDADRETENCION" runat="server" PositiveNumber="True" Width="78px"
                TextAlign="Right" MaxLength="9" DecimalPlaces="2" PlacesBeforeDecimal="6" />
              <asp:Label ID="txtUM6" runat="server" CssClass="TextBox" />
              <asp:RequiredFieldValidator ID="rfvCANTIDADRETENCION" runat="server" Display="dynamic"
                ControlToValidate="nbCANTIDADRETENCION" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
            </td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label10" runat="server" Text="Condiciones de almacenamiento recomendadas por el fabricante:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox7" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                MaxLength="200" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblDESCRIPCIONCONDICIONESALMACENAMIENTO" runat="server" Text="Condiciones de almacenamiento encontradas en el lugar de inspección:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtDESCRIPCIONCONDICIONESALMACENAMIENTO" runat="server" CssClass="TextBoxMultiLine"
                TextMode="MultiLine" MaxLength="200" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label11" runat="server" Text="Bibliografía para la realización del muestreo:" /></td>
            <td class="DataCell">
              <asp:Label ID="Label12" runat="server" Text="Military stándar -105-D" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label13" runat="server" Text="Nivel de inspección utilizable:" /></td>
            <td class="DataCell">
              <asp:RadioButtonList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"
                TextAlign="Left">
                <asp:ListItem Value="1">normal</asp:ListItem>
                <asp:ListItem Value="2">reducido</asp:ListItem>
                <asp:ListItem Value="3">riguroso</asp:ListItem>
              </asp:RadioButtonList>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="dynamic"
                ControlToValidate="CheckBoxList1" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label14" runat="server" Text="Número de unidades a muestrear(n):" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox8" runat="server" CssClass="TextBox" Width="84px" MaxLength="6" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label15" runat="server" Text="Nivel de calidad aceptable a utilizar:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox9" runat="server" CssClass="TextBox" Width="207px" MaxLength="50" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label16" runat="server" Text="Rango de aceptación (Ac) y Rango de rechazo (Re):" /></td>
            <td class="DataCell">
              <asp:TextBox ID="TextBox10" runat="server" CssClass="TextBox" Width="207px" MaxLength="50" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label17" runat="server" Text="Cálculos:" /></td>
            <td class="DataCell">
            </td>
          </tr>
          <tr>
            <td class="LabelCell" colspan="2">
              <asp:TextBox ID="TextBox11" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                MaxLength="50" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plRechazo" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="TituloLeftCell" colspan="2">
              &nbsp;
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <table class="CenteredTable" style="width: 100%;">
                <tr>
                  <td class="LabelCell">
                    <asp:Label ID="lblMotivosNoAceptacion" runat="server" Text="Motivos de la no aceptación del producto:" /></td>
                  <td class="DataCell">
                    <asp:TextBox ID="txtMotivoNoAceptacion" runat="server" CssClass="TextBoxMultiLine"
                      TextMode="MultiLine" MaxLength="200" />
                    <asp:RequiredFieldValidator ID="rfvMotivosNoAceptacion" runat="server" Display="dynamic"
                      ControlToValidate="txtMotivoNoAceptacion" Text="Requerido" ValidationGroup="Guardar" /></td>
                </tr>
              </table>
            </td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:GridView ID="gvMotivosNoAceptacion" runat="server" CssClass="Grid" AutoGenerateColumns="False"
                CellPadding="4" GridLines="None" Width="80%">
                <HeaderStyle CssClass="GridListHeader" />
                <FooterStyle CssClass="GridListFooter" />
                <PagerStyle CssClass="GridListPager" />
                <RowStyle CssClass="GridListItem" />
                <SelectedRowStyle CssClass="GridListSelectedItem" />
                <EditRowStyle CssClass="GridListEditItem" />
                <AlternatingRowStyle CssClass="GridListAlternatingItem" />
                <Columns>
                  <asp:TemplateField HeaderText="Motivo">
                    <ItemTemplate>
                      <%#Eval("DESCRIPCION")%>
                    </ItemTemplate>
                    <FooterTemplate>
                      <cc1:ddlMOTIVOSNOACEPTACION ID="ddlMOTIVOSNOACEPTACION1" runat="server" />
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Left" />
                  </asp:TemplateField>
                  <asp:TemplateField Visible="false">
                    <ItemTemplate>
                      <asp:LinkButton ID="lbEliminar" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Eliminar" />
                    </ItemTemplate>
                    <FooterTemplate>
                      <asp:LinkButton ID="lbAgregar" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Agregar" />
                    </FooterTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                  </asp:TemplateField>
                </Columns>
              </asp:GridView>
            </td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plNoInspeccion" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="TituloLeftCell" colspan="2">
              <asp:Label ID="lblNoInspeccion" runat="server" Text="Motivos de no inspección:" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblMOTIVOSNOINSPECCION" runat="server" Text="Motivo por el cual no procede la inspección:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtMOTIVOSNOINSPECCION" runat="server" CssClass="TextBoxMultiLine"
                TextMode="MultiLine" MaxLength="200" />
              <asp:RequiredFieldValidator ID="rfvMOTIVOSNOINSPECCION" runat="server" Display="dynamic"
                ControlToValidate="txtMOTIVOSNOINSPECCION" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plRepresentanteProveedor" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblREPRESENTANTE" runat="server" Text="Representante del Proveedor:"
                Visible="False" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtREPRESENTANTEPROVEEDOR" runat="server" CssClass="TextBox" MaxLength="50"
                Width="493px" Visible="False" />
              <asp:RequiredFieldValidator ID="rfvREPRESENTANTEPROVEEDOR" runat="server" Display="dynamic"
                ControlToValidate="txtREPRESENTANTEPROVEEDOR" Text="Requerido" ValidationGroup="Guardar"
                Visible="False" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plDatosFinales" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblOBSERVACION" runat="server" Text="Observaciones:" /></td>
            <td class="DataCell">
              <asp:TextBox ID="txtOBSERVACION" runat="server" CssClass="TextBoxMultiLine" TextMode="MultiLine"
                MaxLength="1000" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblIDINSPECTOR" runat="server" Text="Inspector:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtINSPECTOR" runat="server" />
              <asp:Label ID="txtCODIGOINSPECTOR" runat="server" Visible="False" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHAELABORACIONINFORME" runat="server" Text="Fecha de elaboración del informe:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFECHAELABORACIONINFORME" runat="server" DisableTextBoxEntry="False"
                GoToTodayText="" Culture="Spanish (El Salvador)" />
              <asp:RequiredFieldValidator ID="rfvFECHAELABORACIONINFORME" runat="server" Display="dynamic"
                ControlToValidate="cpFECHAELABORACIONINFORME" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFECHAELABORACIONINFORME1" runat="server" ControlToValidate="cpFECHAELABORACIONINFORME"
                ControlToCompare="cpFECHASOLICITUDINSPECCION" Text="La fecha del informe no puede ser anterior a la fecha de solicitud de inspección."
                Display="Dynamic" Type="Date" Operator="GreaterThanEqual" Visible="False" />
              <asp:CompareValidator ID="cvFECHAELABORACIONINFORME2" runat="server" ControlToValidate="cpFECHAELABORACIONINFORME"
                Text="La fecha del informe no puede ser posterior a hoy." Display="Dynamic" Type="Date"
                Operator="LessThanEqual" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblCOORDINADORCC" runat="server" Text="Coordinador de Inspección:" /></td>
            <td class="DataCell">
              <cc1:ddlEMPLEADOS ID="ddlCOORDINADORCC" runat="server" />
              <asp:Label ID="txtCOORDINADORCC" runat="server" Visible="False" />
              <asp:Label ID="txtCODIGOCOORDINADORCC" runat="server" Visible="False" /></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plCertificacion" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td class="TituloLeftCell" colspan="2" style="height: 21px">
              <asp:Label ID="lblCertificacion" runat="server" Text="Certificación:" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblOBSERVACIONCERTIFICACION" runat="server" Text="Observaciones:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtOBSERVACIONCERTIFICACION1" runat="server" Text="El análisis corresponde a la muestra enviada a este laboratorio." />
              <asp:TextBox ID="txtOBSERVACIONCERTIFICACION2" runat="server" CssClass="TextBoxMultiLine"
                TextMode="MultiLine" MaxLength="1000" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblJEFELABORATORIO" runat="server" Text="Jefe de Laboratorio:" /></td>
            <td class="DataCell">
              <asp:Label ID="txtJEFELABORATORIO" runat="server" />
              <asp:Label ID="txtCODIGOJEFELABORATORIO" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblFECHACERTIFICACION" runat="server" Text="Fecha de certificación:" /></td>
            <td class="DataCell">
              <ew:CalendarPopup ID="cpFECHACERTIFICACION" runat="server" DisableTextBoxEntry="False"
                GoToTodayText="" Culture="Spanish (El Salvador)" />
              <asp:RequiredFieldValidator ID="rfvFECHACERTIFICACION" runat="server" Display="dynamic"
                ControlToValidate="cpFECHACERTIFICACION" Text="Requerido" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td colspan="2">
              <asp:CompareValidator ID="cvFECHACERTIFICACION1" runat="server" ControlToValidate="cpFECHACERTIFICACION"
                ControlToCompare="cpFECHAELABORACIONINFORME" Text="La fecha de certificación no puede ser anterior a la del informe."
                Display="Dynamic" Type="Date" Operator="GreaterThanEqual" ValidationGroup="Guardar" />
              <asp:CompareValidator ID="cvFECHACERTIFICACION2" runat="server" ControlToValidate="cpFECHACERTIFICACION"
                Text="La fecha de certificación no puede ser posterior a hoy." Display="Dynamic"
                Type="Date" Operator="LessThanEqual" ValidationGroup="Guardar" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblResultadoInspeccion" runat="server" Text="Resultado final:" /></td>
            <td class="DataCell">
              <asp:DropDownList ID="ddlResultadoInspeccion" runat="server">
                <asp:ListItem Text="Aceptado" Value="1" />
                <asp:ListItem Text="Rechazado" Value="2" />
              </asp:DropDownList></td>
          </tr>
        </table>
      </asp:Panel>
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Panel ID="plBotones" runat="server" Width="100%">
        <table class="CenteredTable" style="width: 100%;">
          <tr>
            <td>
              <asp:ValidationSummary ID="vsGuardar" runat="server" ValidationGroup="Guardar" BorderStyle="None"
                HeaderText="Error! Por favor verifique los valores ingresados." DisplayMode="SingleParagraph" />
            </td>
          </tr>
          <tr>
            <td>
              <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Guardar" />
              <asp:Button ID="btnCerrar" runat="server" Text="Guardar y Enviar" ValidationGroup="Guardar" />
              <asp:Button ID="btnCorregir" runat="server" Text="Corregir" ValidationGroup="Guardar" />
              <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="False" /></td>
          </tr>
        </table>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" UseSubmitBehavior="False"
          Visible="False" />
      </asp:Panel>
    </td>
  </tr>
</table>
<nds:MsgBox ID="MsgBox1" runat="server" />
