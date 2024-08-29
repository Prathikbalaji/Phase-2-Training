<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="RestaurantOrderingSystem.menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            padding: 20px;
            max-width: 600px;
            margin: auto;
        }

        .form-panel {
            background-color: #ffffff;
            padding: 20px;
            border-radius: 8px;
            margin-top: 40px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        input[type="text"], select {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            margin-bottom: 10px;
        }

        input[type="submit"], .btnRegister {
            padding: 10px 20px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        input[type="submit"]:hover, .btnRegister:hover {
            background-color: #218838;
        }

        h2 {
            color: #333;
            margin-bottom: 20px;
        }

        table {
            width: 100%;
        }

        td {
            padding: 10px;
        }

        .grid-view {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .grid-view th, .grid-view td {
            border: 1px solid #ddd;
            padding: 8px;
        }

        .grid-view th {
            background-color: #f4f4f4;
            color: #333;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f9f9f9;
        }

        .search-panel {
            margin-bottom: 20px;
        }
    </style>

    <div class="container">
        <div class="form-panel">
            <h2>Add Menu Item</h2>
            <asp:Panel ID="pnlAddItem" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblItemName" runat="server" Text="Item Name: " AssociatedControlID="txtItemName" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtItemName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCategory" runat="server" Text="Category: " AssociatedControlID="ddlCategory" />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server">
                                <asp:ListItem Text="--Select--" Value="0" />
                                <asp:ListItem Text="Dessert" Value="Dessert" />
                                <asp:ListItem Text="Appetizer" Value="Appetizer" />
                                <asp:ListItem Text="Main Course" Value="Main Course" />
                                <asp:ListItem Text="Beverage" Value="Beverage" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPrice" runat="server" Text="Price: " AssociatedControlID="txtPrice" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPrice" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btnRegister" OnClick="btnAddItem_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="btnRegister" OnClick="btnUpdate_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>

        <div class="form-panel">
            <div class="search-panel">
                <asp:TextBox ID="txtSearch" style="width:30%" runat="server" Placeholder="Search by item name..." />
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnRegister" OnClick="btnSearch_Click" />
            </div>
            <h2>Menu Items</h2>
            <asp:GridView ID="gvMenuItems" runat="server" CssClass="grid-view" AutoGenerateColumns="False" DataKeyNames="ItemID">
                <Columns>
                    <asp:BoundField DataField="ItemID" Visible="false" HeaderText="Item ID" />
                    <asp:BoundField DataField="ItemName" HeaderText="Item Name" />
                    <asp:BoundField DataField="Category" HeaderText="Category" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/images/editicon.png" CommandArgument='<%# Eval("ItemID") %>' Style="margin: auto; padding-left: 20px; width: 16px;" OnClick="btnEdit_click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/images/trash.gif" Style="margin: auto; padding-left: 20px; width: 16px;" CommandArgument='<%# Eval("ItemID") %>'  OnClick="btnDelete_click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
