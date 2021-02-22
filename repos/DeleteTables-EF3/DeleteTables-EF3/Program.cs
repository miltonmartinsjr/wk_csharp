using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteTables_EF3
{
    class Program
    {
        static EMPEntities db = new EMPEntities();
        static void Main(string[] args)
        {
            try
            {
                db.Database.ExecuteSqlCommand("DROP TABLE COMPANY", new object[0]);
                Console.WriteLine("Table Succesfull deleted...");
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Tables not deleted. " + Ex.Message );
            }
            Console.ReadKey();
        }
    }
}
