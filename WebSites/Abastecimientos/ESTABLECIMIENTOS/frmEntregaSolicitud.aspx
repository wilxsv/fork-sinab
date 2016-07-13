<%@ Page Language="VB" MasterPageFile="~/Mastersinmenu.master" MaintainScrollPositionOnPostback="True"
  AutoEventWireup="false" CodeFile="frmEntregaSolicitud.aspx.vb" Inherits="frmEntregaSolicitud" %>

<%@ Register Src="~/Controles/ucPlazosEntregaModificacion.ascx" TagName="ucPlazosEntregaModificacion"
  TagPrefix="uc2" %>
<%@ MasterType VirtualPath="~/Mastersinmenu.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <table width="100%" align="left">
    <tr>
      <td align="left" width="40%">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/botones/Salir.JPG" /></td>
      <td align="center" width="60%">
        <asp:TextBox ID="txtIDSOLICITUD" runat="server" Visible="False" Width="25px"></asp:TextBox></td>
    </tr>
    <tr>
      <td align="center" valign="top" width="40%">
        <asp:TreeView ID="TvEntregas" runat="server" Font-Names="Verdana" Font-Size="Small"
          ImageSet="Inbox" SkipLinkText="" Width="137px">
          <ParentNodeStyle Font-Bold="False" ForeColor="Navy" />
          <HoverNodeStyle Font-Underline="True" />
          <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
          <RootNodeStyle ForeColor="Navy" />
          <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
            NodeSpacing="0px" VerticalPadding="0px" />
        </asp:TreeView>
      </td>
      <td align="center" valign="top" width="60%">
        <uc2:ucPlazosEntregaModificacion ID="UcPlazosEntregaModificacion1" runat="server" />
      </td>
    </tr>
  </table>
</asp:Content>
