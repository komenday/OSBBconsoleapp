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

        public void ShowApartment()
        {
            Console.WriteLine($"Number: {Number}\nArea: {Area}\nAmount in the account: {Account}\nMonthly rent: {MonthlyRent}");

            if (Account < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"DEBT {-Account} UAH");
                Console.ResetColor();
            }
            else if (Account - MonthlyRent < 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"On account is not enough MONEY");
                Console.ResetColor();
            }

            Console.WriteLine("Citizens:");
            foreach (var item in Citizens)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName}");
            }
        }
    }
}
