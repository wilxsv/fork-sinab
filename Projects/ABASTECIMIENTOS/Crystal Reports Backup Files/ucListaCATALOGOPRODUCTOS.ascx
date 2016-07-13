<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucListaCATALOGOPRODUCTOS.ascx.vb"
  Inherits="ucListaCATALOGOPRODUCTOS" %>
<%@ Register TagPrefix="cc1" Namespace="ABASTECIMIENTOS.WUC" Assembly="ABASTECIMIENTOS_WUC" %>
<asp:GridView ID="gvLista" CssClass="Grid" AutoGenerateColumns="False" AllowSorting="True"
  runat="server" AllowPaging="True" CellPadding="4" GridLines="None">
  <HeaderStyle CssClass="GridListHeader" />
  <FooterStyle CssClass="GridListFooter" />
  <PagerStyle CssClass="GridListPager" />
  <RowStyle CssClass="GridListItem" />
  <SelectedRowStyle CssClass="GridListSelectedItem" />
  <EditRowStyle CssClass="GridListEditItem" />
  <AlternatingRowStyle CssClass="GridListAlternatingItem" />
  <Columns>
    <asp:TemplateField HeaderText="Editar/Consultar">
      <ItemTemplate>
        <asp:HyperLink ID="HyperLinkDetalle" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO", "../wfDetaMantCATALOGOPRODUCTOS.aspx?id={0}") %>'
          Text='Seleccionar'></asp:HyperLink>
        <asp:Label ID="Label_IDPRODUCTO" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>' />
      </ItemTemplate>
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    <asp:BoundField DataField="CODIGO" HeaderText="C&#243;digo">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="Subgrupo">
      <ItemTemplate>
        <asp:Label ID="Label_IDTIPOPRODUCTO1" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDTIPOPRODUCTO") %>' />
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS1" runat="server" AutoPostBack="true" Enabled="False"
          CssClass="DDLClassDisabled" Width="128px">
        </cc1:ddlSUBGRUPOS>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:Label ID="Label_IDTIPOPRODUCTO2" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDTIPOPRODUCTO") %>' />
        <cc1:ddlSUBGRUPOS ID="ddlSUBGRUPOS2" runat="server" AutoPostBack="true" CssClass="DDLClass">
        </cc1:ddlSUBGRUPOS>
      </EditItemTemplate>
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="U.M.">
      <ItemTemplate>
        <asp:Label ID="Label_IDUNIDADMEDIDA1" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDUNIDADMEDIDA") %>' />
        <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS1" runat="server" AutoPostBack="true" Enabled="False"
          CssClass="DDLClassDisabled">
        </cc1:ddlUNIDADMEDIDAS>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:Label ID="Label_IDUNIDADMEDIDA2" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.IDUNIDADMEDIDA") %>' />
        <cc1:ddlUNIDADMEDIDAS ID="ddlUNIDADMEDIDAS2" runat="server" AutoPostBack="true" CssClass="DDLClass">
        </cc1:ddlUNIDADMEDIDAS>
      </EditItemTemplate>
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="Nivel de uso">
      <ItemTemplate>
        <asp:Label ID="Label_NIVELUSO1" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.NIVELUSO") %>' />
        <cc1:ddlNIVELESUSO ID="ddlNIVELESUSO1" runat="server" AutoPostBack="true" Enabled="False"
          CssClass="DDLClassDisabled">
        </cc1:ddlNIVELESUSO>
      </ItemTemplate>
      <EditItemTemplate>
        <asp:Label ID="Label_NIVELUSO2" runat="server" Visible="False" Text='<%# DataBinder.Eval(Container, "DataItem.NIVELUSO") %>' />
        <cc1:ddlNIVELESUSO ID="ddlNIVELESUSO2" runat="server" AutoPostBack="true" CssClass="DDLClass">
        </cc1:ddlNIVELESUSO>
      </EditItemTemplate>
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:TemplateField>
    <asp:BoundField DataField="CONCENtrACION" HeaderText="Concentraci&#243;n">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="FORMAFARMACEUTICA" HeaderText="Forma Farmace&#250;tica">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="PRESENTACION" HeaderText="Presentaci&#243;n">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:BoundField DataField="PRIORIDAD" HeaderText="Prioridad">
      <ItemStyle HorizontalAlign="Right" />
      <HeaderStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="PRECIOACTUAL" HeaderText="Precio Actual" DataFormatString="{0:c}">
      <ItemStyle HorizontalAlign="Right" />
      <HeaderStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="APLICALOTE" HeaderText="Aplica Lote" />
    <asp:BoundField DataField="EXISTENCIAACTUAL" HeaderText="Existencia Actual">
      <ItemStyle HorizontalAlign="Right" />
      <HeaderStyle HorizontalAlign="Right" />
    </asp:BoundField>
    <asp:BoundField DataField="ESPECIFICACIONESTECNICAS" HeaderText="Especificaciones T&#233;cnicas">
      <ItemStyle HorizontalAlign="Left" />
      <HeaderStyle HorizontalAlign="Left" />
    </asp:BoundField>
    <asp:TemplateField HeaderText="Eliminar">
      <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CausesValidation="False"
          ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDPRODUCTO") %>'>
          <asp:Image ID="Image1" runat="server" CssClass="GridImagenEliminarItem" ImageUrl="~/Imagenes/Eliminar.gif"
            AlternateText="Elimina el registro" /></asp:LinkButton>
      </ItemTemplate>
    </asp:TemplateField>
  </Columns>
  <PagerTemplate>
    <asp:LinkButton ID="LnkbPrimero" runat="server" Font-Bold="False" OnClick="LnkbPrimero_Click"
      ForeColor="White">Primero</asp:LinkButton>
    <asp:LinkButton ID="LnkbAnterior" runat="server" Font-Bold="False" ForeColor="White"
      OnClick="LnkbAnterior_Click">Anterior</asp:LinkButton>
    <asp:LinkButton ID="LnkbSiguiente" runat="server" Font-Bold="False" ForeColor="White"
      OnClick="LnkbSiguiente_Click">Siguiente</asp:LinkButton>
    <asp:LinkButton ID="LnkbUltimo" runat="server" Font-Bold="False" OnClick="LnkbUltimo_Click"
      ForeColor="White">Ultimo</asp:LinkButton>
  </PagerTemplate>
</asp:GridView>
<asp:RadioButtonList ID="RblTipoFiltro" runat="server" AutoPostBack="true" RepeatDirection="Horizontal"
  Width="268px">
  <asp:ListItem Selected="true" Value="0">Sin filtro</asp:ListItem>
  <asp:ListItem Value="1">C&#243;digo</asp:ListItem>
  <asp:ListItem Value="2">Subgrupo</asp:ListItem>
</asp:RadioButtonList>
<cc1:ddlSUBGRUPOS ID="DdlSUBGRUPOS3" runat="server" Width="257px" Visible="False">
</cc1:ddlSUBGRUPOS>
<asp:TextBox ID="TxtBuscar" runat="server" Width="105px" Visible="False" />
<asp:Button ID="BtnFiltrar" runat="server" CausesValidation="False" Text="Filtrar"
  Width="71px" />
