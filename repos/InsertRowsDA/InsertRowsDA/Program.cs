using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InsertRowsDA
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

            {
                DataRow row = ds.Tables["COMPANY"].NewRow();
                row["ID"] = 2;
                row["NAME"] = "Allen";
                row["AGE"] = 25;
                row["ADDRESS"] = "Texas";
                row["SALARY"] = 15000.00;
                ds.Tables["COMPANY"].Rows.Add(row);
            }

            {
                DataRow row = ds.Tables["COMPANY"].NewRow();
                row["ID"] = 1;
                row["NAME"] = "Paul";
                row["AGE"] = 32;
                row["ADDRESS"] = "California";
                row["SALARY"] = 20000.00;
                ds.Tables["COMPANY"].Rows.Add(row);
            }

            {
                DataRow row = ds.Tables["COMPANY"].NewRow();
                row["ID"] = 3;
                row["NAME"] = "Teddy";
                row["AGE"] = 23;
                row["ADDRESS"] = "Normay";
                row["SALARY"] = 20000.00;
                ds.Tables["COMPANY"].Rows.Add(row);
            }

            {
                DataRow row = ds.Tables["COMPANY"].NewRow();
                row["ID"] = 4;
                row["NAME"] = "Mark";
                row["AGE"] = 25;
                row["ADDRESS"] = "Richmond";
                row["SALARY"] = 65000.00;
                ds.Tables["COMPANY"].Rows.Add(row);
            }

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(ds.Tables["COMPANY"]);

            Console.WriteLine(ds.GetXml());
            Console.ReadKey();

        }
    }
}
