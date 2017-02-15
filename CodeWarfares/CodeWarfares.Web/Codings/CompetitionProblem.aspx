<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="CompetitionProblem.aspx.cs" Inherits="CodeWarfares.Web.Codings.CompetitionProblem" %>

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
    <div>
        <asp:UpdatePanel ID="UpdatePanelCountriesTowns" UpdateMode="Conditional"
            runat="server" class="panel">
            <ContentTemplate>
                <asp:GridView ID="SubmitionsGridView" runat="server" AutoGenerateColumns="False"
                    AllowPaging="True" DataKeyNames="ID" ItemType="CodeWarfares.Data.Models.Submition"
                    OnPageIndexChanging="SubmitionsGridView_PageIndexChanging" PageSize="10"
                    OnRowDataBound="SubmitionsGridView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="SubmitionTime" HeaderText="Submition Time" DataFormatString="{0:MMMM d, yyyy}" />
                        <asp:TemplateField HeaderText="Test Progress">
                            <ItemTemplate>
                                <progress value="<%# Eval("CompletedPercentage") %>" max="100"></progress>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
