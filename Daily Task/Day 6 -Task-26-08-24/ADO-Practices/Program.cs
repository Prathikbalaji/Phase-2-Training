using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ADO
{
    public class Program
    {

        static SqlConnection connection = null;
        void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = SPORTS_prathik ; integrated security = true");
            connection.Open();
        }

        void PerformQuery()
        {
            SqlCommand sqlcd = new SqlCommand("select * from csharp", connection);

            SqlDataReader sdr =  sqlcd.ExecuteReader();

            while (sdr.Read()) {
                Console.WriteLine(sdr[0].ToString() + " " + sdr[1].ToString());
            }

            connection.Close();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.getConn();
            p.PerformQuery();
        }
    }
}



