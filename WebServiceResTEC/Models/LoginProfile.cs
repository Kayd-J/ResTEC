using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.Models{

    public class LoginProfile
    {
        [Key]
        public string Username { get; set;}
        
        [Required]
        public string Password { get; set;}

        public string UserType{ get; set;}
    }
}