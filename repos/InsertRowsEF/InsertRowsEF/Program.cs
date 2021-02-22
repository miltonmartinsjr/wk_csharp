using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertRowsEF
{
    class Program
    {
        static EMPEntities db = new EMPEntities();
        static void Main(string[] args)
        {
            COMPANY company = new COMPANY();
            company.ID = 1;
            company.NAME = "Test";
            company.SALARY = 120000;
            company.AGE = 12;
            company.ADRESS = "Av. Rosemount";

            try
            {
                db.COMPANies.Add(company);
                db.SaveChanges();
                Console.WriteLine("Company Succesfull Created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
