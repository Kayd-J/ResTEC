using System.Collections.Generic;

namespace WebServiceResTEC.Models{

    public class Client
    {
        public int IdCard { get; set;}
        public string Password { get; set;}
        public string Name { get; set;}
        public IEnumerable<int> PhoneNumbers {get; set;}
        public string Email { get; set;}
        public string BirthDate { get; set;}
        public IEnumerable<string> Adress { get; set;}
        public int AmountOrders { get; set;}
    }

}