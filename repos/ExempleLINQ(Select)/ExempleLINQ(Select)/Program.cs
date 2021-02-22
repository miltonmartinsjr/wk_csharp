using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ_Select_
{
    public class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>()
            {
                new Student(){ StudentID = 1, StudentName = "John", Age = 13},
                new Student(){ StudentID = 2, StudentName = "Moin", Age = 21},
                new Student(){ StudentID = 4, StudentName = "Ram", Age = 20},
                new Student(){ StudentID = 3, StudentName = "Bill", Age = 18},
                new Student(){ StudentID = 5, StudentName = "Ron", Age = 15}
            };

            var teenAgerStudent = from s in studentList
                                  select s.StudentName;

            Console.WriteLine("Teen Age Student : ");

            foreach (var name in teenAgerStudent)
            {
                Console.WriteLine( name );
            }

            var teenAgerStudent1 = from s in studentList
                                   select new { Name = s.StudentName, Age = s.Age };

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent1)
            {
                Console.WriteLine(item.Name + "  " + item.Age);
            }

            var teenAgerStudent2 = studentList.Select(s=> s.StudentName);

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent2)
            {
                Console.WriteLine(item);
            }

            var teenAgerStudent3 = studentList.Select(s => new { Name=s.StudentName, s.Age });

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent3)
            {
                Console.WriteLine(item.Name + "  " + item.Age);
            }

            Console.ReadKey();
        }
    }
}
