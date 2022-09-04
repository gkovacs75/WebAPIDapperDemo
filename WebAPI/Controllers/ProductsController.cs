using Breakglass.Core.Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductData _productData;

        public ProductsController(IProductData productData)
        {
            this._productData = productData;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            IEnumerable<Product> products = await this._productData.GetAllAsync();

            return products;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            Product? product = await this._productData.GetByIdAsync(id);

            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await this._productData.InsertAsync(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] Product product)
        {
            await this._productData.UpdateAsync(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
