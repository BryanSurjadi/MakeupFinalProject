<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="OrderMakeup.aspx.cs" Inherits="MakeupFinalProject.Views.MakeupView.OrderMakeup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentBody" runat="server">
    <div class="container">
        <header>
            <h1>Featured Products</h1>
        </header>
        <asp:GridView ID="MakeupList" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowCommand="MakeupList_RowCommand">
            <Columns>
                <asp:BoundField DataField="MakeupID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="MakeupName" HeaderText="Makeup Name" SortExpression="MakeupName" />
                <asp:BoundField DataField="MakeupPrice" HeaderText="Price" SortExpression="MakeupPrice" />
                <asp:BoundField DataField="MakeupWeight" HeaderText="Weight" SortExpression="MakeupWeight" />
                <asp:BoundField DataField="MakeupType.MakeupTypeName" HeaderText="Type" SortExpression="MakeupTypes.MakeupTypeName" />
                <asp:BoundField DataField="MakeupBrand.MakeupBrandName" HeaderText="Brand" SortExpression="MakeupBrands.MakeupBrandName" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="QuantityTextBox" runat="server" Text="1" Width="50px" CssClass="input" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="OrderButton" runat="server" CommandName="Order" CommandArgument='<%# Eval("MakeupID") %>' Text="Order" CssClass="button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="errorLbl" runat="server" CssClass="error-label" Text=""></asp:Label>
    </div>
    <hr />
    <div class="container">
        <header>
            <h1>Carts</h1>
        </header>
        <asp:Label ID="cartLbl" runat="server" CssClass="label" Text=""></asp:Label>
        <asp:Label ID="cartLbl2" runat="server" CssClass="label" Text=""></asp:Label>
        <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="Makeup.MakeupName" HeaderText="Name" SortExpression="Makeups.MakeupName" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="clearBtn" runat="server" Text="Clear Cart" OnClick="clearBtn_Click" CssClass="button" />
        <asp:Button ID="coBtn" runat="server" Text="Checkout" OnClick="coBtn_Click" CssClass="button" />
    </div>
</asp:Content>
