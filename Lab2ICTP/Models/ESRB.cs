using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class ESRB
    {

        public ESRB()
        {
            Games = new List<Game>();
        }
        public int ESRBId { set; get; }

        [Display(Name = "Рейтинг ESRB")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Інформація про рейтинг")]
        public string Info { get; set; }

        public ICollection<Game> Games { get; set; }

    }
}
