using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ADO
{
    public class Program
    {

        static SqlConnection connection = null;
        static void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = SPORTS_prathik ; integrated security = true");
            connection.Open();
        }

        void insert()
        {
            Console.WriteLine("Enter no. of records to be inserted : ");
            int no = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, int> list = new Dictionary<string, int>();
            for (int i = 0; i < no; i++)
            {
                Console.WriteLine("Enter the Product " + (i + 1) + " Name : ");
                string pname = Console.ReadLine();
                Console.WriteLine("Enter the price : ");
                int price = Convert.ToInt32(Console.ReadLine());
                list.Add(pname, price);
            }
            getConn();
            foreach(var v in list)
            {
            SqlCommand sqlcd = new SqlCommand("insert into csharp values(@name , @price) ", connection);
                sqlcd.Parameters.AddWithValue("@name", v.Key);
                sqlcd.Parameters.AddWithValue("@price", v.Value);
                sqlcd.ExecuteNonQuery();
            }
            Console.WriteLine("Inserted Successfully !");
            connection.Close();
        }

        void select()
        {
            getConn();
            SqlCommand sqlcd = new SqlCommand("select * from csharp", connection);

            SqlDataReader sdr = sqlcd.ExecuteReader();
            Console.WriteLine("{0,-10} {1,-10} {2,-10}", "ID", "Name", "Price");
            while (sdr.Read())
            {
                Console.WriteLine("{0,-10} {1,-10} {2,-10}", sdr[0].ToString(), sdr[1].ToString(), sdr[2].ToString());
            }

            connection.Close();
        }


        void delete()
        {
            Console.WriteLine("Enter the ID to be Deleted : ");
            int id = Convert.ToInt32(Console.ReadLine());
           
            getConn();
            SqlCommand sqlcd = new SqlCommand("delete from csharp where id = @id", connection);

            sqlcd.Parameters.AddWithValue("@id", id);
            int res = sqlcd.ExecuteNonQuery();

            if(res == 0)
            {
                Console.WriteLine("Mo such ID");
            }
            else
            {
                Console.WriteLine("Deleted Successfuly ! ");
            }
            connection.Close();
        }
        void update()
        {
            Console.WriteLine("Enter the ID to be Updated : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price : ");
            int price = Convert.ToInt32(Console.ReadLine());

            getConn();
            SqlCommand sqlcd = new SqlCommand("update csharp set Price = @price where id = @id", connection);

            sqlcd.Parameters.AddWithValue("@price", price);
            sqlcd.Parameters.AddWithValue("@id", id);
            sqlcd.ExecuteNonQuery();

            Console.WriteLine("Updated Successfuly ! ");

            connection.Close();
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            string ch;
            int val;
            do
            {
                Console.WriteLine("1.Select\n2.Insert\n3.Update\n4.Delete");
                Console.WriteLine("Enter the value to perform");
                val = Convert.ToInt32(Console.ReadLine());
                switch (val)
                {
                    case 1:
                        p.select();
                        break;
                    case 2:
                        p.insert();
                        break;
                    case 3:
                        p.update();
                        break;
                    case 4:
                        p.delete();
                        break;
                    default:
                        Console.WriteLine("Invalid!");
                        break;
                }
                Console.WriteLine("Enter Y - Continue , N - Exit");
                ch = Console.ReadLine();
            } while (ch.ToUpper().Equals("Y"));
        }
    }
}



