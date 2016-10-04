<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="ingreso.aspx.vb" Inherits="FrmPricipal" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">
  <h1>Reporte de Ingresos por grupo de productos VIH</h1>
    <br />
    <table>
        <tr><td>Fecha de ingresos: </td><td><asp:Calendar ID="Calendar1" runat="server"></asp:Calendar></td></tr>
        <tr>
            <td>Agrupación de productos VIH: </td>
            <td>
                <select>
                    <option>Antirretrovirales</option>
                    <option>Pruebas de VIH</option>
                    <option>Insumos para pruebas de VIH</option>
                    <option>Infecciones Oportunistas</option>
                    <option>ITS</option>
                    <option>Otros VIH</option>
                    <option>Todos</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>Tipo de documento: </td>
            <td>
                <select>
                    <option>PDF</option>
                    <option>ODT - Documento tipo word</option>
                    <option>ODS - Hoja de calculo</option>
                    <option>XLS</option>
                    <option>CSV</option>
                    <option>JSON</option>
                    <option>XML</option>
                </select>
            </td>
        </tr>
        <tr><td></td><td><p style="text-align:right"><button> Generar reporte.</button></p> </td></tr>

    </table>
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
