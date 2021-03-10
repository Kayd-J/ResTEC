using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{

    public class AdminDto
    {
        [Required]
        public string Email { get; set;}
        
        [Required]
        public string Password { get; set;}
    }
}