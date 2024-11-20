<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="InsertMakeup.aspx.cs" Inherits="MakeupFinalProject.Views.MakeupView.InsertMakeup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
    <h1>Insert Makeup</h1>
    <div>
        <asp:Label ID="nameLbl" runat="server" Text="Makeup Name"></asp:Label>
        <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" Text="Makeup Price"></asp:Label>
        <asp:TextBox ID="priceTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Makeup Weight"></asp:Label>
        <asp:TextBox ID="weightTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label3" runat="server" Text="Makeup Type ID"></asp:Label>
        <asp:TextBox ID="typeTxt" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="Label4" runat="server" Text="Makeup Brand ID"></asp:Label>
        <asp:TextBox ID="brandTxt" runat="server"></asp:TextBox>
    </div>
    <div>
    <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>

    </div>
    <asp:Button ID="updateBtn" runat="server" Text="Insert Makeup" OnClick="insertBtn_Click" />
    <asp:Button ID="backBtn" runat="server" Text="Go back to Previous Page" OnClick="backBtn_Click" />
</div>
</asp:Content>
