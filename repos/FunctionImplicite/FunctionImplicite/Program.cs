using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionImplicite
{
    class Program
    {
        static void Main(string[] args)
        {
            var z = new Func<int[], int>(a => {
                int q = 0;
                foreach (int w in a)
                {
                    if (q < w)
                        q = w;
                }
                return q;
            });

            int[] t = new int[] { 30, 10, 6, 7, 5, 3, 9 };
            Console.WriteLine("Le plus grand au Tableau est : " + z(t));
            Console.ReadKey();
        }
    }
}
