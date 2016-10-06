<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
  CodeFile="inventario_desabastecimiento.aspx.vb" Inherits="FrmPricipal" %>

<%-- Agregue aquí los controles de contenido --%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="PageContent">
  <h1>Reporte de Inventario y Desabastecimiento</h1>
    <br />
    <table>
        <tr><td>Fecha de inventario: </td><td>[HASTA]: <input type="text" id="hasta"></td></tr>
        <tr>
            <td>Agrupación de productos VIH: </td>
            <td>
                <select>
                    <option value="pdf">PDF</option>
                    <option value="odt">ODT - Documento tipo word</option>
                    <option value="ods">ODS - Hoja de calculo</option>
                    <option value="xls">XLS</option>
                    <option value="csv">CSV</option>
                    <option value="json">JSON</option>
                    <option value="xml">XML</option>
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
        <tr><td></td><td><p style="text-align:right"><input type="hidden" id="url" value="" /> <button onclick="OpenInNewTabWinBrowser();"> Generar reporte.</button></p> </td></tr>
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
