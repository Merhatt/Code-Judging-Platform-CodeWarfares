<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompetitionsCategory.aspx.cs" Inherits="CodeWarfares.Web.Codings.CompetitionsCategory" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="task-group">
        <h3><%#: this.CategoryName %></h3>
        <asp:ListView ID="Problems" runat="server"
            ItemType="CodeWarfares.Data.Models.Problem">
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="task-description tasks-page">
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
                    <% 
                        if (this.User.IsInRole("Administrator"))
                        {
                    %>
                    <ul class="ul-normal">
                        <li>
                            <a href="/Admin/ProblemEdit?Id=<%#: Item.Id %> " class="link-button btn btn-primary">Редактирай</a>
                        </li>
                    </ul>
                    <%
                        }
                    %>
                </div>
            </ItemTemplate>
        </asp:ListView>
        <div class="clear"></div>
        <asp:DataPager ID="DataPagerProblems" runat="server"
            PagedControlID="Problems" PageSize="8"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="false" />
                <asp:NumericPagerField CurrentPageLabelCssClass="page-list page-current" NumericButtonCssClass="page-list" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>
