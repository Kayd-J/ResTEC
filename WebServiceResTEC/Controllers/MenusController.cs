using WebServiceResTEC.Data;
using WebServiceResTEC.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebServiceResTEC.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace WebServiceResTEC.Controllers
{

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
        [HttpGet(Name="GetMenus")]
        public ActionResult <IEnumerable<MenuDto>> GetMenus()
        {
            var menusItem = _repository.GetAllMenus();
            return Ok(_mapper.Map<IEnumerable<MenuDto>>(menusItem));
        }

        //GET api/menus/{id}
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
        [HttpPost]
        public ActionResult <MenuDto> CreateMenu(MenuDto menuDto)
        {
            var menuModel = _mapper.Map<Menu>(menuDto);
            _repository.CreateMenu(menuModel);

            var newMenuDto = _mapper.Map<MenuDto>(menuModel);

            return CreatedAtRoute(nameof(GetMenuById), new {Id = newMenuDto.Id}, newMenuDto);

        }

        //PUT api/menus/{id}
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
        [HttpPatch("{id}")]
        public ActionResult PartialMenuUpdate(int id, JsonPatchDocument<MenuDto> patchDoc)
        {
            var menuFromRepo = _repository.GetMenuById(id);
            if(menuFromRepo == null)
            {
                return NotFound();
            }

            var menuToPatch = _mapper.Map<MenuDto>(menuFromRepo);
<<<<<<< Updated upstream
            patchDoc.ApplyTo(menuToPatch, ModelState);
=======
            patchDoc.ApplyTo(menuToPatch);
>>>>>>> Stashed changes
            
            if(!TryValidateModel(menuToPatch))
            {
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(menuToPatch, menuFromRepo);
            _repository.UpdateMenu(menuFromRepo);

            return NoContent();

        }

        //DELETE api/menus/{id}
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