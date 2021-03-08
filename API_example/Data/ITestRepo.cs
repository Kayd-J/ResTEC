using System.Collections.Generic;
using API_example.Models;


namespace API_example.Data
{
    
    public interface ITestRepo
    {
        IEnumerable<Test> GetAppTests();
        Test GetTestById(int id);
    }
}