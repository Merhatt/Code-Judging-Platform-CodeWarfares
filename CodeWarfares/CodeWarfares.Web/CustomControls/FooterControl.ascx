<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterControl.ascx.cs" Inherits="CodeWarfares.Web.CustomControls.FooterControl" %>
<footer>
    <p>&copy; <%: DateTime.Now.Year %> - <asp:Label runat="server" ID="WebsiteName"></asp:Label></p>
</footer>
