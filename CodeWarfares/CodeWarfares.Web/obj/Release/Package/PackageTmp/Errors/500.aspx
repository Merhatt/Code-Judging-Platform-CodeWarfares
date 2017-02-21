<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="CodeWarfares.Web.Errors._500" %>
<%@ Register src="../CustomControls/ErrorPage.ascx" tagname="ErrorPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ErrorPage ID="ErrorPage1" runat="server" ErrorCode="500" />
</asp:Content>
