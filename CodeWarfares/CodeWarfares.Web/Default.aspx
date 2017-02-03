<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CodeWarfares.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="home-background">
        <div class="header-text">
            <h1>Code Warfares</h1>
            <p class="lead">Място, където се състезаваш с най-добрите!</p>
        </div>

        <div class="row home-menus">
            <div class="col-md-4">
                <img src="/Images/competition.png" alt="comp" class="competition-img" />
                <h2><a href="/Competitions.aspx">Състезания</a></h2>
                <p>
                    Изкачвай се в класацията сред най-добрите в България
                </p>
            </div>
            <div class="col-md-4">
                <img src="/Images/algorithms.jpg" alt="comp" class="competition-img" />
                <h2><a href="/Competitions.aspx">Алгоритми</a></h2>
                <p>
                    Научавай нови структори от данни и алгоритми и развивай уменията си до като се забавляваш
                </p>
            </div>
            <div class="col-md-4">
                <img src="/Images/cloud.png" alt="comp" class="competition-img" />
                <h2><a href="/Competitions.aspx">Оценяване</a></h2>
                <p>
                    Пращайте код, който се оценява в cloud-a, и получавайте feedback на момента
                </p>
            </div>
        </div>
    </div>
</asp:Content>
