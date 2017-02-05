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
    </div>
</asp:Content>
