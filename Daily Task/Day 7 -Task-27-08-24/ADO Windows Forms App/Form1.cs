using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridEx
{
    public partial class Form1 : Form
    {

        static SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = SPORTS_prathik ; integrated security = true");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("insert into csharp values(@name , @price) ", connection);
            sqlcd.Parameters.AddWithValue("@name", txtName.Text);
            sqlcd.Parameters.AddWithValue("@price", txtPrice.Text);
            sqlcd.ExecuteNonQuery();
            connection.Close();
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";

            btnDisplay_Click(null, null);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("select * from csharp", connection);

            SqlDataReader sdr = sqlcd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(sdr);

            products.DataSource = dt;

            connection.Close();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("select count(*) from csharp", connection);

            int sdr = (int)sqlcd.ExecuteScalar();

            lblCount.Text = sdr.ToString();

            connection.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("select * from csharp where id = @id", connection);
            sqlcd.Parameters.AddWithValue("@id", txtID.Text);

            SqlDataReader sdr = sqlcd.ExecuteReader();
            while (sdr.Read())
            {
                txtName.Text = sdr[1].ToString();
                txtPrice.Text = sdr[2].ToString();
            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("update csharp set Price = @price where id = @id", connection);
            sqlcd.Parameters.AddWithValue("@id", txtID.Text);
            sqlcd.Parameters.AddWithValue("@price", txtPrice.Text);

            sqlcd.ExecuteNonQuery();
            connection.Close();
            btnDisplay_Click(null, null);
        }

        private void btbDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand sqlcd = new SqlCommand("delete from csharp where id = @id", connection);
            sqlcd.Parameters.AddWithValue("@id", txtID.Text);
            sqlcd.ExecuteNonQuery();
            connection.Close();
            btnDisplay_Click(null, null);
        }

    }
}
