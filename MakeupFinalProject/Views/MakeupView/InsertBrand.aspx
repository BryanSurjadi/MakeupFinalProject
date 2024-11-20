<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="InsertBrand.aspx.cs" Inherits="MakeupFinalProject.Views.MakeupView.InsertBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
    <h2>Insert Makeup Brand</h2>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Brand Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Brand Rating"></asp:Label>
        <asp:TextBox ID="rateTxt" runat="server"></asp:TextBox>
    </div>
</div>
<div>
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

</div>
<asp:Button ID="updateBtn" runat="server" Text="Insert Brand" OnClick="insertBtn_Click" />
<asp:Button ID="backBtn" runat="server" Text="Go back to Previous Page" OnClick="backBtn_Click" />
</asp:Content>
