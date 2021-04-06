using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using System.Collections.Generic;

namespace WebServiceResTEC.Controllers
{

    //This is an API Controller for the Chef entity type. This Controller allows a GET request to obtain all the Chefs in the database.
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public ChefsController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/chef
        //This request returns a list of Chef entities in a JSON format representing the chef database.
        [HttpGet]
        public ActionResult <ChefDto> GetAllChefs()
        {
            var chefItem = _repository.GetAllChefs();
            return Ok(_mapper.Map<IEnumerable<ChefDto>>(chefItem));
        }
    }
}