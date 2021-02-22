using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLINQ04_Where_
{
    public class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int Age { get; set; }
    }


    class Program
    {

        public static bool isTeenAger(Student student)
        {
            return student.Age > 12 && student.Age < 20;
        }


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
                                  where s.Age > 12 && s.Age < 20
                                  select s.StudentName;

            Console.WriteLine("Teen Age Student : ");

            foreach (var name in teenAgerStudent)
            {
                Console.WriteLine(name);
            }

            var teenAgerStudent1 = from s in studentList
                                   where isTeenAger(s)
                                   select new { Name = s.StudentName, Age = s.Age };

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent1)
            {
                Console.WriteLine(item.Name + "  " + item.Age);
            }

            //Un autre exemple
            Func<Student, bool> validate = s => s.Age > 12 && s.Age < 20;

            var teenAgerStudent2 = from s in studentList
                                   where validate(s)
                                   select new { Name = s.StudentName, Age = s.Age };

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent2)
            {
                Console.WriteLine(item);
            }

            var teenAgerStudent3  = from s in studentList
                                     where s.Age > 12
                                     where s.Age < 20
                                     select new { Name = s.StudentName, Age = s.Age };

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent3)
            {
                Console.WriteLine(item.Name + "  " + item.Age);
            }


            var teenAgerStudent4 = studentList.Where(s => s.Age > 12 && s.Age < 20);
                                   

            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent4)
            {
                Console.WriteLine(item.StudentName + "  " + item.Age);
            }

            var teenAgerStudent5 = studentList.Where(isTeenAger);


            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent5)
            {
                Console.WriteLine(item.StudentName + "  " + item.Age);
            }


            var teenAgerStudent8 = studentList.Where(s => s.Age > 12).Where(s=> s.Age < 20);


            Console.WriteLine("Teen Age Student : ");

            foreach (var item in teenAgerStudent8)
            {
                Console.WriteLine(item.StudentName + "  " + item.Age);
            }

            Console.ReadKey();
        }
    }
}
