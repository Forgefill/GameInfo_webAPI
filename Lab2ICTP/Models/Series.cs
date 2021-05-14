using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class Series
    {
        public Series()
        {
            Games = new List<Game>();
        }
        public int SeriesId { get; set; }
        [Display(Name = "Серія ігор")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
