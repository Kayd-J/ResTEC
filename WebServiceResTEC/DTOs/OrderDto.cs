using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{

    public class OrderDto
    {
        [Required]
        public int Id { get; set;}
        [Required]
        public string Date { get; set;}
        [Required]
        public string Time { get; set;}
        [Required]
        public int PrepTime {get; set;}
        [Required]
        public string State { get; set;}
        [Required]
        public IEnumerable<int> Dishes { get; set;}
        [Required]
        public int Chef { get; set;}
    }

}