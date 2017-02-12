<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Competitions.aspx.cs" Inherits="CodeWarfares.Web.Codings.Competitions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="task-group">
        <asp:ListView ID="EasyProblems" runat="server"
            ItemType="CodeWarfares.Data.Models.Problem">
            <LayoutTemplate>
                <h3>Лесни Задачи</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="task-description">
                    <a href="/Codings/CompetitionProblem?Id=<%#: Item.Id %> ">
                        <div class="task-img">
                            <div class="up-bar">
                                <span class="task-name"><%#: Item.Name %></span>
                                <span class="task-points">
                                    <img src="/Images/points.png" alt="points" />
                                    +<%#: Item.Xp %> Точки</span>
                            </div>
                            <img src="<%#: Item.CoverImageUrl %>" />
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clear"></div>
        <div>
            <a href="/Codings/CompetitionsCategory?Difficulty=Easy">Виж всички</a>
        </div>
    </div>

    <div class="task-group">
        <asp:ListView ID="MediumProblems" runat="server"
            ItemType="CodeWarfares.Data.Models.Problem">
            <LayoutTemplate>
                <h3>Средни Задачи</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="task-description">
                    <a href="/CompetitionProblem?Id=<%#: Item.Id %> ">
                        <div class="task-img">
                            <div class="up-bar">
                                <span class="task-name"><%#: Item.Name %></span>
                                <span class="task-points">
                                    <img src="/Images/points.png" alt="points" />
                                    +<%#: Item.Xp %> Точки</span>
                            </div>
                            <img src="<%#: Item.CoverImageUrl %>" />
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clear"></div>
        <div>
            <a href="/Codings/CompetitionsCategory?Difficulty=Medium">Виж всички</a>
        </div>
    </div>

     <div class="task-group">
        <asp:ListView ID="HardProblems" runat="server"
            ItemType="CodeWarfares.Data.Models.Problem">
            <LayoutTemplate>
                <h3>Трудни Задачи</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="task-description">
                    <a href="/CompetitionProblem?Id=<%#: Item.Id %> ">
                        <div class="task-img">
                            <div class="up-bar">
                                <span class="task-name"><%#: Item.Name %></span>
                                <span class="task-points">
                                    <img src="/Images/points.png" alt="points" />
                                    +<%#: Item.Xp %> Точки</span>
                            </div>
                            <img src="<%#: Item.CoverImageUrl %>" />
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clear"></div>
        <div>
            <a href="/Codings/CompetitionsCategory?Difficulty=Hard">Виж всички</a>
        </div>
    </div>

    <div class="task-group">
        <asp:ListView ID="VeryHardProblems" runat="server"
            ItemType="CodeWarfares.Data.Models.Problem">
            <LayoutTemplate>
                <h3>Много Трудни Задачи</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="task-description">
                    <a href="/CompetitionProblem?Id=<%#: Item.Id %> ">
                        <div class="task-img">
                            <div class="up-bar">
                                <span class="task-name"><%#: Item.Name %></span>
                                <span class="task-points">
                                    <img src="/Images/points.png" alt="points" />
                                    +<%#: Item.Xp %> Точки</span>
                            </div>
                            <img src="<%#: Item.CoverImageUrl %>" />
                        </div>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clear"></div>
        <div>
            <a href="/Codings/CompetitionsCategory?Difficulty=VeryHard">Виж всички</a>
        </div>
    </div>
</asp:Content>
