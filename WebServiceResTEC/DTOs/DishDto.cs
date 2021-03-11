using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{

    public class DishDto
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public int Price {get; set;}
        public int AmountSales {get; set;}
    }

}