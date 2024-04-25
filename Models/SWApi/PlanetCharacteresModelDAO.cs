using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("PlanetCharacters")]
    public class PlanetCharactersModelDAO
    {        
        public int PlanetId { get; set; }
        public int CharacterId { get; set; }
        public PlanetCharactersModelDAO(int PlanetId, int CharacterId)
        {
            this.PlanetId = PlanetId;
            this.CharacterId = CharacterId;
        }
    }
}
