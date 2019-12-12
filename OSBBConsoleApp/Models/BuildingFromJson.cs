using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OSBBConsoleApp
{
    class BuildingFromJson
    {
        public string JsonFileName
        {   
             get { return Path.Combine(@"C:\Users\komen\OneDrive\Документы\GitHub\OSBBConsoleApp\OSBBconsoleapp\OSBBConsoleApp", "data", "building1.json"); }
        }

        public async Task<Building> GetBuilding()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return await Task.Run(() => JsonConvert.DeserializeObject<Building>(jsonFileReader.ReadToEnd(), new Newtonsoft.Json.Converters.StringEnumConverter()));
            }
        }
    }
}
