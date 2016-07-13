<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ReportesFiltros.ascx.vb" Inherits="UACI_CERTIFICACION_Controles_ReportesFiltros" %>

<div>
    Proceso:
              <asp:DropDownList ID="ddSuministros" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddSuministros_SelectedIndexChanged">
              </asp:DropDownList>
    <asp:DropDownList ID="ddprocesos" runat="server">
    </asp:DropDownList>
</div>

<hr />
<div>
    Proveedor:
        <asp:RadioButtonList ID="rblProveedor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblProveedor_SelectedIndexChanged"
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
            <asp:ListItem Value="1">Proveedor Específico</asp:ListItem>
        </asp:RadioButtonList>
    <asp:Panel runat="server" ID="PnlNit" Visible="False" Style="padding: 5px">
        <asp:Label ID="Label1" runat="server" Text="NIT:" />
        <asp:TextBox ID="tbNit" runat="server" MaxLength="14" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbNit"
            ErrorMessage="* Dato Requerido" ValidationGroup="1" />
    </asp:Panel>
</div>
<hr />
<asp:Panel runat="server" ID="pnlProducto">
    <div>
        Producto:
              <asp:RadioButtonList ID="rblProducto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblProducto_SelectedIndexChanged"
                  RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="0">Todos</asp:ListItem>
                  <asp:ListItem Value="1">Producto Específico</asp:ListItem>
              </asp:RadioButtonList>
        <asp:Panel runat="server" ID="pnlCodigo" Visible="False" Style="padding: 5px">
            <asp:Label ID="Label2" runat="server" Text="Código: " />
            <asp:TextBox ID="tbCodigo" runat="server" MaxLength="8" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCodigo"
                ErrorMessage="* Dato Requerido" ValidationGroup="1" />
        </asp:Panel>
    </div>
    <hr />
</asp:Panel>
<asp:Panel runat="server" ID="pnlEstado">
    <div>
        Estado de Producto:
              <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal">
                  <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                  <asp:ListItem Value="0">Certificado</asp:ListItem>
                  <asp:ListItem Value="1">No Certificado</asp:ListItem>
              </asp:RadioButtonList>

    </div>
    <hr />
</asp:Panel>
<asp:Panel runat="server" ID="pnlFechaLimite" Visible="False">
    <div>
        Fecha límite: 
        <asp:TextBox runat="server" ID="tbFecha" CssClass="datefield" />
        <asp:RequiredFieldValidator ID="rvfFecha" runat="server" ControlToValidate="tbFecha" ErrorMessage="* Dato Requerido" ValidationGroup="1" />
        <asp:CompareValidator ID="cvFecha" runat="server" ControlToValidate="tbFecha"
            ErrorMessage="* Formato Inválido" Operator="DataTypeCheck" Type="Date" ValidationGroup="1" Display="Dynamic" />
    </div>
    <hr />
</asp:Panel>
