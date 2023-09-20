﻿using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var productEntity = ProductMapper.Mapper.Map<Product>(request);
            if (productEntity is null)
                throw new ApplicationException("There is an issue with mapping while creating new product");
            else
            {
                var newProduct = await _productRepository.CreateProduct(productEntity);
                return ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            }
        }
    }
}
