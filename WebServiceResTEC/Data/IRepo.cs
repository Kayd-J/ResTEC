using System.Collections.Generic;
using WebServiceResTEC.Models;


namespace WebServiceResTEC.Data
{
    
    public interface IRepo
    {
        Admin GetAdmin();
        void CreateAdmin(Admin admin);
    }
}