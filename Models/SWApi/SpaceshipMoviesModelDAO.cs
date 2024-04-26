namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("Film_Spaceship")]
    public class SpaceshipMoviesModelDAO
    {
        public int FilmId { get; set; }
        public int SpaceshipId { get; set; }
        public SpaceshipMoviesModelDAO(int SpaceshipId, int FilmId)
        {
            this.SpaceshipId = SpaceshipId;
            this.FilmId = FilmId;
        }
    }
}
