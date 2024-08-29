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
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //controlVisibility();
            }
        }

        /*public void controlVisibility()
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            string name = Session["UName"].ToString();
            string role = "admin";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Users WHERE Username = @Username AND role = @role", conn);
            cmd.Parameters.AddWithValue("@Username", name);
            cmd.Parameters.AddWithValue("@role", role); // Ensure password is hashed and compared securely

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            if(count == 1)
            {
                HomeLink.Visible = true;
                MenuItemsLink.Visible = true;
                AddOrderLink.Visible = true;
                OrdersLink.Visible = true;
                ManageOrdersLink.Visible = true;
            }
            else
            {
                HomeLink.Visible = true;
                MenuItemsLink.Visible = false;
                AddOrderLink.Visible = true;
                OrdersLink.Visible = true;
                ManageOrdersLink.Visible = false;
            }
        }*/

    }
}
