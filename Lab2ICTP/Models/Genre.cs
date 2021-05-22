using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class Genre
    {
        public Genre()
        {
            GamesGenres = new List<GamesGenres>();
        }
        public int Id { get; set; }
        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Інформація про жанр")]
        public string Info { get; set; }


        public ICollection<GamesGenres> GamesGenres { get; set; }
    }
}
