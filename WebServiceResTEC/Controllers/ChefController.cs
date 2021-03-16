using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public ChefController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/chef
        [HttpGet]
        public ActionResult <ChefDto> GetAllChefs()
        {
            var chefItem = _repository.GetAllChefs();
            return Ok(_mapper.Map<ChefDto>(chefItem));
        }
    }
}