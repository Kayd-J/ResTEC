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
        [HttpGet(Name="GetAdmin")]
        public ActionResult <AdminReadDto> GetAdmin()
        {
            var adminItem = _repository.GetAdmin();
            return Ok(_mapper.Map<AdminReadDto>(adminItem));
        }

        //POST api/admin
        [HttpPost(Name="CreateAdmin")]
        public ActionResult <AdminReadDto> CreateAdmin(AdminCreateDto adminCreateDto)
        {
            var adminModel = _mapper.Map<Admin>(adminCreateDto);
            _repository.CreateAdmin(adminModel);

            var adminReadDto = _mapper.Map<AdminReadDto>(adminModel);

            return CreatedAtAction(nameof(GetAdmin), adminReadDto);
            //If it had an id:
            //return CreatedAtRoute(nameof(GetAdminById), new {Id = adminReadDto.Id}, adminReadDto);

        }
    }
}