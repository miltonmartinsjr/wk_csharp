using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QueryDA
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
            Console.WriteLine(ds.GetXml());
            Console.ReadKey();
        }
    }
}
