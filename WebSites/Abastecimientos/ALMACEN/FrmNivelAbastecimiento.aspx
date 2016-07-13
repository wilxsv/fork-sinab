<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmNivelAbastecimiento.aspx.vb"
    Inherits="ALMACEN_FrmNivelAbastecimiento" Title="Nivel de Abastecimiento Red de Hospitales" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
    Almacén » Nivel de Abastecimiento Red de Hospitales
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <h3>Nivel de Abastecimiento Red de Hospitales</h3>
    <table cellspacing="0" cellpadding="5">

        <tr>
            <td>Año:
      
          <asp:DropDownList ID="ddlAnioAbas" runat="server" AutoPostBack="True">
          </asp:DropDownList>
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </td>
            <td>Semana:
            
        <asp:DropDownList ID="ddlSemanaAbas" runat="server" AutoPostBack="True">
        </asp:DropDownList>
                <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">Suministro:
        <asp:DropDownList ID="ddlSuministro" runat="server" Enabled="False">
        </asp:DropDownList></td>
        </tr>
    </table>
    <hr />
    <table width="100%">
        <tr>
            <td>
                <div>
                    <h4>Promedio Nacional</h4>
                    Porcentaje de Desabastecimiento: <b>
                        <asp:Literal ID="ltDesabastecimiento" runat="server" />
                    </b>
                    <br />
                    Porcentaje de Abastecimiento: <b>
                        <asp:Literal ID="ltAbastecimiento" runat="server" />

                    </b>
                </div>
            </td>
            <td>
                <div class="formulario" style="max-width: 500px; float: right">
                    <div class="formularioTitulo">
                        Filtros de Reporte
                    </div>
                    <div class="formularioContenido">
                        Filtro:
                <asp:DropDownList ID="ddlProgramas" runat="server">
                </asp:DropDownList>
                        <div style="margin-top: 15px">
                            <asp:Button ID="Button2" runat="server" Text="Ver Reporte" />
                        </div>
                    </div>
                </div>
            </td>
        </tr>


    </table>

    <table>
    </table>
    <div style="margin: 10px 0px" class="LargeScrollPanel">
        <asp:GridView ID="grvAlmacenes" runat="server" AutoGenerateColumns="False"
            DataKeyNames="IDALMACEN" Width="100%" CssClass="Grid"
            GridLines="None">
            <Columns>

                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltNum" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="NOMBRE" HeaderText="HOSPITAL">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="CUADRO BÁSICO">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltCuadroBasico" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No.PROD DESABASTECIDOS">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDesabas" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% DESABASTECIMIENTO">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltDes" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="% ABASTECIMIENTO">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltAbas" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="GridListHeader" />
            <FooterStyle CssClass="GridListFooter" />
            <PagerStyle CssClass="GridListPager" />
            <RowStyle CssClass="GridListItem" />
            <SelectedRowStyle CssClass="GridListSelectedItem" />
            <EditRowStyle CssClass="GridListEditItem" />
            <AlternatingRowStyle CssClass="GridListAlternatingItem" />
        </asp:GridView>
    </div>
</asp:Content>

