using System;
using System.Xml.Linq;
using WebServiceResTEC.Models;

namespace WebServiceResTEC.Data
{
    public class DataRepo : IRepo
    {
        public void CreateAdmin(Admin admin)
        {
            if(admin == null)
            {
                throw new ArgumentNullException(nameof(admin));
            }
            XElement adminXML = 
            new XElement("Admin",
                new XElement("Email", admin.Email),
                new XElement("Password", admin.Password)
            );

            adminXML.Save("DB\\admin.xml");
        }

        public Admin GetAdmin()
        {
            Admin admin = new Admin();  
            XDocument doc = XDocument.Load("DB\\admin.xml");  
            XElement element = doc.Element("Admin");
            admin.Email = element.Element("Email").Value;
            admin.Password = element.Element("Password").Value; 
            return admin;
        }
    }
}