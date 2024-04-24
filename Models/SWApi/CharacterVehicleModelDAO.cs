using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("CharacterVehicle")]
    public class CharacterVehicleModelDAO
    {        
        public int CharacterId { get; set; }
        public int VehicleId { get; set; }
        public CharacterVehicleModelDAO(int CharacterId, int VehicleId)
        {
            this.CharacterId = CharacterId;
            this.VehicleId = VehicleId;
        }
    }
}
