<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SiteMapDisplay.ascx.cs" Inherits="CodeWarfares.Web.CustomControls.SiteMapDisplay" %>
<div class="hideSkiplink">
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" SkipLinkText=""
        EnableViewState="False" IncludeStyleBlock="False" Orientation="Horizontal"
        DataSourceID="SiteMapDataSource" StaticDisplayLevels="2">
    </asp:Menu>
</div>
