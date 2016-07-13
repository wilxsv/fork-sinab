<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="frmMantProgramacionConsolidado.aspx.vb" Inherits="URMIM_frmMantProgramacionConsolidado" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register TagPrefix="uc1" TagName="ucBarraNavegacion" Src="~/Controles/ucBarraNavegacion.ascx" %>
<%@ Register Assembly="Cooperator.Framework.Web" Namespace="Cooperator.Framework.Web.Controls" TagPrefix="nds" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">

<table class="CenteredTable" style="width: 100%;">
    <tr>
      <td class="LinkMenuRuta" style="height: 18px">
        &nbsp;<asp:LinkButton ID="lnkMenu" runat="server" Text="Menú" CausesValidation="False" />
        URMIM -> Consolidación Programas de Compras</td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td>
        Programaciones Consolidadas
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="4" GridLines="Both" Width="100%" AllowPaging="True" DataKeyNames="IDGRUPO, ESTADO" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:TemplateField HeaderText="Crear Solicitud">
              <ItemTemplate>
               <asp:CheckBox runat="server" id="chkSelect" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="7%" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="IDGRUPO" HeaderText="Correlativo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Suministro" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="15%" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Programaciones">
              <ItemTemplate>
                <asp:BulletedList runat="server" id="lstItems"></asp:BulletedList> 
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="51%" HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fuentes">
              <ItemTemplate>
                 <asp:HyperLink ID="hpFuentes" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDGRUPO", "frmMantProgramacionFuentesConsolidado.aspx?id={0}") %>'
                  Text="Consultar"/>
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="12%" HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Almacenes Entrega">
              <ItemTemplate>
                 <asp:HyperLink ID="hpEntregas" runat="server" Target="_self" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDGRUPO", "frmMantProgramacionAlmacenesConsolidado.aspx?id={0}") %>'
                  Text="Consultar" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="12%" HorizontalAlign="Center" VerticalAlign="Top" />
            </asp:TemplateField>
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones consolidadas</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    
    
    <tr>
      <td>
          <asp:Button ID="Button1" runat="server" Text="Enviar a UACI" />&nbsp;
      </td>
    </tr>
    <tr>
      <td>
        Programaciones Disponibles
      </td>
    </tr>
    <tr>
      <td>
        &nbsp;
      </td>
    </tr>
    <tr>
      <td>
        <asp:GridView ID="gvLista2" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          CellPadding="2" Width="100%" DataKeyNames="IDPROGRAMACION,IDSUMINISTRO" Font-Size="8pt">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" BackColor="Gainsboro" />
          <Columns>
            <asp:TemplateField HeaderText="Seleccionar">
              <ItemTemplate>
                <asp:CheckBox runat="server" ID="chkPrg" />
              </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="10%" HorizontalAlign="Center" />
            </asp:TemplateField>
              <asp:BoundField DataField="IDPROGRAMACION" HeaderText="IdPrg" />
            <asp:BoundField DataField="PERIODO" HeaderText="Periodo" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:BoundField>
             <asp:BoundField DataField="SUMINISTRO" HeaderText="Suministro" >
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripci&#243;n" >
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" Width="60%" />
            </asp:BoundField>
             
         </Columns>
          <EmptyDataTemplate>
            No se encontraron programaciones disponibles</EmptyDataTemplate>
        </asp:GridView>
      </td>
    </tr>
    <tr>
      <td align="right">
        <asp:Button runat="server" ID="btnIniciar" Text="Iniciar" Width="150px" />
      </td>
    </tr>
  </table>


  <nds:MsgBox ID="MsgBox1" runat="server"></nds:MsgBox>
</asp:Content>

