﻿using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.UpdateProduct(new Core.Entities.Product { 
                Id = request.Id, 
                Name = request.Name,
                Description = request.Description,
                Brands = request.Brands,
                Types = request.Types,
                ImageFıle = request.ImageFıle,
                Price = request.Price,
                Summary = request.Summary
            });

        }
    }
}
