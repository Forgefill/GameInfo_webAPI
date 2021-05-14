using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2ICTP.Models
{
    public class GamesGenres
    {

        public int GamesGenresId { get; set; }

        public int GenreId { get; set; }

        public int GameId { get; set; }


        public virtual Genre Genre { get; set; }
        public virtual Game Game { get; set; }

    }
}
