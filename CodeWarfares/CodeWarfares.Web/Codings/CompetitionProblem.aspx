<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompetitionProblem.aspx.cs" Inherits="CodeWarfares.Web.Codings.CompetitionProblem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-up">
        <div class="float-left">
            <h3 runat="server" id="PageTitle" class="problem-title"></h3>
        </div>
        <div class="float-right">
            <asp:Button ID="GetDescription" class="btn btn-warning download" OnClick="GetDescription_Click" Text="Изтегли Условието" runat="server" />
        </div>
        <div class="clear"></div>
    </div>
    <div class="page-middle">
        <div class="form-group">
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control textbox-problem" ID="CodeText">

            </asp:TextBox>
        </div>
        <div class="float-left">
            <asp:Button ID="SendTask" class="btn btn-success" Text="Изпрати Решението" OnClick="SendTask_Click" runat="server" />
        </div>
        <div class="float-right">
            <asp:DropDownList runat="server" ID="DropdownLaungages">
            </asp:DropDownList>
        </div>
        <div class="float-right choose-laungage">
            Избери Програмен Език: 
        </div>
        <div class="clear"></div>
    </div>
</asp:Content>
