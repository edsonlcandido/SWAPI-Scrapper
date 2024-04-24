using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("PlanetMovies")]
    public class PlanetMoviesModelDAO
    {        
        public int PlanetId { get; set; }
        public int MovieId { get; set; }
        public PlanetMoviesModelDAO(int PlanetId, int MovieId)
        {
            this.PlanetId = PlanetId;
            this.MovieId = MovieId;
        }
    }
}
