using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    class Worker
    {
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public Worker(string position, string name, string surname, int salary)
        {
            Position = position;
            FirstName = name;
            LastName = surname;
            Salary = salary;
        }
    }
}
