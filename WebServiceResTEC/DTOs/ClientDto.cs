using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{

    public class ClientDto
    {
        [Required]
        public int IdCard { get; set;}
        [Required]
        public string Password { get; set;}
        [Required]
        public string Name { get; set;}
        [Required]
        public IEnumerable<int> PhoneNumbers {get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string BirthDate { get; set;}
        [Required]
        public IEnumerable<string> Address { get; set;}
        public int AmountOrders { get; set;}
    }

}