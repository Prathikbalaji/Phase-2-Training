using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RestaurantOrderingSystem
{
    public partial class menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuItems();
            }
        }

        private void BindMenuItems()
        {

            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "SELECT ItemID, ItemName, Category, Price FROM items";

                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    query += " WHERE ItemName LIKE @ItemName";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    cmd.Parameters.AddWithValue("@ItemName", "%" + txtSearch.Text.Trim() + "%");
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(sdr);
                gvMenuItems.DataSource = dt;
                gvMenuItems.DataBind();
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
            }

        }

        public void btnDelete_click(object sender , ImageClickEventArgs e)
        {
            ImageButton btnDelete = (ImageButton)sender;
            int itemId = Convert.ToInt32(btnDelete.CommandArgument);

            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from items where ItemID = @itemid", conn);
            cmd.Parameters.AddWithValue("@itemid", itemId);


            cmd.ExecuteNonQuery();
            conn.Close();

            BindMenuItems();
        }

        public void btnSearch_Click(object sender , EventArgs e)
        {
            BindMenuItems();
        }

        public void btnEdit_click(object sender, ImageClickEventArgs e)
        {
            btnAddItem.Visible = false;
            btnUpdate.Visible = true;


            ImageButton btnEdit = (ImageButton)sender;
            int itemId = Convert.ToInt32(btnEdit.CommandArgument);
            Session["itemID"] = itemId;
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from items where ItemID = @itemid", conn);
            cmd.Parameters.AddWithValue("@itemid", itemId);

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                txtItemName.Text = sdr[1].ToString();
                txtPrice.Text = sdr[3].ToString();
                ddlCategory.SelectedValue = sdr[2].ToString();
            }

            conn.Close();

        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;
            string iname = txtItemName.Text;
            string cat = ddlCategory.SelectedItem.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int itemId = (int)Session["itemId"];
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update items set ItemName = @iname , Category = @Cat , Price = @price where ItemId = @id", conn);
            cmd.Parameters.AddWithValue("@iname", iname);
            cmd.Parameters.AddWithValue("@Cat", cat);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@id", itemId);

            cmd.ExecuteNonQuery();

            conn.Close();
            txtItemName.Text = "";
            ddlCategory.SelectedValue = "0";
            txtPrice.Text = "";

            btnAddItem.Visible = true;
            btnUpdate.Visible = false;
            BindMenuItems();
            string script = "alert('Item Updated!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }




        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemname = txtItemName.Text;
            string category = ddlCategory.SelectedValue;
            decimal price = Convert.ToDecimal(txtPrice.Text);

            if (category.Equals("0"))
            {
                string script = "alert('Select Valid Category.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }
              
           
            string connString = ConfigurationManager.ConnectionStrings["rosConn"].ConnectionString;

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into items values(@name , @category , @price)", conn);
                cmd.Parameters.AddWithValue("@name", itemname);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@price", price);


                int count = cmd.ExecuteNonQuery();
                conn.Close();

                if (count > 0)
                {
                    txtItemName.Text = "";
                    txtPrice.Text = "";
                    ddlCategory.SelectedValue = "0";
                    string script = "alert('Item inserted successfully!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    BindMenuItems();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('An error occurred: {ex.Message}');</script>");
            }
        }

    }
}