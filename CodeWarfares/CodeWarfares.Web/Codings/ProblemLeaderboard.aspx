<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemLeaderboard.aspx.cs" Inherits="CodeWarfares.Web.Codings.ProblemLeaderboard" %>

<asp:Content ID="Body" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ProblemName" runat="server" class="leaderboard-problemname"></asp:Label>
    <asp:GridView ID="ProblemLeaderboardGridView" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" DataKeyNames="ID" ItemType="CodeWarfares.Data.Models.Submition"
        OnPageIndexChanging="ProblemLeaderboardGridView_PageIndexChanging" PageSize="20"
        CssClass="history-table">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Име">
                <ItemTemplate>
                    <div> <%#: Eval("Author.UserName") %></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Точки">
                <ItemTemplate>
                    <div class="progress-text"><%# Eval("CompletedPercentage") %>/100</div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Прогрес">
                <ItemTemplate>
                    <progress value="<%# Eval("CompletedPercentage") %>" max="100"></progress>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
