using System.Collections.Generic;

namespace WebServiceResTEC.Models{

    public class Order
    {
        public int Id { get; set;}
        public string Date { get; set;}
        public string Time { get; set;}
        public int PrepTime {get; set;}
        public string State { get; set;}
        public IEnumerable<int> Dishes { get; set;}
        public int Chef { get; set;}
    }

}