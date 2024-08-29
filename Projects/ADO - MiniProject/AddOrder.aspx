<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddOrder.aspx.cs" Inherits="RestaurantOrderingSystem.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container {
            padding: 20px;
            max-width: 800px;
            margin: auto;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }

        .grid-view th {
            background-color: #f4f4f4;
            color: #333;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .btnAction {
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
        }

        .btnAction:hover {
            background-color: #0056b3;
        }

        .grid-view .ddlItems {
            width: 100%;
            padding: 6px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .grid-view .txtQuantity {
            width: 100%;
            padding: 6px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            box-sizing: border-box;
        }
    </style>

    <div class="container">
        <h2>Available Menu Items</h2>
        
        <asp:GridView ID="gvMenuItems" runat="server" CssClass="grid-view" AutoGenerateColumns="False" DataKeyNames="ItemID">
            <Columns>
                <asp:BoundField DataField="ItemID" Visible="false" HeaderText="Item ID" />
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="container">
        <h2>Create Your Order</h2>
        <asp:Button ID="btnAddNewRow" runat="server" Text="Add New Row" CssClass="btnAction btnAddNewRow" OnClick="btnAddNewRow_Click" />
        
        <asp:GridView ID="gvOrderItems" runat="server" CssClass="grid-view" OnRowDataBound="gvOrderItems_RowDataBound" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Item">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlItems" runat="server" CssClass="ddlItems" DataTextField="ItemName" DataValueField="ItemID" AppendDataBoundItems="true">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="txtQuantity"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Button ID="btnOrder" runat="server" style="margin-top : 15px" Text="Order" CssClass="btnAction" OnClick="btnOrder_Click" />
    </div>
</asp:Content>
