<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompetitionsCategory.aspx.cs" Inherits="CodeWarfares.Web.Codings.CompetitionsCategory" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewProblems" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" DataKeyNames="ID" PageSize="10"
            onpageindexchanging="GridViewProblems_PageIndexChanging">
            <Columns>
                <asp:ImageField DataImageUrlField="CoverImageUrl" HeaderText="Снимка"></asp:ImageField>
                <asp:BoundField DataField="Name" HeaderText="Име" />
                <asp:BoundField DataField="Description" HeaderText="Описание" />   
            </Columns>
        </asp:GridView>
</asp:Content>
