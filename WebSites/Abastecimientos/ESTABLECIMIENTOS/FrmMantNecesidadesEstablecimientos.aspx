<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="FrmMantNecesidadesEstablecimientos.aspx.vb" Inherits="FrmMantNecesidadesEstablecimientos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls"
  TagPrefix="nds" %>
<%@ Register Assembly="ABASTECIMIENTOS_WUC" Namespace="ABASTECIMIENTOS.WUC" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table class="CenteredTable" style="width: 100%">
    <tr>
      <td class="LinkMenuRuta">
        &nbsp;<asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False">Men&uacute</asp:LinkButton>&nbsp;&nbsp;
        &nbsp;<asp:Label ID="LblRuta" runat="server" Text="Establecimientos -> Calculo de necesidades" /></td>
    </tr>
    <tr>
      <td>
        <uc1:ucBarraNavegacion ID="ucBarraNavegacion1" runat="server" />
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="Label1" runat="server" CssClass="Titulo" Text="CALCULO DE NECESIDADES" />&nbsp;
      </td>
    </tr>
    <tr>
      <td>
        <asp:DataGrid ID="dgLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
          ForeColor="#333333" GridLines="None" Width="60%" AllowPaging="True">
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
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD", "FrmDetaMantNecesidadEstablecimiento.aspx?id={0}")+ DataBinder.Eval(Container, "DataItem.IDESTADO", "&estado={0}") %>'
                  Target="_self" Text="Editar/Consultar"></asp:HyperLink>
                <asp:Label ID="ID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'
                  Visible="False" />
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="8pt"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="FECHAELABORACION" DataFormatString="{0:d}" HeaderText="Fecha"
              SortExpression="FECHAELABORACION">
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="8pt"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:BoundColumn>
            <asp:TemplateColumn HeaderText="Elabor&amp;oacute">
              <ItemTemplate>
                <asp:Label ID="Lbl_Empleado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDEMPLEADO") %>'
                  Visible="False" />
                <cc1:ddlEMPLEADOS ID="DdlEMPLEADOS1" runat="server" Visible="False">
                </cc1:ddlEMPLEADOS>
                <asp:TextBox ID="TxtEmpleado" runat="server" ReadOnly="True" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Names="Verdana" Font-Size="9pt"
                  Width="80px"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Estado">
              <ItemTemplate>
                <asp:Label ID="Label_IdEstado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IDESTADO") %>'
                  Visible="False" />
                <cc1:ddlESTADOSNECESIDADES ID="DdlESTADOSNECESIDADES1" runat="server" Visible="False">
                </cc1:ddlESTADOSNECESIDADES>
                <asp:TextBox ID="TxtEstado" runat="server" ReadOnly="True" Width="89px" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="9pt"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Periodo Inicio">
              <ItemTemplate>
                <asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="True" Visible="False"
                  Width="47px" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.MESINICIOPERIODO") %>'>
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
                </asp:DropDownList><asp:DropDownList ID="DdlAño" runat="server" Visible="False" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.ANIOINICIOPERIODO") %>'>
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
                <asp:TextBox ID="TxtMesConsumo" runat="server" ReadOnly="True" Width="119px" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="9pt"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Periodo Fin">
              <ItemTemplate>
                <asp:DropDownList ID="DdlMes2" runat="server" AutoPostBack="True" Visible="False"
                  Width="47px" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.MESFINPERIODO") %>'>
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
                <asp:DropDownList ID="DdlAño2" runat="server" Visible="False" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.ANIOFINPERIODO") %>'>
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
                <asp:TextBox ID="TxtMesConsumo2" runat="server" ReadOnly="True" Width="115px" BackColor="Transparent"
                  BorderColor="Transparent" BorderStyle="None" Font-Size="9pt"></asp:TextBox>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Left" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Prop.">
              <ItemTemplate>
                &nbsp;<asp:DropDownList ID="ddlPropuesta" runat="server" AppendDataBoundItems="True"
                  Enabled="False" SelectedValue='<%# DataBinder.Eval(Container, "DataItem.PROPUESTA") %>'
                  Visible="False" Width="42px">
                  <asp:ListItem Value="1">A</asp:ListItem>
                  <asp:ListItem Value="2">B</asp:ListItem>
                  <asp:ListItem Value="3">C</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TxtProp" runat="server" BackColor="Transparent" BorderColor="Transparent"
                  BorderStyle="None" ReadOnly="True" Width="15px"></asp:TextBox>
              </ItemTemplate>
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Center" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Eliminar Programa">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'>
												<img src='Imagenes/Eliminar.gif' alt='Eliminar programa' border='0' /></asp:LinkButton>
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Enviar UTMIM">
              <ItemTemplate>
                <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"
                  ToolTip='<%# DataBinder.Eval(Container, "DataItem.IDNECESIDAD") %>'>
												<img src='Imagenes/enviar.gif' alt='Enviar programa' border='0' /></asp:LinkButton>
                <br />
                <asp:Label ID="lblObservacion" runat="server" Font-Size="7pt" />
              </ItemTemplate>
              <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
              <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Size="Small"
                Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
            </asp:TemplateColumn>
          </Columns>
        </asp:DataGrid>
      </td>
    </tr>
  </table>
  <nds:MsgBox ID="MsgBox1" runat="server" />
</asp:Content>
