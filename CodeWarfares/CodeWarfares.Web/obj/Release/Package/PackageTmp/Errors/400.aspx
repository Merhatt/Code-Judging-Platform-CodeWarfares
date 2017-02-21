<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="400.aspx.cs" Inherits="CodeWarfares.Web.Errors._400" %>
<%@ Register src="../CustomControls/ErrorPage.ascx" tagname="ErrorPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ErrorPage ID="ErrorPage1" runat="server" ErrorCode="400"/>
</asp:Content>
