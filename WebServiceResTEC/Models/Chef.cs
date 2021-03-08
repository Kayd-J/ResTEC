using System.Collections.Generic;

namespace WebServiceResTEC.Models{

    public class Chef
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
        public IEnumerable<int> Orders { get; set;}
    }

}
