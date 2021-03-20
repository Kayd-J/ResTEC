using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WebServiceResTEC.Models;

namespace WebServiceResTEC.Data
{
    public class DataRepo : IRepo
    {

        public Admin GetAdmin()
        {
            Admin admin = new Admin();  
            XDocument doc = XDocument.Load("DB\\admin.xml");  
            XElement element = doc.Element("Admin");
            admin.Email = element.Element("Email").Value;
            admin.Password = element.Element("Password").Value; 
            return admin;
        }

        public LoginProfile CheckCredentials(LoginProfile loginProfile)
        {
            List<Chef> chefs = (List<Chef>)GetAllChefs();
            List<Client> clients = (List<Client>)GetAllClients();
            Admin admin = GetAdmin();


            if (admin.Email == loginProfile.Username && admin.Password == loginProfile.Password)
            {
                loginProfile.UserType = "Admin";
                return loginProfile;
            }

            foreach(Chef chef in chefs)
            {
                if (chef.Email == loginProfile.Username && chef.Password == loginProfile.Password)
                {
                    loginProfile.UserType = "Chef";
                    return loginProfile;
                }
            }
            foreach(Client client in clients)
            {
                if (client.IdCard.ToString() == loginProfile.Username && client.Password == loginProfile.Password)
                {
                    loginProfile.UserType = "Client";
                    return loginProfile;
                }
            }

            return null;
        }
        public IEnumerable<Chef> GetAllChefs()
        {
            List<Chef> chefs = new List<Chef>();  
            XDocument doc = XDocument.Load("DB\\chefs.xml");  
            foreach (XElement element in doc.Descendants("Chefs")  
                .Descendants("Chef")) 
            {
                Chef chef = new Chef();
                chef.Id = Int32.Parse(element.Element("Id").Value);
                chef.Name = element.Element("Name").Value;
                chef.Email = element.Element("Email").Value;
                chef.Password = element.Element("Password").Value;
                List<int> orders = new List<int>();
                    foreach (XElement order in element.Descendants("Order"))
                    {
                        orders.Add(Int32.Parse(order.Value));
                    }
                chef.Orders = orders;
                chefs.Add(chef);
            }
            
            return chefs;
        }

        public IEnumerable<Dish> GetAllDishes()
        {
            List<Dish> dishes = new List<Dish>();      
            XDocument doc = XDocument.Load("DB\\dishes.xml");  
            foreach (XElement element in doc.Descendants("Dishes")  
                .Descendants("Dish"))  
            {  
                Dish dish = new Dish();  
                dish.Id = Int32.Parse(element.Element("Id").Value);  
                dish.Name = element.Element("Name").Value;  
                dish.Description  = element.Element ("Description").Value;  
                dish.Price  = Int32.Parse(element.Element ("Price").Value);
                dish.AmountSales  = Int32.Parse(element.Element ("AmountSales").Value);
                List<string> ingredients = new List<string>();
                foreach (XElement ingredient in element.Descendants("Ingredient"))
                {
                    ingredients.Add(ingredient.Value);
                }
                dish.Ingredients = ingredients;
                dish.PrepTime  = Int32.Parse(element.Element ("PrepTime").Value);
                dishes.Add(dish);     
            }  
            return dishes;  
        }

        public Dish GetDishById(int id)
        {
            Dish dish = new Dish();  
            XDocument doc = XDocument.Load("DB\\dishes.xml");  
            XElement element = doc.Element("Dishes")  
                                .Elements("Dish").Elements("Id").  
                                SingleOrDefault(x => x.Value == id.ToString());
            if (element != null)  
            {  
                XElement parent = element.Parent;  
                dish.Id = Int32.Parse(parent.Element("Id").Value);  
                dish.Name = parent.Element("Name").Value;  
                dish.Description  = parent.Element ("Description").Value;  
                dish.Price  = Int32.Parse(parent.Element ("Price").Value);
                dish.AmountSales  = Int32.Parse(parent.Element ("AmountSales").Value);
                List<string> ingredients = new List<string>();
                foreach (XElement ingredient in element.Descendants("Ingredient"))
                {
                    ingredients.Add(ingredient.Value);
                }
                dish.Ingredients = ingredients;
                dish.PrepTime  = Int32.Parse(parent.Element ("PrepTime").Value);
                return dish;
            }  
            return null;
        }

        public void UpdateDish(Dish dish)
        {
            XDocument xmlDoc = XDocument.Load("DB\\dishes.xml");  
            var items = from item in xmlDoc.Descendants("Dish")
                        where Int32.Parse(item.Element("Id").Value) == dish.Id
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("Name", dish.Name);
                itemElement.SetElementValue("Description", dish.Description);
                itemElement.SetElementValue("Price", dish.Price);
                itemElement.SetElementValue("AmountSales", dish.AmountSales);
                foreach (string ingredient in dish.Ingredients)
                {
                    itemElement.Descendants("Ingredients").FirstOrDefault().Add(
                        new XElement ("Ingredient", ingredient)
                    );
                }
            }
            xmlDoc.Save("DB\\dishes.xml");
        }

        public void DeleteDish(Dish dish)
        {
            if(dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }
            XDocument xmlDoc = XDocument.Load("DB\\dishes.xml");  
            var dishToDelete = from item in xmlDoc.Descendants("Dish")
                        where Int32.Parse(item.Element("Id").Value) == dish.Id
                        select item;

            dishToDelete.Remove();

            xmlDoc.Save("DB\\dishes.xml");
        }

        public void CreateDish(Dish dish)
        {
            if(dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }

            XDocument xmlDoc = XDocument.Load("DB\\dishes.xml");
            dish.Id = Int32.Parse(xmlDoc.Element("Dishes").Element("LastDishId").Value)+ 1; 

            XElement ingredients = new XElement("Ingredients");
            var amountIngredients = 0;
            foreach (string ingredient in dish.Ingredients)
            {
                ingredients.Add(new XElement ("Ingredient", ingredient));
                amountIngredients += 1;
            }
            dish.PrepTime = amountIngredients*2;
            xmlDoc.Element("Dishes").Add(
                new XElement("Dish",
                    new XElement("Id", dish.Id),
                    new XElement("Name", dish.Name),
                    new XElement("Description", dish.Description),
                    new XElement("Price", dish.Price),
                    new XElement("AmountSales", 0),
                    new XElement(ingredients),
                    new XElement("PrepTime", dish.PrepTime)
                )
            );
            xmlDoc.Element("Dishes").Element("LastDishId").Value = dish.Id.ToString();
            xmlDoc.Save("DB\\dishes.xml");
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            List<Menu> menus = new List<Menu>();      
            XDocument doc = XDocument.Load("DB\\menus.xml");  
            foreach (XElement element in doc.Descendants("Menus")  
                .Descendants("Menu"))  
            {  
                Menu menu = new Menu();  
                menu.Id = Int32.Parse(element.Element("Id").Value);  
                menu.Type = element.Element("Type").Value;  
                menu.Calories = Int32.Parse(element.Element ("Calories").Value);
                List<int> dishes = new List<int>();
                foreach (XElement dish in element.Descendants("Dish"))
                {
                    dishes.Add(Int32.Parse(dish.Value));
                }
                menu.Dishes = dishes;
                menu.Price = Int32.Parse(element.Element ("Price").Value);
                menus.Add(menu);     
            } 
            return menus;  
        }

        public Menu GetMenuById(int id)
        {
            Menu menu = new Menu();  
            XDocument doc = XDocument.Load("DB\\menus.xml");  
            XElement element = doc.Element("Menus")  
                                .Elements("Menu").Elements("Id").  
                                SingleOrDefault(x => x.Value == id.ToString());
            if (element != null)  
            {  
                XElement parent = element.Parent;  
                menu.Id = Int32.Parse(parent.Element("Id").Value);  
                menu.Type = parent.Element("Type").Value;  
                menu.Calories  = Int32.Parse(parent.Element ("Calories").Value);
                List<int> dishes = new List<int>();
                foreach (XElement dish in parent.Descendants("Dish"))
                {
                    dishes.Add(Int32.Parse(dish.Value));
                }
                menu.Dishes = dishes;
                menu.Price = Int32.Parse(element.Element ("Price").Value);
                return menu;
            }  
            return null;
        }

        public void UpdateMenu(Menu menu)
        {
            XDocument xmlDoc = XDocument.Load("DB\\menus.xml");  
            var items = from item in xmlDoc.Descendants("Menu")
                        where Int32.Parse(item.Element("Id").Value) == menu.Id
                        select item;

            foreach (XElement itemElement in items)
            {
                itemElement.SetElementValue("Type", menu.Type);
                itemElement.SetElementValue("Calories", menu.Calories);
                itemElement.SetElementValue("Dishes", "");
                foreach (int dish in menu.Dishes)
                {
                    itemElement.Descendants("Dishes").FirstOrDefault().Add(
                        new XElement ("Dish", dish.ToString())
                    );
                }
            }
            xmlDoc.Save("DB\\menus.xml");
        }

        public void DeleteMenu(Menu menu)
        {
            if(menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }
            XDocument xmlDoc = XDocument.Load("DB\\menus.xml");  
            var dishToDelete = from item in xmlDoc.Descendants("Menu")
                        where Int32.Parse(item.Element("Id").Value) == menu.Id
                        select item;

            dishToDelete.Remove();

            xmlDoc.Save("DB\\menus.xml");
        }

        public void CreateMenu(Menu menu)
        {
            if(menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }

            XDocument xmlDoc = XDocument.Load("DB\\menus.xml");
            menu.Id = Int32.Parse(xmlDoc.Element("Menus").Element("LastMenuId").Value)+ 1; 

            XElement dishes = new XElement("Dishes");
            int price = 0;
            foreach (int dish in menu.Dishes)
            {
                dishes.Add(new XElement ("Dish", dish.ToString()));
                price += GetDishById(dish).Price;
            }

            menu.Price = price;
            Console.WriteLine(menu.Price);

            xmlDoc.Element("Menus").Add(
                new XElement("Menu",
                    new XElement("Id", menu.Id),
                    new XElement("Type", menu.Type),
                    new XElement("Calories", menu.Calories),
                    new XElement(dishes),
                    new XElement("Price", menu.Price)
                )
            );

            xmlDoc.Element("Menus").Element("LastMenuId").Value = menu.Id.ToString();
            xmlDoc.Save("DB\\menus.xml");
        }

        public void CreateClient(Client client)
        {
            if(client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            XDocument xmlDoc = XDocument.Load("DB\\clients.xml");

            XElement phoneNumbers = new XElement("PhoneNumbers");
            foreach (int PhoneNumber in client.PhoneNumbers)
            {
                phoneNumbers.Add(new XElement ("PhoneNumber", PhoneNumber.ToString()));
            }

            xmlDoc.Element("Clients").Add(
                new XElement("Client",
                    new XElement("IdCard", client.IdCard),
                    new XElement("Password", client.Password),
                    new XElement("Name", client.Name),
                    new XElement(phoneNumbers),
                    new XElement("Email", client.Email),
                    new XElement("BirthDate", client.BirthDate),
                    new XElement("Address", 
                        new XElement("Province", client.Address.ElementAt(0)),
                        new XElement("Canton", client.Address.ElementAt(1)),
                        new XElement("District", client.Address.ElementAt(2))
                    ),
                    new XElement("AmountOrders", client.AmountOrders)
                )
            );

            xmlDoc.Save("DB\\clients.xml");
        }

        public IEnumerable<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();      
            XDocument doc = XDocument.Load("DB\\clients.xml");  
            foreach (XElement element in doc.Descendants("Clients")  
                .Descendants("Client"))  
            {  
                Client client = new Client();  
                client.IdCard = Int32.Parse(element.Element("IdCard").Value);  
                client.Password = element.Element("Password").Value; 
                client.Name = element.Element("Name").Value;  


                List<int> phoneNumbers = new List<int>();
                foreach (XElement phoneNumber in element.Descendants("PhoneNumber"))
                {
                    phoneNumbers.Add(Int32.Parse(phoneNumber.Value));
                }
                client.PhoneNumbers = phoneNumbers;

                client.Email  = element.Element ("Email").Value;
                client.BirthDate  = element.Element ("BirthDate").Value;

                List<string> address = new List<string>();
                address.Add(element.Element("Address").Element("Province").Value);
                address.Add(element.Element("Address").Element("Canton").Value);
                address.Add(element.Element("Address").Element("District").Value);
                client.Address = address;
                
                client.AmountOrders = Int32.Parse(element.Element("AmountOrders").Value);  
                clients.Add(client);     
            } 
            return clients;  
        }

        public void CreateOrder(Order order)
        {
            if(order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            XDocument xmlDoc = XDocument.Load("DB\\orders.xml");
            order.Id = Int32.Parse(xmlDoc.Element("Orders").Element("LastOrderId").Value)+ 1; 

            XElement dishes = new XElement("Dishes");
            foreach (int dish in order.Dishes)
            {
                dishes.Add(new XElement ("Dish", dish.ToString()));
            }

            xmlDoc.Element("Orders").Add(
                new XElement("Order",
                    new XElement("Id", order.Id),
                    new XElement("Date", order.Date),
                    new XElement("Time", order.Time),
                    new XElement("PrepTime", order.PrepTime),
                    new XElement("State", order.State),
                    new XElement(dishes),
                    new XElement("Chef", order.Chef)
                )
            );
            
            xmlDoc.Element("Orders").Element("LastOrderId").Value = order.Id.ToString();
            xmlDoc.Save("DB\\orders.xml");
        }

        public IEnumerable<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();      
            XDocument doc = XDocument.Load("DB\\orders.xml");  
            foreach (XElement element in doc.Descendants("Orders")  
                .Descendants("Order"))  
            {  
                Order order = new Order();  
                order.Id = Int32.Parse(element.Element("Id").Value);  
                order.Date = element.Element("Date").Value; 
                order.Time = element.Element("Time").Value;  
                order.PrepTime = Int32.Parse(element.Element ("PrepTime").Value);
                order.State = element.Element ("State").Value;

                List<int> dishes = new List<int>();
                foreach (XElement dish in element.Descendants("Dish"))
                {
                    dishes.Add(Int32.Parse(dish.Value));
                }
                order.Dishes = dishes;
                order.Chef = Int32.Parse(element.Element ("Chef").Value);
                
                orders.Add(order);     
            } 
            return orders;
        }

        
    }
}