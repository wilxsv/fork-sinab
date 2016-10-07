<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="inventario.aspx.vb" Inherits="FrmPricipal" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">      
  <h1>Reporte de Inventarios por grupo de productos VIH</h1>
    <br>
    <table>
        <tbody><tr><td>Inventario hasta la fecha: </td><td><input type="text" id="hasta" class="hasDatepicker"></td></tr>
        <tr>
            <td>Agrupación de productos VIH: </td>
            <td>
                <select id="tipo">
                    <option value="6">Antirretrovirales</option>
                    <option value="7">Pruebas de VIH</option>
                    <option value="8">Insumos para pruebas de VIH</option>
                    <option value="9">Infecciones Oportunistas</option>
                    <option value="10">ITS</option>
                    <option value="11">Otros VIH</option>
                    <option value="2" selected>Todos</option>
                </select>
            </td>
        </tr>
        <tr>
            <td>Tipo de documento: </td>
            <td>
                <select id="format">
                    <option value="pdf" selected>PDF</option>
                    <option value="odt">ODT - Documento tipo word</option>
                    <option value="ods">ODS - Hoja de calculo</option>
                    <option value="xls">XLS</option>
                    <option value="csv">CSV</option>
                    <option value="json">JSON</option>
                    <option value="xml">XML</option>
                </select>
            </td>
        </tr>
        <input type="hidden" id="unit" value="pvih_inventario"> 
        <input type="hidden" id="titulo" value="Inventarios por grupo de productos VIH"> 
        <tr><td></td><td><p style="text-align:right"><button onclick="OpenInNewTabWinBrowser();"> Generar reporte.</button></p> </td></tr>

    </tbody></table>
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
