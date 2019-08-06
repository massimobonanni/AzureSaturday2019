using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Newtonsoft.Json.Serialization;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.Infrastructure;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;
        private readonly IMapper mapper;

        public ProductsController(IMapper mapper, IProductsRepository productsRepository)
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            if (productsRepository == null)
                throw new ArgumentNullException(nameof(productsRepository));

            this.mapper = mapper;
            this.productsRepository = productsRepository;
        }

        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var products = this.productsRepository.GetAll();

            return Ok(this.mapper.ProjectTo<Product, ProductDto>(products).AsEnumerable());
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var product = this.productsRepository.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(this.mapper.Map<Product, ProductDto>(product));
        }

        // POST: api/Products
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post([FromBody] ProductDto productDto)
        {
            var product = this.mapper.Map<ProductDto, Product>(productDto);
            if (this.productsRepository.Add(product))
                return Ok();
            return StatusCode(500);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] ProductDto productDto)
        {
            var product = this.mapper.Map<ProductDto, Product>(productDto);
            product.Id = id;
            if (this.productsRepository.Update(product))
                return Ok();
            return StatusCode(500);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            if (this.productsRepository.Delete(id))
                return Ok();
            return StatusCode(500);
        }
    }
}
