using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.Models{

    public class Menu
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Type { get; set;}
        [Required]
        public int Calories { get; set;}
        [Required]
        public IEnumerable<int> Dishes {get; set;}

        public int Price {get; set;}
    }

}
