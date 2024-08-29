using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantOrderingSystem
{
    public partial class Orders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindOrders();
        }

        protected void bindOrders()
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            string name = Session["CName"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT o.OrderID, o.CName, STRING_AGG(i.ItemName, ', ') AS Items,FORMAT(o.DateOrdered, 'dd-MM-yyyy') as DateOrdered,SUM(i.Price * od.Quantity) AS TotalAmount, CASE WHEN o.Status = 0 THEN 'Order Pending' WHEN o.Status = 1 THEN 'Order Accepted' END AS Status FROM Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID JOIN  Items i ON od.ItemName = i.ItemName WHERE o.CName = @cname GROUP BY o.OrderID, o.CName, o.DateOrdered, o.Status";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("cname", name);

            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            gvOrders.DataSource = dt;
            gvOrders.DataBind();
            conn.Close();
        }
    }
}