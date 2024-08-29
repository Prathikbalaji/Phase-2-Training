using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net.Mail;

namespace RestaurantOrderingSystem
{
    public partial class AddOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuItems();
                InitializeGrid();
            }
        }

        public void BindddlItems(DropDownList ddlItems)
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT ItemID, ItemName FROM items";


            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            conn.Close();

            ddlItems.DataTextField = "ItemName";
            ddlItems.DataValueField = "ItemID";
            ddlItems.DataSource = dt;
            ddlItems.DataBind();
            ddlItems.Items.Insert(0, new ListItem("Select Item", ""));
        }

        private void InitializeGrid()
        {
            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Item"), new DataColumn("Quantity") });
            dt.Rows.Add(dt.NewRow());

            gvOrderItems.DataSource = dt;
            gvOrderItems.DataBind();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            int OrderID;
            string name = Session["CName"] as string;
            string email = Session["email"] as string;
            string subject = "Jahseh's Restaurant";
            string body = "Your order has been placed successfully!";

            DateTime date = DateTime.Now;
            int status = 0;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cm = new SqlCommand("insert into orders values(@name,@date,@status)", conn);
            cm.Parameters.AddWithValue("@name", name);
            cm.Parameters.AddWithValue("@date", date);
            cm.Parameters.AddWithValue("@status", status);
            cm.ExecuteNonQuery();
            string query = "SELECT max(OrderID) FROM Orders";
            SqlCommand cmd = new SqlCommand(query, conn);
            OrderID = (int)cmd.ExecuteScalar();
            try
            {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 587; 
            smtpServer.Credentials = new System.Net.NetworkCredential("prathikbalaji2003@gmail.com", "llaw oazi sldh koxh");
            smtpServer.EnableSsl = true; 


            mail.From = new MailAddress("prathikbalaji2003@gmail.com","Restaurant Ordering System");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;

            
            smtpServer.Send(mail);
            }
            catch(Exception ex)
            {

            }
            conn.Close();
            foreach (GridViewRow row in gvOrderItems.Rows)
            {
                
                DropDownList ddlItems = (DropDownList)row.FindControl("ddlItems");
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                string ItemName = ddlItems.SelectedItem .Text;
                int qt = Convert.ToInt32(txtQuantity.Text);

                conn.Open();
                SqlCommand cmdOrd = new SqlCommand("insert into OrderDetails values(@OrderID,@ItemName,@Qty)", conn);
                cmdOrd.Parameters.AddWithValue("@OrderID", OrderID);
                cmdOrd.Parameters.AddWithValue("@ItemName", ItemName);
                cmdOrd.Parameters.AddWithValue("@Qty", qt);

                cmdOrd.ExecuteNonQuery();

                conn.Close();

            }
            string script = "alert('Order Placed!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            gvOrderItems.DataSource = null;
            gvOrderItems.DataBind();
            InitializeGrid();

        }
        protected void btnAddNewRow_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        private void AddNewRow()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Item"), new DataColumn("Quantity") });

            foreach (GridViewRow row in gvOrderItems.Rows)
            {
                DataRow dr = dt.NewRow();

                DropDownList ddlItems = (DropDownList)row.FindControl("ddlItems");
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                dr["Item"] = ddlItems.SelectedValue;  
                dr["Quantity"] = txtQuantity.Text;    

                dt.Rows.Add(dr);  
            }

            dt.Rows.Add(dt.NewRow());

            gvOrderItems.DataSource = dt;
            gvOrderItems.DataBind();
        }

        protected void gvOrderItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlItems = (DropDownList)e.Row.FindControl("ddlItems");
                BindddlItems(ddlItems);

                if (ddlItems != null && DataBinder.Eval(e.Row.DataItem, "Item") != DBNull.Value)
                {
                    ddlItems.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Item").ToString();
                }

                TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");
                if (txtQuantity != null && DataBinder.Eval(e.Row.DataItem, "Quantity") != DBNull.Value)
                {
                    txtQuantity.Text = DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();
                }
            }
        }

        private void BindMenuItems()
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string query = "SELECT ItemID, ItemName, Category, Price FROM items";

           
            SqlCommand cmd = new SqlCommand(query, conn);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            gvMenuItems.DataSource = dt;
            gvMenuItems.DataBind();
            conn.Close();
        }

    }
}