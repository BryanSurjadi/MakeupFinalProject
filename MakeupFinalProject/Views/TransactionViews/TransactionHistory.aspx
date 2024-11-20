<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="MakeupFinalProject.Views.TransactionViews.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <h2>Transaction History</h2>
        <asp:GridView ID="transactionView" runat="server" AutoGenerateColumns="False" OnRowCommand="transactionView_RowCommand">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="ID" SortExpression="TransactionID" />
                <asp:BoundField DataField="User.Username" HeaderText="Name" SortExpression="Users.Username" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" SortExpression="TransactionDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                
                <asp:ButtonField ButtonType="Button" CommandName="ViewDetails" HeaderText="View Details" ShowHeader="False" Text="View Details" />
                
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>
