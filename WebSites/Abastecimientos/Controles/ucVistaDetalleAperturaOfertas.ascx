<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucVistaDetalleAperturaOfertas.ascx.vb"
  Inherits="Controles_ucVistaDetalleAperturaOfertas" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>

<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register TagPrefix="uc2" TagName="ucVistaDetalleSolicProcesCompra" Src="~/Controles/ucVistaDetalleSolicProcesCompra.ascx" %>
<div>
    <uc1:ucBarraNavegacion ID="UcBarraNavegacion1" runat="server" />
      <asp:Label ID="lblMsg" runat="server" />
</div>

 <uc2:ucVistaDetalleSolicProcesCompra ID="UcVistaDetalleSolicProcesCompra1" runat="server" />
<table class="CenteredTable" >
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label3" runat="server" Text="Código de Proceso de Compra:" /></td>
    <td >
      <asp:Label ID="lblCodigoProcesoCompra" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label1" runat="server" Text="Código de bases:" /></td>
    <td >
      <asp:Label ID="lblCodigoBase" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label5" runat="server" Text="Fecha de publicación:" /></td>
    <td >
      <asp:Label ID="lblFechaPublicacion" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label6" runat="server" Text="Fecha de iniciado el proceso de compra:" /></td>
    <td >
      <asp:Label ID="lblFechaIniciadoProceso" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label7" runat="server" Text="Fecha de recepción de las ofertas:" /></td>
    <td >
        <asp:TextBox runat="server" ID="cpFechaRecepcionOferta" Enabled="False" CssClass="datefield"/>
     <%-- <ew:CalendarP+opup ID="cpFechaRecepcionOferta" runat="server" EnableTheming="False"
        Enabled="False" Culture="Spanish (El Salvador)" />--%>
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label2" runat="server" Text="Hora de recepción de las ofertas:" /></td>
    <td >
        <asp:TextBox runat="server" ID="tpHoraRecepcionOferta" Enabled="False" CssClass="timefield"/>
      <%--<ew:TimePicker ID="tpHoraRecepcionOferta" runat="server" Enabled="False" EnableTheming="False" />--%>
    </td>
  </tr>
 </table>
 <hr />
 <div style="margin:10px 0">
      <asp:Label ID="Label12" runat="server" Text="Para generar el acta es necesario que ingrese los siguientes datos:"
        Font-Bold="True" />
        <table class="CenteredTable" >
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label9" runat="server" Text="Número del Acta de Apertura:" /></td>
    <td >
      <asp:TextBox ID="txtNoActa" runat="server" Width="163px" MaxLength="50" />
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoActa"
        ErrorMessage="Requerido" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label14" runat="server" Text="Lugar en que se realiza la apertura:" /></td>
    <td >
      <asp:TextBox ID="txtLugarApertura" runat="server" Width="289px" MaxLength="100" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label15" runat="server" Text="Código de licitación:" /></td>
    <td >
      <asp:Label ID="lblCodigoLicitacion" runat="server" /></td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label16" runat="server" Text="Título de licitación:" /></td>
    <td >
      <asp:Label ID="lblTituloLicitacion" runat="server" /></td>
  </tr>
  </table>
  </div>
<hr />
  <div style="margin:10px 0">
      <asp:Label ID="Label17" runat="server" Text="Listado de empresas que presentaron ofertas"
        Font-Bold="True" />
  
      <div class="LargeScrollPanel">
          <div>
  <asp:DataGrid ID="dgEmpresaPresentaOferta" CssClass="Grid" runat="server" CellPadding="4" ForeColor="#333333"
        GridLines="None" AutoGenerateColumns="False"  Width="100%">
        <HeaderStyle CssClass="GridListHeader" />
        <FooterStyle CssClass="GridListFooter" />
        <PagerStyle CssClass="GridListPager" Mode="NumericPages" />
        <ItemStyle CssClass="GridListItem" />
        <SelectedItemStyle CssClass="GridListSelectedItem" />
        <EditItemStyle CssClass="GridListEditItem" />
        <AlternatingItemStyle CssClass="GridListAlternatingItem" />
        <Columns>
          <asp:ButtonColumn CommandName="Select" Text="&gt;&gt;" Visible="False" />
          <asp:BoundColumn DataField="NOMBRE" HeaderText="Proveedor" ItemStyle-HorizontalAlign="Left" />
          <asp:BoundColumn DataField="ORDENLLEGADA" HeaderText="Orden de llegada" Visible="False" />
          <asp:BoundColumn DataField="FECHAENTREGA" HeaderText="Fecha" ItemStyle-HorizontalAlign="Left" />
          <asp:BoundColumn DataField="IDPROVEEDOR" Visible="False" ItemStyle-HorizontalAlign="Left" />
          <asp:TemplateColumn HeaderText="Representante">
            <ItemStyle HorizontalAlign="Left" />
            <ItemTemplate>
              <asp:TextBox ID="txtRepresentante" runat="server" Text='<%# databinder.eval(container, "dataitem.NOMBREREPRESENTANTE") %>' />
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Monto Oferta ($)">
            <ItemStyle HorizontalAlign="Left" />
            <ItemTemplate>
              <asp:Label ID="MONTOOFERTA" runat="server" Text='' />
              <ew:NumericBox ID="TXTMONTOOFERTA" runat="server" Text='<%# databinder.eval(container, "dataitem.montooferta") %>'
                AutoFormatCurrency="True" PositiveNumber="True" DecimalPlaces="2" MaxLength="15"
                TextAlign="Right">$0</ew:NumericBox>
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Monto Garant&#237;a ($)">
            <ItemStyle HorizontalAlign="Left" />
            <ItemTemplate>
              <asp:Label ID="MONTOGARANTIA" runat="server" Text='' />
              <ew:NumericBox ID="TXTMONTOGARANTIA" runat="server" Text='<%# databinder.eval(container, "dataitem.montogarantia") %>'
                AutoFormatCurrency="True" PositiveNumber="True" DecimalPlaces="2" MaxLength="15"
                TextAlign="Right">$0</ew:NumericBox>
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:TemplateColumn HeaderText="Guardar Proveedor">
            <ItemTemplate>
              <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Update"
                CssClass="GridGuardar" ToolTip="Guardar el Registro" BorderStyle="None" />
            </ItemTemplate>
          </asp:TemplateColumn>
          <asp:BoundColumn DataField="estahabilitado" Visible="False" />
          <asp:BoundColumn DataField="observacion" Visible="False" />
        </Columns>
      </asp:DataGrid>
              </div>
          </div>
      </div>
     <div>
       <uc1:ucBarraNavegacion ID="UcBarraNavegacion2" runat="server" Visible="false" />
   <table class="CenteredTable" >
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label23" runat="server" Text="Fecha de realizado el proceso de apertura" /></td>
    <td >
        <asp:TextBox runat="server" ID="cpFechaRealizadoProceso" CssClass="datefield"/>
      <%--<ew:CalendarPopup ID="cpFechaRealizadoProceso" runat="server" Culture="Spanish (El Salvador)" />--%>
    </td>
  </tr>
  <tr>
    <td class="LabelCell">
      <asp:Label ID="Label24" runat="server" Text="Hora de realizado el proceso de apertura" /></td>
    <td >
        <asp:TextBox runat="server" ID="tpHoraRealizadoProceso" CssClass="timefield"/>
      <%--<ew:TimePicker ID="tpHoraRealizadoProceso" runat="server" MinuteInterval="OneMinute"
        DisableTextBoxEntry="False" LowerBoundTime="07/09/2008 07:00:00" />--%>
    </td>
  </tr>
  <tr>
    <td class="LabelCell" style="vertical-align: text-top">
      <asp:Label ID="Label10" runat="server" Text="Comentarios relevantes:" /></td>
 
    <td>
      <asp:TextBox ID="txtObservacionesActa" runat="server" CssClass="TextBoxMultiLine"
        TextMode="MultiLine" Width="300px" /></td>
  </tr>
  </table>
  </div>
<hr />
<div>
  <asp:Label ID="Label25" runat="server" Text="Nombres y cargos de los representantes del MSPAS"
        Font-Bold="True" />
        <div>
             <asp:Label ID="lblDependencia" runat="server" />
        </div>
        
      <asp:Panel ID="Panel1" runat="server" Width="100%">
        <table class="CenteredTable" >
          <tr>
            <td class="LabelCell">
              <asp:Label ID="Label4" runat="server" Text="NOMBRE" /></td>
            <td >
              <asp:Label ID="Label8" runat="server" Text="CARGO" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblId1" runat="server" Text="Label" Visible="False" />
              <asp:TextBox ID="txtNombre1" runat="server" /></td>
            <td >
              <asp:TextBox ID="txtCargo1" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblId2" runat="server" Text="Label" Visible="False" />
              <asp:TextBox ID="txtNombre2" runat="server" /></td>
            <td >
              <asp:TextBox ID="txtCargo2" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblId3" runat="server" Text="Label" Visible="False" />
              <asp:TextBox ID="txtNombre3" runat="server" /></td>
            <td >
              <asp:TextBox ID="txtCargo3" runat="server" /></td>
          </tr>
          <tr>
            <td class="LabelCell">
              <asp:Label ID="lblId4" runat="server" Text="Label" Visible="False" />
              <asp:TextBox ID="txtNombre4" runat="server" /></td>
            <td >
              <asp:TextBox ID="txtCargo4" runat="server" /></td>
          </tr>
        </table>
      </asp:Panel>
   </div>
   
<hr />
   <div class="NavBar">
  
      <asp:LinkButton ID="ibtnGuardar" runat="server" CssClass="opGuardar" Text="Guardar" ToolTip="Guardar el registro" Width="50" />
      
      <asp:LinkButton ID="ibtnImprimir" runat="server" CausesValidation="False" Text="Imprimir" CssClass="opImprimir" Width="50" ToolTip="Consultar registros" />
  </div>
  <div style="margin: 10px 0">
      <asp:Button ID="btnFinalizarApertura" runat="server" Enabled="False" Text="Finalizar Apertura de Ofertas" />
      </div>

<%--<nds:MsgBox ID="MsgBox1" runat="server" />--%>
