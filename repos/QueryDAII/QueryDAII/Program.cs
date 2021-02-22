using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QueryDAII
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "EMP";
            cs.UserID = "pepito";
            cs.Password = "pepito";
            String sql = "SELECT * FROM COMPANY";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, cs.ConnectionString);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "COMPANY");
            foreach(DataRow x in ds.Tables["COMPANY"].Rows)
            {
                Console.WriteLine("Id = {0} ; Name = {1} ", x[0].ToString(), x[1].ToString());
                Console.WriteLine("Age = {0} ", x[2].ToString());
                Console.WriteLine("Address = {0} ", x[4].ToString());
                Console.WriteLine("Salary = {0:F2} ", x["SALARY"]);
            }
            Console.ReadKey();
        }
    }
}
