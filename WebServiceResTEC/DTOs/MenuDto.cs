using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{
    public class MenuDto
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public string Type { get; set;}
        [Required]
        public int Calories { get; set;}
        public IEnumerable<int> Dishes {get; set;}

        public int Price {get; set;}
    }

}