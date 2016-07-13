<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantConsultaSolicitudUFI.aspx.vb" Inherits="FrmMantConsultaSolicitudUFI" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" CausesValidation="False" Text="Menú" />&nbsp;&nbsp;<asp:Label
          ID="lblRuta" runat="server" Text="UFI -> Consulta Solicitud de compras" /></td>
    </tr>
    <tr>
      <td valign="top">
        &nbsp;</td>
    </tr>
    <tr>
      <td valign="top">
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="SOLICITUD DE COMPRA" />&nbsp;
      </td>
    </tr>
    <tr>
      <td>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <asp:DropDownList ID="DdlCriterio" runat="server" AutoPostBack="True" Width="134px">
          <asp:ListItem Value="0">Criterio</asp:ListItem>
          <asp:ListItem Value="CORRELATIVO">No Solicitud</asp:ListItem>
          <asp:ListItem Value="FECHASOLICITUD">Fecha Solicitud</asp:ListItem>
          <asp:ListItem Value="IDDEPENDENCIASOLICITANTE">Dependencia</asp:ListItem>
          <asp:ListItem Value="PLAZOENTREGA">Plazo de Entrega</asp:ListItem>
          <asp:ListItem Value="IDESTADO">Estado</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlOperadorBusqueda" runat="server" AutoPostBack="True" Width="113px">
          <asp:ListItem Value="=">Igual (=)</asp:ListItem>
          <asp:ListItem Value="&gt;">Mayor que (&gt;)</asp:ListItem>
          <asp:ListItem Value="&lt;">Menor que (&lt;)</asp:ListItem>
          <asp:ListItem Value="&gt;=">Mayor o igual que (&gt;=)</asp:ListItem>
          <asp:ListItem Value="&lt;=">Menor o igual que (&lt;=)</asp:ListItem>
          <asp:ListItem Value="LIKE">Incluido en</asp:ListItem>
          <asp:ListItem Value="&lt;&gt;">Diferente de</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="DdlPlazoentrega" runat="server" Width="95px" AutoPostBack="True">
          <asp:ListItem Value="0">0 Dias</asp:ListItem>
          <asp:ListItem Value="15">15 Dias</asp:ListItem>
          <asp:ListItem Value="30">30 Dias</asp:ListItem>
          <asp:ListItem Value="45">45 Dias</asp:ListItem>
          <asp:ListItem Value="60">60 dias</asp:ListItem>
          <asp:ListItem Value="75">75 Dias</asp:ListItem>
          <asp:ListItem Value="90">90 Dias</asp:ListItem>
          <asp:ListItem Value="105">105 Dias</asp:ListItem>
          <asp:ListItem Value="120">120 Dias</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TxtBuscar" runat="server" Width="81px" CausesValidation="True"></asp:TextBox>&nbsp;
        <asp:DropDownList ID="DdlEstado" runat="server" AutoPostBack="True" Width="150px">
          <asp:ListItem Value="4">Rechazada UFI</asp:ListItem>
          <asp:ListItem Value="5">Enviada UFI</asp:ListItem>
          <asp:ListItem Value="6">Autorizada UFI</asp:ListItem>
        </asp:DropDownList><asp:DropDownList ID="DdlDependencias" runat="server" AutoPostBack="True"
          Width="504px">
          <asp:ListItem Value="0">Dependencias</asp:ListItem>
        </asp:DropDownList>&nbsp;
      </td>
    </tr>
    <tr>
      <td valign="top">
        <asp:Label ID="LblFechaInicio" runat="server" Text="Fecha Inicio:" />
        <asp:Label ID="lblinicio" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="74px" />
        <asp:Button ID="bttCal1" runat="server" Text="..." Width="31px" />
        <asp:Label ID="LblFechaFin" runat="server" Text="Fecha Fin:" />
        <asp:Label ID="lblFin" runat="server" BackColor="Transparent" BorderColor="LightBlue"
          BorderStyle="Solid" BorderWidth="1px" Width="74px" />
        <asp:Button ID="bttCal2" runat="server" Text="..." Width="31px" />
        <asp:Calendar ID="CalendarFechaInicio" runat="server" BackColor="White" BorderColor="#3366CC"
          BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
          Font-Size="8pt" ForeColor="#003399" Height="71px" Width="104px">
          <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
          <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
          <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
          <WeekendDayStyle BackColor="#CCCCFF" />
          <OtherMonthDayStyle ForeColor="#999999" />
          <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
          <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
          <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="Navy" Height="25px" />
        </asp:Calendar>
        <asp:Calendar ID="CalendarFechaFin" runat="server" BackColor="White" BorderColor="#3366CC"
          BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
          Font-Size="8pt" ForeColor="#003399" Height="71px" Width="104px">
          <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
          <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
          <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
          <WeekendDayStyle BackColor="#C0C0FF" />
          <OtherMonthDayStyle ForeColor="#999999" />
          <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
          <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
          <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
            Font-Size="10pt" ForeColor="Navy" Height="25px" />
        </asp:Calendar>
      </td>
    </tr>
    <tr>
      <td valign="top">
        <asp:Button ID="BttFiltrar" runat="server" CausesValidation="False" Text="Mostrar datos filtrados"
          Width="144px" />
        <asp:Button ID="BttRestarurar" runat="server" Text="Nuevo filtro" /></td>
    </tr>
    <tr>
      <td valign="top">
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtBuscar"
          ErrorMessage="* Ingresó caracteres no permitidos" ValidationExpression="[0-9]+\/[0-9]+" /></td>
    </tr>
    <tr>
      <td valign="top" style="width: 787px">
        <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          GridLines="None" Width="100%" AllowPaging="True" ForeColor="#333333">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <ItemStyle CssClass="GridListItem" />
          <SelectedItemStyle CssClass="GridListSelectedItem" />
          <EditItemStyle CssClass="GridListEditItem" />
          <AlternatingItemStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:TemplateColumn HeaderText="Editar">
              <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD", "FrmDetaConsultaSolicitudUFI.aspx?id={0}") + DataBinder.Eval(Container, "DataItem.IDESTADO", "&estado={0}") + DataBinder.Eval(Container, "DataItem.COMPRACONJUNTA", "&conjunta={0}") + DataBinder.Eval(Container, "DataItem.IDCLASESUMINISTRO", "&suministro={0}") + DataBinder.Eval(Container, "DataItem.IDDEPENDENCIASOLICITANTE", "&dependencia={0}") %>'
                  Text="Imprimir / Consultar" Font-Size="Smaller" />
                <asp:Label ID="ID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITUD") %>'
                  Visible="False" />
                <asp:Label ID="DEP" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDDEPENDENCIASOLICITANTE") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Width="10%" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="CORRELATIVO" HeaderText="N&#176; Solicitud" SortExpression="CORRELATIVO">
              <HeaderStyle Width="10%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:BoundColumn DataField="FECHASOLICITUD" HeaderText="Fecha Creaci&amp;oacuten"
              SortExpression="FECHASOLICITUD" DataFormatString="{0:d}">
              <HeaderStyle Width="15%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Plazo Entrega">
              <ItemTemplate>
                <asp:Label ID="Label_IdPlazoEntrega" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PLAZOENTREGA") %>'
                  Visible="False" Width="72px" />
                <asp:DropDownList ID="ddlPlazoEntrega" runat="server" Width="47px" Height="15px"
                  Visible="False">
                  <asp:ListItem Value="0">0 Dias</asp:ListItem>
                  <asp:ListItem Value="15">15 Dias</asp:ListItem>
                  <asp:ListItem Value="30">30 Dias</asp:ListItem>
                  <asp:ListItem Value="45">45 Dias</asp:ListItem>
                  <asp:ListItem Value="60">60 Dias</asp:ListItem>
                  <asp:ListItem Value="75">75 Dias</asp:ListItem>
                  <asp:ListItem Value="90">90 Dias</asp:ListItem>
                  <asp:ListItem Value="105">105 Dias</asp:ListItem>
                  <asp:ListItem Value="120">120 Dias</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TxtPlazoEntrega" runat="server" ReadOnly="True" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="Small" Width="59px"></asp:TextBox>
              </ItemTemplate>
              <HeaderStyle Width="10%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Estado">
              <ItemTemplate>
                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                  Visible="False" Width="30px" />
                <asp:DropDownList ID="ddlEstado" runat="server" Width="153px" Height="15px" Visible="False">
                </asp:DropDownList>
                <asp:TextBox ID="TxtEstado" runat="server" ReadOnly="True" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" BorderWidth="1px" Font-Size="Small"
                  Width="181px"></asp:TextBox>
              </ItemTemplate>
              <HeaderStyle Width="10%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Compra Conjunta">
              <ItemTemplate>
                <asp:CheckBox ID="ChkCompraConjunta" runat="server" Enabled="False" />
                <asp:Label ID="lblcj" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.COMPRACONJUNTA") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Width="5%" HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Responsable">
              <ItemTemplate>
                <asp:Label ID="LblResp" runat="server" Width="148px" />
                <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Visible="False" Width="22px" />
                <asp:Label ID="idrep" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDSOLICITANTE") %>'
                  Visible="False" />
              </ItemTemplate>
              <HeaderStyle Width="20%" HorizontalAlign="Left" />
              <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="IDCLASESUMINISTRO" HeaderText="SUMINISTRO" Visible="False">
            </asp:BoundColumn>
          </Columns>
        </asp:DataGrid>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
