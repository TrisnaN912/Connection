using System;
using System.Data.SqlClient;

namespace Connection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Program program = new Program();

            //program.insert(3, "Eropa");
            //program.update(3, "Amerika");
            program.delete(3);
            program.Display();
        }

        public void Display()
        {
            SqlConnection sqlConnection;
            string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC001; User ID=Trisna;Password=1234567890;";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "select * from Regions";

            SqlParameter sqlParameter = new SqlParameter();

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine(sqlDataReader[1]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void insert(int id, string nama)
        {
            SqlConnection sqlConnection;
            string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC001; User ID=Trisna;Password=1234567890;";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "insert into Regions values(@RegionId, @RegionName)";
                sqlCommand.Parameters.Add(new SqlParameter("@RegionId", id));
                sqlCommand.Parameters.Add(new SqlParameter("@RegionName", nama));
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        public void update(int id, string nama)
        {
            SqlConnection sqlConnection;
            string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC001; User ID=Trisna;Password=1234567890;";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Update Regions set RegionName='"+nama+"' where RegionId='"+id+"'";
                sqlCommand.Parameters.Add(new SqlParameter("RegionId", id));
                sqlCommand.Parameters.Add(new SqlParameter("RegionName", nama));
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void delete(int id)
        {
            SqlConnection sqlConnection;
            string connectionString = "Data Source=NARUTO;Initial Catalog=DTSMCC001; User ID=Trisna;Password=1234567890;";
            sqlConnection = new SqlConnection(connectionString);
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Delete from Regions where RegionId="+id;
                sqlCommand.Parameters.Add(new SqlParameter("RegionId", id));
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

    }
}
