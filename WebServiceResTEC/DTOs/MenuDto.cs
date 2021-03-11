using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebServiceResTEC.Models;

namespace WebServiceResTEC.DTOs{
    public class MenuDto
    {

        public int Id { get; set;}
        [Required]
        public string Type { get; set;}
        [Required]
        public int Calories { get; set;}
        public IEnumerable<int> Dishes {get; set;}
    }

}