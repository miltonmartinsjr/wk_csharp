using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ01A
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> stringList = new List<string>()
            {
                "C# Tutorials",
                "VB.Net Tutorials",
                "Learn C++",
                "MVC Tutorials",
                "Java"
            };

            var result = stringList.Where(s => s.Contains("Tutor"));

            foreach (var str in result)
            {
                Console.WriteLine(str);
            }

            //function differente 
            Func<String, bool> validate = s => s.Contains("Tutor");

            var delega = from s in stringList
                         where validate(s)
                         select s;

            foreach (var str in delega)
            {
                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
