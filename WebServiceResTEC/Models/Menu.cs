using System.Collections.Generic;

namespace WebServiceResTEC.Models{

    public class Menu
    {
        public int Id { get; set;}
        public string Type { get; set;}
        public int Calories { get; set;}
        public IEnumerable<int> Dishes {get; set;}
    }

}
