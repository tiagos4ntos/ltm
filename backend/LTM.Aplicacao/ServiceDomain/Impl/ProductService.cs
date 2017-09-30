using AutoMapper;
using LTM.Application.Dto;
using LTM.Core.Domain.Repositories;
using LTM.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LTM.Application.ServiceDomain.Impl
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> ListAll()
        {
            try
            {
                var products = _productRepository.ListAll();
                return _mapper.Map<List<ProductDto>>(products);
            }
            catch (Exception)
            {                
                throw;
            }
        }
    }
}
