using System.ComponentModel.DataAnnotations;

namespace WebServiceResTEC.Models{

    public class Admin
    {
        [Key]
        public string Email { get; set;}

        [Required]
        public string Password { get; set;}
    }

}