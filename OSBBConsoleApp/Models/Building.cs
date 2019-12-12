using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp
{
    class Building
    {
        public string Address { get; set; }
        public List<Apartment> Apartments { get; set; }
        public bool HasElevator { get; private set; }
        public bool HasYard { get; set; }

        [JsonProperty("Garbage")]
        public GarbageTarrif GarbageExport { get; set; }

        [JsonProperty("Cleaning")]
        public CleaningTarrif CleaningFrequency { get; set; }

        [JsonProperty("Maintenance")]
        public ScheduleMaintenance MaintenanceFrequency { get; set; }

        public void SetRent()
        {
            MonthlyRentCalculator.Calculate(this);
        }
    }
}
