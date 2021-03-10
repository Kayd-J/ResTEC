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

            // foreach (var e in dishToDelete)
            // {
            // e.Remove();

            // }

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

            xmlDoc.Element("Dishes").Add(
                new XElement("Dish",
                    new XElement("Id", dish.Id),
                    new XElement("Name", dish.Name),
                    new XElement("Description", dish.Description),
                    new XElement("Price", dish.Price),
                    new XElement("AmountSales", 0)
                )
            );
            xmlDoc.Element("Dishes").Element("LastDishId").Value = dish.Id.ToString();
            xmlDoc.Save("DB\\dishes.xml");
        }
    }
}