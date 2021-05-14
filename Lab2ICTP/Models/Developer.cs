using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class Developer
    {

        public Developer()
        {
            Games = new List<Game>();
        }

        public int DeveloperId { get; set; }
        [Display(Name = "Розробник")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Display(Name = "Інформація про розробника")]
        public string Info { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }


        public ICollection<Game> Games { get; set; }

    }
}
