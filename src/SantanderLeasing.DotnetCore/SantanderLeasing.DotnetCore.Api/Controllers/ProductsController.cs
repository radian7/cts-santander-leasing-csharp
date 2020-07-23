using Microsoft.AspNetCore.Mvc;
using SantanderLeasing.DotnetCore.IServices;
using SantanderLeasing.DotnetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SantanderLeasing.DotnetCore.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }


        // GET api/products
        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.Get();
            return Ok(products);
        }
    }
}
