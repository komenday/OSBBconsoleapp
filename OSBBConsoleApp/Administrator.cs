﻿using OSBBConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    class Administrator
    {
        public delegate void Salary(object sender, SalaryEventArgs e);
        public event Salary IssueASalary;
        public Building Building { get; set; }
        public Fund Fund { get; set; }
        private BuildingFromJson BuildingFromJson { get; set; }

        public Administrator()
        {
            Fund = new Fund();
            BuildingFromJson = new BuildingFromJson();
            Building = BuildingFromJson.GetBuilding().Result;
            Building.SetRent();

            IssueASalary += Fund.PayDirector;
            IssueASalary += Fund.PayAccounter;
            IssueASalary += Fund.PayCleaner;
            IssueASalary += Fund.PayTrashman;
            IssueASalary += Fund.MakeSavings;

            foreach (Apartment apartment in Building.Apartments)
            {
                apartment.PayRent += Fund.GetRent;
            }
        }

        private void DoOperation()
        {
            foreach (Apartment apartment in Building.Apartments)
            {
                apartment.MonthlyPayment();
            }

            IssueASalary?.Invoke(this, new SalaryEventArgs(150));
            SaveInFile();
        }

        private void RefillScore(int sum, int number)
        {
            try
            {
                Apartment selected = Building.Apartments.First(x => x.Number == number);
                selected.ReplenishScore(sum);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Wrong apartment number");
            }
        }

        private async void SaveInFile()
        {
            using (StreamWriter sw = new StreamWriter(BuildingFromJson.JsonFileName, false))
            {
                BuildingToJson buildingToJson = new BuildingToJson(Building);
                await sw.WriteLineAsync(buildingToJson.ToString());
            }
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to OSBB manager!\n");
            do
            {
                Console.WriteLine("\nChoose action:\n\n1\tMake a payment\n2\tRefill account\n3\tShow information about seperate apartment\n4\tShow information about building\n5\tShow information about fund\n6\tWithdraw money from savings\n0\tExit\n\nEnter a digit: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        {
                            Console.WriteLine("Are you sure? y - yes, n - no");
                            string exit = Console.ReadLine();
                            if (exit[0] == 'y') Environment.Exit(0);
                            else break;
                        }
                        break;
                    case 1:
                        {
                            DoOperation();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter number of apartment:");
                            int num = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter a sum of refill:");
                            int sum = Convert.ToInt32(Console.ReadLine());
                            RefillScore(sum, num);
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter number of apartment:");
                            int num = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                Apartment selected = Building.Apartments.First(x => x.Number == num);
                                selected.ShowApartment();
                                Console.WriteLine();
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("Wrong apartment number");
                            }
                        }
                        break;
                    case 4:
                        {
                            Building.ShowBuilding();
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine(Fund);
                            Console.WriteLine();
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Enter a sum of withdraw:");
                            int sum = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Fund.WithdrawSavings(sum);
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid digit. Please try again.");
                            Console.WriteLine();
                        }
                        break;
                }
            } while (true);
        }
    }
}
