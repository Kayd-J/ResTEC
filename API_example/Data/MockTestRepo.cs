using System.Collections.Generic;
using API_example.Models;

namespace API_example.Data
{
    public class MockTestRepo : ITestRepo
    {
        public IEnumerable<Test> GetAppTests()
        {
            var tests = new List<Test>
            {
                new Test{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Pan"},
                new Test{Id=1, HowTo="Cut Bread", Line="Get Knife", Platform="Chopping Board"},
                new Test{Id=2, HowTo="Make Tea", Line="Place teabag in cup", Platform="Kettle"}
            };
            
            return tests;
        }

        public Test GetTestById(int id)
        {
            return new Test{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Pan"};
        }
    }
}