using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    class Apartment
    {
        public delegate void Pay(object sender, RentEventArgs e);
        public event Pay PayRent;

        public int Number { get; set; }
        public List<Person> Citizens { get; set; }

        double area;
        public double Area {
            get { return area; }

            set { 
                if (value > 0)
                {
                    area = value;
                }
            } 
        }
        public double Account { get; set; }
        public double MonthlyRent { get; set; }

        public void ReplenishScore(double sum)
        {
            try
            {
                if (sum <= 0) throw new Exception("Wrong top-up amount");
                Account += sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void MonthlyPayment()
        {
            PayRent?.Invoke(this, new RentEventArgs(MonthlyRent));
            Account -= MonthlyRent;
        }
    }
}
