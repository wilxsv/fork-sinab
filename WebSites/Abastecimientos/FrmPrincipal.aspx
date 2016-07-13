<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="FrmPrincipal.aspx.vb" Inherits="FrmPricipal" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">
  <br />
  <br />
    
  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Maroon"
    Text="Avisos:" />
  <br />
  <asp:GridView ID="gvLista" runat="server" AutoGenerateColumns="False" CellPadding="4"
    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
    CellSpacing="2" Width="100%">
    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    <Columns>
      <asp:ImageField DataImageUrlField="IMAGEN" DataImageUrlFormatString="~/Imagenes/{0}"
        AlternateText="Nuevo" />
      <%--     <asp:BoundField  DataField="FECHAINICIO" HeaderText="Fecha">
        <ItemStyle HorizontalAlign="Left" />
        <HeaderStyle HorizontalAlign="Left" />
      </asp:BoundField> --%>
      <asp:BoundField DataField="MENSAJE" HeaderText="Mensaje" ItemStyle-HorizontalAlign="Left"
        HeaderStyle-HorizontalAlign="Left" />
    </Columns>
  </asp:GridView>
  <asp:MultiView ID="mvMensajes" runat="server">
      <asp:View runat="server" ID="vMensaje">
            <div class="aviso">
                <asp:Literal runat="server" ID="avisoMsj"/>
            </div>
        </asp:View>

        <asp:View runat="server" ID="vAlerta">
            <div class="alerta">
                <asp:Literal runat="server" ID="alertaMsj"/>
            </div>
        </asp:View>
        
        <asp:View ID="vError" runat="server">
            <div class="error">
                <asp:Literal runat="server" ID="errorMsj"/>
            </div>
        </asp:View>
    </asp:MultiView>
    
  <%-- <div class="aviso">Here's an info message.</div>
<div class="error">Here's an error message.</div>--%>

</asp:Content>
