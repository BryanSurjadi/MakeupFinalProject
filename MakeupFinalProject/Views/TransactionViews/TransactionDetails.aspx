<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="TransactionDetails.aspx.cs" Inherits="MakeupFinalProject.Views.TransactionViews.TransactionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div>
        <h2>Transaction Details</h2>
        
        <asp:Label ID="lblTransactionID" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblTransactionDate" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label><br />

        <asp:GridView ID="transactionDetailsView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
