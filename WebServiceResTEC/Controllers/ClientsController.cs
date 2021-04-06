using WebServiceResTEC.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using WebServiceResTEC.Models;
using System.Collections.Generic;


namespace WebServiceResTEC.Controllers
{
    
    // This is an API Controller for the Client entity type. This Controller allows a GET and POST request.
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
        //This request returns a list of Client entities in a JSON format representing the Clients database.
        [HttpGet(Name="GetClients")]
        public ActionResult <ClientDto> GetClients()
        {
            var clientItem = _repository.GetAllClients();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientItem));
        }

        //POST api/clients
        //This request receives a JSON representing a new Client Entity. This JSON is mapped to a Client Data Model 
        //and the added to the database.
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