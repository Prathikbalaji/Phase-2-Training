using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantOrderingSystem
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basic validation checks
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = "Please enter both username and password.";
                lblErrorMessage.Visible = true;
                return;
            }
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

             try
             {
                 SqlConnection conn = new SqlConnection(connString);
                 conn.Open();
                 SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Users WHERE Username = @Username AND Password = @Password", conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // Ensure password is hashed and compared securely
                 int count = Convert.ToInt32(cmd.ExecuteScalar());
                SqlCommand cm = new SqlCommand("SELECT email FROM Users WHERE Username = @Username AND Password = @Password", conn);
                cm.Parameters.AddWithValue("@Username", username);
                cm.Parameters.AddWithValue("@Password", password);

                string email = (string)cm.ExecuteScalar();

                Session["email"] = email;

                conn.Close();

                 if (count == 1)
                 {
                    Session["CName"] = username;
                    Response.Redirect("Home.aspx");
                 }
                 else
                 {
                     lblErrorMessage.Text = "Invalid username or password.";
                     lblErrorMessage.Visible = true;
                 }
             }
             catch (Exception ex)
             {
                 lblErrorMessage.Text = "An error occurred: " + ex.Message;
                 lblErrorMessage.Visible = true;
             }
        }
    }
}