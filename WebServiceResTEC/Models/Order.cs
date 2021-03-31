using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.Models{

    public class Order
    {
        [Key]
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
        public string Chef { get; set;}

        [Required]
        public int Client { get; set;}

        public string FeedbackTime { get; set;}

        public string FeedbackScore { get; set;}

    }

}