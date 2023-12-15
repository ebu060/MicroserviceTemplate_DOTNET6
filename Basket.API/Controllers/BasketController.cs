using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    public class BasketController : ApiController
    {
        private readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]/{userName}",Name ="GetBasketByUserName")]
        [ProducesResponseType(typeof(ShoppingCartResponse),(int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> GetBasketByUserName(string userName)
        {
            return Ok(await _mediator.Send(new GetBasketByUserNameQuery(userName)));
        }

        [HttpPost("CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartResponse>> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
        {
            return Ok(await _mediator.Send(createShoppingCartCommand));
        }

        [HttpDelete]
        [Route("{userName}",Name ="DeleteBasketByUserName")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasketByUserName(string userName)
        {
            await _mediator.Send(new DeleteBasketByUserNameCommand(userName));
            return Ok();
        }
    }
}
