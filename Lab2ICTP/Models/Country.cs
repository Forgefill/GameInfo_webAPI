using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Lab2ICTP.Models
{
    public class Country
    {
        public Country()
        {
            Publishers = new List<Publisher>();
            Developers = new List<Developer>();
        }
        public int CountryId { get; set; }
        [Display(Name = "Країна")]
        [Required(ErrorMessage ="Поле не повинно бути порожнім")]
        public string Name { get; set; }

        public ICollection<Publisher> Publishers { get; set; }

        public ICollection<Developer> Developers { get; set; }

    }
}
