<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantConsumos.aspx.vb" Inherits="FrmMantConsumos" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
  <asp:Content runat="server" ContentPlaceHolderID="MenuContent" ID="pMenu">
      <asp:LinkButton ID="LnkMenu" runat="server" Text="Menú"/>&nbsp;
        <asp:Label ID="LblRuta" runat="server" Text="Establecimientos » Ingreso Consumos" />
  </asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
 
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
     <div>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="INGRESO DE CONSUMO, EXISTENCIA Y DEMANDA INSATISFECHA" />
     </div>
    <div>
        &nbsp;<asp:ImageButton ID="BttConsumoAnterior" runat="server" ImageUrl="~/Imagenes/botones/GenerarNuevoConsumo1.gif" />
        <asp:ImageButton ID="BttImportarConsumos" runat="server" ImageUrl="~/Imagenes/botones/ImportarConsumo.gif" />
    </div>
    <div>
        <asp:Label ID="LblMensaje1" runat="server" Text="Consumo a tomar como base para generar uno nuevo:" /><br />
        &nbsp;<asp:Label ID="LblMes" runat="server" Text="Mes:" />
        <asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="True" Width="129px">
          <asp:ListItem Value="1">Enero</asp:ListItem>
          <asp:ListItem Value="2">Febrero</asp:ListItem>
          <asp:ListItem Value="3">Marzo</asp:ListItem>
          <asp:ListItem Value="4">Abril</asp:ListItem>
          <asp:ListItem Value="5">Mayo</asp:ListItem>
          <asp:ListItem Value="6">Junio</asp:ListItem>
          <asp:ListItem Value="7">Julio</asp:ListItem>
          <asp:ListItem Value="8">Agosto</asp:ListItem>
          <asp:ListItem Value="9">Septiembre</asp:ListItem>
          <asp:ListItem Value="10">Octubre</asp:ListItem>
          <asp:ListItem Value="11">Noviembre</asp:ListItem>
          <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:Label ID="Lblanio" runat="server" Text="Año:" Width="39px" />&nbsp;<asp:DropDownList
          ID="DdlAño" runat="server">
          <asp:ListItem>2006</asp:ListItem>
          <asp:ListItem>2007</asp:ListItem>
          <asp:ListItem>2008</asp:ListItem>
          <asp:ListItem>2009</asp:ListItem>
          <asp:ListItem>2010</asp:ListItem>
          <asp:ListItem>2011</asp:ListItem>
          <asp:ListItem>2012</asp:ListItem>
          <asp:ListItem>2013</asp:ListItem>
          <asp:ListItem>2014</asp:ListItem>
          <asp:ListItem>2015</asp:ListItem>
          <asp:ListItem>2016</asp:ListItem>
          <asp:ListItem>2017</asp:ListItem>
          <asp:ListItem>2018</asp:ListItem>
          <asp:ListItem>2019</asp:ListItem>
          <asp:ListItem>2020</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:Button ID="BttRecuperar" runat="server" Text="Recuperar" />
        <br />
        <asp:Label ID="lblmensaje2" runat="server" Text="Favor elija el consumo a tomar de base" />
        </div>
  
        <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Width="60%" AllowPaging="True">
          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <EditItemStyle BackColor="#2461BF" />
          <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
          <AlternatingItemStyle BackColor="White" />
          <ItemStyle BackColor="#EFF3FB" />
          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
          <Columns>
            <asp:TemplateColumn HeaderText="Editar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDCONSUMO", "FrmDetaMantConsumos.aspx?id={0}")+ DataBinder.Eval(Container, "DataItem.IDESTADO", "&estado={0}") %>'
                  Target="_self" Text="Editar/consultar" Font-Size="X-Small"></asp:HyperLink>
                <asp:Label ID="ID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDCONSUMO") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="IDCONSUMO" HeaderText="C&amp;oacutedigo" SortExpression="IDCONSUMO">
              <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Mes">
              <ItemTemplate>
                <asp:Label ID="Label_IdMesConsumo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MESCONSUMO") %>'
                  Visible="False" Height="10px" Width="36px" />
                <asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="True" Visible="False"
                  Width="47px">
                  <asp:ListItem Value="1">Enero</asp:ListItem>
                  <asp:ListItem Value="2">Febrero</asp:ListItem>
                  <asp:ListItem Value="3">Marzo</asp:ListItem>
                  <asp:ListItem Value="4">Abril</asp:ListItem>
                  <asp:ListItem Value="5">Mayo</asp:ListItem>
                  <asp:ListItem Value="6">Junio</asp:ListItem>
                  <asp:ListItem Value="7">Julio</asp:ListItem>
                  <asp:ListItem Value="8">Agosto</asp:ListItem>
                  <asp:ListItem Value="9">Septiembre</asp:ListItem>
                  <asp:ListItem Value="10">Octubre</asp:ListItem>
                  <asp:ListItem Value="11">Noviembre</asp:ListItem>
                  <asp:ListItem Value="12">Diciembre</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TxtMesConsumo" runat="server" ReadOnly="True" Width="95px" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="X-Small"></asp:TextBox>
              </ItemTemplate>
              <HeaderStyle Width="20%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="ANIOCONSUMO" HeaderText="A&#241;o" SortExpression="ANIOCONSUMO">
              <HeaderStyle Width="5%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Establecimiento" Visible="False">
              <ItemTemplate>
                <asp:Label ID="Label_IdEstablecimiento" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTABLECIMIENTO") %>'
                  Visible="False" Width="34px" />
                <cc1:ddlESTABLECIMIENTOS ID="DdlESTABLECIMIENTOS1" runat="server" Visible="False"
                  Width="44px">
                </cc1:ddlESTABLECIMIENTOS>
                <asp:TextBox ID="TxtEstablecimiento" runat="server" ReadOnly="True" Width="169px"
                  BackColor="Transparent" BorderColor="Transparent" BorderStyle="None"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Estado">
              <ItemTemplate>
                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                  Visible="False" />
                <cc1:ddlESTADOSCONSUMOS ID="DdlESTADOSCONSUMOS1" runat="server" Visible="False">
                </cc1:ddlESTADOSCONSUMOS>
                <asp:TextBox ID="TxtEstado" runat="server" ReadOnly="True" Width="79px" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="X-Small"></asp:TextBox>
              </ItemTemplate>
              <HeaderStyle Width="15%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="X-Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Usuario">
              <ItemTemplate>
                <asp:Label ID="LblEmpleado" runat="server" Font-Size="X-Small" Width="229px" />
                <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Width="38px" Visible="False">
                </cc1:ddlEMPLEADOS>
                <asp:Label ID="lblidemp" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDEMPLEADO") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Width="20%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Eliminar Consumo">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDCONSUMO") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar el Registro' border='0' /></asp:LinkButton>
              </ItemTemplate>
              <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Center" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Enviar">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDCONSUMO") %>'>
												<img src='Imagenes/enviar.gif' alt='Enviar a UTMIM' border='0' /></asp:LinkButton>
                <br />
                <asp:Label ID="lblObservacion" runat="server" />
              </ItemTemplate>
              <HeaderStyle Width="10%" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Center" />
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid>
</asp:Content>
