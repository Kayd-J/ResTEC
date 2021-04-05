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
    //This is an API Controller for the Dish entity type. This Controller allows GETs, PUT, POST, PATCH and DELETE requests.
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
        //This request returns a list of Dish entities in a JSON format representing the Dishes database.
        [HttpGet(Name="GetDishes")]
        public ActionResult <IEnumerable<DishDto>> GetDishes()
        {
            var dishesItem = _repository.GetAllDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/dishes/{id}
        //This request returns a single Client entity in a JSON format. This entity has the same id as the
        //received in the request header.
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
        //This request receives a JSON representing a new Dish Entity. This JSON is mapped to a Dish Data Model 
        //and the added to the database.
        [HttpPost]
        public ActionResult <DishDto> CreateDish(DishDto dishDto)
        {
            var dishModel = _mapper.Map<Dish>(dishDto);
            _repository.CreateDish(dishModel);

            var newDishDto = _mapper.Map<DishDto>(dishModel);

            return CreatedAtRoute(nameof(GetDishById), new {Id = newDishDto.Id}, newDishDto);

        }

        //PUT api/dishes/{id}
        //This request receives a JSON representing Dish Entity to be updated. This JSON is mapped to a Dish Data Model 
        //and with the id received in the header of the request, the matching entity will be replaced with the new info.
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
        //This requests is to update a Dish Entity with the matching id, but only when partial
        //info of the entity needs to be updated.
        [HttpPatch("{id}")]
        public ActionResult PartialDishUpdate(int id, JsonPatchDocument<DishDto> patchDoc)
        {
            var dishFromRepo = _repository.GetDishById(id);
            if(dishFromRepo == null)
            {
                return NotFound();
            }

            var dishToPatch = _mapper.Map<DishDto>(dishFromRepo);
            patchDoc.ApplyTo(dishToPatch);
            
            if(!TryValidateModel(dishToPatch))
            {
                return ValidationProblem(ModelState); 
            }

            _mapper.Map(dishToPatch, dishFromRepo);
            _repository.UpdateDish(dishFromRepo);

            return NoContent();

        }

        //DELETE api/dishes/{id}
        //This request deletes the Dish entity with the id received in the request header.
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