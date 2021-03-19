using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using WebServiceResTEC.Models;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public LoginController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //POST api/login
        [HttpPost]
        public ActionResult <LoginDto> CreateDish(LoginDto loginDto)
        {
            var loginProfile = _mapper.Map<LoginProfile>(loginDto);
            LoginProfile user = _repository.CheckCredentials(loginProfile);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LoginDto>(user));

        }
    }
}