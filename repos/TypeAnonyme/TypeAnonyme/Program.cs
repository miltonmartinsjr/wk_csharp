using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeAnonyme
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = 5;

            Console.WriteLine("Le type de la variable a est " + a.GetType().ToString());
            Console.WriteLine(" a = " + a);

            var c = new { nom = "Jean", Age = 25 };
            Console.WriteLine("Le type de la variable a est " + c.GetType().ToString());
            Console.WriteLine(" Nom = " + c.nom);

            Console.ReadKey();

        }
    }
}
