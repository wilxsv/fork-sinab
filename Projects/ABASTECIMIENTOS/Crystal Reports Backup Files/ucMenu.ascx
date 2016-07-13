<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucMenu.ascx.vb" Inherits="ucMenu" %>
<asp:Menu ID="Menu1" runat="server" CssClass="menu" 
DynamicVerticalOffset="1" Orientation="Horizontal"
  DynamicHorizontalOffset="2" StaticSubMenuIndent="10px" RenderingMode="List" 
    StaticEnableDefaultPopOutImage="False" DisappearAfter="500">
    <StaticSelectedStyle CssClass="active" />
</asp:Menu>
