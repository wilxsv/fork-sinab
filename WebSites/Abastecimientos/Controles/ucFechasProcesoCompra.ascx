<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucFechasProcesoCompra.ascx.vb" Inherits="Controles_ucFechasProcesoCompra" %>

        
    
<asp:MultiView runat="server" ID="mv">
    <asp:View runat="server" ID="vinfo">
        <table class="CenteredTable">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label4" runat="server" Text="Fecha de publicación:" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaPublicacion" runat="server"  />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label6" runat="server" Text="Fecha de iniciado el proceso de compra:" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaIniciadoProceso" runat="server"  />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label8" runat="server" Text="Fecha de inicio para recepción de ofertas" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaRecepcionOfertas" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label11" runat="server" Text="Fecha final para recepción de ofertas" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaFinRecepOferta" runat="server" />
        </td>
    </tr>
             <tr>
        <td class="LabelCell">
            <asp:Label ID="Label9" runat="server" Text="Fecha de inicio de apertura" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblinicioapertura" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label12" runat="server" Text="Fecha de fin de apertura" />
        </td>
        <td class="DataCell">
            <asp:label ID="lblfinapertura" runat="server"  />
        </td>
    </tr>
</table>
        <asp:Button runat="server" Text="Editar" ID="btnEdit"/>
    </asp:View>
    <asp:View runat="server" ID="vform">
        <table class="CenteredTable">
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label1" runat="server" Text="Fecha de publicación:" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaPublicacion2" runat="server"  />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label2" runat="server" Text="Fecha de iniciado el proceso de compra:" />
        </td>
        <td class="DataCell">
            <asp:Label ID="lblFechaIniciadoProceso2" runat="server" />
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label3" runat="server" Text="Fecha de inicio para recepción de ofertas" />
        </td>
        <td class="DataCell">
            <asp:TextBox ID="tbFechaRecepcionOfertas" runat="server" CssClass="datefield" />
            <asp:TextBox runat="server" ID="tbTiempoRecepcionOfertas" CssClass="timefield"/>
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label10" runat="server" Text="Fecha final para recepción de ofertas" />
        </td>
        <td class="DataCell">
            <asp:TextBox ID="tbFechaFinRecepOferta" runat="server"  CssClass="datefield" />
             <asp:TextBox runat="server" ID="tbTiempoFinRecepOferta" CssClass="timefield"/>
        </td>
    </tr>
            <tr>
        <td class="LabelCell">
            <asp:Label ID="Label5" runat="server" Text="Fecha de inicio de apertura" />
        </td>
        <td class="DataCell">
            <asp:TextBox ID="tbInicioApertura" runat="server" CssClass="datefield" />
             <asp:TextBox runat="server" ID="tbTiempoInicioApertura" CssClass="timefield"/>
        </td>
    </tr>
    <tr>
        <td class="LabelCell">
            <asp:Label ID="Label7" runat="server" Text="Fecha de fin de apertura" />
        </td>
        <td class="DataCell">
            <asp:TextBox ID="tbfinapertura" runat="server"  CssClass="datefield" />
            <asp:TextBox runat="server" ID="tbTiempofinapertura" CssClass="timefield"/>
        </td>
    </tr>
</table>
        <div>
            <asp:Button runat="server" ID="btnOk" Text="Guardar" OnClientClick="return confirm('Esto cambiará las fechas del proceso de compra y puede afectar las operaciones que sobre el proceso se realizan. ¿Está seguro/a de continuar?')" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancelar"/>
        </div>
    </asp:View>
</asp:MultiView>
