using WebServiceResTEC.Data;
using WebServiceResTEC.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace WebServiceResTEC.Controllers
{

    //This is an API Controller for the Menu entity type. This Controller allows GETs, PUT, POST, PATCH and DELETE requests.
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public MenusController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/menus
        //This request returns a list of Menu entities in a JSON format representing the menus database.
        [HttpGet(Name="GetMenus")]
        public ActionResult <IEnumerable<MenuDto>> GetMenus()
        {
            var menusItem = _repository.GetAllMenus();
            return Ok(_mapper.Map<IEnumerable<MenuDto>>(menusItem));
        }

        //GET api/menus/{id}
        //This request returns a single Menu entity in a JSON format. This entity has the same id as the
        //received in the request header.
        [HttpGet("{id}", Name = "GetMenuById")]
        public ActionResult <MenuDto> GetMenuById(int id)
        {
            var menuModel = _repository.GetMenuById(id);
            if(menuModel != null){
                return Ok(_mapper.Map<MenuDto>(menuModel));
            }
            return NotFound();
        }

        //POST api/admin
        //This request receives a JSON representing a new Menu Entity. This JSON is mapped to a Menu Data Model 
        //and then added to the database.
        [HttpPost]
        public ActionResult <MenuDto> CreateMenu(MenuDto menuDto)
        {
            var menuModel = _mapper.Map<Menu>(menuDto);
            _repository.CreateMenu(menuModel);

            var newMenuDto = _mapper.Map<MenuDto>(menuModel);

            return CreatedAtRoute(nameof(GetMenuById), new {Id = newMenuDto.Id}, newMenuDto);

        }

        //PUT api/menus/{id}
        //This request receives a JSON representing Menu Entity to be updated. This JSON is mapped to a Menu Data Model 
        //and with the id received in the header of the request, the matching entity will be replaced with the new info.
        [HttpPut("{id}")]
        public ActionResult UpdateMenu(int id, MenuDto menuDto)
        {
            var menuFromRepo = _repository.GetMenuById(id);
            menuDto.Id = menuFromRepo.Id;
            if(menuFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(menuDto, menuFromRepo);
            _repository.UpdateMenu(menuFromRepo);

            return NoContent();
        }

        //PATCH api/menus/{id}
        //This requests is to update a Menu Entity with the matching id, but only when partial
        //info of the entity needs to be updated.
        [HttpPatch("{id}")]
        public ActionResult PartialMenuUpdate(int id, JsonPatchDocument<MenuDto> patchDoc)
        {
            var menuFromRepo = _repository.GetMenuById(id);
            if(menuFromRepo == null)
            {
                return NotFound();
            }

            var menuToPatch = _mapper.Map<MenuDto>(menuFromRepo);
            patchDoc.ApplyTo(menuToPatch);
            
            if(!TryValidateModel(menuToPatch))
            {
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(menuToPatch, menuFromRepo);
            _repository.UpdateMenu(menuFromRepo);

            return NoContent();

        }

        //DELETE api/menus/{id}
        //This request deletes the Menu entity with the id received in the request header.
        [HttpDelete("{id}")]
        public ActionResult DeleteMenu(int id)
        {
            var menuFromRepo = _repository.GetMenuById(id);
            if(menuFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteMenu(menuFromRepo);
            return NoContent();
        }

    }
}