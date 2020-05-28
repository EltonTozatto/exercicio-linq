using ExercicioLinq.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ExercicioLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double salaryChose = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Email of people whose salary is more than 2000.00: ");
            var result1 = employees.Where(e => e.Salary > salaryChose).OrderBy(e => e.Email).Select(e => e.Email);
            foreach(string s in result1)
            {
                Console.WriteLine(s);
            }

            var sum = employees.Where(e => e.Name[0] == 'M').Select(e => e.Salary).Sum().ToString("F2", CultureInfo.InvariantCulture);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum);
        }
    }
}
