using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("CharacterMovie")]
    public class CharacterMovieModelDAO
    {        
        public int CharacterId { get; set; }
        public int MovieId { get; set; }
        public CharacterMovieModelDAO(int CharacterId, int MovieId)
        {
            this.CharacterId = CharacterId;
            this.MovieId = MovieId;
        }
    }
}
