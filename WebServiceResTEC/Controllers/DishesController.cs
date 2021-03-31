using WebServiceResTEC.Data;
using WebServiceResTEC.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using WebServiceResTEC.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;

namespace WebServiceResTEC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public DishesController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }     

        //GET api/dishes
        [HttpGet(Name="GetDishes")]
        public ActionResult <IEnumerable<DishDto>> GetDishes()
        {
            var dishesItem = _repository.GetAllDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/dishes/{id}
        [HttpGet("{id}", Name = "GetDishById")]
        public ActionResult <DishDto> GetDishById(int id)
        {
            var dishModel = _repository.GetDishById(id);
            if(dishModel != null){
                return Ok(_mapper.Map<DishDto>(dishModel));
            }
            return NotFound();
        }

        //POST api/dishes
        [HttpPost]
        public ActionResult <DishDto> CreateDish(DishDto dishDto)
        {
            var dishModel = _mapper.Map<Dish>(dishDto);
            _repository.CreateDish(dishModel);

            var newDishDto = _mapper.Map<DishDto>(dishModel);

            return CreatedAtRoute(nameof(GetDishById), new {Id = newDishDto.Id}, newDishDto);

        }

        //PUT api/dishes/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDish(int id, DishDto dishDto)
        {
            var dishFromRepo = _repository.GetDishById(id);
            dishDto.Id = dishFromRepo.Id;
            if(dishFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(dishDto, dishFromRepo);
            _repository.UpdateDish(dishFromRepo);

            return NoContent();
        }

        //PATCH api/dishes/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialDishUpdate(int id, JsonPatchDocument<DishDto> patchDoc)
        {
            var dishFromRepo = _repository.GetDishById(id);
            if(dishFromRepo == null)
            {
                return NotFound();
            }

            var dishToPatch = _mapper.Map<DishDto>(dishFromRepo);
            patchDoc.ApplyTo(dishToPatch, ModelState);
            
            if(!TryValidateModel(dishToPatch))
            {
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(dishToPatch, dishFromRepo);
            _repository.UpdateDish(dishFromRepo);

            return NoContent();

        }

        //DELETE api/dishes/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDish(int id)
        {
            var dishFromRepo = _repository.GetDishById(id);
            if(dishFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteDish(dishFromRepo);
            return NoContent();
        }

    }
}