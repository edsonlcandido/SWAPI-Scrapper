using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Models.SWApi
{

    [Dapper.Contrib.Extensions.Table("VehicleMovies")]
    public class VehicleMoviesModelDAO
    {
        public int VehicleId { get; set; }
        public int MovieId { get; set; }

        public VehicleMoviesModelDAO(int vehicleId, int movieId)
        {
            VehicleId = vehicleId;
            MovieId = movieId;
        }
    }
}
