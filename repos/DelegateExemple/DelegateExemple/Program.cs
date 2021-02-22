using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExemple
{
    class Program
    {
        private delegate int MyFunction(int a);

        private static int myF1(int a) { return a + 1; }
        private static int myF2(int a) { return a + 2; }
        private static int myF3(int a) { return a * 3; }

        static void Main(string[] args)
        {
            MyFunction z;

            z = myF1;
            Console.WriteLine("myF1 : " + z(9));

            z = myF2;
            Console.WriteLine("myF2 : " + z(9));

            z = myF3;
            Console.WriteLine("myF3 : " + z(9));

            z = s => 5 * s;
            Console.WriteLine("myF4 : " + z(9));

            z = new MyFunction(s => 7 * s);
            Console.WriteLine("myF5 : " + z(9));

            Console.WriteLine("myF6 : " + new MyFunction(s => 8 * s)(9));


            //================================================================

            Func<int, int> y;

            y = myF1;
            Console.WriteLine("myF1 : " + y(9));

            y = myF2;
            Console.WriteLine("myF2 : " + y(9));

            y = myF3;
            Console.WriteLine("myF3 : " + y(9));

            y = s => 5 * s;
            Console.WriteLine("myF4 : " + z(9));

            y = new Func<int, int>(s => 7 * s);
            Console.WriteLine("myF5 : " + z(9));

            Console.WriteLine("myF6 : " + new Func<int, int>(s => 8 * s)(9));


            //===============================================================

            var f3 = new MyFunction(s => 9 * s);
            Console.WriteLine("myF20 : " + f3(9));

            var f4 = new Func<int, int>(s => 11 * s);
            Console.WriteLine("myF20 : " + f4(9));

            Console.ReadKey();

        }
    }
}
