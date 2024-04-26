using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Models.SWApi
{
    [Dapper.Contrib.Extensions.Table("Film")]
    internal class MovieModelDAO
    {   
        public int Id { get; set; }
        public string Title { get; set; }
        public int Episode { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }

    }
}
