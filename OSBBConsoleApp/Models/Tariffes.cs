using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    enum GarbageTarrif { Once = 3, Twice = 6, Thrice = 9 }
    enum CleaningTarrif { Daily = 16, In_a_day = 8, Twice = 4 }
    enum ScheduleMaintenance { Monthly = 5, Every2Month = 3 }
    struct OtherRents {
        public const double ElevatorRent = 0.2;
        public const double YardRent = 0.4;
        public const double StuffSalary = 1;
    }
}
