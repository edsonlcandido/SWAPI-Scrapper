using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Models.SWApi
{

    [Dapper.Contrib.Extensions.Table("Film_Vehicle")]
    public class VehicleMoviesModelDAO
    {
        public int VehicleId { get; set; }
        public int FilmId { get; set; }

        public VehicleMoviesModelDAO(int VehicleId, int FilmId)
        {
            this.VehicleId = VehicleId;
            this.FilmId = FilmId;
        }
    }
}
