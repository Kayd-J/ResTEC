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
    }
}