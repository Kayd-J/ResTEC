using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using WebServiceResTEC.Models;
using System.Collections.Generic;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public ClientsController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/admin
        [HttpGet(Name="GetClients")]
        public ActionResult <ClientDto> GetClients()
        {
            var clientItem = _repository.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientItem));
        }

        //POST api/clients
        [HttpPost]
        public ActionResult <ClientDto> CreateClient(ClientDto clientDto)
        {
            var clientModel = _mapper.Map<Client>(clientDto);
            _repository.CreateClient(clientModel);

            var newClientDto = _mapper.Map<ClientDto>(clientModel);

            return CreatedAtRoute(nameof(GetClients), new {Id = newClientDto.IdCard}, newClientDto);

        }
    }
}