using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CatalogController : ApiController
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{id}",Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id)
        {       
            return Ok(await _mediator.Send(new GetProductByIdQuery(id)));
        }

        [HttpGet]
        [Route("[action]/{productName}", Name = "GetProductByProductName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByProductName(string productName)
        {
            return Ok(await _mediator.Send(new GetProductByNameQuery(productName)));
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
        {
            return Ok(await _mediator.Send(new GetAllBrandsQuery()));
        }

        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<TypesResponse>>> GetAllTypes()
        {
            return Ok(await _mediator.Send(new GetAllTypesQuery()));
        }


        [HttpGet]
        [Route("[action]/{brandName}", Name = "GetProductsByBrandName")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductsByBrandName(string brandName)
        {
            return Ok(await _mediator.Send(new GetProductByBrandQuery(brandName)));
        }

        [HttpPost]
        [Route("CreateProduct", Name = "CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand productCommand)
        {
            return Ok(await _mediator.Send(productCommand));
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand productCommand)
        {
            return Ok(await _mediator.Send(productCommand));
        }

        [HttpDelete]
        [Route("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            return Ok(await _mediator.Send(new DeleteProductByIdQuery(id)));
        }
    }
}
 