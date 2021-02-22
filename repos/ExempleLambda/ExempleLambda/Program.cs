using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLambda
{
    class Program
    {
        private delegate int myFunctionType1(int a);
        private delegate int myFunctionType2(int a, int b);

        static void Main(string[] args)
        {
            myFunctionType1 myF1 = a => a + 1;
            myFunctionType1 myF2 = a => { return a + 1; };
            myFunctionType1 myF3 = a => { Console.WriteLine("MyFlv3 : bonjour "); return a + 1; };

            Func<int, int> myF4 = a => a + 1;
            Func<int, int> myF5 = a => { return a + 1; };
            Func<int, int> myF6 = a => { Console.WriteLine("MyFlv3 : bonjour "); return a + 1; };

            var myF7 = new myFunctionType1( a => { return a + 1; });
            var myF8 = new Func<int, int>(a => { Console.WriteLine("MyFlv3 : bonjour "); return a + 1; });

            myFunctionType2 myF11 = (a,b) => a + 1;
            myFunctionType2 myF12 = (a,b) => { return a + b + 1; };
            myFunctionType2 myF13 = (a,b)=> { Console.WriteLine("MyFlv3 : bonjour "); return a + b + 1; };

            Func<int, int, int> myF14 = (a, b) => a + b + 1;
            Func<int, int, int> myF15 = (a, b) => { return a + b + 1; };
            Func<int, int, int> myF16 = (a, b) => { Console.WriteLine("MyFlv3 : bonjour "); return a + b + 1; };

            Console.WriteLine("myF1 : " + myF1(9));
            Console.WriteLine("myF2 : " + myF2(9));
            Console.WriteLine("myF3 : " + myF3(9));
            Console.WriteLine("myF4 : " + myF4(9));
            Console.WriteLine("myF5 : " + myF5(9));
            Console.WriteLine("myF6 : " + myF6(9));
            Console.WriteLine("myF7 : " + myF7(9));
            Console.WriteLine("myF8 : " + myF8(9));
            Console.WriteLine("myF11 : " + myF11(9, 1));
            Console.WriteLine("myF12 : " + myF12(9, 1));
            Console.WriteLine("myF13 : " + myF13(9, 1));
            Console.WriteLine("myF14 : " + myF14(9, 1));
            Console.WriteLine("myF15 : " + myF15(9, 1));
            Console.WriteLine("myF16 : " + myF16(9, 1));


            Console.WriteLine("Anonym : " + new myFunctionType1(a => 10 * 2)(9));
            Console.WriteLine("Anonym : " + new Func<int, int>(a => 10 * 2)(9));

            Console.ReadKey();
        }
    }
}
