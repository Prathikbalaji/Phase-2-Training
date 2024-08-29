<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="RestaurantOrderingSystem.register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - ROS</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
        }

        .register-container {
            width: 400px;
            margin: 80px auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
        }

        h2 {
            margin-left: 35%;
            margin-bottom: 30px;
            color: #333333;
        }

        table {
            width: 100%;
        }

        table td {
            padding: 10px;
        }

        table td:first-child {
            text-align: right;
            color: #555555;
            padding-right: 10px;
        }

        table td:last-child {
            text-align: left;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            font-size: 14px;
        }

        input[type="text"]:focus,
        input[type="password"]:focus {
            border-color: #66afe9;
            outline: none;
            box-shadow: 0 0 8px rgba(102, 175, 233, 0.6);
        }

        .btnRegister {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }

        .btnRegister:hover {
            background-color: #45a049;
        }

        .error-message {
            color: red;
            font-size: 12px;
            text-align: center;
        }

        .login-link {
            margin-top: 20px;
            text-align: center;
            display: block;
            text-decoration: none;
            font-size: 14px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-container">
            <h2>Register</h2>

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblUsername" runat="server" Text="Username: " />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email: " />
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password: " />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password: " />
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding-top: 20px;">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_click" CssClass="btnRegister" />
                    </td>
                </tr>
            </table>

            <!-- Placeholder for potential error messages -->
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message" Visible="false" />

            <!-- Login link -->
            <p class="login-link" >Already have an account? <a href="login.aspx">Login</a> </p>
        </div>
    </form>
</body>
</html>
