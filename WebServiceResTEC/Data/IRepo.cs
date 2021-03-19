using System.Collections.Generic;
using WebServiceResTEC.Models;


namespace WebServiceResTEC.Data
{
    
    public interface IRepo
    {
        Admin GetAdmin();
        LoginProfile CheckCredentials(LoginProfile loginProfile);
        IEnumerable<Chef> GetAllChefs();
        IEnumerable<Dish> GetAllDishes();
        Dish GetDishById(int id);
        void UpdateDish(Dish dish);
        void DeleteDish(Dish dish);
        void CreateDish(Dish dish);


        IEnumerable<Menu> GetAllMenus();
        Menu GetMenuById(int id);
        void UpdateMenu(Menu menu);
        void DeleteMenu(Menu menu);
        void CreateMenu(Menu menu);

        IEnumerable<Client> GetAllClients();
        void CreateClient(Client client);

        IEnumerable<Order> GetAllOrders();
        void CreateOrder(Order order);
    }
}