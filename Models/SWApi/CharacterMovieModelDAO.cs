using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("Film_Characters")]
    public class CharacterMovieModelDAO
    {        
        public int CharacterId { get; set; }
        public int FilmId { get; set; }
        public CharacterMovieModelDAO(int CharacterId, int FilmId)
        {
            this.CharacterId = CharacterId;
            this.FilmId = FilmId;
        }
    }
}
