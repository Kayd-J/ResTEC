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
        [HttpGet("topselling")]
        public ActionResult <IEnumerable<DishDto>> GetBestSellingDishes()
        {
            var dishesItem = _repository.GetBestSellingDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/reports/topprofit
        [HttpGet("topprofit")]
        public ActionResult <IEnumerable<DishDto>> GetBestProfitDishes()
        {
            var dishesItem = _repository.GetBestProfitDishes();
            return Ok(_mapper.Map<IEnumerable<DishDto>>(dishesItem));
        }

        //GET api/reports/topclients
        [HttpGet("topclients")]
        public ActionResult <IEnumerable<ClientDto>> GetClientsByAmountOrders()
        {
            var clientsItem = _repository.GetClientsByAmountOrders();
            return Ok(_mapper.Map<IEnumerable<ClientDto>>(clientsItem));
        }

        //GET api/reports/toporders
        [HttpGet("toporders")]
        public ActionResult <IEnumerable<OrderDto>> GetOrdersByFeedBack()
        {
            var ordersItem = _repository.GetOrdersByFeedBack();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(ordersItem));
        }
    }
}