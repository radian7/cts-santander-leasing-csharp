using Microsoft.AspNetCore.Mvc;
using SantanderLeasing.DotnetCore.DbServices;
using SantanderLeasing.DotnetCore.DbServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantanderLeasing.DotnetCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET api/orders
        [HttpGet]
        public IEnumerable<SalesOrderHeader> Get()
        {
            IEnumerable<SalesOrderHeader> orders = orderService.Get();
            return orders;
        }


        // GET api/orders/10

        [HttpGet("{id}", Name = "GetById")]
        public IActionResult Get(int id)
        {
            SalesOrderHeader order = orderService.Get(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST api/orders
        [HttpPost]
        public IActionResult Post([FromBody] SalesOrderHeader order)
        {
            orderService.Add(order);

            return CreatedAtAction("GetById", new { Id = order.SalesOrderId }, order);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, SalesOrderHeader order)
        {

            if (id != order.SalesOrderId)
                return BadRequest();
            try
            {
                orderService.Update(order);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            orderService.Remove(id);

            return NoContent();
        }

    }
}
