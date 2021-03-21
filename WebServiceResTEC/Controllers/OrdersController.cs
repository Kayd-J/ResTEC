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
    public class OrdersController : ControllerBase
    {
        private readonly IRepo _repository;
        private readonly IMapper _mapper;

        public OrdersController(IRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }        

        //GET api/admin
        [HttpGet(Name="GetOrders")]
        public ActionResult <OrderDto> GetOrders()
        {
            var orderItem = _repository.GetAllOrders();
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orderItem));
        }

        //GET api/admin
        [HttpGet("{email}")]
        public ActionResult <OrderDto> GetOrdersByChef(string email)
        {
            var orderItem = _repository.GetOrdersByChef(email);
            return Ok(_mapper.Map<IEnumerable<OrderDto>>(orderItem));
        }

        //POST api/clients
        [HttpPost]
        public ActionResult <OrderDto> CreateOrder(OrderDto orderDto)
        {
            var orderModel = _mapper.Map<Order>(orderDto);
            _repository.CreateOrder(orderModel);

            var newOrderDto = _mapper.Map<OrderDto>(orderModel);

            return CreatedAtRoute(nameof(GetOrders), new {Id = newOrderDto.Id}, newOrderDto);

        }
    }
}