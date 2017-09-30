using AutoMapper;
using LTM.Application.ServiceDomain;
using LTM.WebApi.Filters;
using LTM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LTM.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [TokenAuthorization]
        [HttpGet]
        [Route("api/v1/products")]
        public IHttpActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductModel>>(_productService.ListAll());

            if (!products.Any())
                return NotFound();

            return Ok(products);
        }
    }
}
