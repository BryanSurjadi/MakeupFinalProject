<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateType.aspx.cs" Inherits="MakeupFinalProject.Views.MakeupView.UpdateType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <h2>Update Makeup Type</h2>
        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

    </div>
    <asp:Button ID="updateBtn" runat="server" Text="Update Type" OnClick="updateBtn_Click" />
    <asp:Button ID="backBtn" runat="server" Text="Go back to Previous Page" OnClick="backBtn_Click" />
</asp:Content>
