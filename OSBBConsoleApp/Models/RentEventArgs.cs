using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    class RentEventArgs : EventArgs
    {
        public double MonthlyRent { get; set; }
        public RentEventArgs(double MonthlyRent)
        {
            this.MonthlyRent = MonthlyRent;
        }
    }

    class SalaryEventArgs : EventArgs
    {
        public double Salary { get; set; }
        public SalaryEventArgs(double Salary)
        {
            this.Salary = Salary;
        }
    }
}
