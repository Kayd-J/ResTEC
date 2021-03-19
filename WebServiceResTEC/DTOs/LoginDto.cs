using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.DTOs{

    public class LoginDto
    {
        [Required]
        public string Username { get; set;}
        
        [Required]
        public string Password { get; set;}

        public string UserType{ get; set;}

    }
}