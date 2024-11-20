<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MakeupFinalProject.Views.HomeViews.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <div class="user-info">
            <asp:Label ID="Label1" runat="server" CssClass="label" Text="Hello"></asp:Label>
            <asp:Label ID="nameLbl" runat="server" Text=""></asp:Label>
            <asp:Label ID="roleLbl" runat="server" Text=""></asp:Label>
        </div>

        <header>
            <h1>Customer List</h1>
            <hr />
        </header>

        <asp:GridView ID="userView" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID" />
                <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                <asp:BoundField DataField="UserDOB" HeaderText="DOB" SortExpression="UserDOB" />
                <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
                <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
