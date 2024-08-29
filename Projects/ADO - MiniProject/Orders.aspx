<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Orders.aspx.cs" Inherits="RestaurantOrderingSystem.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            padding: 30px;
            max-width: 900px;
            margin: auto;
            background-color: #fff;
            
        }

        h2 {
            text-align: center;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            color: #333;
            margin-bottom: 20px;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: left;
            vertical-align: middle;
        }

        .grid-view th {
            background-color: #007bff;
            color: white;
            font-weight: bold;
            font-size: 16px;
        }

        .grid-view td {
            font-size: 14px;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .grid-view tr:hover {
            background-color: #f1f1f1;
        }

        .grid-view tr.selected-row {
            background-color: #007bff;
            color: white;
        }

        .grid-view tr.selected-row:hover {
            background-color: #0056b3;
        }

    </style>

    <div class="container">
        <h2>Your Orders</h2>
        <asp:GridView ID="gvOrders" runat="server" CssClass="grid-view" AutoGenerateColumns="False" RowStyle-BorderColor="#ddd">
            <Columns>
                <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                <asp:BoundField DataField="CName" HeaderText="Customer Name" />
                <asp:BoundField DataField="Items" HeaderText="Items" />
                <asp:BoundField DataField="DateOrdered" HeaderText="Order Date" />
                <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
