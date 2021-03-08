using System.Collections.Generic;
using WebServiceResTEC.Models;


namespace WebServiceResTEC.Data
{
    
    public interface ITestRepo
    {
        IEnumerable<Test> GetAppTests();
        Test GetTestById(int id);
    }
}