using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    // The class is designed to store information about the total amount of money in a company account.
    class Fund : IPayStuff
    {
        double account;
        public double Account { 
            get 
            {
                return account;
            }
            set 
            { 
                if (account >= 0)
                {
                    account = value;
                }
                else
                {
                    throw new Exception("Not enough money in the fund");
                }
            } 
        }
        public double UnexpectedCosts { get; set; }

        public void GetRent(object sender, RentEventArgs e)
        {
            Account += e.MonthlyRent;
        }

        public void PayAccounter(object sender, SalaryEventArgs e)
        {
            Account -= e.Salary;
        }

        public void PayCleaner(object sender, SalaryEventArgs e)
        {
            Account -= e.Salary;
        }

        public void PayDirector(object sender, SalaryEventArgs e)
        {
            Account -= e.Salary;
        }

        public void PayTrashman(object sender, SalaryEventArgs e)
        {
            Account -= e.Salary;
        }

        public void MakeSavings(object sender, SalaryEventArgs e)
        {
            double forSavings = Account / 100 * 15;
            UnexpectedCosts += forSavings;
            Account -= forSavings;
        }

        public void WithdrawSavings(int sum)
        {
            try
            {
                if (sum > UnexpectedCosts) throw new Exception("Not enough money");
                UnexpectedCosts -= sum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return $"Total sum: {Account}\nSavings: {UnexpectedCosts}\n";
        }
    }
}
