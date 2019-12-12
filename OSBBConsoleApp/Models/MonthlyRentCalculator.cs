using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    static class MonthlyRentCalculator
    {
        public static void Calculate(Building House)
        {
            double k = 1 +
                ((double)House.CleaningFrequency / 10) +
                ((double)House.GarbageExport / 10) +
                ((double)House.MaintenanceFrequency / 10) +
                OtherRents.StuffSalary;

            if (House.HasElevator) k += OtherRents.ElevatorRent;
            if (House.HasYard) k += OtherRents.YardRent;

            foreach (Apartment apartment in House.Apartments)
            {
                apartment.MonthlyRent = k * apartment.Area;
            }
        }
    }
}
