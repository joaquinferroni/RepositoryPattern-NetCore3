using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RP.BL.IServices;
using RP.Core.Models;

namespace RP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IBaseService<Product> _productService;
        public ProductsController(IBaseService<Product> _productService)
        {
            this._productService = _productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();
            return new OkObjectResult(products);
        }

        [HttpGet,Route("{Id}")]
        public IActionResult Get(int Id)
        {
            //we want to find the product by id and load the category 
            var products = _productService.Get(x=> x.Id == Id, i=>i.Category);
            if(!products.Any()){
                return new NoContentResult();
            }
            return new OkObjectResult(products.First());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productService.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Product product)
        {
            if(product!= null){
                _productService.Update(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var products = _productService.Get(x=> x.Id == id);
            if(!products.Any()){
                return new NoContentResult();
            }
            _productService.Delete(products.First());
            return new OkResult();
        }
    }
}
