using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSBBConsoleApp.Models
{
    // Сlass designed for pulling data to json file
    class BuildingToJson
    {
        public Building House { get; set; }
        public BuildingToJson(Building building)
        {
            House = building;
        }
        public override string ToString() => JsonConvert.SerializeObject(House, new StringEnumConverter());
    }
}
