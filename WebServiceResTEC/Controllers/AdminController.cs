using WebServiceResTEC.Data;
using WebServiceResTEC.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public AdminController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/admin
        [HttpGet]
        public ActionResult <AdminDto> GetAdmin()
        {
            var adminItem = _repository.GetAdmin();
            return Ok(_mapper.Map<AdminDto>(adminItem));
        }
    }
}