using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{

    [Dapper.Contrib.Extensions.Table("Spaceship")]
    internal class SpaceshipModelDAO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaxSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string Class { get; set; }
        public string HyperdriveRating { get; set; }
        public string MGLT { get; set; }
    }
}
