<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="frmGenerarAclaraciones.aspx.vb" Inherits="frmGenerarAclaraciones" ValidateRequest="false"
  MaintainScrollPositionOnPostback="true" %>

<%@ Register Src="~/Controles/ucBarraNavegacion.ascx" TagName="ucBarraNavegacion"
  TagPrefix="uc3" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content runat="server" ID="cmenu" ContentPlaceHolderID="MenuContent">
    <asp:LinkButton ID="LnkMenu" runat="server" CausesValidation="False" Text="Menú"/>
        <asp:Label ID="LblRuta" runat="server" Text="UACI » Adjudicación » Generar Aclaraciones" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <asp:Panel runat="server" ID="pNavegacion" >
          <div class="NavBar" style="text-align: left">
              <asp:LinkButton runat="server" ID="btGuardar" Text="Agregar" CssClass="opAgregar" Width="50px"/>
          </div>
          </asp:Panel>
   <div class="CenteredTable">
   
     <div style="text-align: left">
        <asp:Label ID="lblSeleccione" runat="server" Text="Seleccione la Aclaración:" />
        </div>
        
        <asp:GridView ID="gvAclaraciones" runat="server" CssClass="Grid" AutoGenerateColumns="False"
          Width="726px" AllowPaging="True" DataKeyNames="IDACLARACION" GridLines="None">
          <HeaderStyle CssClass="GridListHeader" />
          <FooterStyle CssClass="GridListFooter" />
          <PagerStyle CssClass="GridListPager" />
          <RowStyle CssClass="GridListItem" />
          <SelectedRowStyle CssClass="GridListSelectedItem" />
          <EditRowStyle CssClass="GridListEditItem" />
          <AlternatingRowStyle CssClass="GridListAlternatingItem" />
          <Columns>
            <asp:CommandField HeaderText="Ver/Imprimir" SelectText="Ver" ShowSelectButton="True" />
            <asp:BoundField DataField="IDACLARACION" HeaderText="ID Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="IdProcesoCompra" HeaderText="Proceso de compra">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="NUMEROACLARACION" HeaderText="Numero de Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="FECHAACLARACION" HeaderText="Fecha de Aclaracion">
              <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
          </Columns>
          <EmptyDataTemplate>
            No hay Aclaraciones para este Procesos.
          </EmptyDataTemplate>
        </asp:GridView>
     </div> 
</asp:Content>
