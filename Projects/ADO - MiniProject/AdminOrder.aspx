<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdminOrder.aspx.cs" Inherits="RestaurantOrderingSystem.AdminOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Order Management</h2>
    <style>
        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-family: Arial, sans-serif;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .grid-view th {
            background-color: #007bff;
            color: white;
            font-weight: bold;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-view tr:hover {
            background-color: #ddd;
        }
    </style>
    
    <asp:GridView ID="gvManageOrders" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
            <asp:BoundField DataField="CName" HeaderText="Customer Name" />
            <asp:BoundField DataField="Items" HeaderText="Items" />
            <asp:BoundField DataField="DateOrdered" HeaderText="Order Date" />
            <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="status-dropdown" >
                        <asp:ListItem Text="Pending" Value="Pending" />
                        <asp:ListItem Text="Accepted" Value="Accepted" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="ButtonUpdate" runat="server" Text="Update" 
                        OnClick="ButtonUpdate_Click" 
                        CommandArgument='<%# Eval("OrderID") %>' 
                        CssClass="update-button" />
                </ItemTemplate>
            </asp:TemplateField> 

        </Columns>
    </asp:GridView>
</asp:Content>

