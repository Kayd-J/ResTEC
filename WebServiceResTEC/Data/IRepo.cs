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
        //Reads the Dishes database, returns the Dish Data Model that matches with the received id.
        Dish GetDishById(int id);
        //Reads the Dishes database, and replaces with new info the Dish with the received id.
        void UpdateDish(Dish dish);
        //Deletes the Dish with the received id from the database
        void DeleteDish(Dish dish);
        //Creates a completely new Dish
        void CreateDish(Dish dish);


        //Reads the menus database, obtains all menus and returns a list of Menu Data Models.
        IEnumerable<Menu> GetAllMenus();
        //Reads the menus database, returns the Menu Data Model that matches with the received id.
        Menu GetMenuById(int id);
        //Reads the menus database, and replaces with new info the Menu with the received id.
        void UpdateMenu(Menu menu);
        //Deletes the menu with the received id from the database
        void DeleteMenu(Menu menu);
        //Creates a completely new menu
        void CreateMenu(Menu menu);


        //Reads the clients database, obtains all clients and returns a list of Client Data Models.
        IEnumerable<Client> GetAllClients();
        //Creates a completely new client
        void CreateClient(Client client);


        //Reads the orders database, obtains all orders and returns a list of Order Data Models.
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        //Creates a completely new order
        void CreateOrder(Order order);
        //Reads the orders database, returns a list of Order Data Model that matches with the received chef email.
        IEnumerable<Order> GetOrdersByChef(string email);
        //Reads the menus database, and updates the chef info of the Order with the received id.
        Order UpdateOrderState(Order order);
        //Reads the menus database, and updates the feedback info of the Order with the received id.
        Order UpdateOrderFeedback(Order order);


        //Reads the dishes database, and only returns the top 10 best selling dishes (List of Dish Data Model).
        IEnumerable<Dish> GetBestSellingDishes();
        //Reads the dishes database, and only returns the top 10 best profit dishes (List of Dish Data Model).
        IEnumerable<Dish> GetBestProfitDishes();
        //Reads the clients database, and only returns the top 10 clients by amount of Orders (List of Client Data Model).
        IEnumerable<Client> GetClientsByAmountOrders();
        //Reads the orders database, and only returns the top 10 best reviewed orders (List of Order Data Model).
        IEnumerable<Order> GetOrdersByFeedBack();


        


    }
}