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

    //This is an API Controller for generation of different info reports. This Controller allows four different GET requests.
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public ReportsController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }     

        //GET api/reports/topselling
        //This request returns a list of the 10 top selling Dish entities in a JSON format.
        [HttpGet("topselling")]
        public ActionResult <IEnumerable<DishDto>> GetBestSellingDishes()
        {
            var dishesItem = _repository.GetBestSellingDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/reports/topprofit
        //This request returns a list of the 10 top most profit Dish entities in a JSON format.
        [HttpGet("topprofit")]
        public ActionResult <IEnumerable<DishDto>> GetBestProfitDishes()
        {
            var dishesItem = _repository.GetBestProfitDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/reports/topclients
        //This request returns a list of the 10 top Client entities by amount of orders in a JSON format.
        [HttpGet("topclients")]
        public ActionResult <IEnumerable<ClientDto>> GetClientsByAmountOrders()
        {
            var clientsItem = _repository.GetClientsByAmountOrders();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsItem));
        }

        //GET api/reports/toporders
        //This request returns a list of the 10 top Order entities with best feedback in a JSON format.
        [HttpGet("toporders")]
        public ActionResult <IEnumerable<OrderDto>> GetOrdersByFeedBack()
        {
            var ordersItem = _repository.GetOrdersByFeedBack();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersItem));
        }
    }
}