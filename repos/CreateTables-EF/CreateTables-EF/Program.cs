using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTables_EF
{
    class Program
    {
        static EMPEntities db = new EMPEntities();
        static void Main(string[] args)
        {
            String cmdText = "CREATE TABLE COMPANY (" +
                "ID INT PRIMARY KEY   NOT NULL," +
                "NAME VARCHAR(50) NOT NULL," +
                "AGE INT NOT NULL," +
                "ADRESS VARCHAR(50)," +
                "SALARY REAL)";

            try
            {
                db.Database.ExecuteSqlCommand(cmdText, new object[0]);
                Console.WriteLine("Table cree suces...");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
