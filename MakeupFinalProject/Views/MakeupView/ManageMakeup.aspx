<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageMakeup.aspx.cs" Inherits="MakeupFinalProject.Views.MakeupView.ManageMakeup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <header>
            <h2>Makeups</h2>
        </header>
        <asp:GridView ID="makeupList" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowDeleting="makeupList_RowDeleting" OnRowEditing="makeupList_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="MakeupID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupTypeID" HeaderText="Type ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupBrandID" HeaderText="Brand ID" SortExpression="MakeupBrandID" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="insertMakeupBtn" runat="server" Text="Insert New Makeup" OnClick="insertMakeupBtn_Click" CssClass="button" />
    </div>

    <div class="container">
        <header>
            <h2>Makeup Types</h2>
        </header>
        <asp:GridView ID="typeList" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowDeleting="typeList_RowDeleting" OnRowEditing="typeList_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupTypeID" HeaderText="ID" SortExpression="MakeupTypeID" />
                <asp:BoundField DataField="MakeupTypeName" HeaderText="Type Name" SortExpression="MakeupTypeName" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="insertTypeBtn" runat="server" Text="Insert New Type" OnClick="insertTypeBtn_Click" CssClass="button" />
    </div>

    <div class="container">
        <header>
            <h2>Makeup Brands</h2>
        </header>
        <asp:GridView ID="brandList" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowDeleting="brandList_RowDeleting" OnRowEditing="brandList_RowEditing">
            <Columns>
                <asp:BoundField DataField="MakeupBrandID" HeaderText="ID" SortExpression="MakeupBrandID" />
                <asp:BoundField DataField="MakeupBrandName" HeaderText="Brand Name" SortExpression="MakeupBrandName" />
                <asp:BoundField DataField="MakeupBrandRating" HeaderText="Rating" SortExpression="MakeupBrandRating" />
                <asp:CommandField ButtonType="Button" HeaderText="Actions" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="insertBrandBtn" runat="server" Text="Insert New Brand" OnClick="insertBrandBtn_Click" CssClass="button" />
    </div>
</asp:Content>
