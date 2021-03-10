using System.Collections.Generic;
using WebServiceResTEC.Models;


namespace WebServiceResTEC.Data
{
    
    public interface IRepo
    {
        Admin GetAdmin();

        IEnumerable<Dish> GetAllDishes();
        Dish GetDishById(int id);
        void UpdateDish(Dish dish);
        void DeleteDish(Dish dish);
        
        void CreateDish(Dish dish);
    }
}