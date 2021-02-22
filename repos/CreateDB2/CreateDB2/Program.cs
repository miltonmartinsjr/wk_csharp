using System;
using System.Data.SqlClient;

namespace CreateDB2
{
    class Program
    {
        static void Main(string[] args)
        {



            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = "PC304-03";
            sqlConnectionString.UserID = "pepito";
            sqlConnectionString.Password = "pepito";

            Console.WriteLine(sqlConnectionString.ConnectionString);

            SqlConnection connection = new SqlConnection(sqlConnectionString.ConnectionString);
            connection.Open();
            
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection Suces.");
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into Etudiant values ( 10, 'Test')";
                command.ExecuteNonQuery();
                Console.WriteLine("Connection Suces.");
            }
            else
            {
                Console.WriteLine("Ne pas possible etablir la connection. ");
            }
            
            connection.Close();
            Console.ReadKey();
        }
    }
}
