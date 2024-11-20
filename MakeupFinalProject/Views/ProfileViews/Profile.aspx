<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MakeupFinalProject.Views.ProfileViews.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <h2>Account Profile</h2>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="usernameTxt" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
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
        <asp:Label ID="errorLbl" runat="server" Text=""></asp:Label>
        <asp:Button ID="updateBtn" runat="server" Text="Update Profile" OnClick="updateBtn_Click" />

        <h2>Change Password</h2>
            <asp:Label ID="passwordErrorLbl" runat="server" ></asp:Label><br />
            <asp:Label ID="oldPasswordLbl" runat="server" Text="Old Password: "></asp:Label>
            <asp:TextBox ID="oldPasswordTxt" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="newPasswordLbl" runat="server" Text="New Password: "></asp:Label>
            <asp:TextBox ID="newPasswordTxt" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="updatePasswordBtn" runat="server" Text="Update Password" OnClick="updatePasswordBtn_Click" />
        <br />
       

    </div>

</asp:Content>
