using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.Models{

    public class Dish
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public int Price {get; set;}
        [Required]
        public IEnumerable<string> Ingredients {get; set;}
        public int AmountSales {get; set;}
        public int PrepTime {get; set;}

    }

}