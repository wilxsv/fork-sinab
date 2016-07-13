<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FrmImpresionComision.aspx.vb"
    Inherits="FrmImpresionComision" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Impresión de Comisión</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblcomision" runat="server" Font-Bold="True" Text="COMISION:" />&nbsp;
        <asp:Label ID="Label2" runat="server" /><br />
        <asp:GridView ID="gvComisionEvaluacion" runat="server" AutoGenerateColumns="False"
            DataKeyNames="idempleado,nombre,cargo">
            <Columns>
                <asp:BoundField DataField="idempleado" HeaderText="C&#243;digo" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                <asp:TemplateField HeaderText="Habilitado">
                    <ItemTemplate>
                        <%#EstaHabilitadoEmpleado(CType(Eval("estahabilitado"), Integer))%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" Text="Imprimir" />
    </form>
</body>
</html>
