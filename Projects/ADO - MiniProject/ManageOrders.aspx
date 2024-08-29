<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageOrders.aspx.cs" Inherits="RestaurantOrderingSystem.ManageOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            padding: 20px;
            max-width: 1000px;
            margin: auto;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            font-family: Arial, sans-serif;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 10px;
            text-align: left;
        }

        .grid-view th {
            background-color: #007bff;
            color: white;
            font-weight: bold;
            font-size: 16px;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-view tr:hover {
            background-color: #ddd;
        }

        .status-dropdown {
            width: 100%;
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            background-color: #fff;
            color: #333;
        }

        .status-dropdown:focus {
            border-color: #4CAF50;
            outline: none;
        }

        .status-dropdown option {
            padding: 5px;
        }

        .update-button {
            padding: 5px 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }

        .update-button:hover {
            background-color: #45a049;
        }

        .no-records {
            text-align: center;
            color: #777;
            padding: 20px;
        }

    </style>

    <div class="container">
        <h2>Manage Orders</h2>
        <asp:GridView ID="gvManageOrders" runat="server" CssClass="grid-view" AutoGenerateColumns="False" DataKeyNames="OrderID">
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
                <asp:TemplateField HeaderText="Update">
                    <ItemTemplate>
                        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" 
                            OnClick="ButtonUpdate_Click" 
                            CommandArgument='<%# Eval("OrderID") %>' 
                            CssClass="update-button" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="no-records">No records found</div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
