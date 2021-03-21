using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using System.Collections.Generic;

namespace WebServiceResTEC.Controllers
{

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
        [HttpGet]
        public ActionResult <ChefDto> GetAllChefs()
        {
            var chefItem = _repository.GetAllChefs();
            return Ok(_mapper.Map<IEnumerable<ChefDto>>(chefItem));
        }
    }
}