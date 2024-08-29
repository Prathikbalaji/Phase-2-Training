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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnRegister_click(object sender , EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                lblErrorMessage.Text = "Username is required.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                lblErrorMessage.Text = "email is required.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblErrorMessage.Text = "Password is required.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                lblErrorMessage.Text = "Confirm Password is required.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (password != confirmPassword)
            {
                lblErrorMessage.Text = "Passwords do not match.";
                lblErrorMessage.Visible = true;
                return;
            }

            string role = "user";
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into users values(@uname,@password,@role,@email)",conn);
            cmd.Parameters.Add("@uname",username );
            cmd.Parameters.Add("@password", password);
            cmd.Parameters.Add("@role", role);
            cmd.Parameters.Add("@email", email);

            cmd.ExecuteNonQuery();
            conn.Close();

            

            Response.Redirect("login.aspx");
        }

    }
}