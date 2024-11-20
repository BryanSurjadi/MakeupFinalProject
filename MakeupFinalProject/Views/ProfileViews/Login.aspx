<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MakeupFinalProject.Views.ProfileViews.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="~/Styles/AdminStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <header>
                <h1>Login</h1>
            </header>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Username"></asp:Label>
                <asp:TextBox ID="usernameTxt" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Password"></asp:Label>
                <asp:TextBox ID="passTxt" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:CheckBox ID="isRemember" runat="server" CssClass="checkbox" Text="Remember me?" />
            </div>
            <div class="form-group">
                <asp:Label ID="errorLbl" runat="server" CssClass="error-label" Text=""></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="loginBtn" runat="server" CssClass="button" Text="Login" OnClick="loginBtn_Click" />
            </div>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" CssClass="label" Text="Don't have an account? "></asp:Label>
                <asp:Button ID="registerBtn" runat="server" CssClass="button" Text="Register Here" OnClick="registerBtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
