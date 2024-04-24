using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("CharacterStarship")]
    public class CharacterStarshipModelDAO
    {        
        public int CharacterId { get; set; }
        public int StarshipId { get; set; }
        public CharacterStarshipModelDAO(int CharacterId, int StarshipId)
        {
            this.CharacterId = CharacterId;
            this.StarshipId = StarshipId;
        }
    }
}
