using System.Collections.Generic;
using WebServiceResTEC.Models;


namespace WebServiceResTEC.Data
{
    
    public interface IRepo
    {
        //Reads the Admin database and returns an Admin Data Model with the obtained info.
        Admin GetAdmin();
    
        //Reads the Admin, Clients and Chefs database to check credentials for the received loginProfile.
        LoginProfile CheckCredentials(LoginProfile loginProfile);

        //Reads the Chefs database, obtains all chefs and returns a list of Chef Data Models.
        IEnumerable<Chef> GetAllChefs();
        
        //Reads the Dishes database, obtains all dishes and returns a list of Dish Data Models.
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
        Order GetOrderById(int id);
        void CreateOrder(Order order);
        IEnumerable<Order> GetOrdersByChef(string email);
        Order UpdateOrderState(Order order);
        Order UpdateOrderFeedback(Order order);

        IEnumerable<Dish> GetBestSellingDishes();
        IEnumerable<Dish> GetBestProfitDishes();
        IEnumerable<Client> GetClientsByAmountOrders();
        IEnumerable<Order> GetOrdersByFeedBack();


        


    }
}