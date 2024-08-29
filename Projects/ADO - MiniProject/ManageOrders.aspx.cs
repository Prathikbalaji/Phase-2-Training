using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace RestaurantOrderingSystem
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindOrders();
            }
        }

        public  void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string orderId = btn.CommandArgument;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            DropDownList ddlStatus = (DropDownList)row.FindControl("ddlStatus");
            string st = ddlStatus.SelectedValue;
            int status = 0;
            if (st.Equals("Accepted"))
            {
                status = 1;
            }
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "update Orders set Status = @status where OrderID = @oid";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@status", status);
            cmd.Parameters.Add("@oid", orderId);

            cmd.ExecuteNonQuery();
            conn.Close();
            bindOrders();

        }

        


        protected void bindOrders()
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT o.OrderID, o.CName, STRING_AGG(i.ItemName + '(' + CAST(od.Quantity AS VARCHAR) + ')', ', ') AS Items, FORMAT(o.DateOrdered, 'dd-MM-yyyy') as DateOrdered, SUM(i.Price * od.Quantity) AS TotalAmount FROM Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID JOIN Items i ON od.ItemName = i.ItemName WHERE o.Status = 0 GROUP BY o.OrderID, o.CName, o.DateOrdered, o.Status";

            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            gvManageOrders.DataSource = dt;
            gvManageOrders.DataBind();
            conn.Close();
        }

    }
}

