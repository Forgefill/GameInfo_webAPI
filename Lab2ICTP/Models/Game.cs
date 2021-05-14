using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class Game
    {

        public Game()
        {
            GamesGenres = new List<GamesGenres>();
        }

        public int GameId { get; set; }
        [Display(Name = "Гра")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Дата випуску")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public DateTime RealeseDate { get; set; }
        [Display(Name = "10-бальний рейтинг")]

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(0,10, ErrorMessage ="Оцінка повинна бути в діапазоні 0-10")]

        public int Rating { get; set; }
        [Display(Name = "Інформація про гру")]
        public string Info { get; set; }
        [Display(Name = "Ціна")]

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Range(0, 100000, ErrorMessage = "ціна не повинна перевищувати сто тисяч")]
        public decimal Price { get; set; }

        public int SeriesId { get; set; }
        public int DeveloperId { get; set; }
        public int PublisherId { get; set; }
        public int ESRBId { get; set; }

        public virtual Series Series { get; set; }
        public virtual Developer Developer { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ESRB ESRB { get; set; }


        public ICollection<GamesGenres> GamesGenres { get; set; }

    }
}
