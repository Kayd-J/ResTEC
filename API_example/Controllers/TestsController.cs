using System.Collections.Generic;
using API_example.Data;
using API_example.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_example.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestRepo _repository;

        public TestsController(ITestRepo repository)
        {
            _repository = repository;
        }        

        //GET api/tests
        [HttpGet]
        public ActionResult <IEnumerable<Test>> GetAllTests()
        {
            var testItems = _repository.GetAppTests();

            return Ok(testItems);
        }

        //GET api/tests/{id}
        [HttpGet("{id}")]
        public ActionResult <Test> GetTestById(int id)
        {
            var testItem = _repository.GetTestById(id);
            return Ok(testItem);
        }
    }
}