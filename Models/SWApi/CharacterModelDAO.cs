using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("Character")]
    internal class CharacterModelDAO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public int PlanetId { get; set; }

    }
}
