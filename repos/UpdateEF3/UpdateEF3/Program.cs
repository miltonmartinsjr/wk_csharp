using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateEF3
{

    
    class Program
    {
        static EMPEntities db = new EMPEntities();
        static void Main(string[] args)
        {
            var result = db.COMPANY.Where(s => s.ID == 1).SingleOrDefault();
            if (result != null)
            {
                result.SALARY = (float)25000.00;
            }
            var result2 = db.COMPANY.Where(s => s.ID == 2).SingleOrDefault();
            if (result2 != null)
            {
                db.COMPANY.Remove(result2);
            }
            try
            {
                db.SaveChanges();
                Console.WriteLine("Data Succesfull Changed...");
            }catch(Exception ex){
                Console.WriteLine("Data not updated.");

            }

            foreach( var c in db.COMPANY)
            {
                Console.WriteLine("Id = " + c.ID + " " + c.NAME);
                Console.WriteLine("Age = " + c.AGE);
                Console.WriteLine("Adress = " + c.ADRESS);
                Console.WriteLine("Salary = {0:F2}" + c.SALARY);
                Console.WriteLine("Salary = " + c.SALARY.Value.ToString("F2"));
                Console.WriteLine("Salary = " + c.SALARY.Value.ToString("N2"));
            }

            Console.ReadKey();
        }
    }
}
