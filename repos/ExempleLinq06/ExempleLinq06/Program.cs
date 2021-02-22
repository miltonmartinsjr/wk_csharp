using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleLinq06
{

    public class Departement
    {
        public int DepId { get; set; }
        public String DepName { get; set; }
    }

    public class Employee
    {
        public int EmpId { get; set; }
        public String Name { get; set; }
        public int DepId { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {

            List<Departement> depList = new List<Departement>()
            {
                new Departement{ DepId=1, DepName="Accounting"},
                new Departement{ DepId=2, DepName="Finance"},
                new Departement{ DepId=3, DepName="Sales"}
            };

            List<Employee> empList = new List<Employee>()
            {
                new Employee{ EmpId=1, Name="Anne Tremblay", DepId=1},
                new Employee{ EmpId=2, Name="Jean Desjardin", DepId=1},
                new Employee{ EmpId=3, Name="Robert Gagnon", DepId=2},
                new Employee{ EmpId=4, Name="Luis Benoit", DepId=2},
                new Employee{ EmpId=5, Name="Pierre Lafont"}
            };

            //Inner Join
            var resultQ1 = from e in depList
                           from f in empList
                           where e.DepId == f.DepId
                           select new { EmployeeName = f.Name, DepartementName = e.DepName };

            foreach(var item in resultQ1)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }

            Console.WriteLine();

            var resultQ2 = empList.SelectMany(_ => depList, (x, y) => new { x, y })
                           .Where(z => z.x.DepId == z.y.DepId)
                           .Select(z => new { EmployeeName = z.x.Name, DepartementName = z.y.DepName });

            foreach (var item in resultQ2)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }
            Console.WriteLine();

            //Cross Join
            var resultQ3 = from e in depList
                           from f in empList
                           select new { EmployeeName = f.Name, DepartementName = e.DepName };

            foreach (var item in resultQ3)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }

            Console.WriteLine();

            var resultQ4 = empList.SelectMany(_ => depList, (x, y) => new { x, y })
                           .Select(z => new { EmployeeName = z.x.Name, DepartementName = z.y.DepName });

            foreach (var item in resultQ4)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }
            Console.WriteLine();


            //Cross Join
            var resultQ5 = from e in depList
                           join f in empList
                           on e.DepId equals f.DepId into empDep
                           select new { Employees = empDep, DepartementName = e.DepName };

            foreach (var item in resultQ5)
            {
                Console.WriteLine(item.DepartementName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(" ---> " + emp.Name);
                }  
            }

            Console.WriteLine();

            //Cross Join
            var resultQ6 = depList.GroupJoin(empList, d => d.DepId, e => e.DepId, (d, e) => new { Employees = e, DepartementName = d.DepName });

            foreach (var item in resultQ6)
            {
                Console.WriteLine(item.DepartementName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(" ---> " + emp.Name);
                }
            }

            Console.WriteLine();
            //Cross Join
            var resultQ7 = from e in depList
                           join f in empList
                           on e.DepId equals f.DepId into empDep
                           select new { Employees = from e2 in empDep
                                                    orderby e2.Name descending select e2.Name , DepartementName = e.DepName };

            foreach (var item in resultQ7)
            {
                Console.WriteLine(item.DepartementName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(" ---> " + emp);
                }
            }

            Console.WriteLine();

            //Cross Join
            var resultQ8 = depList.GroupJoin(empList, d => d.DepId, e => e.DepId, (d, e) => new { Employees = e.OrderByDescending(s => s.Name).Select(s => s.Name), DepartementName = d.DepName });

            foreach (var item in resultQ8)
            {
                Console.WriteLine(item.DepartementName);
                foreach (var emp in item.Employees)
                {
                    Console.WriteLine(" ---> " + emp);
                }
            }

            Console.WriteLine();


            //Left Join
            var resultQ9 = from e in empList
                           join d in depList
                           on e.DepId equals d.DepId 
                           into depEmp
                           from dd in depEmp.DefaultIfEmpty(new Departement())
                           select new
                           {
                               EmployeName = e.Name,
                               DepartementName = dd.DepName
                           };

            foreach (var item in resultQ9)
            {
                Console.WriteLine(item.EmployeName + " | " + item.DepartementName);
            }
            Console.WriteLine();


            //Cross Join
            var result10 = empList.GroupJoin(depList, e => e.DepId, d => d.DepId, (e, d) => new { e.Name, d })
                            .SelectMany(z => z.d.DefaultIfEmpty(new Departement()), (z, d) => new { EmployeeName = z.Name, DepartementName = d.DepName});

            foreach (var item in result10)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }

            Console.WriteLine();

            //Left Join
            var resultQ10 = from e in empList
                           join d in depList
                           on e.DepId equals d.DepId
                           into depEmp
                           from dd in depEmp.DefaultIfEmpty(null)
                           select new
                           {
                               EmployeName = e.Name,
                               DepartementName = dd == null ? "No Deparment" : dd.DepName
                           };

            foreach (var item in resultQ10)
            {
                Console.WriteLine(item.EmployeName + " | " + item.DepartementName);
            }
            Console.WriteLine();

            //Cross Join
            var result11 = empList.GroupJoin(depList, e => e.DepId, d => d.DepId, (e, d) => new { e.Name, d })
                            .SelectMany(z => z.d.DefaultIfEmpty(null), (z, d) => new { EmployeeName = z.Name, DepartementName = d == null ? "No Departement" : d.DepName });

            foreach (var item in result11)
            {
                Console.WriteLine(item.EmployeeName + " | " + item.DepartementName);
            }

            Console.ReadKey();
        }
    }
}
