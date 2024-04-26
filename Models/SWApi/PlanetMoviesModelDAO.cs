using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("Film_Planet")]
    public class PlanetMoviesModelDAO
    {        
        public int FilmId { get; set; }
        public int PlanetId { get; set; }
        public PlanetMoviesModelDAO(int PlanetId, int FilmId)
        {
            this.PlanetId = PlanetId;
            this.FilmId = FilmId;
        }
    }
}
