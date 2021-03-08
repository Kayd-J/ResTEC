using System.Xml.Linq;
using WebServiceResTEC.Models;

namespace WebServiceResTEC.Data
{
    public class AdminRepo : IRepo
    {
        public Admin GetAdmin()
        {
            Admin admin = new Admin();  
            XDocument doc = XDocument.Load("C:\\Users\\erick\\Documents\\TEC\\2021 - I Semestre\\Bases de Datos\\Tareas Cortas\\1\\ResTEC\\WebServiceResTEC\\DB\\admin.xml");  
            XElement element = doc.Element("Admin");
            admin.Email = element.Element("Email").Value;
            admin.Password = element.Element("Password").Value; 
            return admin;  
            // return new Admin{Email="aaaa", Password="123"};
        }
    }
}