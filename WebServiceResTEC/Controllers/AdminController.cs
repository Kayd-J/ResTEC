using WebServiceResTEC.Data;
using WebServiceResTEC.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepo _repository;

        public AdminController(IRepo repository)
        {
            _repository = repository;
        }        

        //GET api/admin
        [HttpGet]
        public ActionResult <Admin> GetAdmin()
        {
            var admin = _repository.GetAdmin();
            return Ok(admin);
        }
    }
}