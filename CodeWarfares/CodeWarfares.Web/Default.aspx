<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodeWarfares.Web._Default" %>

<%@ Register src="CustomControls/MainPagePictures.ascx" tagname="MainPagePictures" tagprefix="uc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="home-background">
        <div class="header-text">
            <h1>Code Warfares</h1>
            <p class="lead">Място, където се състезаваш с най-добрите!</p>
        </div>

        <uc1:MainPagePictures ID="MainPagePictures1" runat="server" />
    </div>
</asp:Content>
