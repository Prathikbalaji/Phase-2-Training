using ADOmvc.Models;
using System.Data.SqlClient;

namespace ADOmvc.Data_Access
{
    public class ProductDataAccess
    {
        static SqlConnection connection = null;
        static void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = SPORTS_prathik ; integrated security = true");
            connection.Open();
        }    

        public List<Products>  select()
        {
            List<Products> li = new List<Products>();
            getConn();
            SqlCommand sqlcd = new SqlCommand("select * from csharp", connection);

            SqlDataReader sdr = sqlcd.ExecuteReader();
            while (sdr.Read())
            {
                li.Add(new Products() { Id = (int)sdr[0], Name = sdr[1].ToString(),Price = (int)sdr[2] });
            }
            connection.Close();
            return li;
        }

        public void insert(Products pd)
        {
            getConn();
            SqlCommand sqlcd = new SqlCommand("insert into csharp values ( @name , @price)", connection);
            sqlcd.Parameters.AddWithValue("@name", pd.Name);
            sqlcd.Parameters.AddWithValue("@price", pd.Price);

            sqlcd.ExecuteNonQuery();
            connection.Close();

        }

        public void delete(int id)
        {
            getConn();
            SqlCommand sqlcd = new SqlCommand("delete from csharp where id = @id", connection);
            sqlcd.Parameters.AddWithValue("@id", id);

            sqlcd.ExecuteNonQuery();
            connection.Close();
        }

        public void update(Products pd)
        {
            getConn();
            SqlCommand sqlcd = new SqlCommand("update csharp set name = @name , Price = @price where id = @id", connection);

            sqlcd.Parameters.AddWithValue("@name", pd.Name);
            sqlcd.Parameters.AddWithValue("@price", pd.Price);
            sqlcd.Parameters.AddWithValue("@id", pd.Id);

            sqlcd.ExecuteNonQuery();
            connection.Close();

        }

        public Products search(int id)
        {
            Products pd = new Products();
            getConn();
            SqlCommand sqlcd = new SqlCommand("select * from csharp where id = "+id, connection);

            SqlDataReader sdr = sqlcd.ExecuteReader();
            while (sdr.Read())
            {
                pd.Id = (int)sdr[0];
                pd.Name = sdr[1].ToString();
                pd.Price = (int)sdr[2];
            }
            connection.Close();
            return pd;
        }

    }
}
