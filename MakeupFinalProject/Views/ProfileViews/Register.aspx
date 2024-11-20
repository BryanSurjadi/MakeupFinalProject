<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MakeupFinalProject.Views.ProfileViews.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register an Account</h2>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="passTxt" runat="server" Type="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label>
                <asp:TextBox ID="confirmPassTxt" runat="server" Type="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
                <asp:RadioButtonList ID="genderList" runat="server">
                    <asp:ListItem Value="Male">
                        Male
                    </asp:ListItem>
                    <asp:ListItem Value="Female">
                        Female
                    </asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <div>
                <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>
                <asp:Calendar ID="dobCalendar" runat="server"></asp:Calendar>
            </div>
            <asp:Label ID="errorTxt" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
        </div>
        <asp:Label ID="Label7" runat="server" Text="Already have an account? "></asp:Label>
        <asp:Button ID="loginBtn" runat="server" Text="Login Here" OnClick="loginBtn_Click" />
    </form>
</body>
</html>
