<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="FrmRequisicionElegir.aspx.vb" Inherits="ALMACEN_FrmRequisicionElegir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
        <div>
            <div>
            <asp:Label runat="server" Text="Código de requisición: " />
            <asp:TextBox runat="server" ID="tbReqCode" />
            </div>
        </div>
        </asp:View>
         <asp:View ID="View2" runat="server">
    </asp:View>
    </asp:MultiView>
   
</asp:Content>

