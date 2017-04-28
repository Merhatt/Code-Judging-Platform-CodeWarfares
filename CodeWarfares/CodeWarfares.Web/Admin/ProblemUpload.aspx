<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProblemUpload.aspx.cs" Inherits="CodeWarfares.Web.Admin.ProblemUpload" %>

<%@ Register Src="../CustomControls/ErrorDisplay.ascx" TagName="ErrorDisplay" TagPrefix="uc1" %>

<asp:Content ID="AdminPageContainer" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group admin-page">
        <uc1:ErrorDisplay id="ErrorDisplay" runat="server" />
        <div class="admin-el">
            <label class="btn btn-warning btn-file">
                Избери Условие
                <asp:FileUpload ID="DescriptionUpload" runat="server" CssClass="input-hidden" />
            </label>
        </div>
        <div class="admin-el">
            <asp:Label Text="Заглавие на Задачата" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="ProblemTitle"></asp:TextBox>
        </div>
        <div class="admin-el">
            <asp:Label Text="Линк на Снимката на задачата" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="ImgUrl"></asp:TextBox>
        </div>
        <div class="admin-el">
            <asp:Label Text="Максимално позволено време(ms)" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="MaxTime" TextMode="Number"></asp:TextBox>
        </div>
        <div class="admin-el">
            <asp:Label Text="Максимална позволена памет(kb)" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="MaxMemory" TextMode="Number"></asp:TextBox>
        </div>
        <div class="admin-el">
            <asp:Label Text="Точки за решена задача" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="Points" TextMode="Number"></asp:TextBox>
        </div>
        <div class="admin-el">
            <asp:Label Text="Изберете трудност" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="DropdownDifficulty">
            </asp:DropDownList>
        </div>
        <div class="admin-el">
            <asp:Label Text="Брой Тестове" runat="server"></asp:Label>
            <asp:TextBox CssClass="form-control ctr" runat="server" ID="TestsCount" TextMode="Number" AutoPostBack="true" OnTextChanged="TestsCount_TextChanged"></asp:TextBox>
            <div>
                <asp:Panel CssClass="vhod-panel-all" ID="VhodPanel" runat="server" GroupingText="Вход">
                    <asp:TextBox CssClass="vhod-panel form-control" ID="Vhod1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="vhod-panel form-control" ID="Vhod2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="vhod-panel form-control" ID="Vhod3" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="vhod-panel form-control" ID="Vhod4" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="vhod-panel form-control" ID="Vhod5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </asp:Panel>
                <asp:Panel CssClass="izhod-panel-all" ID="IzhodPanel" runat="server" GroupingText="Очакван Изход">
                    <asp:TextBox CssClass="izhod-panel form-control" ID="Izhod1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="izhod-panel form-control" ID="Izhod2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="izhod-panel form-control" ID="Izhod3" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="izhod-panel form-control" ID="Izhod4" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox CssClass="izhod-panel form-control" ID="Izhod5" runat="server" TextMode="MultiLine"></asp:TextBox>
                </asp:Panel>
                <div class="clear"></div>
            </div>
        </div>
        <asp:Button runat="server" ID="UploadButton" Text="Изпрати Задачата" OnClick="UploadButton_Click" CssClass="btn btn-success" />
    </div>
</asp:Content>
