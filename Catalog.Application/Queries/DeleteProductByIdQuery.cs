using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class DeleteProductByIdQuery:IRequest<bool>
    {
        public string ProductId { get; set; }
        public DeleteProductByIdQuery(string productId)
        {
            ProductId = productId;
        }
    }
}
