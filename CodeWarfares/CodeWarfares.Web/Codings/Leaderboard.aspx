<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="CodeWarfares.Web.Codings.Leaderboard" %>
<%@ OutputCache Duration="30" VaryByParam="None" %>
<asp:Content ID="PageBody" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="ProblemName" runat="server" class="leaderboard-problemname"></asp:Label>
    <asp:GridView ID="ProblemLeaderboardGridView" runat="server" AutoGenerateColumns="False"
        AllowPaging="True" DataKeyNames="ID" ItemType="CodeWarfares.Data.Models.User"
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
                    <div> <%#: Eval("UserName") %></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Общи Точки">
                <ItemTemplate>
                    <div class="progress-text"><%# Eval("TotalPoints") %></div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
